using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using DDManagerSolution.Model;

namespace DDManagerSolution.ViewModel
{
    public class EncounterViewModel : Notify
    {
        #region Private

        private Encounter _encounter;

        #endregion

        #region Properties

        public DiceRollerViewModel DiceVMRef { get; }

        private EncounterCreatureViewModel _selectedCreature;
        public EncounterCreatureViewModel SelectedCreature
        {
            get { return _selectedCreature; }
            set
            {
                _selectedCreature = value;
                OnPropertyChanged("SelectedCreature");
            }
        }

        public ICommand DeleteSelectedCreature { get; set; }

        #endregion

        public EncounterViewModel(Encounter encounter)
        {
            _encounter = encounter;

            EncounterCreatures = new ObservableCollection<EncounterCreatureViewModel>();

            AddCreature = new RelayCommand(AddCreatureExecuted, AddCreatureCanExecute);
            DeleteSelectedCreature = new RelayCommand(DeleteSelectedCreatureExecuted, DeleteSelectedCreatureCanExecute);

            DiceVMRef = new DiceRollerViewModel(new DiceRoller());
        }

        private void DeleteSelectedCreatureExecuted(object parameter)
        {
            if (SelectedCreature == null)
                return;

            EncounterCreatures.Remove(SelectedCreature);

            SelectedCreature = (EncounterCreatures.Count > 0) ? EncounterCreatures[0] : null;
        }

        private bool DeleteSelectedCreatureCanExecute(object sender)
        {
            return true;
        }

        private void SortEncounterByInitiative()
        {

            List<EncounterCreatureViewModel> sorter = new List<EncounterCreatureViewModel>();

            sorter = EncounterCreatures.OrderByDescending(i => i.Initiative).ToList();

            EncounterCreatures.Clear();

            foreach (EncounterCreatureViewModel creature in sorter)
            {
                EncounterCreatures.Add(creature);
            }           
        }

        #region Properties

        public ICommand AddCreature { get; set; }

        private EncounterCreatureViewModel _creatureToAdd = new EncounterCreatureViewModel();
        public EncounterCreatureViewModel CreatureToAdd
        {
            get
            {
                return _creatureToAdd;
            }
            set
            {
                _creatureToAdd = value;
                OnPropertyChanged("CreatureToAdd");
            }
        }

        public ObservableCollection<EncounterCreatureViewModel> EncounterCreatures { get; }

        #endregion

        #region Handlers

        public void AddCreatureExecuted(object parameter)
        {
            EncounterCreatures.Add(CreatureToAdd);
            SortEncounterByInitiative();
            CreatureToAdd = new EncounterCreatureViewModel();
        }

        public bool AddCreatureCanExecute(object sender)
        {
            return true;
        }

        #endregion

    }
}
