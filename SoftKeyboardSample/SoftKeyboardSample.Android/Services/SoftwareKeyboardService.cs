using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SoftKeyboardSample.Controls;
using SoftKeyboardSample.Droid.Listeners;
using SoftKeyboardSample.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(SoftKeyboardSample.Droid.Services.SoftwareKeyboardService))]
namespace SoftKeyboardSample.Droid.Services
{
    public class SoftwareKeyboardService : ISoftwareKeyboardService
    {
        public virtual event EventHandler<SoftwareKeyboardEventArgs> KeyboardHeightChanged;

        private readonly Android.App.Activity activity;
        private readonly GlobalLayoutListener globalLayoutListener;

        public bool IsKeyboardVisible => globalLayoutListener.IsKeyboardVisible;

        //public SoftwareKeyboardService(Android.App.Activity activity)
        public SoftwareKeyboardService()
        {
            //this.activity = activity;
            this.activity = Xamarin.Essentials.Platform.CurrentActivity;
            globalLayoutListener = new GlobalLayoutListener(activity, this);
            this.activity.Window.DecorView.ViewTreeObserver.AddOnGlobalLayoutListener(this.globalLayoutListener);
        }

        internal void InvokeKeyboardHeightChanged(SoftwareKeyboardEventArgs args)
        {
            var handler = KeyboardHeightChanged;
            handler?.Invoke(this, args);
        }
    }
}