using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_TreeView_Example.TreeView.DataModel;

namespace WPF_TreeView_Example.TreeView.ViewModel
{
    public class TopNodeViewModel
    {
        readonly ReadOnlyCollection<ApplicationViewModel> _ApplicationsToDisplayViewModel;

        public TopNodeViewModel(ApplicationToDisplay[] ApplicationsToDisplay)
        {
            _ApplicationsToDisplayViewModel = new ReadOnlyCollection<ApplicationViewModel>(
                (from applicationToDisplay in ApplicationsToDisplay
                 select new ApplicationViewModel(applicationToDisplay))
                .ToList());
        }

        public ReadOnlyCollection<ApplicationViewModel> ApplicationsToDisplay
        {
            get { return _ApplicationsToDisplayViewModel; }
        }
    }
}
