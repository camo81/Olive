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

        public string pickertitle = Traduzioni.Language_pickerTitle;
        public string pickerTitle
        {
            get { return pickertitle; }
            set
            {
                pickertitle = value;
                Set(nameof(pickerTitle), ref value);
            }

        }

        public string savebutton = Traduzioni.Language_save;
        public string saveButton
        {
            get { return savebutton; }
            set
            {
                savebutton = value;
                Set(nameof(saveButton), ref value);
            }

        }
        #endregion


        public vmLangSettings()
        {
            this.Lingue = new List<Lingue>();
            Lingue.Add(new Lingue { langCode = "en-GB", languageName = "English" });
            Lingue.Add(new Lingue { langCode = "it-IT", languageName = "Italian" });

            try
            {
                var i = ManageData.getLang();
                LangSelected = Lingue.Where(x => x.langCode == i.LangCode).FirstOrDefault();
            }
            catch (Exception e)
            {
                //OpStatus = "Not set" + e;

            }


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
                Acr.UserDialogs.UserDialogs.Instance.ShowSuccess("");
                var linguaCorrente = new System.Globalization.CultureInfo(lingua.LangCode);
                Traduzioni.Culture = linguaCorrente;
            }
            catch (Exception e)
            {

                
            }

            return true;
        }


    }
}
