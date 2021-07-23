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

namespace DDManagerSolution.View
{
    /// <summary>
    /// Interaction logic for _5eRichTextBox.xaml
    /// </summary>
    public partial class RichTextBox5E : UserControl
    {

        public RichTextBox5E()
        {
            InitializeComponent();

            this.Loaded += (s, e) =>
            {
                RTB.Document.PageWidth = this.ActualWidth;
            };
        }

        private void RichTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            RichTextBox rtb = sender as RichTextBox;
            if (rtb == null)
                return;

            string inputText = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd).Text;

            string[] tokens = inputText.Split(' ');

            List<TextBlock> blocks = new List<TextBlock>();

            rtb.Document.Blocks.Clear();

            foreach(string t in tokens)
            {
                if (MatchTokenToCondition(t.Trim()))
                {
                    LinkedTextblock ltb = new LinkedTextblock();
                    ltb.Text = t;
                    rtb.Document.Blocks.Add(new BlockUIContainer(ltb));
                }
                else
                {
                    rtb.Document.Blocks.Add(new Paragraph(new Run(t)));
                }
            }
        }

        private bool MatchTokenToCondition(string value)
        {
            return Enum.IsDefined(typeof(Conditions), value);
        }
    }
}
