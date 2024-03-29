﻿using System;
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

        public ICommand CloseApplication { get; set; }

        public ICommand SaveWorkspace { get; set; }

        public ICommand LoadWorkspace { get; set; }

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

            CloseApplication = new RelayCommand(CloseApplicationExecuted, CloseApplicationCanExecute);

            SaveWorkspace = new RelayCommand(SaveWorkspaceExecuted, SaveWorkspaceCanExecute);

            LoadWorkspace = new RelayCommand(LoadWorkspaceExecuted, LoadWorkspaceCanExecute);

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
            
            if ((ScreenTypes)parameter == ScreenTypes.Reference)
            {
                ScreenViewModel screenVMRef = Screens[Screens.Count - 1];
                screenVMRef.CreateReference.Execute(null);
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

        private void CloseApplicationExecuted(object parameter)
        {
            DDManager.Shutdown();
        }

        private bool CloseApplicationCanExecute(object sender)
        {
            return true;
        }

        private void SaveWorkspaceExecuted(object parameter)
        {
            if (SelectedScreen.ScreenContext.GetType() == typeof(EncounterViewModel))
            {
                (SelectedScreen.ScreenContext as EncounterViewModel).SaveEncounter.Execute(null);
            }
        }

        private bool SaveWorkspaceCanExecute(object sender)
        {
            return true;
        }

        private void LoadWorkspaceExecuted(object parameter)
        {
            Screens.Add(new ScreenViewModel(DDManager.InitializeNewScreen()));
            Screens[Screens.Count - 1].ScreenContext = new EncounterViewModel(Persistence.LoadEncounter());
            Screens[Screens.Count - 1].HasContent = true;
            HasScreens = true;
            SelectedScreen = Screens[Screens.Count - 1];
        }

        private bool LoadWorkspaceCanExecute(object sender)
        {
            return true;
        }

        #endregion
    }
}
