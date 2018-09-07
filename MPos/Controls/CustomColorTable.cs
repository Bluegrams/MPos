using System;
using System.Drawing;
using System.Windows.Forms;

namespace MPos.Controls
{
    /// <summary>
    /// A color table with a light and a dark theme.
    /// </summary>
    class CustomColorTable : ProfessionalColorTable
    {
        private bool dark;
        /// <summary>
        /// Get or set a value indicating whether the dark theme is being used.
        /// </summary>
        public bool Dark
        {
            get { return dark; }
            set
            {
                dark = value;
                applyTheme();
            }
        }

        private Color BackColor { get; set; }

        private Color HighlightBackColor { get; set; }

        private Color BorderColor { get; set; }

        public CustomColorTable(bool dark)
        {
            this.Dark = dark;
        }

        private void applyTheme()
        {
            BackColor = dark ? Color.FromArgb(16, 16, 16) : SystemColors.Control;
            HighlightBackColor = dark ? Color.FromArgb(50, 50, 50) : SystemColors.ControlLight;
            BorderColor = dark ? Color.Black : SystemColors.ControlDark;
        }

        public override Color MenuItemSelectedGradientBegin => HighlightBackColor;
        public override Color MenuItemSelectedGradientEnd => HighlightBackColor;
        public override Color MenuItemSelected => HighlightBackColor;

        public override Color MenuItemPressedGradientBegin => HighlightBackColor;
        public override Color MenuItemPressedGradientEnd => HighlightBackColor;

        public override Color MenuItemBorder => BorderColor;
        public override Color MenuBorder => BorderColor;

        public override Color ToolStripDropDownBackground => BackColor;
        public override Color ImageMarginGradientBegin => BackColor;
        public override Color ImageMarginGradientMiddle => BackColor;
        public override Color ImageMarginGradientEnd => BackColor;
    }
}
