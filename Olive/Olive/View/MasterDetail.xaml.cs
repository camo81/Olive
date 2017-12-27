using System;

using Xamarin.Forms;

namespace Olive.View
{
    public partial class MasterDetail : MasterDetailPage
    {
        public MasterDetail()
        {
            InitializeComponent();
            Detail = new NavigationPage(new HomePage());
        }

        void MenuHomePage(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new HomePage());
            IsPresented = false;
        }

        void MenuSettings(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Settings());
            IsPresented = false;
        }

        void MenuLanguage(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new LangSettings());
            IsPresented = false;
        }
        void MenuAbout(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new About());
            IsPresented = false;
        }
    }
}
