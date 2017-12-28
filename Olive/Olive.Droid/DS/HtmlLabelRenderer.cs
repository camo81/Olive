using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Olive.Droid;
using Xamarin.Forms.Platform.Android;
using Olive.Model;
using Olive.Droid.DS;
using Android.Content;
using Android.Text;

[assembly: ExportRenderer(typeof(HtmlLabel), typeof(HtmlLabelRenderer))]

namespace Olive.Droid.DS
{
    public class HtmlLabelRenderer : LabelRenderer
    {
        public HtmlLabelRenderer(Context context) : base(context)
        {

        }



    }
}