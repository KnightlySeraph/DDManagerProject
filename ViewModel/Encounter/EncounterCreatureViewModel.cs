using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DDManagerSolution.Model;

namespace DDManagerSolution.ViewModel
{
    public class EncounterCreatureViewModel : Notify
    {
        private Model.EncounterCreature _encounterCreature;

        public EncounterCreatureViewModel()
        {
            _encounterCreature = new EncounterCreature();
        }
        public EncounterCreatureViewModel(Model.EncounterCreature encounterCreature)
        {
            _encounterCreature = encounterCreature;
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

        public int HitPoints
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


        #endregion

    }
}
