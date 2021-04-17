using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using DDManagerSolution.ViewModel;

namespace DDManagerSolution.View
{
    /// <summary>
    /// Interaction logic for CreatureView.xaml
    /// </summary>
    public partial class CreatureView : UserControl
    {
        public CreatureView()
        {
            InitializeComponent();
        }

        public EncounterCreatureViewModel Creature
        {
            get
            {
                return this.DataContext as EncounterCreatureViewModel;
            }
        }

        #region Dependency Properties

        public string CreatureName
        {
            get { return (string)GetValue(CreatureNameProperty); }
            set { SetValue(CreatureNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreatureName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreatureNameProperty =
            DependencyProperty.Register("CreatureName", typeof(string), typeof(CreatureView), new PropertyMetadata(string.Empty));

        public int ArmorClass
        {
            get { return (int)GetValue(ArmorClassProperty); }
            set { SetValue(ArmorClassProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ArmorClass.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ArmorClassProperty =
            DependencyProperty.Register("ArmorClass", typeof(int), typeof(CreatureView), new PropertyMetadata(0));

        public string HitPoints
        {
            get { return (string)GetValue(HitPointsProperty); }
            set { SetValue(HitPointsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HitPoints.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HitPointsProperty =
            DependencyProperty.Register("HitPoints", typeof(string), typeof(CreatureView), new PropertyMetadata(string.Empty));

        public int Initiative
        {
            get { return (int)GetValue(InitiativeProperty); }
            set { SetValue(InitiativeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Initiative.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InitiativeProperty =
            DependencyProperty.Register("Initiative", typeof(int), typeof(CreatureView), new PropertyMetadata(0));

        #endregion

        private void CalculateExpression(object sender, KeyEventArgs e)
        {
            if (Creature == null)
                return;

            if (Keyboard.IsKeyDown(Key.Enter))
            {
                Creature.EvaluateHitPointExpression.Execute(null);
            }
        }
    }
}
