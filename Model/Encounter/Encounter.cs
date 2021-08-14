using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DDManagerSolution.Model
{
    [DataContract(Name = "Encounter")]
    public class Encounter
    {
        [DataMember()]
        private List<EncounterCreature> _creatures = new List<EncounterCreature>();

        public List<EncounterCreature> Creatures
        {
            get
            {
                return _creatures;
            }
        }

        public Encounter()
        {

        }

        public void AddCreature(EncounterCreature creature)
        {
            _creatures.Add(creature);
        }

        public EncounterCreature InitializeNewCreature()
        {
            return new EncounterCreature();
        }

        

        public void SaveEncounter()
        {
            Persistence.SaveEncounter(this);
        }

        public void LoadEncounter()
        {
            Persistence.LoadEncounter();
        }      
    }
}
