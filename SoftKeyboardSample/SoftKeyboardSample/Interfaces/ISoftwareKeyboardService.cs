using SoftKeyboardSample.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftKeyboardSample.Interfaces
{
    public interface ISoftwareKeyboardService
    {
        event EventHandler<SoftwareKeyboardEventArgs> KeyboardHeightChanged;
        bool IsKeyboardVisible { get; }
    }
}
