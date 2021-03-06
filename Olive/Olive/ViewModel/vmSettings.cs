﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using Olive.Model;
using Acr.UserDialogs;
using System.Text;
using System.Collections.Generic;
using Olive.FunzioniComuni;

namespace Olive.ViewModel
{
    public class vmSettings : ViewModelBase
    {

        #region binding 

        private bool isselected = true;
        public bool isSelected
        {
            get { return isselected; }
            set
            {
                isselected = value;
                Set(nameof(isSelected), ref value);

            }
        }

        private String switchtext = Traduzioni.Settings_sound;
        public String switchText
        {
            get { return switchtext; }
            set
            {
                switchtext = value;
                Set(nameof(switchText), ref value);

            }
        }

        public string description = Traduzioni.Settings_Description;
        public String Description
        {
            get { return description; }
            set
            {
                description = value;
                Set(nameof(Description), ref value);
            }
        }
        
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


        public ICommand gotoPage
        {
            get
            {
                return new RelayCommand(() => { funzioniComuni.pageAsync(new View.About()); });
            }


        }
        #endregion

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

            try
            {
                var i = ManageData.getValue("PlaySound");
                if (i.SettingValue == "False")
                {
                    isSelected = false;
                }

            }
            catch (Exception e)
            {
    

            }
        }
        #endregion

        public void SaveSet()
        {
            var dati = new Settings();

            //set della variabile Username
            dati.SettingName = "Username";
            dati.SettingValue = Username;
            int u = 0;

            //verifico se esiste già un setting per Username
            var tmp = ManageData.getValue("Username");

            if ( (tmp == null) && (ValidateSettings(dati)) )
            {   
                // se non esiste faccio l'insert
                try
                {
                  u = ManageData.InsertSettings(dati);                        
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
                u = ManageData.UpdateSettings(dati);                   
            }



            //set della variabile Password
            dati.SettingName = "Password";
            dati.SettingValue = Password;
            int p = 0;
            
            tmp = ManageData.getValue("Password");

            if ( (tmp == null) && (ValidateSettings(dati)) )
            {
                try
                {
                p = ManageData.InsertSettings(dati);                    
                }
                catch (Exception e)
                {
                    OpStatus = "" + e;
                }
            }
            else if (ValidateSettings(dati))
            {
            dati.IdSetting = tmp.IdSetting;
            p = ManageData.UpdateSettings(dati);
            }

            List<Settings> multi = new List<Settings>();

            Settings AddressExt = new Settings();
            AddressExt.SettingValue = IpAddressExt;
            AddressExt.SettingName = "IpAddressExt";
            //AddressExt.IdSetting = 1;
            multi.Add(AddressExt);

            Settings AddressInt = new Settings();
            AddressInt.SettingValue = IpAddress;
            AddressInt.SettingName = "IpAddress";
            //AddressInt.IdSetting = 2;
            multi.Add(AddressInt);

            
            //set della variabile isSelected
            dati.SettingName = "PlaySound";

            dati.SettingValue = isSelected.ToString();
            var tmp2 = ManageData.getValue("PlaySound");
            if ((tmp2 == null))
            {
                // se non esiste faccio l'insert
                try
                {
                    var play = ManageData.InsertSettings(dati);
                }
                catch (Exception e)
                {
                    
                }
            }
            else
            {
                dati.IdSetting = tmp2.IdSetting;
                var play = ManageData.UpdateSettings(dati);
            }

            var MultiSave = MultiValidateAndSave(multi);

            if ((u != 0) && (p != 0) && (MultiSave.Count > 0) )
            {
                UserDialogs.Instance.ShowSuccess(Traduzioni.Settings_SaveSetOk);
            }
            else {
                UserDialogs.Instance.ShowError(Traduzioni.Settings_SaveSetKo);
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

        /*Presa una lista di n valori ne salva uno o più in base al fatto che esistta, in quella lista, alemno un item con un valore valido. 
         * Se passo ip interno e ip esterno entrambi validi li salva entrambi, se passo uno valido e uno vuoto li salva entrambi.
         * Se ne passo uno valido e uno no (non inizia con http) salva solo il primo.
         * Se ne passo 2 invalidi o vuoti non salva nulla
         */
        public List<Settings> MultiValidateAndSave(List<Settings> dati)
        {
            List<Settings> Saved = new List<Settings>();
            List<Settings> lista = new List<Settings>(dati);
            lista.RemoveAll(item => string.IsNullOrWhiteSpace(item.SettingValue));
            var i = lista.Count;

            foreach (var item in dati)
            {
                bool iss = funzioniComuni.startWithHttp(item.SettingValue);
                var p = string.IsNullOrWhiteSpace(item.SettingValue);

                if ( (lista.Count > 0) && ( (funzioniComuni.startWithHttp(item.SettingValue)) || ( string.IsNullOrWhiteSpace(item.SettingValue)) ) )
                {
                    
                    var tmp = ManageData.getValue(item.SettingName);
                    if (tmp == null)
                    {
                        try
                        {
                            ManageData.InsertSettings(item);
                        }
                        catch (Exception e)
                        {
                            OpStatus = "" + e;
                        }
                    }
                    else
                    {
                        item.IdSetting = tmp.IdSetting;
                        ManageData.UpdateSettings(item);
                    }

                    Saved.Add(item);
                }
                else {

                }
            }


            //Se ho come ritorno solo un elemento verifico che non sia vuoto e in caso lo cancello. 
            /*Questo succede quando  faccio l'update dei due campi, di cui uno è vuoto e quello nuovamente inserrito è sbagliato (esemlio, scrivo htp invece che http)*/
            if (Saved.Count == 1)
            {
                Saved.RemoveAll(item => string.IsNullOrWhiteSpace(item.SettingValue));
            }

            return Saved;

        }


    }
}