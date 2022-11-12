using SoftKeyboardSample.Renderers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SoftKeyboardSample.ViewModels
{
    public class OrderItemViewModel : BaseViewModel
    {
        public ICommand BarcodeScannedCommand { get; private set; }

        public string _barcode;
        public int _orderQty;
        public OrderItemViewModel()
        {
            BarcodeScannedCommand = new Command<object>((obj) => BarcodeScanned(obj), (obj) => IsControlEnable);
        }

        private void BarcodeScanned(object obj)
        {
            IsControlEnable = false;
            IsBusy = true;
            (BarcodeScannedCommand as Command).ChangeCanExecute();

            ExtendedEntry barcodeEntry = ((ExtendedEntry)((ContentPage)obj).FindByName("BarcodeEntry"));
            ExtendedEntry orderQtyEntry = ((ExtendedEntry)((ContentPage)obj).FindByName("OrderQtyEntry"));

            //barcodeEntry.IsEnabled = false;
            //orderQtyEntry.IsEnabled = false;


            //ToDo : 바코드가 상품마스터에 있는지 체크등 Biz로직
            if(this.Barcode == "123456")
            {
                //스캔한 바코드가 마스터에 있고 수량입력 하기 위해 포커스를 발주수량으로 이동 시킬 경우
                orderQtyEntry.IsEnabled = true;
                orderQtyEntry.CursorPosition = 0;
                orderQtyEntry.SelectionLength = orderQtyEntry.Text.Length;
                orderQtyEntry.Focus();
            }
            else
            {
                //스캔한 바코드가 마스터에 없을경우 재 스캔 해야 하기 때문에 다시 스캔 해야 하는 경우
                barcodeEntry.IsEnabled = true;
                barcodeEntry.CursorPosition = 0;
                barcodeEntry.SelectionLength = barcodeEntry.Text.Length;
                barcodeEntry.Focus();
                //barcodeEntry.HideKeyboard(); //이건 필요는 없는데 필요하면 사용
            }

            //ToDo

            //barcodeEntry.IsEnabled = true;
            //orderQtyEntry.IsEnabled = true;

            IsControlEnable = true;
            IsBusy = false;
            (BarcodeScannedCommand as Command).ChangeCanExecute();
        }

        public string Barcode
        {
            get => _barcode;
            set => SetProperty(ref this._barcode, value);
        }

        public int OrderQty
        {
            get => _orderQty;
            set => SetProperty(ref this._orderQty, value);
        }
    }
}
