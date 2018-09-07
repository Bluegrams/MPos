using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Linq;

namespace MPos
{
    public class WinHotKeys : IDisposable
    {
        #region Win Api methods
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        #endregion

        private IntPtr handle;
        private int hotKeyCount = 0;

        public const int WM_HOTKEY = 0x0312;

        public WinHotKeys(IntPtr handle)
        {
            this.handle = handle;
        }

        /// <summary>
        /// Globally registers a hotkey.
        /// </summary>
        /// <param name="keyCombination">The hotkey to register.</param>
        /// <returns>The ID of the hotkey (starting with 0).</returns>
        public int RegisterHotKey(KeyCombination keyCombination)
        {
            if (!RegisterHotKey(handle, hotKeyCount, (uint)keyCombination.Modifiers, (uint)keyCombination.Key))
                throw new InvalidOperationException("Registering hot key failed.");
            var hotKeyId = hotKeyCount;
            hotKeyCount++;
            return hotKeyId;
        }

        /// <summary>
        /// Unregisters a hotkey.
        /// </summary>
        /// <param name="id">The ID of the hotkey to be unregistered.</param>
        /// <returns>True on success, false otherwise.</returns>
        public bool UnregisterHotKey(int id)
        {
            return UnregisterHotKey(handle, id);
        }

        public void Dispose()
        {
            for (int i = 0; i < hotKeyCount; i++)
                UnregisterHotKey(handle, i);
        }

        /// <summary>
        /// Reads a Windows message and returns the key combination of a hotkey if one was pressed.
        /// </summary>
        /// <param name="msg">The message to process.</param>
        /// <returns>The key combination of a pressed hotkey, null otherwise.</returns>
        public static KeyCombination GetHotKeyCombination(ref Message msg)
        {
            KeyCombination combination = null;
            // WM_HOTKEY = 0x0312
            if (msg.Msg == WM_HOTKEY)
            {
                Keys key = (Keys)(((int)msg.LParam >> 16) & 0xffff);
                ModifierKeys modifiers = (ModifierKeys)((int)msg.LParam & 0xffff);
                combination = new KeyCombination() { Key = key, Modifiers = modifiers };
            }
            return combination;
        }
    }

    /// <summary>
    /// Represents a key combination out of modifiers and keys.
    /// </summary>
    public class KeyCombination
    {
        public ModifierKeys Modifiers { get; set; }
        public Keys Key { get; set; }

        public override string ToString()
        {
            var modifierString = String.Join("+", Modifiers.ToString().Replace(" ", "").Split(',').Reverse());
            return modifierString + "+" + Key.ToString();
        }
    }

    /// <summary>
    /// Enumeration of possible modifiers.
    /// </summary>
    [Flags]
    public enum ModifierKeys : uint
    {
        Alt = 1,
        Ctrl = 2,
        Shift = 4,
        Win = 8
    }
}
