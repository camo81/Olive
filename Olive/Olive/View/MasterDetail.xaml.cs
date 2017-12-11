﻿using System;

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
    }
}