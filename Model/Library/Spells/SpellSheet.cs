using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDManagerSolution.Model
{
    public class SpellSheet
    {
        public SpellSheet(bool generateNewCollections = true)
        {
            if (generateNewCollections)
                _initializeSpellCollections();
        }

        private void _initializeSpellCollections()
        {
            _cantrips       = new List<Spell>();
            _first          = new List<Spell>();
            _second         = new List<Spell>();
            _third          = new List<Spell>();
            _fourth         = new List<Spell>();
            _fifth          = new List<Spell>();
            _sixth          = new List<Spell>();
            _seventh        = new List<Spell>();
            _eightth        = new List<Spell>();
            _ninth          = new List<Spell>();
        }

        private List<Spell> _cantrips;
        private List<Spell> _first;
        private List<Spell> _second;
        private List<Spell> _third;
        private List<Spell> _fourth;
        private List<Spell> _fifth;
        private List<Spell> _sixth;
        private List<Spell> _seventh;
        private List<Spell> _eightth;
        private List<Spell> _ninth;
    }
}
