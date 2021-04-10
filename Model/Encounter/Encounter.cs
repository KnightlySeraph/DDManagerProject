using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDManagerSolution.Model
{
    public class Encounter
    {
        private List<EncounterCreature> _creatures = new List<EncounterCreature>();

        public Encounter()
        {

        }

        public EncounterCreature InitializeNewCreature()
        {
            return new EncounterCreature();
        }
    }
}
