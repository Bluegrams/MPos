using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MPos
{
    public struct PositionData
    {
        /// <summary>
        /// The physical pixel position on the screen.
        /// </summary>
        public readonly Point PhysicalPosition;
        /// <summary>
        /// The DPI-scaled pixel position on the screen.
        /// </summary>
        public readonly Point ScaledPosition;
        /// <summary>
        /// The position relative to the currently focused window in pixels.
        /// </summary>
        public readonly Point RelativePosition;
        /// <summary>
        /// The DPI value of the current monitor.
        /// </summary>
        public readonly int Dpi;
        /// <summary>
        /// The raw DPI value of the current monitor.
        /// </summary>
        public readonly int RawDpi;
        /// <summary>
        /// The currently set DPI scaling for the current monitor.
        /// </summary>
        public readonly double DpiScaling;
        /// <summary>
        /// The DPI to raw DPI ratio.
        /// </summary>
        public readonly double DpiRawRatio;
        /// <summary>
        /// The bounds of the current monitor.
        /// </summary>
        public readonly Size ScreenResolution;
        /// <summary>
        /// The color of the pixel at the position.
        /// </summary>
        public readonly Color PixelColor;

        /// <summary>
        /// Creates a PositionData instance from a given point.
        /// </summary>
        public PositionData(Point position)
        {
            WinPoint winPos = (WinPoint)position;
            this.PhysicalPosition = position;
            // Determine dpi information
            this.Dpi = WinApi.GetMonitorDpiFromPoint(winPos, MonitorDpiType.EFFECTIVE_DPI);
            this.DpiScaling = Math.Round(Dpi / (double)96, 2);
            // Determine scaled position.
            this.ScaledPosition = new Point((int)(position.X / DpiScaling),
                                        (int)(position.Y / DpiScaling));
            // Determine relative position.
            this.RelativePosition = (Point)WinApi.ScreenPointToClient(winPos);
            // Determine raw dpi.
            this.RawDpi = WinApi.GetMonitorDpiFromPoint(winPos, MonitorDpiType.RAW_DPI);
            this.DpiRawRatio = Math.Round(Dpi / (double)RawDpi, 2);
            // Determine screen bounds
            this.ScreenResolution = Screen.FromPoint(position).Bounds.Size;
            // Determine color at mouse position.
            this.PixelColor = GetPixelColor(winPos);
        }

        /// <summary>
        /// Returns the color of the pixel at the mouse's position.
        /// </summary>
        public static Color GetPixelColor(WinPoint point)
        {
            Bitmap bmp = new Bitmap(1, 1);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                try
                {
                    g.CopyFromScreen(point.X, point.Y, 0, 0, new Size(1, 1));
                }
                catch { }
            }
            Color color = bmp.GetPixel(0, 0);
            bmp.Dispose();
            return Color.FromArgb(color.R, color.G, color.B);
        }

        public override string ToString() => ToString(new Settings());

        public string ToString(Settings settings)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(formatPoint(settings, "Physical", PhysicalPosition));
            //String s = $"Physical: {PhysicalPosition}";
            if (settings.ScaledVisible)
                sb.Append("; ").Append(formatPoint(settings, "Scaled", ScaledPosition));
            //s += $"; Scaled: {ScaledPosition}";
            if (settings.RelativeVisible)
                sb.Append("; ").Append(formatPoint(settings, "Relative", RelativePosition));
            //s += $"; Relative: {RelativePosition}";
            if (settings.DpiVisible)
                sb.Append("; ").Append(formatDpi(settings));
            //s += $"; Dpi: {Dpi}; Raw Dpi: {RawDpi}; Dpi Ratio: {DpiRawRatio}";
            if (settings.ScreenResolutionVisible)
                sb.Append("; ").Append(formatResolution(settings, "Screen Resolution", ScreenResolution));
            //s += $"; Screen Resolution: {ScreenResolution}";
            if (settings.PixelColorVisible)
                sb.Append("; ").Append(formatColor(settings, PixelColor));
                //s += $"; Pixel Color: {ColorTranslator.ToHtml(PixelColor)}";
            return sb.ToString();
        }

        private StringBuilder formatPoint(Settings settings, string name, Point p)
            => new StringBuilder(settings.DataFormatPoint)
                .Replace("{name}", name)
                .Replace("{x}", p.X.ToString())
                .Replace("{y}", p.Y.ToString());

        private StringBuilder formatDpi(Settings settings)
            => new StringBuilder(settings.DataFormatDpi)
                .Replace("{dpi}", Dpi.ToString())
                .Replace("{rawDpi}", RawDpi.ToString())
                .Replace("{dpiRatio}", DpiRawRatio.ToString());

        private StringBuilder formatResolution(Settings settings, string name, Size s)
            => new StringBuilder(settings.DataFormatResolution)
                .Replace("{name}", name)
                .Replace("{x}", s.Width.ToString())
                .Replace("{y}", s.Height.ToString());

        private StringBuilder formatColor(Settings settings, Color c)
            => new StringBuilder(settings.DataFormatColor)
                .Replace("{value}", ColorTranslator.ToHtml(c));
    }
}
