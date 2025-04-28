using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_TreeView_Example.TreeView.DataModel;

namespace WPF_TreeView_Example.TreeView.ViewModel
{
    public class ActionViewModel : TreeViewItemViewModel
    {
        readonly ActionToDisplay _actionToDisplay;

        public ActionToDisplay TheAction { get { return _actionToDisplay; } }

        public ActionViewModel(ActionToDisplay actionToDisplay, ApplicationViewModel appViewModel)
            : base(appViewModel, true)
        {
            _actionToDisplay = actionToDisplay;
            base.IsExpanded = true;
        }

        public string ActionToDisplayName
        {
            get { return _actionToDisplay.Name; }
        }
    }
}
