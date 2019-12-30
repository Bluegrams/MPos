using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using System.Linq;
using MPos.Controls;
using Bluegrams.Windows.Tools;
using Bluegrams.Application;
using Bluegrams.Application.WinForms;

namespace MPos
{
    public partial class MainForm : DragSnapForm
    {
        private WinFormsWindowManager manager;
        private IUpdateChecker updateChecker;
        private Timer timer;
        // Global shortcut
        private GlobalHotKey hotKey;
        // Custom color table to support different themes.
        private CustomColorTable colorTable;
        // The currently used DPI value for per-monitor scaling.
        private int dpiValue = 96;
        // Parameters for text in main panel.
        private int lineHeight = 24;
        private float paintFontSize = 9;

        public Settings Settings { get; set; }
        /// <summary>
        /// The most recently captured cursor position.
        /// </summary>
        public PositionData Position { get; set; }
        /// <summary>
        /// The capturing interval for capturing the cursor position.
        /// </summary>
        public int CapturingInterval
        {
            get { return timer.Interval; }
            set { timer.Interval = value; }
        }

        public MainForm()
        {
            Settings = new Settings();
            Position = new PositionData();
            initManager();
            updateChecker = new WinFormsUpdateChecker(Program.UpdateCheckUrl, this);
            InitializeComponent();
            initControls();
            this.KeyPreview = true;
            this.KeyDown += MainForm_KeyDown;
            // Create and start the timer.
            timer = new Timer() { Interval = 50 };
            timer.Tick += Timer_Tick;
            // Set initial scaling.
            dpiValue = WinApi.GetMonitorDpiFromPoint((WinPoint)this.Location, MonitorDpiType.EFFECTIVE_DPI);
            this.Scale(new SizeF(dpiValue / 96.0f, dpiValue / 96.0f));
            panDraw.Focus();
        }

        private void initManager()
        {
            manager = new WinFormsWindowManager(this);
            manager.ManageDefault();
            manager.Manage(nameof(Settings), nameof(TopMost));
            manager.Manage(nameof(Opacity), 1);
            manager.Manage(nameof(ShowInTaskbar), true);
            manager.Manage(nameof(CapturingInterval), 50);
            manager.Initialize();
        }

        private void initControls()
        {
            // Init main drawing panel.
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, panDraw, new object[] { true });
            panDraw.Paint += PanDraw_Paint;
            // Adjust appearance of some controls (esp. for theming).
            colorTable = new CustomColorTable(Settings.DarkMode);
            menuMain.Renderer = new ToolStripProfessionalRenderer(colorTable);
            contextMain.Renderer = new ToolStripProfessionalRenderer(colorTable);
            contextList.Renderer = new ToolStripProfessionalRenderer(colorTable);
            contextView.Renderer = new ToolStripProfessionalRenderer(colorTable);
            butStart.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100, 100);
            butStart.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 100, 100, 100);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.TopMost = TopMost; // Ensures that TopMost works properly.
            applyCurrentTheme();
            if (Settings.Capturing) timer.Start();
            butStart.Text = Settings.Capturing ? "Stop" : "Start";
            restoreUI(dpiValue / 96.0f);
            setNewHotKey(Settings.ShortcutKey);
            updateChecker.CheckForUpdates();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                // --- Check of DPI of monitor changed ---
                // WM_DPICHANGED = 0x02E0 (>= Win 8.1)
                case 0x02E0:
                    float factor = (short)m.WParam / (float)dpiValue;
                    dpiValue = (short)m.WParam;
#if DEBUG
                    System.Diagnostics.Debug.WriteLine("DPI changed: {0}; {1}", dpiValue, factor);
