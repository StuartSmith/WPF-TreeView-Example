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
using WPF_TreeView_Example.TreeView.ViewModel;

namespace WPF_TreeView_Example.TreeView
{
    /// <summary>
    /// Interaction logic for ApplicationTreeViewControl.xaml
    /// </summary>
    public partial class ApplicationTreeViewControl : UserControl
    {
        public Action<ActionToDisplay> ActionToDisplayChanged;

        public ApplicationTreeViewControl()
        {
            InitializeComponent();

            ApplicationToDisplay[] ApplicationsToDisplay = Controler.GetApplications().ToArray();
            TopNodeViewModel viewModel = new TopNodeViewModel(ApplicationsToDisplay);

            base.DataContext = viewModel;
        }

        private void OnTreeNodeDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (sender is HeaderedItemsControl && (((HeaderedItemsControl)sender).HasHeader == true))
            {

            }
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

            System.Windows.Controls.TreeView myTreeView = sender as System.Windows.Controls.TreeView;
            object o = myTreeView.SelectedItem;
            if (myTreeView.SelectedItem is ActionViewModel)
            {

                ActionViewModel MyActionViewModel = (ActionViewModel)myTreeView.SelectedItem;
                if (ActionToDisplayChanged != null)
                {
                    ActionToDisplayChanged(MyActionViewModel.TheAction);
                }
            }

        }


    }
}
