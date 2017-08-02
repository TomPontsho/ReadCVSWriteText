using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ReadCVSWriteText.Views {
    /// <summary>
    /// A textbox that does not allow charactors that can not be used to name a file/directory
    /// </summary>
    public class NamingTextBox : TextBox {

        static NamingTextBox() {
            invalidCharactersProperty = DependencyProperty.Register(
                  nameof(invalidCharacters), typeof(string), typeof(NamingTextBox), new PropertyMetadata(""));
        }

        public NamingTextBox() {

            TextChanged += onTextChanged;
        }

        private bool isCallFromOneSelf = false;
        private void onTextChanged(object sender, TextChangedEventArgs e) {

            if (isCallFromOneSelf)
                return;

            NamingTextBox tb = sender as NamingTextBox;
            if (!string.IsNullOrEmpty(tb.Text) && !string.IsNullOrEmpty(invalidCharacters)) {

                int cursorPos = tb.CaretIndex;
                int lengthB4Regex = tb.Text.Length;

                isCallFromOneSelf = true;
                tb.Text = Regex.Replace(tb.Text, "[" + invalidCharacters + "]", "");

                if (cursorPos <= 0)
                    tb.CaretIndex = 0;
                else if (cursorPos >= tb.Text.Length + 1)
                    tb.CaretIndex = tb.Text.Length;
                else {

                    if (lengthB4Regex == tb.Text.Length)
                        tb.CaretIndex = cursorPos;
                    else
                        tb.CaretIndex = cursorPos - 1;
                }

            }
            isCallFromOneSelf = false;

        }

        public static readonly DependencyProperty invalidCharactersProperty;
        public string invalidCharacters {
            get { return (string)GetValue(invalidCharactersProperty); }
            set { SetValue(invalidCharactersProperty, value); }
        }
    }
}
