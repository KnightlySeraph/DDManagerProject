using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DDManagerSolution.Model;

namespace DDManagerSolution.ViewModel
{
    public class ScreenViewModel : Notify
    {
        private Screen _screen;

        public ScreenViewModel(Screen screen)
        {
            _screen = screen;
            CreateEncounter = new RelayCommand(CreateNewEncounterExecuted, CreateNewEncounterCanExecute);
        }

        #region Properties

        public ICommand CreateEncounter { get; set; }

        private object _screenContext;
        public object ScreenContext
        {
            get
            {
                return _screenContext;
            }
            set
            {
                _screenContext = value;
                OnPropertyChanged("ScreenContext");
            }
        }

        private bool _hasContent;
        public bool HasContent
        {
            get
            {
                return _hasContent;
            }
            set
            {
                _hasContent = value;
                OnPropertyChanged("HasContent");
            }
        }

        public string ScreenName
        {
            get { return _screen.ScreenName(); }
            set
            {
                _screen.ScreenName(value);
                OnPropertyChanged("ScreenName");
            }
        }

        #endregion

        #region Commands

        private void CreateNewEncounterExecuted(object parameter)
        {
            ScreenContext = new EncounterViewModel(DDManager.InitializeNewEncounter());
            HasContent = true;
        }

        private bool CreateNewEncounterCanExecute(object sender)
        {
            return ScreenContext == null;
        }

        #endregion
    }
}
