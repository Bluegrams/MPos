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
        /// Determines if the screen resolution should be displayed.
        /// </summary>
        public bool ScreenResolutionVisible { get; set; } = true;
        /// <summary>
        /// Determines if the pixel color should be displayed.
        /// </summary>
        public bool PixelColorVisible { get; set; } = true;
        /// <summary>
        /// Determines if the app is in dark mode.
        /// </summary>
        public bool DarkMode { get; set; } = false;
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
        /// <summary>
        /// Specifies the font family used for drawing the main data display.
        /// </summary>
        public string FontFamilyName { get; set; } = "Segoe UI";
        /// <summary>
        /// Specifies the font size used for drawing the main data display.
        /// </summary>
        public int FontSize { get; set; } = 12;

        public string DataFormatPoint { get; set; } = "{name}: X={x},Y={y}";
        public string DataFormatDpi { get; set; } = "Dpi: {dpi}; Raw Dpi: {rawDpi}; Dpi Ratio: {dpiRatio}";
        public string DataFormatResolution { get; set; } = "{name}: {x}x{y}";
        public string DataFormatColor { get; set; } = "Pixel Color: {value}";

        /// <summary>
        /// An event that allows to explicitly inform users of this class about changes.
        /// </summary>
        public event EventHandler Changed;

        /// <summary>
        /// Invoke the Changed event.
        /// </summary>
        public void InvokeChanged() => Changed?.Invoke(this, EventArgs.Empty);
    }
}
