using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDManagerSolution.Model
{
    public class EncounterCreature
    {
        private string _creatureName;
        private int _hitPoints;
        private int _armorClass;
        private string _notes;
        private List<string> _conditions;

        public EncounterCreature()
        {

        }

        public void CreatureName(string creatureName)
        {
            _creatureName = creatureName;
        }

        public string CreatureName()
        {
            return _creatureName;
        }

        public void HitPoints(int hitPoints)
        {
            _hitPoints = hitPoints;
        }

        public int HitPoints()
        {
            return _hitPoints;
        }

        public void ArmorClass(int armorClass)
        {
            _armorClass = armorClass;
        }

        public int ArmorClass()
        {
            return _armorClass;
        }

        public void Notes(string notes)
        {
            _notes = notes;
        }

        public string Notes()
        {
            return _notes;
        }
    }
}
