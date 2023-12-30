using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace QuanLyChiTieu.Behavior
{
    public class DecimalInputBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PreviewTextInput += PreviewTextInput;
            DataObject.AddPastingHandler(AssociatedObject, Pasting);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PreviewTextInput -= PreviewTextInput;
            DataObject.RemovePastingHandler(AssociatedObject, Pasting);
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var proposedText = AssociatedObject.Text.Insert(AssociatedObject.SelectionStart, e.Text);
            decimal m;
            e.Handled = !decimal.TryParse(proposedText, out m);
        }

        private void Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private Boolean IsTextAllowed(String text)
        {
            return Array.TrueForAll<Char>(text.ToCharArray(), delegate (Char c) { return Char.IsDigit(c) || Char.IsControl(c); });
        }
    }

}
