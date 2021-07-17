using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DDManagerSolution.View
{
    public class LinkedTextblock : TextBlock
    {
        public ContentControl LinkedContent
        {
            get { return (ContentControl)GetValue(LinkedContentProperty); }
            set { SetValue(LinkedContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LinkedContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LinkedContentProperty =
            DependencyProperty.Register("LinkedContent", typeof(ContentControl), typeof(LinkedTextblock), new PropertyMetadata(null));

    }
}
