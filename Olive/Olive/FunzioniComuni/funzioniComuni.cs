using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Olive.View;

namespace Olive.FunzioniComuni
{
    public static class funzioniComuni
    {

        public static void changePage(Page page) {

            MasterDetailPage about = App.Current.MainPage as MasterDetailPage;
            about.Detail = new NavigationPage(page);
            about.IsPresented = false;

        }

    }
}
