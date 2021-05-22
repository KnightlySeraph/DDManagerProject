using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DDManagerSolution.View
{
    public static class TextBoxBehavior
    {
        static TextBoxBehavior()
        {
            EventManager.RegisterClassHandler(typeof(TextBox), TextBox.GotFocusEvent, new RoutedEventHandler(FocusedEventHandler));
        }

        static void FocusedEventHandler(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == null)
                return;

            tb.Dispatcher.BeginInvoke(new Action(() => tb.SelectAll()));
        }       
    }
}
