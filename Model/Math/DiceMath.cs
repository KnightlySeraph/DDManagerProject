using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDManagerSolution.Model
{
    public static class DiceMath
    {
        private static Random _dieEngine = new Random();

        public static int RollDie(int die)
        {
            return _dieEngine.Next(die) + 1;
        }

        public static int Roll20()
        {
            return _dieEngine.Next(20) + 1;
        }
    }
}
