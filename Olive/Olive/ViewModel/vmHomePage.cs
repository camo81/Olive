using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Olive.Model;
using Acr.UserDialogs;
using System.Net;
using Plugin.Connectivity;
using Olive.FunzioniComuni;

namespace Olive.ViewModel
{
    public class vmHomePage : ViewModelBase
    {
        #region binding

        public String Username;
        public String Password;
        public String IpAddress;
        public String IpAddressExt;

        public String buttonactiontext = Traduzioni.HomePage_Label1;
        public String ButtonActionText
        {
            get { return buttonactiontext; }
            set
            {
                buttonactiontext = value;
                Set(nameof(ButtonActionText), ref value);
            }
        }

        public String buttontext = Traduzioni.HomePage_Button1;
        public String ButtonText
        {
            get { return buttontext; }
            set
            {
                buttontext = value;
                Set(nameof(ButtonText), ref value);
            }
        }

        public ICommand CommandSendAction
        {
            get
            {
                return new RelayCommand(() => { SendAction(); });
            }

        }

        public ICommand gotoPage
        {
            get
            {
                return new RelayCommand(() => { funzioniComuni.changePage(new View.About()); });
            }


        }
        #endregion

        public vmHomePage()
        {
            var tmp = ManageData.getValue("Username");
            if (tmp == null)
            {
                Username = "";
            }
            else {
                Username = tmp.SettingValue;
            }


            tmp = ManageData.getValue("Password");
            if (tmp == null)
            {
                Password = "";
            }
            else
            {
                Password = tmp.SettingValue;
            }


            tmp = ManageData.getValue("IpAddress");
            if (tmp == null)
            {
                IpAddress = "";
            }
            else
            {
                IpAddress = tmp.SettingValue;
            }



            tmp = ManageData.getValue("IpAddressExt");
            if (tmp == null)
            {
                IpAddressExt = "";
            }
            else
            {
                IpAddressExt = tmp.SettingValue;
            }

        }

        public void SendAction() {

            runTask();
             
        }

        public string idiotMessage() {
            var messages = Traduzioni.Loading_message;
            string[] messageList = messages.Split('|');
            var rnd = new Random();
            var message = messageList[rnd.Next(0, messageList.Length)];

            return message;
        }

        public async void runTask()
        {
            string message = idiotMessage();

            UserDialogs.Instance.ShowLoading(message, MaskType.Black);

            await Task.Delay(2000);
           
            if ((string.IsNullOrWhiteSpace(Username)) || (string.IsNullOrWhiteSpace(Password)) ||
                 ((string.IsNullOrWhiteSpace(IpAddress)) && (string.IsNullOrWhiteSpace(IpAddressExt))))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.ShowError(Traduzioni.HomePage_buttonError);
            }
            else
            {

                var IPA = Xamarin.Forms.DependencyService.Get<IWebRequest>().apriCancello(Username, Password, IpAddress, IpAddressExt);

                if (IPA != "")
                {
                    //ButtonText = IPA;
                    var sbuild = new StringBuilder();
                    var text = sbuild.AppendFormat(Traduzioni.HomePage_success, IPA);

                    UserDialogs.Instance.HideLoading();
                    UserDialogs.Instance.ShowSuccess("" + text);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    UserDialogs.Instance.ShowError(Traduzioni.HomePage_dnsError);
                }


            }
            


        }
    }
}
