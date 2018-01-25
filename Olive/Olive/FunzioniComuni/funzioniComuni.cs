using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Olive.View;
using Olive.Model;

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

        public static void pageAsync(Page page, bool animation = true)
        {

            MasterDetailPage tmp = Application.Current.MainPage as MasterDetailPage;
            tmp.Detail.Navigation.PushAsync(page, animation);

        }

        public static string idiotMessage()
        {
            var messages = Traduzioni.Loading_message;
            string[] messageList = messages.Split('|');
            var rnd = new Random();
            var message = messageList[rnd.Next(0, messageList.Length)];

            return message;
        }

    }
}
