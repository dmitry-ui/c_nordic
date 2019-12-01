using System;
using System.Collections.Generic;
using System.Text;

namespace A_Event_PressKey
{
    public class KeyEventArgs : EventArgs
    {
        public char ch;
    }

    public class KeyEvent
    {
        public event EventHandler<KeyEventArgs> KeyPress;
        public void OnPressKey(char letter)
        {
            KeyEventArgs kea = new KeyEventArgs();
            if (KeyPress != null)
            {
                kea.ch = letter;
                KeyPress(this, kea);
            }
        }
    }
}
