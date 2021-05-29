using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DDManagerSolution.Model;

namespace DDManagerSolution.ViewModel
{
    public class DiceRollerViewModel : Notify
    {
        private DiceRoller _roller;
        private int _rollAmount;

        #region Properties

        public ICommand RollFourSided { get; set; }
        public ICommand RollSixSided { get; set; }
        public ICommand RollEightSided { get; set; }
        public ICommand RollTenSided { get; set; }
        public ICommand RollTwelveSided { get; set; }
        public ICommand RollTwentySided { get; set; }
        public ICommand RollAll { get; set; }
       
        public string FourCount
        {
            get { return _roller.FourCount(); }
            set
            {
                _roller.FourCount(IntConversion(value));
                OnPropertyChanged("FourCount");
            }
        }

        public string SixCount
        {
            get { return _roller.SixCount(); }
            set
            {
                _roller.SixCount(IntConversion(value));
                OnPropertyChanged("SixCount");
            }
        }

        public string EightCount
        {
            get { return _roller.EightCount(); }
            set
            {
                _roller.EightCount(IntConversion(value));
                OnPropertyChanged("EightCount");
            }
        }

        public string TenCount
        {
            get { return _roller.TenCount(); }
            set
            {
                _roller.TenCount(IntConversion(value));
                OnPropertyChanged("TenCount");
            }
        }

        public string TwelveCount
        {
            get { return _roller.TwelveCount(); }
            set
            {
                _roller.TwelveCount(IntConversion(value));
                OnPropertyChanged("TwelveCount");
            }
        }

        public string TwentyCount
        {
            get { return _roller.TwentyCount(); }
            set
            {
                _roller.TwentyCount(IntConversion(value));
                OnPropertyChanged("TwentyCount");
            }
        }

        #endregion

        public DiceRollerViewModel(DiceRoller roller)
        {
            _roller = roller;

            // Initialize
            RollHistory = new ObservableCollection<string>();

            RollAll = new RelayCommand(RollDiceExecuted, RollDiceCanExecute);
        }

        private void UpdateHistory()
        {
            RollHistory.Clear();

            foreach (string s in _roller.ReturnRollHistory())
            {
                RollHistory.Add(s);
            }
        }

        #region Command Execution

        private void RollDiceExecuted(object parameter)
        {
            int param;

            if (!int.TryParse(parameter.ToString(), out param))
                return;

            switch (param)
            {
                case 0:
                    _roller.RollD4();
                    break;
                case 1:
                    _roller.RollD6();
                    break;
                case 2:
                    _roller.RollD8();
                    break;
                case 3:
                    _roller.RollD10();
                    break;
                case 4:
                    _roller.RollD12();
                    break;
                case 5:
                    _roller.RollD20();
                    break;
                default:
                    _roller.Roll();
                    break;
            }

            UpdateHistory();
        }

        private bool RollDiceCanExecute(object sender)
        {
            return true;
        }

        #endregion

        private int IntConversion(string value)
        {
            int conversion = 1;
            if (int.TryParse(value, out conversion))
                return conversion;

            return conversion;
        }

        public ObservableCollection<string> RollHistory { get; }

        public int RollAmount
        {
            get
            {
                return _rollAmount;
            }
            set
            {
                _rollAmount = value;
                OnPropertyChanged("RollAmount");
            }
        } 



    }
}
