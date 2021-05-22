using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using DDManagerSolution.View;
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

            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(TextBoxBehavior).TypeHandle);
        }

        private void InitializeEngine()
        {
            _engine = new DDManagerViewModel();
        }
       
    }
}
