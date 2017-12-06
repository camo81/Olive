using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Olive.Model;

namespace Olive.ViewModel
{
    public class vmHomePage : ViewModelBase
    {
        #region binding

        public String User;
        public String Password;
        public String IpAddress;
        public String IpAddressExt;

        public String buttonactiontext = "Schiaccia il bottone per aprire il cancello";
        public String ButtonActionText
        {
            get { return buttonactiontext; }
            set
            {
                buttonactiontext = value;
                Set(nameof(ButtonActionText), ref value);
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
            User = ManageData.getValue("Username").SettingValue;
            Password = ManageData.getValue("Password").SettingValue;
            IpAddress = ManageData.getValue("IpAddress").SettingValue;
            IpAddressExt = ManageData.getValue("IpAddressExt").SettingValue;
        }

        public int SendAction() {


            ButtonActionText = "" + User + Password + IpAddress + IpAddressExt;




            return 1;
        }
    }
}
