using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Olive.View;
using Olive.Model;
using Acr.UserDialogs;

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

        public static bool startWithHttp(string url)
        {

            if ((string.IsNullOrWhiteSpace(url)) || (url.Length < 11))
            {
                return false;
            }

            int startIndex = 0;
            int length = 7;

            var pippo = url.Substring(startIndex, length).ToLower();

            if ((url.Substring(startIndex, length).ToLower() == "http://") || (url.Substring(startIndex, length + 1).ToLower() == "https://"))
            {
                return true;
            }
            else
            {
                var text = Traduzioni.Settings_httpvalidation;
                UserDialogs.Instance.ShowError(text);
                return false;
            }




        }

    }
}
