using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Olive.Droid;
using Xamarin.Forms.Platform.Android;
using Olive.Model;
using Olive.Droid.DS;


[assembly: ExportRenderer(typeof(ButtonWithoutShadow), typeof(ButtonWithoutShadowRenderer))]

namespace Olive.Droid.DS
{
    public class ButtonWithoutShadowRenderer : ButtonRenderer
    {
        public ButtonWithoutShadowRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var button = this.Control;
            button.SetAllCaps(false);
        }



    }
}
