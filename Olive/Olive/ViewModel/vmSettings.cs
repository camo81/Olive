using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using Olive.Model;
using Acr.UserDialogs;
using System.Text;

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

        public String usernameplaceholder = Traduzioni.Settings_userPH;
        public String UsernamePlaceholder
        {
            get { return usernameplaceholder; }
            set
            {
                usernameplaceholder = value;
                Set(nameof(UsernamePlaceholder), ref value);
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

        public String passwordplaceholder = Traduzioni.Settings_passPH;
        public String PasswordPlaceholder
        {
            get { return passwordplaceholder; }
            set
            {
                passwordplaceholder = value;
                Set(nameof(PasswordPlaceholder), ref value);
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


        public String ipaddressplaceholder = Traduzioni.Settings_ipPH;
        public String IpAddressPlaceholder
        {
            get { return ipaddressplaceholder; }
            set
            {
                ipaddressplaceholder = value;
                Set(nameof(IpAddressPlaceholder), ref value);
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

        public String ipaddressextplaceholder = Traduzioni.Settings_ipextPH;
        public String IpAddressExtPlaceholder
        {
            get { return ipaddressextplaceholder; }
            set
            {
                ipaddressextplaceholder = value;
                Set(nameof(IpAddressExtPlaceholder), ref value);
            }
        }

        public String savesettingstext = Traduzioni.Settings_SaveSettingsText;
        public String SaveSettingsText
        {
            get { return savesettingstext; }
            set
            {
                savesettingstext = value;
                Set(nameof(SaveSettingsText), ref value);
            }
        }

        public String delsettingstext = Traduzioni.Settings_DelSettingsText;
        public String DelSettingsText
        {
            get { return delsettingstext; }
            set
            {
                delsettingstext = value;
                Set(nameof(DelSettingsText), ref value);
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


        public ICommand DelSettings
        {
            get
            {
                return new RelayCommand(() => { DelSet(); });
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

            if ( (tmp == null) && (ValidateSettings(dati)) )
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
            else if (ValidateSettings(dati))
            {
                dati.IdSetting = tmp.IdSetting;
                var i = ManageData.UpdateSettings(dati);                   
            }



            //set della variabile Password
            dati.SettingName = "Password";
            dati.SettingValue = Password;
            
            tmp = ManageData.getValue("Password");

            if ( (tmp == null) && (ValidateSettings(dati)) )
            {
                try
                {
                var Pass = ManageData.InsertSettings(dati);                    
                }
                catch (Exception e)
                {
                    OpStatus = "" + e;
                }
            }
            else if (ValidateSettings(dati))
            {
            dati.IdSetting = tmp.IdSetting;
            var i = ManageData.UpdateSettings(dati);
            }


            //set della variabile IPA
            dati.SettingName = "IpAddress";
            dati.SettingValue = IpAddress;

            tmp = ManageData.getValue("IpAddress");

            if ( (tmp == null) && (ValidateSettings(dati)) )
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
            else if (ValidateSettings(dati))
            {
            dati.IdSetting = tmp.IdSetting;
            var i = ManageData.UpdateSettings(dati);                
            }


            //set della variabile IPAEXT
            dati.SettingName = "IpAddressExt";
            dati.SettingValue = IpAddressExt;

            tmp = ManageData.getValue("IpAddressExt");

            if ( (tmp == null) && (ValidateSettings(dati)) )
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
            else if (ValidateSettings(dati))
            {
                dati.IdSetting = tmp.IdSetting;
                var i = ManageData.UpdateSettings(dati);
            }


        }

        public async void DelSet()
        {
            var result = await UserDialogs.Instance.ConfirmAsync(new ConfirmConfig
            {
                Message = Traduzioni.Setting_confirmMessage,
                OkText = Traduzioni.Setting_confirm_yes,
                CancelText = Traduzioni.Setting_confirm_no
            });
            if (result)
            {
                ManageData.delSettings();
                Username = Password = IpAddress = IpAddressExt = "";
            }

        }

        public bool ValidateSettings(Settings dati)
        {

            switch (dati.SettingName)
            {
                case "Username":
                    //OpStatus = "Username non valido";
                    if (string.IsNullOrWhiteSpace(dati.SettingValue))
                        {
                        var sbuild = new StringBuilder();
                        var text = sbuild.AppendFormat(Traduzioni.Settings_validationError, dati.SettingName);
                        UserDialogs.Instance.ShowError(""+text);
                        return false;
                        } 
                    
                    break;

                case "Password":
                    if (string.IsNullOrWhiteSpace(dati.SettingValue))
                    {
                        var sbuild = new StringBuilder();
                        var text = sbuild.AppendFormat(Traduzioni.Settings_validationError, dati.SettingName);
                        UserDialogs.Instance.ShowError("" + text);
                        return false;
                    }
                    break;

                case "IpAddress":
                    if (string.IsNullOrWhiteSpace(dati.SettingValue))
                    {
                        var sbuild = new StringBuilder();
                        var text = sbuild.AppendFormat(Traduzioni.Settings_validationError, dati.SettingName);
                        UserDialogs.Instance.ShowError("" + text);
                        return false;
                    }
                    break;

                case "IpAddressExt":
                    if (string.IsNullOrWhiteSpace(dati.SettingValue))
                    {
                        var sbuild = new StringBuilder();
                        var text = sbuild.AppendFormat(Traduzioni.Settings_validationError, dati.SettingName);
                        UserDialogs.Instance.ShowError("" + text);
                        return false;
                    }
                    break;
            }


            return true;

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