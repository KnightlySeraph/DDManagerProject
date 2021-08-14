using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDManagerSolution.Model
{
    public static class DDManager
    {
        public static Screen InitializeNewScreen()
        {
            return new Screen();
        }

        public static Encounter InitializeNewEncounter()
        {
            return new Encounter();
        }

        public static Reference InitializeNewReference()
        {
            return new Reference();
        }

        public static void Shutdown()
        {
            App.Current.Shutdown();
        }
    }
}
