using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DDManagerSolution.Model;

namespace DDManagerSolution.ViewModel
{
    public class EncounterCreatureViewModel : Notify
    {
        private Model.EncounterCreature _encounterCreature;

        public EncounterCreatureViewModel()
        {
            _encounterCreature = new EncounterCreature();
            Initialize();
        }
        public EncounterCreatureViewModel(Model.EncounterCreature encounterCreature)
        {
            _encounterCreature = encounterCreature;
            Initialize();
        }

        public EncounterCreature GetCreature()
        {
            return _encounterCreature;
        }

        #region Properties

        public string CreatureName
        {
            get
            {
                return _encounterCreature.CreatureName();
            }
            set
            {
                _encounterCreature.CreatureName(value);
                OnPropertyChanged("CreatureName");
            }
        }

        public string HitPoints
        {
            get
            {
                return _encounterCreature.HitPoints();
            }
            set
            {
                _encounterCreature.HitPoints(value);
                OnPropertyChanged("HitPoints");
            }
        }

        public int ArmorClass
        {
            get
            {
                return _encounterCreature.ArmorClass();
            }
            set
            {
                _encounterCreature.ArmorClass(value);
                OnPropertyChanged("ArmorClass");
            }
        }

        public string Notes
        {
            get
            {
                return _encounterCreature.Notes();
            }
            set
            {
                _encounterCreature.Notes(value);
                OnPropertyChanged("Notes");
            }
        }

        public int Initiative
        {
            get
            {
                return _encounterCreature.Initiative();
            }
            set
            {
                _encounterCreature.Initiative(value);
                OnPropertyChanged("Initiative");
            }
        }

        public ICommand EvaluateHitPointExpression { get; set; }

        #endregion

        #region Methods

        private void Initialize()
        {
            EvaluateHitPointExpression = new RelayCommand(EvaluateExpressionExecuted, EvaluateExpressionCanExecute);
        }

        private bool EvaluateExpressionCanExecute(object sender)
        {
            return true;
        }

        private void EvaluateExpressionExecuted(object sender)
        {
            _encounterCreature.CalculateHitPointExpression();
            OnPropertyChanged("HitPoints");
        }

        #endregion

    }
}
