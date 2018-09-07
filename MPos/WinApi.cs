using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Security;

namespace MPos
{
    /// <summary>
    /// Represents a Win32 point structure.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WinPoint
    {
        public int X;
        public int Y;

        public static explicit operator Point(WinPoint point)
        {
            return new Point(point.X, point.Y);
        }

        public static explicit operator WinPoint(Point point)
        {
            WinPoint pt = new WinPoint();
            pt.X = (int)point.X;
            pt.Y = (int)point.Y;
            return pt;
        }
    }

    public enum MonitorOptions
    {
        MONITOR_DEFUALRRONULL = 0,
        MONITOR_DEFAULTTOPRIMARY = 1,
        MONITOR_DEFUALTTONEAREST = 2
    }

    public enum MonitorDpiType
    {
        EFFECTIVE_DPI = 0,
        ANGULAR_DPI = 1,
        RAW_DPI = 2,
    }

    /// <summary>
    /// A class that wraps some used Win32 Api calls.
    /// </summary>
    public class WinApi
    {
        #region API methods

        [SuppressUnmanagedCodeSecurity]
        [DllImport("User32.dll")]
        private static extern bool ScreenToClient(IntPtr hWnd, ref WinPoint lpPoint);

        [SuppressUnmanagedCodeSecurity]
        [DllImport("User32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [SuppressUnmanagedCodeSecurity]
        [DllImport("User32.dll")]
        private static extern IntPtr MonitorFromPoint(WinPoint pt, MonitorOptions dwFlags);

        // requires Windows 8.1 or newer
        [SuppressUnmanagedCodeSecurity]
        [DllImport("Shcore.dll")]
        private static extern IntPtr GetDpiForMonitor(IntPtr hmonitor, MonitorDpiType dpiType, out int dpiX, out int dpiY);

        #endregion

        #region Static methods

        /// <summary>
        /// Maps a point in screen coordinates to coordinates relative to the active window.
        /// </summary>
        /// <param name="point">A point in screen coordinates.</param>
        /// <returns>The given point in coordinates relative to the active window.</returns>
        public static WinPoint ScreenPointToClient(WinPoint point)
        {
            IntPtr hWnd = GetForegroundWindow();
            ScreenToClient(hWnd, ref point);
            return point;
        }

        /// <summary>
        /// Gets the dpi of the monitor.
        /// </summary>
        /// <param name="pt">A point specifying the monitor that should be used.</param>
        /// <param name="dpiType">A value of MonitorDpiType indicating the dpi type to be returned.</param>
        /// <returns>The dpi of the monitor.</returns>
        public static int GetMonitorDpiFromPoint(WinPoint pt, MonitorDpiType dpiType)
        {
            IntPtr hmonitor = MonitorFromPoint(pt, MonitorOptions.MONITOR_DEFUALTTONEAREST);
            GetDpiForMonitor(hmonitor, dpiType, out int dpiX, out int dpiY);
            return dpiX;
        }
        #endregion
    }
}
