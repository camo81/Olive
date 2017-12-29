using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Olive.Model;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace Olive.ViewModel
{
    public class vmAbout : ViewModelBase
    {

        public String aboutheading = Traduzioni.About_heading;
        public String AboutHeading
        {
            get { return aboutheading; }
            set
            {
                aboutheading = value;
                Set(nameof(AboutHeading), ref value);
            }
        }


        public String abouttext = Traduzioni.About_text;
        public String AboutText
        {
            get { return abouttext; }
            set
            {
                abouttext = value;
                Set(nameof(AboutText), ref value);
            }
        }

        public ICommand CommandOpenUrl
        {
            get
            {
                return new RelayCommand(() => { OpenUrl(); });
            }

        }
        

        public vmAbout()
        {

        }

        public void OpenUrl() {
            var url = Traduzioni.General_GitUri;
            Uri uri = new Uri(url);

            Device.OpenUri(uri);
        }
    }
}
