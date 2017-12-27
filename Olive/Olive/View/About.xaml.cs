using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Olive.View
{
    public partial class About : ContentPage
    {
        public About()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.vmAbout();
        }
    }
}
