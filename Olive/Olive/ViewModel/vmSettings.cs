using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using Olive.Model;

namespace Olive.ViewModel
{
    public class vmSettings : ViewModelBase
    {

        #region binding 

        public String username;
        public String Username
        {
            get { return username; }
            set
            {
                username = value;
                Set(nameof(Username), ref value);
            }
        }

        public String password;
        public String Password
        {
            get { return password; }
            set
            {
                password = value;
                Set(nameof(Password), ref value);
            }
        }

        public String ipaddress;
        public String IpAddress
        {
            get { return ipaddress; }
            set
            {
                ipaddress = value;
                Set(nameof(IpAddress), ref value);
            }
        }


        public String ipaddressext;
        public String IpAddressExt
        {
            get { return ipaddressext; }
            set
            {
                ipaddressext = value;
                Set(nameof(IpAddressExt), ref value);
            }
        }

        public String opstatus;
        public String OpStatus
        {
            get { return opstatus; }
            set
            {
                opstatus = value;
                Set(nameof(OpStatus), ref value);
            }
        }


        public ICommand SaveSettings
        {
            get
            {
                return new RelayCommand ( () => { SaveSet(); } );
            }

        }

        #endregion
        public void SaveSet()
        {
            var dati = new Settings();

            //set della variabile Username
            dati.SettingName = "Username";
            dati.SettingValue = Username;

            //verifico se esiste già un setting per Username
            var tmp = ManageData.getValue("Username");

            if (tmp == null)
            {   
                // se non esiste faccio l'insert
                try
                {
                    var UserI = ManageData.InsertSettings(dati);
                }
                catch (Exception e)
                {
                    OpStatus = "" + e;
                }
            }
            //altrimenti l'update
            else {
                dati.IdSetting = tmp.IdSetting;
                var i = ManageData.UpdateSettings(dati);
            }



            //set della variabile Password
            dati.SettingName = "Password";
            dati.SettingValue = Password;
            
            tmp = ManageData.getValue("Password");

            if (tmp == null)
            {
                try
                {
                    var PassI = ManageData.InsertSettings(dati);
                }
                catch (Exception e)
                {
                    OpStatus = "" + e;
                }
            }
            else {
                dati.IdSetting = tmp.IdSetting;
                var i = ManageData.UpdateSettings(dati);
            }


            //set della variabile IPA
            dati.SettingName = "IpAddress";
            dati.SettingValue = IpAddress;

            tmp = ManageData.getValue("IpAddress");

            if (tmp == null)
            {
                try
                {
                    var IPAI = ManageData.InsertSettings(dati);
                }
                catch (Exception e)
                {
                    OpStatus = "" + e;
                }

            }
            else {
                dati.IdSetting = tmp.IdSetting;
                var i = ManageData.UpdateSettings(dati);
            }


            //set della variabile IPAEXT
            dati.SettingName = "IpAddressExt";
            dati.SettingValue = IpAddressExt;

            tmp = ManageData.getValue("IpAddressExt");

            if (tmp == null)
            {
                try
                {
                    var IPAIE = ManageData.InsertSettings(dati);
                }
                catch (Exception e)
                {
                    OpStatus = "" + e;
                }

            }
            else
            {
                dati.IdSetting = tmp.IdSetting;
                var i = ManageData.UpdateSettings(dati);
            }


        }
        #region ctor
        public vmSettings()
        {
            var tmp = ManageData.getValue("Username");

            if (tmp != null)
            {
                Username = tmp.SettingValue;
            }

            tmp = ManageData.getValue("Password");

            if (tmp != null)
            {
                Password = tmp.SettingValue;
            }

            tmp = ManageData.getValue("IpAddress");

            if (tmp != null)
            {
                IpAddress = tmp.SettingValue;
            }

            tmp = ManageData.getValue("IpAddressExt");

            if (tmp != null)
            {
                IpAddressExt = tmp.SettingValue;
            }
        }
        #endregion
    }
}