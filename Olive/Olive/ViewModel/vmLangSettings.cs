using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Olive.Model;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Olive.ViewModel
{
    public class vmLangSettings : ViewModelBase
    {

        #region binding
        public String langset = "";
        public String LangSet
        {
            get { return langset; }
            set
            {
                langset = value;
                Set(nameof(LangSet), ref value);
           
            }
        }

        IList<Lingue> lingue;
        public IList<Lingue> Lingue {
            get { return lingue; }
            set { lingue = value;
                Set(nameof(Lingue), ref value);
            }
        }

        public Lingue langselected;
        public Lingue LangSelected {
            get { return langselected; }
            set
            {
                langselected = value;
                Set(nameof(LangSelected), ref value);
            }

        }

        public ICommand SaveLanguage
        {
            get
            {
                return new RelayCommand(() => { SaveLang(); });
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
        #endregion

        public vmLangSettings()
        {

            this.Lingue = new List<Lingue>();
            Lingue.Add(new Lingue { langCode = "en-GB", languageName = "English" });
            Lingue.Add(new Lingue { langCode = "it-IT", languageName = "Italian" });

            var i = ManageData.getLang();
            OpStatus = "--->:"+i.LanguageName;

        }

        public bool SaveLang() {

            var lingua = new Language();
            lingua.LangCode = LangSelected.langCode;
            lingua.LanguageName = LangSelected.languageName;
            var op = 0;
            ManageData.delLanguage();
            try
            {
                op = ManageData.InsertLanguage(lingua);
            }
            catch (Exception)
            {

                throw;
            }


            //OpStatus = ""+op;

            
/*
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
            }*/


            return true;
        }
    }
}
