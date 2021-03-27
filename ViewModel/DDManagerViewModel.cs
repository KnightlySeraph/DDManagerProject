using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DDManagerSolution.ViewModel
{
    public class DDManagerViewModel
    {

        #region Properties

        public ICommand AddWorkspace { get; set; }

        #endregion

        public DDManagerViewModel()
        {
            AddWorkspace = new RelayCommand(AddWorkspaceExecuted, AddWorkspaceCanExecute);
        }

        #region Event Handlers

        private void AddWorkspaceExecuted(object parameter)
        {
            Console.WriteLine("Command Binding was Successful!");
        }

        private bool AddWorkspaceCanExecute(object sender)
        {
            return true;
        }

        #endregion
    }
}
