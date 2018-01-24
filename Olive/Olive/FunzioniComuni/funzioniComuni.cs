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


        public static void changePage(Page page)
        {
            MasterDetailPage newPage = App.Current.MainPage as MasterDetailPage;
            newPage.Detail = new NavigationPage(page);
            newPage.IsPresented = false;

        }

    }
}
