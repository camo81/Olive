using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Olive.Model;
using Xamarin.Forms;
using Acr.UserDialogs;

namespace Olive
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            ManageData.CreaDataBase();            
            //setto la lingua di default dell'applicazione
            var currentLang = ManageData.getLang();
            System.Globalization.CultureInfo lingua;
            if (currentLang == null)
            {
                lingua = new System.Globalization.CultureInfo("en-GB");
            }
            else {
                lingua = new System.Globalization.CultureInfo(currentLang.LangCode);
            }

            //cerca nei file di traduzione una con il culture info specificato, se non lo trova carica il default senza culture info
            Traduzioni.Culture = lingua;
            MainPage = new View.MasterDetail();


        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

