using SoftKeyboardSample.Interfaces;
using SoftKeyboardSample.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SoftKeyboardSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderItemView : ContentPage
    {
        private ExtendedEntry _currententry;
        private ISoftwareKeyboardService _keyboardService;
        public OrderItemView()
        {
            InitializeComponent();

            _keyboardService = DependencyService.Get<ISoftwareKeyboardService>();
        }

        private void ToolbarItemKeyboard_Clicked(object sender, EventArgs e)
        {
            if (_currententry != null)
            {
                if (this._keyboardService.IsKeyboardVisible)
                {
                    _currententry.HideKeyboard();
                }
                else
                {
                    _currententry.ShowKeyboard();
                }
            }

        }

        private void BarcodeEntry_Focused(object sender, FocusEventArgs e)
        {
            _currententry = sender as ExtendedEntry;
        }

        private void OrderQtyEntry_Focused(object sender, FocusEventArgs e)
        {
            _currententry = sender as ExtendedEntry;
        }
    }
}