using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using DDManagerSolution.ViewModel;

using Conditions = DDManagerSolution.ViewModel.Conditions;

namespace DDManagerSolution.View
{
    public class ConditionTemplateSelector : DataTemplateSelector
    {
        public DataTemplate BlindedTemplate { get; set; }
        public DataTemplate CharmedTemplate { get; set; }
        public DataTemplate DeafenedTemplate { get; set; }
        public DataTemplate FrightenedTemplate { get; set; }
        public DataTemplate GrappledTemplate { get; set; }
        public DataTemplate IncapacitatedTemplate { get; set; }
        public DataTemplate InvisibleTemplate { get; set; }
        public DataTemplate ParalyzedTemplate { get; set; }
        public DataTemplate PetrifiedTemplate { get; set; }
        public DataTemplate PoisonedTemplate { get; set; }
        public DataTemplate ProneTemplate { get; set; }
        public DataTemplate RestrainedTemplate { get; set; }
        public DataTemplate StunnedTemplate { get; set; }
        public DataTemplate UnconsciousTemplate { get; set; }
        public DataTemplate ExhaustionTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null)
                return null;

            Conditions condition = (Conditions)item;

            switch(condition)
            {
                case Conditions.Blinded:
                    return BlindedTemplate;
                case Conditions.Charmed:
                    return CharmedTemplate;
                case Conditions.Deafened:
                    return DeafenedTemplate;
                case Conditions.Frightened:
                    return FrightenedTemplate;
                case Conditions.Grappled:
                    return GrappledTemplate;
                case Conditions.Incapacitated:
                    return IncapacitatedTemplate;
                case Conditions.Invisible:
                    return InvisibleTemplate;
                case Conditions.Paralyzed:
                    return ParalyzedTemplate;
                case Conditions.Petrified:
                    return PetrifiedTemplate;
                case Conditions.Poisoned:
                    return PoisonedTemplate;
                case Conditions.Prone:
                    return ProneTemplate;
                case Conditions.Restrained:
                    return RestrainedTemplate;
                case Conditions.Stunned:
                    return StunnedTemplate;
                case Conditions.Unconscious:
                    return UnconsciousTemplate;
                case Conditions.Exhaustion:
                    return ExhaustionTemplate;
            }

            return null;
        }
    }
}
