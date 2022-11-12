using System;
using System.Collections.Generic;
using System.Text;

namespace SoftKeyboardSample.Controls
{
    public class SoftwareKeyboardEventArgs : EventArgs
    {
        public SoftwareKeyboardEventArgs(int keyboardheight)
        {
            KeyboardHeight = keyboardheight;
        }

        public int KeyboardHeight { get; private set; }
    }
}
