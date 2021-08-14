using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DDManagerSolution.Model
{
    [DataContract(Name ="EncounterCreature")]
    public class EncounterCreature
    {
        [DataMember()]
        private string _creatureName;
        [DataMember()]
        private string _hitPoints;
        [DataMember()]
        private int _armorClass;
        [DataMember()]
        private int _initiative;
        [DataMember()]
        private string _notes;

        private List<string> _conditions;

        public EncounterCreature()
        {
            _creatureName = "Unnamed Creature";
            _hitPoints = "0";
            _armorClass = 10;
            _initiative = 10;
        }

        public void CreatureName(string creatureName)
        {
            _creatureName = creatureName;
        }

        public string CreatureName()
        {
            return _creatureName;
        }

        public void HitPoints(string hitPoints)
        {
            _hitPoints = hitPoints;
        }

        public string HitPoints()
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

        public void Initiative(int initiative)
        {
            _initiative = initiative;
        }

        public int Initiative()
        {
            return _initiative;
        }

        public void Notes(string notes)
        {
            _notes = notes;
        }

        public string Notes()
        {
            return _notes;
        }

        public void CalculateHitPointExpression()
        {
            _hitPoints = StringMath.CalculateFromExpression(_hitPoints);
        }
    }
}
