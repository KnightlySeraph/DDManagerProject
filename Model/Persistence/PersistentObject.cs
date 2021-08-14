using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDManagerSolution.Model
{
    public abstract class PersistentObject
    {
        public abstract void SerializeData();
        public abstract void UnserializeData();
    }
}
