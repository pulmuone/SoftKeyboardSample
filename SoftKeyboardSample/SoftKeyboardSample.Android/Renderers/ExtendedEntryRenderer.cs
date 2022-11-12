using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using SoftKeyboardSample.Droid.Renderers;
using SoftKeyboardSample.Interfaces;
using SoftKeyboardSample.Renderers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace SoftKeyboardSample.Droid.Renderers
{
    public class ExtendedEntryRenderer : EntryRenderer, IVirtualKeyboard
    {
        public ExtendedEntryRenderer(Context context) : base(context)
        {
        }

        /// <summary>
        /// Called when [element changed].
        /// </summary>
        /// <param name="e">The e.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if ((e.OldElement == null) && (Control != null))
            {
                var edittext = (EditText)Control;

                edittext.SetPadding(0, 0, 0, 0);
                edittext.SetTextIsSelectable(true);
                edittext.SetSelectAllOnFocus(true);
                edittext.ShowSoftInputOnFocus = false; //true: 키보드 보임, false: 키보다 안보임

                var view = (ExtendedEntry)Element;

                view.VirtualKeyboardHandler = this;
            }
        }

        public void ShowKeyboard()
        {
            try
            {
                Control.RequestFocus();
                var inputMethodManager = Control.Context.GetSystemService(Context.InputMethodService) as InputMethodManager;
                inputMethodManager.ShowSoftInput(Control, ShowFlags.Implicit);
                //Show Force : 사용자가 명시적으로 키보드를 표시하도록 요청했으면(예:키보드 열기 버튼을 눌러) 시스템이 키보드를 강제로
                //열어야 함을 의미합니다. 이 경우 플래그를 사요하여 키보드를 숨기려는 기존 요청은 무시됩니다.(따라서 키보드는 강제로 열림)
                //SHOW_IMPLICIT 으로 키보드를 열었을 경우 숨길 때는 HIDE_IMPLICIT_ONLY /HIDE_NOT_ALWAYS 으로 숨겨야 한다.
            }
            catch (Exception ex)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                var properties = new Dictionary<string, string>
                {
                    { m.ReflectedType.FullName, m.ReflectedType.Name}
                };
                //Crashes.TrackError(ex, properties);
            }
        }

        public void HideKeyboard()
        {
            try
            {
                Control.RequestFocus();
                var inputMethodManager = Control.Context.GetSystemService(Context.InputMethodService) as InputMethodManager;
                //inputMethodManager.HideSoftInputFromWindow(this.Control.WindowToken, HideSoftInputFlags.None); // this probably needs to be set to ToogleSoftInput, forced.
                inputMethodManager.HideSoftInputFromWindow(this.Control.WindowToken, HideSoftInputFlags.ImplicitOnly);
            }
            catch (Exception ex)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                var properties = new Dictionary<string, string>
                {
                    { m.ReflectedType.FullName, m.ReflectedType.Name}
                };
                //Crashes.TrackError(ex, properties);
            }
        }
    }
}