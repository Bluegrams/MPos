using System;
using System.Drawing;
using System.Windows.Forms;

namespace MPos
{
    public class DragSnapForm : Form
    {
        public const int SnapMargin = 10;

        private bool mouseDown;
        private Point mouseLoc;

        public DragSnapForm()
        {
            this.LocationChanged += DragSnapForm_LocationChanged;
            this.Load += DragSnapForm_Load;
        }

        private void DragSnapForm_Load(object sender, EventArgs e)
        {
            catchMouseEvents(this);
        }

        /// <summary>
        /// Recursively subscribe to all mouse events of contained controls.
        /// </summary>
        private void catchMouseEvents(Control control)
        {
            foreach (Control child in control.Controls)
            {
                catchMouseEvents(child);
            }
            control.MouseDown += DragSnapForm_MouseDown;
            control.MouseMove += DragSnapForm_MouseMove;
            control.MouseUp += DragSnapForm_MouseUp;
        }

        /// <summary>
        /// Snaps the given windows to the screen border when it's near.
        /// </summary>
        private void DragSnapForm_LocationChanged(object sender, EventArgs e)
        {
            if (!this.Visible) return;
            Screen screen = Screen.FromControl(this);
            Point upperLeft = screen.WorkingArea.Location;
            Point lowerRight = new Point(screen.WorkingArea.Right, screen.WorkingArea.Bottom);
            if (Math.Abs(this.Left - upperLeft.X) <= SnapMargin)
                this.Left = upperLeft.X;
            if (Math.Abs(this.Top - upperLeft.Y) <= SnapMargin)
                this.Top = upperLeft.Y;
            if (Math.Abs(this.Right - lowerRight.X) <= SnapMargin)
                this.Left = lowerRight.X - this.Width;
            if (Math.Abs(this.Bottom - lowerRight.Y) <= SnapMargin)
                this.Top = lowerRight.Y - this.Height;
        }

        private void DragSnapForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            mouseLoc = e.Location;
        }

        private void DragSnapForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(this.Location.X - mouseLoc.X + e.X, this.Location.Y - mouseLoc.Y + e.Y);
            }
        }

        private void DragSnapForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
