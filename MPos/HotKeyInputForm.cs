using System;
using System.Windows.Forms;

namespace MPos
{
    public partial class HotKeyInputForm : Form
    {
        public KeyCombination SelectedKeys { get; private set; }

        public HotKeyInputForm(KeyCombination initialKeys)
        {
            InitializeComponent();
            SelectedKeys = initialKeys;
            for (int i = 65; i <= 90; i++)
                comKeys.Items.Add((char)i);
            setInitialKeys();
        }

        private void setInitialKeys()
        {
            chkControl.Checked = (SelectedKeys.Modifiers & MPos.ModifierKeys.Ctrl) == MPos.ModifierKeys.Ctrl;
            chkAlt.Checked = (SelectedKeys.Modifiers & MPos.ModifierKeys.Alt) == MPos.ModifierKeys.Alt;
            chkShift.Checked = (SelectedKeys.Modifiers & MPos.ModifierKeys.Shift) == MPos.ModifierKeys.Shift;
            comKeys.SelectedItem = (char)SelectedKeys.Key;
        }

        private void butSubmit_Click(object sender, EventArgs e)
        {
            // Read modifier checkboxes.
            uint modifiers = 0;
            if (chkControl.Checked) modifiers |= (uint)MPos.ModifierKeys.Ctrl;
            if (chkAlt.Checked) modifiers |= (uint)MPos.ModifierKeys.Alt;
            if (chkShift.Checked) modifiers |= (uint)MPos.ModifierKeys.Shift;
            // At least one modifier must be checked for a valid shortcut.
            if (modifiers == 0)
            {
                MessageBox.Show("Please specify at least one modifier key (Control, Alt or Shift).", "Invalid Shortcut");
                return;
            }
            SelectedKeys.Modifiers = (ModifierKeys)modifiers;
            SelectedKeys.Key = (Keys)(char)comKeys.SelectedItem;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
