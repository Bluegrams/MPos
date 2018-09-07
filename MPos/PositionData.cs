using System;
using System.Drawing;

namespace MPos
{
    public class PositionData
    {
        /// <summary>
        /// The physical pixel position on the screen.
        /// </summary>
        public Point PhysicalPosition { get; set; }
        /// <summary>
        /// The DPI-scaled pixel position on the screen.
        /// </summary>
        public Point ScaledPosition { get; set; }
        /// <summary>
        /// The position relative to the currently focused window in pixels.
        /// </summary>
        public Point RelativePosition { get; set; }
        /// <summary>
        /// The DPI value of the current monitor.
        /// </summary>
        public int Dpi { get; set; }
        /// <summary>
        /// The raw DPI value of the current monitor.
        /// </summary>
        public int RawDpi { get; set; }
        /// <summary>
        /// The currently set DPI scaling for the current monitor.
        /// </summary>
        public double DpiScaling { get { return Math.Round(Dpi / (double)96, 2); } }
        /// <summary>
        /// The DPI to raw DPI ratio.
        /// </summary>
        public double DpiRawRatio { get { return Math.Round(Dpi / (double)RawDpi, 2); } }
        /// <summary>
        /// The color of the pixel at the position.
        /// </summary>
        public Color PixelColor { get; set; }

        public void Update(Point position)
        {
            PhysicalPosition = position;
            Dpi = WinApi.GetMonitorDpiFromPoint((WinPoint)position, MonitorDpiType.EFFECTIVE_DPI);
            // Determine scaled position.
            ScaledPosition = new Point((int)(position.X / DpiScaling),
                                        (int)(position.Y / DpiScaling));
            // Determine relative position.
            RelativePosition = (Point)WinApi.ScreenPointToClient((WinPoint)position);
            // Determine raw dpi.
            RawDpi = WinApi.GetMonitorDpiFromPoint((WinPoint)position, MonitorDpiType.RAW_DPI);
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
                "Pixel Color: {7}",
                PhysicalPosition, ScaledPosition, RelativePosition,
                Dpi, RawDpi, DpiScaling, DpiRawRatio, ColorTranslator.ToHtml(PixelColor));
        }
    }
}
