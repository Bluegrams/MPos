namespace MPos
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.conPositionsVisible = new System.Windows.Forms.ToolStripMenuItem();
            this.conClearPositions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.conShortcut = new System.Windows.Forms.ToolStripMenuItem();
            this.lstPositions = new System.Windows.Forms.ListBox();
            this.contextList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.conPositionsCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.conPositionsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.conCopyAll = new System.Windows.Forms.ToolStripMenuItem();
            this.panMenu = new System.Windows.Forms.Panel();
            this.numSpeed = new System.Windows.Forms.NumericUpDown();
            this.butStart = new System.Windows.Forms.Button();
            this.panDraw = new System.Windows.Forms.Panel();
            this.contextMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.conStart = new System.Windows.Forms.ToolStripMenuItem();
            this.conLog = new System.Windows.Forms.ToolStripMenuItem();
            this.conShownData = new System.Windows.Forms.ToolStripMenuItem();
            this.conShowScaled = new System.Windows.Forms.ToolStripMenuItem();
            this.conShowRelative = new System.Windows.Forms.ToolStripMenuItem();
            this.conShowDpi = new System.Windows.Forms.ToolStripMenuItem();
            this.conShowColor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.conTopmost = new System.Windows.Forms.ToolStripMenuItem();
            this.conMenuVisible = new System.Windows.Forms.ToolStripMenuItem();
            this.conPositionsVisibleMain = new System.Windows.Forms.ToolStripMenuItem();
            this.conShowInTaskbar = new System.Windows.Forms.ToolStripMenuItem();
            this.conDarkMode = new System.Windows.Forms.ToolStripMenuItem();
            this.conOpacity = new System.Windows.Forms.ToolStripMenuItem();
            this.trackOpacity = new MPos.Controls.TrackBarMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.conAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.conExit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblHelp = new System.Windows.Forms.Label();
            this.menuMain.SuspendLayout();
            this.contextList.SuspendLayout();
            this.panMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).BeginInit();
            this.contextMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.AutoSize = false;
            this.menuMain.BackColor = System.Drawing.Color.Transparent;
            this.menuMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOptions});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Padding = new System.Windows.Forms.Padding(0);
            this.menuMain.Size = new System.Drawing.Size(220, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // menuOptions
            // 
            this.menuOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conPositionsVisible,
            this.conClearPositions,
            this.toolStripSeparator3,
            this.conShortcut});
            this.menuOptions.Name = "menuOptions";
            this.menuOptions.Size = new System.Drawing.Size(61, 24);
            this.menuOptions.Text = "Options";
            this.menuOptions.DropDownOpening += new System.EventHandler(this.menuOptions_DropDownOpening);
            // 
            // conPositionsVisible
            // 
            this.conPositionsVisible.Name = "conPositionsVisible";
            this.conPositionsVisible.Size = new System.Drawing.Size(184, 22);
            this.conPositionsVisible.Text = "Show Position Log";
            this.conPositionsVisible.Click += new System.EventHandler(this.conPositionsVisible_Click);
            // 
            // conClearPositions
            // 
            this.conClearPositions.Name = "conClearPositions";
            this.conClearPositions.Size = new System.Drawing.Size(184, 22);
            this.conClearPositions.Text = "Clear Position Log";
            this.conClearPositions.Click += new System.EventHandler(this.conClearPositions_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(181, 6);
            // 
            // conShortcut
            // 
            this.conShortcut.Name = "conShortcut";
            this.conShortcut.Size = new System.Drawing.Size(184, 22);
            this.conShortcut.Text = "Configure Shortcut...";
            this.conShortcut.Click += new System.EventHandler(this.conShortcut_Click);
            // 
            // lstPositions
            // 
            this.lstPositions.BackColor = System.Drawing.SystemColors.Control;
            this.lstPositions.ContextMenuStrip = this.contextList;
            this.lstPositions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstPositions.FormattingEnabled = true;
            this.lstPositions.Location = new System.Drawing.Point(0, 168);
            this.lstPositions.Margin = new System.Windows.Forms.Padding(0);
            this.lstPositions.Name = "lstPositions";
            this.lstPositions.Size = new System.Drawing.Size(220, 56);
            this.lstPositions.TabIndex = 1;
            this.lstPositions.LocationChanged += new System.EventHandler(this.lstPositions_LocationChanged);
            this.lstPositions.VisibleChanged += new System.EventHandler(this.lstPositions_VisibleChanged);
            // 
            // contextList
            // 
            this.contextList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conPositionsCopy,
            this.conPositionsDelete,
            this.toolStripSeparator4,
            this.conCopyAll});
            this.contextList.Name = "contextList";
            this.contextList.Size = new System.Drawing.Size(162, 76);
            this.contextList.Opening += new System.ComponentModel.CancelEventHandler(this.contextList_Opening);
            // 
            // conPositionsCopy
            // 
            this.conPositionsCopy.Name = "conPositionsCopy";
            this.conPositionsCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.conPositionsCopy.Size = new System.Drawing.Size(161, 22);
            this.conPositionsCopy.Text = "Copy";
            this.conPositionsCopy.Click += new System.EventHandler(this.conPositionsCopy_Click);
            // 
            // conPositionsDelete
            // 
            this.conPositionsDelete.Name = "conPositionsDelete";
            this.conPositionsDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.conPositionsDelete.Size = new System.Drawing.Size(161, 22);
            this.conPositionsDelete.Text = "Delete";
            this.conPositionsDelete.Click += new System.EventHandler(this.conPositionsDelete_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(158, 6);
            // 
            // conCopyAll
            // 
            this.conCopyAll.Name = "conCopyAll";
            this.conCopyAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.conCopyAll.Size = new System.Drawing.Size(161, 22);
            this.conCopyAll.Text = "Copy All";
            this.conCopyAll.Click += new System.EventHandler(this.conCopyAll_Click);
            // 
            // panMenu
            // 
            this.panMenu.Controls.Add(this.numSpeed);
            this.panMenu.Controls.Add(this.butStart);
            this.panMenu.Controls.Add(this.menuMain);
            this.panMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panMenu.Location = new System.Drawing.Point(0, 0);
            this.panMenu.Margin = new System.Windows.Forms.Padding(0);
            this.panMenu.Name = "panMenu";
            this.panMenu.Size = new System.Drawing.Size(220, 24);
            this.panMenu.TabIndex = 2;
            // 
            // numSpeed
            // 
            this.numSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSpeed.Location = new System.Drawing.Point(80, 2);
            this.numSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSpeed.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numSpeed.Name = "numSpeed";
            this.numSpeed.Size = new System.Drawing.Size(60, 20);
            this.numSpeed.TabIndex = 2;
            this.toolTip1.SetToolTip(this.numSpeed, "Capturing Speed (ms)");
            this.numSpeed.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numSpeed.ValueChanged += new System.EventHandler(this.numSpeed_ValueChanged);
            // 
            // butStart
            // 
            this.butStart.BackColor = System.Drawing.Color.Transparent;
            this.butStart.Dock = System.Windows.Forms.DockStyle.Right;
            this.butStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butStart.Location = new System.Drawing.Point(145, 0);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(75, 24);
            this.butStart.TabIndex = 1;
            this.butStart.Text = "Start";
            this.butStart.UseVisualStyleBackColor = false;
            this.butStart.Click += new System.EventHandler(this.butStart_Click);
            // 
            // panDraw
            // 
            this.panDraw.ContextMenuStrip = this.contextMain;
            this.panDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDraw.Location = new System.Drawing.Point(0, 24);
            this.panDraw.Name = "panDraw";
            this.panDraw.Size = new System.Drawing.Size(220, 144);
            this.panDraw.TabIndex = 3;
            // 
            // contextMain
            // 
            this.contextMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conStart,
            this.conLog,
            this.conShownData,
            this.toolStripSeparator1,
            this.conTopmost,
            this.conMenuVisible,
            this.conPositionsVisibleMain,
            this.conShowInTaskbar,
            this.conDarkMode,
            this.conOpacity,
            this.toolStripSeparator2,
            this.conAbout,
            this.conExit});
            this.contextMain.Name = "contextMain";
            this.contextMain.ShowCheckMargin = true;
            this.contextMain.ShowImageMargin = false;
            this.contextMain.Size = new System.Drawing.Size(187, 258);
            this.contextMain.Opening += new System.ComponentModel.CancelEventHandler(this.contextMain_Opening);
            // 
            // conStart
            // 
            this.conStart.Name = "conStart";
            this.conStart.Size = new System.Drawing.Size(186, 22);
            this.conStart.Text = "Start/ Stop Capturing";
            this.conStart.Click += new System.EventHandler(this.butStart_Click);
            // 
            // conLog
            // 
            this.conLog.Name = "conLog";
            this.conLog.Size = new System.Drawing.Size(186, 22);
            this.conLog.Text = "Grab Position";
            this.conLog.Click += new System.EventHandler(this.conLog_Click);
            // 
            // conShownData
            // 
            this.conShownData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conShowScaled,
            this.conShowRelative,
            this.conShowDpi,
            this.conShowColor});
            this.conShownData.Name = "conShownData";
            this.conShownData.Size = new System.Drawing.Size(186, 22);
            this.conShownData.Text = "Shown Data";
            // 
            // conShowScaled
            // 
            this.conShowScaled.Name = "conShowScaled";
            this.conShowScaled.Size = new System.Drawing.Size(200, 22);
            this.conShowScaled.Tag = "Scaled";
            this.conShowScaled.Text = "Dpi-Scaled Position";
            this.conShowScaled.Click += new System.EventHandler(this.shownDataItem_Click);
            // 
            // conShowRelative
            // 
            this.conShowRelative.Name = "conShowRelative";
            this.conShowRelative.Size = new System.Drawing.Size(200, 22);
            this.conShowRelative.Tag = "Relative";
            this.conShowRelative.Text = "Relative Position";
            this.conShowRelative.Click += new System.EventHandler(this.shownDataItem_Click);
            // 
            // conShowDpi
            // 
            this.conShowDpi.Name = "conShowDpi";
            this.conShowDpi.Size = new System.Drawing.Size(200, 22);
            this.conShowDpi.Tag = "Dpi";
            this.conShowDpi.Text = "Dpi Information";
            this.conShowDpi.Click += new System.EventHandler(this.shownDataItem_Click);
            // 
            // conShowColor
            // 
            this.conShowColor.Name = "conShowColor";
            this.conShowColor.Size = new System.Drawing.Size(200, 22);
            this.conShowColor.Tag = "PixelColor";
            this.conShowColor.Text = "Color at Cursor Position";
            this.conShowColor.Click += new System.EventHandler(this.shownDataItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
            // 
            // conTopmost
            // 
            this.conTopmost.Name = "conTopmost";
            this.conTopmost.ShortcutKeyDisplayString = "Ctrl+T";
            this.conTopmost.Size = new System.Drawing.Size(186, 22);
            this.conTopmost.Text = "Stay on Top";
            this.conTopmost.Click += new System.EventHandler(this.conTopmost_Click);
            // 
            // conMenuVisible
            // 
            this.conMenuVisible.Name = "conMenuVisible";
            this.conMenuVisible.ShortcutKeyDisplayString = "Alt";
            this.conMenuVisible.Size = new System.Drawing.Size(186, 22);
            this.conMenuVisible.Text = "Show Menu Bar";
            this.conMenuVisible.Click += new System.EventHandler(this.conMenuVisible_Click);
            // 
            // conPositionsVisibleMain
            // 
            this.conPositionsVisibleMain.Name = "conPositionsVisibleMain";
            this.conPositionsVisibleMain.Size = new System.Drawing.Size(186, 22);
            this.conPositionsVisibleMain.Text = "Show Position Log";
            this.conPositionsVisibleMain.Click += new System.EventHandler(this.conPositionsVisible_Click);
            // 
            // conShowInTaskbar
            // 
            this.conShowInTaskbar.Name = "conShowInTaskbar";
            this.conShowInTaskbar.Size = new System.Drawing.Size(186, 22);
            this.conShowInTaskbar.Text = "Show in Taskbar";
            this.conShowInTaskbar.Click += new System.EventHandler(this.conShowInTaskbar_Click);
            // 
            // conDarkMode
            // 
            this.conDarkMode.Name = "conDarkMode";
            this.conDarkMode.Size = new System.Drawing.Size(186, 22);
            this.conDarkMode.Text = "Dark Mode";
            this.conDarkMode.Click += new System.EventHandler(this.conDarkMode_Click);
            // 
            // conOpacity
            // 
            this.conOpacity.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trackOpacity});
            this.conOpacity.Name = "conOpacity";
            this.conOpacity.Size = new System.Drawing.Size(186, 22);
            this.conOpacity.Text = "Opacity";
            // 
            // trackOpacity
            // 
            this.trackOpacity.Name = "trackOpacity";
            this.trackOpacity.Size = new System.Drawing.Size(104, 20);
            this.trackOpacity.Text = "trackBarMenuItem2";
            this.trackOpacity.ToolTipText = "Set Opacity";
            this.trackOpacity.TrackBarValue = 10;
            this.trackOpacity.ValueChanged += new System.EventHandler<MPos.Controls.TrackBarEventArgs>(this.trackOpacity_ValueChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(183, 6);
            // 
            // conAbout
            // 
            this.conAbout.Name = "conAbout";
            this.conAbout.ShortcutKeyDisplayString = "F1";
            this.conAbout.Size = new System.Drawing.Size(186, 22);
            this.conAbout.Text = "About";
            this.conAbout.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // conExit
            // 
            this.conExit.Name = "conExit";
            this.conExit.Size = new System.Drawing.Size(186, 22);
            this.conExit.Text = "Exit";
            this.conExit.Click += new System.EventHandler(this.conExit_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMain;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "MPos - Mouse Position Tracker";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // lblHelp
            // 
            this.lblHelp.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblHelp.Location = new System.Drawing.Point(0, 168);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(220, 56);
            this.lblHelp.TabIndex = 4;
            this.lblHelp.Text = "No shortcut.";
            this.lblHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHelp.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(220, 224);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.panDraw);
            this.Controls.Add(this.lstPositions);
            this.Controls.Add(this.panMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MPos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.contextList.ResumeLayout(false);
            this.panMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).EndInit();
            this.contextMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuOptions;
        private System.Windows.Forms.ListBox lstPositions;
        private System.Windows.Forms.Panel panMenu;
        private System.Windows.Forms.ToolStripMenuItem conPositionsVisible;
        private System.Windows.Forms.Button butStart;
        private System.Windows.Forms.Panel panDraw;
        private System.Windows.Forms.ContextMenuStrip contextMain;
        private System.Windows.Forms.ToolStripMenuItem conShownData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem conTopmost;
        private System.Windows.Forms.ToolStripMenuItem conShowInTaskbar;
        private System.Windows.Forms.ToolStripMenuItem conDarkMode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem conAbout;
        private System.Windows.Forms.ToolStripMenuItem conExit;
        private System.Windows.Forms.ToolStripMenuItem conShowScaled;
        private System.Windows.Forms.ToolStripMenuItem conShowRelative;
        private System.Windows.Forms.ToolStripMenuItem conShowDpi;
        private System.Windows.Forms.ToolStripMenuItem conShowColor;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem conOpacity;
        private Controls.TrackBarMenuItem trackOpacity;
        private System.Windows.Forms.NumericUpDown numSpeed;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem conMenuVisible;
        private System.Windows.Forms.ToolStripMenuItem conClearPositions;
        private System.Windows.Forms.ContextMenuStrip contextList;
        private System.Windows.Forms.ToolStripMenuItem conPositionsCopy;
        private System.Windows.Forms.ToolStripMenuItem conPositionsDelete;
        private System.Windows.Forms.ToolStripMenuItem conStart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem conShortcut;
        private System.Windows.Forms.ToolStripMenuItem conLog;
        private System.Windows.Forms.ToolStripMenuItem conCopyAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem conPositionsVisibleMain;
        private System.Windows.Forms.Label lblHelp;
    }
}