#endif
                    this.Scale(new SizeF(factor, factor));
                    restoreUI(dpiValue / 96.0f);
                    break;
            }
            base.WndProc(ref m);          
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.T:
                        conTopmost.PerformClick();
                        break;
                }
            }
            else if (e.KeyCode == Keys.Menu) conMenuVisible.PerformClick();
            else if (e.KeyCode == Keys.F1) conAbout.PerformClick();
            else if (e.KeyCode == Keys.Escape) conExit.PerformClick();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            hotKey?.Dispose();
        }

        #region Scaling

        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            base.ScaleControl(factor, specified);
            trackOpacity.Scale(factor);
            scaleFonts(factor.Height);
        }

        /// <summary>
        /// Manually scales the fonts of several controls.
        /// </summary>
        private void scaleFonts(float scaleFactor)
        {
            // Scale fonts for some controls.
            scaleFontForControl(contextMain, scaleFactor);
            scaleFontForControl(panMenu, scaleFactor);
            scaleFontForControl(contextList, scaleFactor);
            scaleFontForControl(contextView, scaleFactor);
            scaleFontForControl(lstPositions, scaleFactor);
            scaleFontForControl(lblHelp, scaleFactor);
        }

        private void scaleFontForControl(Control control, float factor)
        {
            control.Font = new Font(control.Font.FontFamily,
                   control.Font.Size * factor,
                   control.Font.Style);
            if (control is NumericUpDown) return;
            foreach (Control child in control.Controls)
                scaleFontForControl(child, factor);
        }

        /// <summary>
        /// Rebuilds the UI according to the current settings and the given scaling factor.
        /// </summary>
        /// <param name="factor">Scaling relative to the design scaling (96 dpi).</param>
        private void restoreUI(float factor)
        {
            lineHeight = (int)Math.Ceiling(factor * 24);
            paintFontSize = (int)(factor * 9);
#if DEBUG
            System.Diagnostics.Debug.WriteLine("Line height: {0}; font size: {1}", lineHeight, paintFontSize);
#endif
            int height = 2 * lineHeight;
            if (Settings.MenuVisible) height += panMenu.Height;
            if (Settings.PositionLogVisible) height += lstPositions.Height;
            if (Settings.RelativeVisible) height += lineHeight;
            if (Settings.ScaledVisible) height += lineHeight;
            if (Settings.DpiVisible) height += lineHeight;
            if (Settings.ScreenResolutionVisible) height += lineHeight;
            if (Settings.PixelColorVisible) height += lineHeight;
            this.Height = height;
            panMenu.Visible = Settings.MenuVisible;
            lstPositions.Visible = Settings.PositionLogVisible;
            panDraw.Invalidate();
        }

        #endregion

        private void Timer_Tick(object sender, EventArgs e) => updatePosition();

        private void updatePosition() => updatePosition(new PositionData(MousePosition));

        /// <summary>
        /// The method that determines all wanted values and that is called in every tick.
        /// </summary>
        private void updatePosition(PositionData positionData)
        {
            // Update position.
            Position = positionData;
            // Update coordinates in title.
            this.Text = String.Format("MPos | X: {0} Y: {1}", Position.PhysicalPosition.X, Position.PhysicalPosition.Y);
            // Attempt to redraw panel.
            panDraw.Invalidate();
        }

        

        /// <summary>
        /// Called when panel with position data needs to be updated.
        /// </summary>
        private void PanDraw_Paint(object sender, PaintEventArgs e)
        {
            int paddLeft = 5, paddTop = 3;
            int w3 = panDraw.Width / 3 + paddLeft;
            Graphics g = e.Graphics;
            using (Font f = new Font("Segoe UI", paintFontSize))
            using (Brush b = new SolidBrush(Settings.DarkMode ? Color.White : Color.Black))
            {
                g.DrawString("Physical", f, b, paddLeft, paddTop);
                g.DrawString(formatPoint(Position.PhysicalPosition), f, b, w3, paddTop);
                // Draw position data only if they should be displayed.
                int i = 1;
                if (Settings.ScaledVisible)
                {
                    g.DrawString("Scaled", f, b, paddLeft, paddTop + i * lineHeight);
                    g.DrawString(formatPoint(Position.ScaledPosition), f, b, w3, paddTop + i * lineHeight);
                    i++;
                }
                if (Settings.RelativeVisible)
                {
                    g.DrawString("Relative", f, b, paddLeft, paddTop + i * lineHeight);
                    g.DrawString(formatPoint(Position.RelativePosition), f, b, w3, paddTop + i * lineHeight);
                    i++;
                }
                if (Settings.DpiVisible)
                {
                    g.DrawString("Scaling", f, b, paddLeft, paddTop + i * lineHeight);
                    g.DrawString(String.Format("{0} ({1} dpi)", Position.DpiScaling, Position.Dpi),
                        f, b, w3, paddTop + i * lineHeight);
                    g.DrawString("Raw Dpi", f, b, paddLeft, paddTop + (i + 1) * lineHeight);
                    g.DrawString(String.Format("{0}  (Ratio: {1})", Position.RawDpi, Position.DpiRawRatio),
                        f, b, w3, paddTop + (i + 1) * lineHeight);
                    i += 2;
                }
                if (Settings.ScreenResolutionVisible)
                {
                    g.DrawString("Resolution", f, b, paddLeft, paddTop + i * lineHeight);
                    g.DrawString(formatSize(Position.ScreenResolution), f, b, w3, paddTop + i * lineHeight);
                    i++;
                }
                if (Settings.PixelColorVisible)
                {
                    Color col = Position.PixelColor;
                    g.DrawString(String.Format("R: {0,-4}  G: {1,-4}  B: {2,-4}", col.R, col.G, col.B),
                        f, b, paddLeft, paddTop + i * lineHeight);
                }
            }
        }

        private string formatPoint(Point pt) => String.Format("X: {0,-10}Y: {1,-10}", pt.X, pt.Y);
        private string formatSize(Size pt) => String.Format("{0} x {1}", pt.Width, pt.Height);

        /// <summary>
        /// Applies the theme currently set in the settings to all controls.
        /// </summary>
        private void applyCurrentTheme()
        {
            // --- Set back colors of elements ---
            this.BackColor = Settings.DarkMode ? Color.FromArgb(16, 16, 16) : SystemColors.Control;
            lstPositions.BackColor = BackColor;
            colorTable.Dark = Settings.DarkMode;
            // --- Set foreground colors of controls ---
            menuMain.ForeColor = Settings.DarkMode ? Color.White : Color.Black;
            // Explicitly set foreground color of menu items.
            foreach (var item in menuMain.Items)
                if (item is ToolStripMenuItem menuItem)
                    foreach (ToolStripItem dropDown in menuItem.DropDownItems)
                        dropDown.ForeColor = menuMain.ForeColor;
            contextMain.ForeColor = menuMain.ForeColor;
            contextList.ForeColor = menuMain.ForeColor;
            contextView.ForeColor = menuMain.ForeColor;
            // Explicitly set foreground color of menu items.
            foreach (ToolStripItem item in contextMain.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    // Apply theme to submenus if existent.
                    foreach (ToolStripItem childItem in menuItem.DropDownItems)
                    {
                        childItem.ForeColor = contextMain.ForeColor;
                        childItem.BackColor = this.BackColor;
                    }
                }
            }
            butStart.ForeColor = menuMain.ForeColor;
            lstPositions.ForeColor = menuMain.ForeColor;
            this.Invalidate();
        }

        /// <summary>
        /// Adds the current position to the position log list.
        /// </summary>
        private void addPositionToLog()
        {
            if (!Settings.Capturing) updatePosition();
            lblHelp.Visible = false;
            lstPositions.Items.Add(Position);
            // Select newly added element.
            lstPositions.SelectedIndex = lstPositions.Items.Count - 1;
            // Show position list box if not visible.
            if (!Settings.PositionLogVisible) conPositionsVisible.PerformClick();
            var text = Position.ToString().Replace("; ", Environment.NewLine);
            Clipboard.SetText(text);
        }

        private void notifyIcon_Click(object sender, EventArgs e) => Activate();

        #region Context Menu

        // Load all current settings when opening menu.
        private void contextMain_Opening(object sender, CancelEventArgs e)
        {
            conTopmost.Checked = TopMost;
            conDarkMode.Checked = Settings.DarkMode;
            conMenuVisible.Checked = Settings.MenuVisible;
            conShowInTaskbar.Checked = ShowInTaskbar;
            conPositionsVisibleMain.Checked = Settings.PositionLogVisible; 
            trackOpacity.TrackBarValue = (int)(this.Opacity*100);
        }

        private void contextView_Opening(object sender, CancelEventArgs e)
        {
            conShowScaled.Checked = Settings.ScaledVisible;
            conShowRelative.Checked = Settings.RelativeVisible;
            conShowDpi.Checked = Settings.DpiVisible;
            conShowResolution.Checked = Settings.ScreenResolutionVisible;
            conShowColor.Checked = Settings.PixelColorVisible;
        }

        private void conLog_Click(object sender, EventArgs e) => addPositionToLog();

        private void shownDataItem_Click(object sender, EventArgs e)
        {
            // Read the tag of the menu item to get the name 
            // of the property for which to change visibility.
            var menuItem = (ToolStripMenuItem)sender;
            string prop = (string)menuItem.Tag + "Visible";
            typeof(Settings).GetProperty(prop).SetValue(Settings, !menuItem.Checked);
            this.Height += menuItem.Checked ? -lineHeight : +lineHeight;
            panDraw.Invalidate();
        }

        private void conTopmost_Click(object sender, EventArgs e) => TopMost = !TopMost;

        private void conMenuVisible_Click(object sender, EventArgs e)
        {
            Settings.MenuVisible = !Settings.MenuVisible;
            panMenu.Visible = Settings.MenuVisible;
            // Remove or add space used for main menu.
            this.Height += Settings.MenuVisible ? +panMenu.Height : -panMenu.Height;
        }

        private void conShowInTaskbar_Click(object sender, EventArgs e)
        {
            ShowInTaskbar = !ShowInTaskbar;
        }

        private void conDarkMode_Click(object sender, EventArgs e)
        {
            Settings.DarkMode = !Settings.DarkMode;
            applyCurrentTheme();
        }

        private void trackOpacity_ValueChanged(object sender, TrackBarEventArgs e)
        {
            this.Opacity = e.NewValue / 100.0;
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            var resMan = new ResourceManager(this.GetType());
            var img = ((Icon)resMan.GetObject("$this.Icon")).ToBitmap();
            AboutForm aboutForm = new AboutForm(img);
            aboutForm.UpdateChecker = updateChecker;
            aboutForm.AccentColor = Color.FromArgb(16, 16, 16);
            aboutForm.TopMost = this.TopMost;
            aboutForm.ShowDialog();
        }

        private void conExit_Click(object sender, EventArgs e) => this.Close();

        #endregion

        #region Top Menu

        private void menuOptions_DropDownOpening(object sender, EventArgs e)
        {
            conPositionsVisible.Checked = Settings.PositionLogVisible;
        }

        private void conPositionsVisible_Click(object sender, EventArgs e)
        {
            Settings.PositionLogVisible = !Settings.PositionLogVisible;
            lstPositions.Visible = Settings.PositionLogVisible;
            // Remove or add space used for the list box.
            this.Height += Settings.PositionLogVisible ? +lstPositions.Height : -lstPositions.Height;
        }

        private void conClearPositions_Click(object sender, EventArgs e)
        {
            lstPositions.Items.Clear();
            lblHelp.Visible = true;
        }

        private void conShortcut_Click(object sender, EventArgs e)
        {
            HotKeyInputForm hotKeyInput = new HotKeyInputForm(Settings.ShortcutKey);
            hotKeyInput.TopMost = this.TopMost;
            if (hotKeyInput.ShowDialog() == DialogResult.OK)
            {
                setNewHotKey(hotKeyInput.SelectedKeys);
            }
        }

        /// <summary>
        /// Sets a new key combination as global shortcut for grabbing the current position.
        /// </summary>
        private void setNewHotKey(Keys keys)
        {
            hotKey?.Dispose();
            Settings.ShortcutKey = keys;
            KeyCombination combination = (KeyCombination)keys;
            try
            {
                hotKey = new GlobalHotKey(combination, (k) => addPositionToLog());
                hotKey.Register();
                lblHelp.Text = String.Format("Press {0} to capture a position.", combination);
                conLog.ShortcutKeyDisplayString = combination.ToString();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(
                    "Registering global keyboard shortcut failed.\nThis could be caused by another app using the same global shortcut.",
                    "MPos - Error");
            }
        }

        private void butStart_Click(object sender, EventArgs e)
        {
            Settings.Capturing = !Settings.Capturing;
            timer.Enabled = Settings.Capturing;
            butStart.Text = Settings.Capturing ? "Stop" : "Start";
        }
        #endregion

        #region Positions List Box

        private void contextList_Opening(object sender, CancelEventArgs e)
        {
            contextList.Enabled = lstPositions.SelectedIndex > -1;
        }

        // Move label showing shortcut together with list box.
        private void lstPositions_LocationChanged(object sender, EventArgs e) => lblHelp.Location = lstPositions.Location;

        private void conCopyAll_Click(object sender, EventArgs e)
        {
            var items = from object item in lstPositions.Items
                        select item.ToString();
            Clipboard.SetText(String.Join("\n", items));
        }

        private void conPositionsCopy_Click(object sender, EventArgs e)
        {
            var text = lstPositions.SelectedItem.ToString().Replace("; ", Environment.NewLine);
            Clipboard.SetText(text);
        }

        private void conPositionsDelete_Click(object sender, EventArgs e)
        {
            lstPositions.Items.Remove(lstPositions.SelectedItem);
            if (lstPositions.Items.Count > 0)
                lstPositions.SelectedIndex = lstPositions.Items.Count - 1;
            else lblHelp.Visible = true;
        }

        private void lstPositions_VisibleChanged(object sender, EventArgs e)
        {
            if (lstPositions.Visible && lstPositions.Items.Count < 1) lblHelp.Visible = true;
        }

        private void lstPositions_Click(object sender, EventArgs e)
        {
            // set shown data to selected item from list
            if (!Settings.Capturing && lstPositions.SelectedItem != null)
            {
                updatePosition((PositionData)lstPositions.SelectedItem);
            }
        }
        #endregion
    }
}
