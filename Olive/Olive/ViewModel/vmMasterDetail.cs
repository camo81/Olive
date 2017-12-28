using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Olive.Model;

namespace Olive.ViewModel
{
    public class vmMasterDetail : ViewModelBase
    {


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

           
        public vmMasterDetail()
        {

        }

    }
}
