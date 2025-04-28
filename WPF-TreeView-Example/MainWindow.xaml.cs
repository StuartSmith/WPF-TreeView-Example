using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_TreeView_Example.TreeView.DataModel;

namespace WPF_TreeView_Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<ActionUI> ActionUIs = new List<ActionUI>();
        public MainWindow()
        {
            InitializeComponent();

            this.TreeViewTool.ActionToDisplayChanged = ChangeActionControl;


            ActionUIs.Add(new ActionUI() { ClassName = "UserControlUpgradeDatabase", uiElement = new UserControlUpradeDatabase.UserControlUpgradeDatabase() });
            ActionUIs.Add(new ActionUI() { ClassName = "UserControlManageUserAccounts", uiElement = new UserControlManageUserAccounts.UserControlManageUserAccounts() });
            ActionUIs.Add(new ActionUI() { ClassName = "UserControlManageUserRoles", uiElement = new UserControlManageUserRoles.UserControlManageUserRoles() });
        }


        public void ChangeActionControl(ActionToDisplay actionToDisplay)
        {
            this.ComponentGrid.Children.Clear();
            if (string.IsNullOrEmpty(actionToDisplay.ClassName))
                return;


            var Query = from actionUI in ActionUIs
                        where actionUI.ClassName == actionToDisplay.ClassName
                        select actionUI;

            if (Query.Count() == 0)
            {
                MessageBox.Show("Could not find Action UI for " + actionToDisplay.ClassName);
                throw new Exception(string.Format("Could not find  Class Name {0} in collection", actionToDisplay.ClassName));
            }


            this.ComponentGrid.Children.Add(Query.First().uiElement);

        }


    }
}

