using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Olive.Model;

using Xamarin.Forms;

namespace Olive
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //setto la lingua di default dell'applicazione
            System.Globalization.CultureInfo lingua = new System.Globalization.CultureInfo("en-GB");
            //cerco se esiste un file resource con quella lingua nella cartella model, se non lo trova pesca il default
            Traduzioni.Culture = lingua;
            
            ManageData.CreaDataBase();
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
