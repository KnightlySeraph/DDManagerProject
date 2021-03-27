using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using DDManagerSolution.ViewModel;

namespace DDManagerSolution
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private DDManagerViewModel _engine;
        public DDManagerViewModel Engine
        {
            get
            {
                return _engine;
            }
        }        

        public App()
        {
            InitializeEngine();
        }

        private void InitializeEngine()
        {
            _engine = new DDManagerViewModel();
        }
    }
}
