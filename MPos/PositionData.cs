using System;
using System.Drawing;
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

        public override string ToString()
        {
            return String.Format("Physical: {0}; " +
                "Scaled: {1}; " +
                "Relative: {2}; " +
                "Dpi: {3}; " +
                "Raw Dpi: {4}; " +
                "Dpi Scaling: {5}; " +
                "Dpi Ratio: {6}; " +
                "Screen Resolution: {7}; " +
                "Pixel Color: {8}",
                PhysicalPosition, ScaledPosition, RelativePosition,
                Dpi, RawDpi, DpiScaling, DpiRawRatio,
                ScreenResolution, ColorTranslator.ToHtml(PixelColor));
        }
    }
}
