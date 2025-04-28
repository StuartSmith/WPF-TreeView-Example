using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_TreeView_Example.TreeView.DataModel;

namespace WPF_TreeView_Example.TreeView.ViewModel
{
    public class ApplicationViewModel : TreeViewItemViewModel
    {
        readonly ApplicationToDisplay _ApplicationToDispay;

        public ApplicationViewModel(ApplicationToDisplay applicationToDisplay)
            : base(null, true)
        {
            _ApplicationToDispay = applicationToDisplay;
            base.IsExpanded = true;
        }

        public string ApplicationToDisplayName
        {
            get { return _ApplicationToDispay.Name; }
        }

        protected override void LoadChildren()
        {
            foreach (ActionToDisplay actionToDisplay in Controler.GetActions(_ApplicationToDispay))
                base.Children.Add(new ActionViewModel(actionToDisplay, this));
        }

        public void MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
