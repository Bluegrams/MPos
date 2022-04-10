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
            // First tab
            chkDarkMode.Checked = settings.DarkMode;
            trackOpacity.Value = (int)(this.Owner.Opacity * 100);
            cmbFont.SelectedItem = settings.FontFamilyName;
            numFontSize.Value = settings.FontSize;
            // Second tab
            txtDataFormatPoint.Text = settings.DataFormatPoint;
            txtDataFormatDpi.Text = settings.DataFormatDpi;
            txtDataFormatResolution.Text = settings.DataFormatResolution;
            txtDataFormatColor.Text = settings.DataFormatColor;
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

        private void butDataFormat_Click(object sender, EventArgs e)
        {
            settings.DataFormatPoint = txtDataFormatPoint.Text;
            settings.DataFormatDpi = txtDataFormatDpi.Text;
            settings.DataFormatResolution = txtDataFormatResolution.Text;
            settings.DataFormatColor = txtDataFormatColor.Text;
            settings.InvokeChanged();
        }
    }
}
