using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DDManagerSolution.Model;

namespace DDManagerSolution.ViewModel
{
    public class ReferenceViewModel : Notify
    {
        private Reference _reference;

        private Conditions _selectedCondition;
        public Conditions SelectedCondition
        {
            get { return _selectedCondition; }
            set
            {
                _selectedCondition = value;
                OnPropertyChanged("SelectedCondition");
            }
        }

        public ReferenceViewModel (Reference reference)
        {
            _reference = reference;
        }        
    }
}
