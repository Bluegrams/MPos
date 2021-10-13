using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace MPos
{
    public partial class CustomizeForm : Form
    {
        private Settings settings;

        public CustomizeForm(Settings settings)
        {
            this.settings = settings;
            InitializeComponent();
            // Fill font families
            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            foreach (FontFamily fontFamily in installedFontCollection.Families)
            {
                cmbFont.Items.Add(fontFamily.Name);
            }
        }

        private void CustomizeForm_Load(object sender, EventArgs e)
        {
            // Init values
            chkDarkMode.Checked = settings.DarkMode;
            trackOpacity.Value = (int)(this.Owner.Opacity * 100);
            cmbFont.SelectedItem = settings.FontFamilyName;
            numFontSize.Value = settings.FontSize;
        }

        private void chkDarkMode_CheckedChanged(object sender, EventArgs e)
        {
            settings.DarkMode = chkDarkMode.Checked;
            settings.InvokeChanged();
        }

        private void trackOpacity_Scroll(object sender, EventArgs e)
        {
            this.Owner.Opacity = trackOpacity.Value / 100.0;
        }

        private void cmbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.FontFamilyName = cmbFont.SelectedItem.ToString();
            settings.InvokeChanged();
        }

        private void numFontSize_ValueChanged(object sender, EventArgs e)
        {
            settings.FontSize = (int)numFontSize.Value;
            settings.InvokeChanged();
        }
    }
}
