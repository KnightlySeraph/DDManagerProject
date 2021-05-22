using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDManagerSolution.Model
{
   public class DiceRoller
    {
        #region Local Data

        private int _fourCount;
        private int _sixCount;
        private int _eightCount;
        private int _tenCount;
        private int _twelveCount;
        private int _twentyCount;

        List<string> _rollHistory = new List<string>();

        #endregion

        public DiceRoller()
        {

        }

        public List<string> ReturnRollHistory()
        {
            return _rollHistory;
        }

        #region Getter/Setter Region

        public string FourCount()
        {
            return _fourCount.ToString();
        }

        public void FourCount(int value)
        {
            _fourCount = value;
        }

        public string SixCount()
        {
            return _sixCount.ToString();
        }

        public void SixCount(int value)
        {
            _sixCount = value;
        }

        public string EightCount()
        {
            return _eightCount.ToString();
        }

        public void EightCount(int value)
        {
            _eightCount = value;
        }

        public string TenCount()
        {
            return _tenCount.ToString();
        }

        public void TenCount(int value)
        {
            _tenCount = value;
        }

        public string TwelveCount()
        {
            return _twelveCount.ToString();
        }

        public void TwelveCount(int value)
        {
            _twelveCount = value;
        }

        public string TwentyCount()
        {
            return _twentyCount.ToString();
        }

        public void TwentyCount(int value)
        {
            _twentyCount = value;
        }

        #endregion

        public int RollD4()
        {
            int total = 0;
            string historyItem = "";
            for (int i = 0; i < _fourCount; i++)
            {
                int dieRoll = DiceMath.RollDie(4);

                if (i + 1 == _fourCount)
                    historyItem += dieRoll + " = ";
                else
                    historyItem += dieRoll + " + ";


                total += dieRoll;
            }

            historyItem += total;
            _rollHistory.Add(historyItem);

            return total;
        }

        public int Roll()
        {
            return 0;
        }
    }
}
