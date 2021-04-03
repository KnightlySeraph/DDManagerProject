using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

using DDManagerSolution.Model;
using System.ComponentModel;

namespace DDManagerSolution.ViewModel
{
    public class DDManagerViewModel : INotifyPropertyChanged
    {

        #region Properties

        public ICommand AddWorkspace { get; set; }

        public ObservableCollection<ScreenViewModel> Screens { get; set; }

        private object _selectedScreen;
        public object SelectedScreen
        {
            get
            {
                return _selectedScreen;
            }
            set
            {
                _selectedScreen = value;
                OnPropertyChanged("SelectedScreen");
            }
        }

        private bool _hasScreens;
        public bool HasScreens
        {
            get
            {
                return _hasScreens;
            }
            set
            {
                _hasScreens = value;
                OnPropertyChanged("HasScreens");
            }
        }

        #endregion

        public DDManagerViewModel()
        {
            AddWorkspace = new RelayCommand(AddWorkspaceExecuted, AddWorkspaceCanExecute);

            Screens = new ObservableCollection<ScreenViewModel>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Event Handlers

        private void AddWorkspaceExecuted(object parameter)
        {
            Screens.Add(new ScreenViewModel(DDManager.InitializeNewScreen()));
            HasScreens = true;
        }

        private bool AddWorkspaceCanExecute(object sender)
        {
            return true;
        }

        #endregion
    }
}
