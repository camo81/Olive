using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Olive.Model;

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
        public vmAbout()
        {

        }
    }
}
