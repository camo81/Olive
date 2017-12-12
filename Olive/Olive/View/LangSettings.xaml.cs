using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Olive.View
{
    public partial class LangSettings : ContentPage
    {
        public LangSettings()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.vmLangSettings();
        }
    }
}
