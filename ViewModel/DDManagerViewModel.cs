using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

using DDManagerSolution.Model;
using DDManagerSolution.View;
using System.ComponentModel;

namespace DDManagerSolution.ViewModel
{
    public class DDManagerViewModel : INotifyPropertyChanged
    {

        #region Properties

        public ICommand AddWorkspace { get; set; }

        public ICommand NewDieWindow { get; set; }   
        
        public ICommand CloseSelectedWorkspace { get; set; }

        public ObservableCollection<ScreenViewModel> Screens { get; set; }

        private ScreenViewModel _selectedScreen;
        public ScreenViewModel SelectedScreen
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
            #region Command Init

            AddWorkspace = new RelayCommand(AddWorkspaceExecuted, AddWorkspaceCanExecute);

            NewDieWindow = new RelayCommand(NewDieWindowExecuted, NewDieWindowCanExecute);

            CloseSelectedWorkspace = new RelayCommand(CloseSelectedWorkspaceExcuted, CloseSelectedWorkspaceCanExecute);

            #endregion

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

            if (parameter is null)
                return;

            if ((ScreenTypes)parameter == ScreenTypes.Encounter)
            {
                ScreenViewModel screenVMRef = Screens[Screens.Count - 1];
                screenVMRef.CreateEncounter.Execute(null);
            }           
        }

        private bool AddWorkspaceCanExecute(object sender)
        {
            return true;
        }

        private void CloseSelectedWorkspaceExcuted(object parameter)
        {
            if (SelectedScreen == null)
                return;

            Screens.Remove(SelectedScreen);

            SelectedScreen = (Screens.Count > 0) ? Screens[0] : null;

            HasScreens = Screens.Count > 0;
        }

        private bool CloseSelectedWorkspaceCanExecute(object sender)
        {
            return true;
        }

        private void NewDieWindowExecuted(object parameter)
        {
            DiceRollerWindow diceRoller = new DiceRollerWindow();
            diceRoller.DataContext = new DiceRollerViewModel(new DiceRoller());

            diceRoller.Show();
        }

        private bool NewDieWindowCanExecute(object sender)
        {
            return true;
        }

        #endregion
    }
}
