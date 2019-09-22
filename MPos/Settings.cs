using System;
using System.Windows.Forms;

namespace MPos
{
    [Serializable]
    public class Settings
    {
        /// <summary>
        /// Determines if the dpi-scaled coordinates should be displayed.
        /// </summary>
        public bool ScaledVisible { get; set; } = true;
        /// <summary>
        /// Determines if the relative coordinates should be displayed.
        /// </summary>
        public bool RelativeVisible { get; set; } = true;
        /// <summary>
        /// Determines if dpi related information should be displayed.
        /// </summary>
        public bool DpiVisible { get; set; } = true;
        /// <summary>
        /// Determines if the pixel color should be displayed.
        /// </summary>
        public bool PixelColorVisible { get; set; } = true;
        /// <summary>
        /// Determines if the app is in dark mode.
        /// </summary>
        public bool DarkMode { get; set; } = false;
        /// <summary>
        /// Determines of the main menu is visible.
        /// </summary>
        public bool MenuVisible { get; set; } = true;
        /// <summary>
        /// Determines if the list box containing logged positions is visible.
        /// </summary>
        public bool PositionLogVisible { get; set; } = false;
        /// <summary>
        /// Determines if position capturing is on.
        /// </summary>
        public bool Capturing { get; set; } = true;
        /// <summary>
        /// Specifies the global shortcut keys to copy/ log the current position.
        /// </summary>
        public Keys ShortcutKey { get; set; } = Keys.Control | Keys.Alt | Keys.X;
    }
}
