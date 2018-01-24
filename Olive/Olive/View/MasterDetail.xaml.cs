using System;

using Xamarin.Forms;

namespace Olive.View
{
    public partial class MasterDetail : MasterDetailPage
    {
        public MasterDetail()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.vmMasterDetail(this);
        }

    }
}
