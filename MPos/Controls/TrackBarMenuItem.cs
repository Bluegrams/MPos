using System;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace MPos.Controls
{
    /// <summary>
    /// Wraps a TrackBar for usage in a (context) menu strip.
    /// </summary>
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.MenuStrip |
                                   ToolStripItemDesignerAvailability.ContextMenuStrip)]
    public class TrackBarMenuItem : ToolStripControlHost
    {
        private TrackBar TrackBar { get { return Control as TrackBar; } }

        public int TrackBarValue
        {
            get { return TrackBar.Value; }
            set { TrackBar.Value = value; }
        }

        public event EventHandler<TrackBarEventArgs> ValueChanged;

        public TrackBarMenuItem() : base(CreateControl()) { }

        private static Control CreateControl()
        {
            TrackBar trackbar = new TrackBar()
            {
                AutoSize = false,
                Height = 20,
                TickFrequency = 10,
                Minimum = 10,
                Maximum = 100,
                SmallChange = 10,
                LargeChange = 10,
                TickStyle = TickStyle.None
            };
            return trackbar;
        }

        public void Scale(System.Drawing.SizeF factor) => Control.Scale(factor);

        protected override void OnSubscribeControlEvents(Control control)
        {
            base.OnSubscribeControlEvents(control);
            TrackBar trackBar = control as TrackBar;
            trackBar.ValueChanged += TrackBar_ValueChanged;
        }

        protected override void OnUnsubscribeControlEvents(Control control)
        {
            base.OnUnsubscribeControlEvents(control);
            TrackBar trackBar = control as TrackBar;
            trackBar.ValueChanged -= TrackBar_ValueChanged;
        }

        private void TrackBar_ValueChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(this, new TrackBarEventArgs(TrackBar.Value));
        }
    }

    public class TrackBarEventArgs : EventArgs
    {
        public int NewValue { get; private set; }

        public TrackBarEventArgs(int value)
        {
            NewValue = value;
        }
    }
}
