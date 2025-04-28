using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TreeView_Example.TreeView.DataModel
{
    public class ApplicationToDisplay
    {
        public ApplicationToDisplay(string Name)
        {
            this.Name = Name;
        }

        /// <summary>
        /// Name of the application in the TreeView
        /// </summary>
        public string Name { get; set; }
    }
}
