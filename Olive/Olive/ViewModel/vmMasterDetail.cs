using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Olive.Model;
using Olive.View;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace Olive.ViewModel
{
    public class vmMasterDetail : ViewModelBase
    {

        #region binding
        public String menumain = Traduzioni.MasterMain;
        public String MenuMain
        {
            get { return menumain; }
            set
            {
                menumain = value;
                Set(nameof(MenuMain), ref value);
            }
        }

        public String menusettings = Traduzioni.MasterSettings;
        public String MenuSettings
        {
            get { return menusettings; }
            set
            {
                menusettings = value;
                Set(nameof(MenuSettings), ref value);
            }
        }

        public String menulang = Traduzioni.MasterLanguage;
        public String MenuLang
        {
            get { return menulang; }
            set
            {
                menulang = value;
                Set(nameof(MenuLang), ref value);
            }
        }

        public String menuabout = Traduzioni.MasterAbout;
        public String MenuAbout
        {
            get { return menuabout; }
            set
            {
                menuabout = value;
                Set(nameof(MenuAbout), ref value);
            }
        }

        private HomePage mainpage = new HomePage();
        public HomePage mainPage
        {
            get { return mainpage; }
            set
            {
                mainpage = value;
                Set(nameof(mainPage), ref value);
            }
        }

        private SettingsPage settingspage = new SettingsPage();
        public SettingsPage settingsPage
        {
            get { return settingspage; }
            set
            {
                settingspage = value;
                Set(nameof(settingsPage), ref value);
            }
        }

        private LangSettings languagepage = new LangSettings();
        public LangSettings languagePage
        {
            get { return languagepage; }
            set
            {
                languagepage = value;
                Set(nameof(languagePage), ref value);
            }
        }

        public ICommand gotoPage
        {
            get
            {

                return new RelayCommand<Page>((page) => {

                    //get type of object passed
                    Type t = page.GetType();
                    //create a new instance of obj                    
                    page = Activator.CreateInstance(t) as Page;
                    FunzioniComuni.funzioniComuni.changePage(page);
                });
            }


        }

        #endregion
        public vmMasterDetail(MasterDetailPage current)
        {

            Page page = new Page();
            page = new HomePage();
            current.Detail = new NavigationPage(page);

        }

    }
}
