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

        public int SendAction() {


            if ((string.IsNullOrWhiteSpace(Username)) || (string.IsNullOrWhiteSpace(Password)) || (string.IsNullOrWhiteSpace(IpAddress)) || (string.IsNullOrWhiteSpace(IpAddressExt)))
            {
                UserDialogs.Instance.ShowError(Traduzioni.HomePage_buttonError);
            }
            else {
                ButtonActionText = "" + Username + Password + IpAddress + IpAddressExt;

                WebRequest call = WebRequest.Create(IpAddress);
                /*
                 
                    string url = @"https://telematicoprova.agenziadogane.it/TelematicoServiziDiUtilitaWeb/ServiziDiUtilitaAutServlet?UC=22&SC=1&ST=2";
                    WebRequest request = WebRequest.Create(url);
                    request.Credentials = GetCredential();
                    request.PreAuthenticate = true;
                    and this is GetCredential()

                    private CredentialCache GetCredential()
                    {
                        string url = @"https://telematicoprova.agenziadogane.it/TelematicoServiziDiUtilitaWeb/ServiziDiUtilitaAutServlet?UC=22&SC=1&ST=2";
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                        CredentialCache credentialCache = new CredentialCache();
                        credentialCache.Add(new System.Uri(url), "Basic", new NetworkCredential(ConfigurationManager.AppSettings["ead_username"], ConfigurationManager.AppSettings["ead_password"]));
                        return credentialCache;
                    }


            ALTRO SU 
            https://stackoverflow.com/questions/4334521/httpwebrequest-using-basic-authentication
             
             */

            }





            return 1;
        }
    }
}
