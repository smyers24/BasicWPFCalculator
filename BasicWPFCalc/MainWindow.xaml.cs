using System.Windows;
using System.Windows.Controls;

namespace BasicWPFCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private long number1;
        private long number2;
        private string operation = string.Empty;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumericButton_Click(object sender, RoutedEventArgs e)

        {
            //Conversions are fun :)
            //No need to check if content is parseable or whatnot because this is a simple calculator app
            var buttonValue = int.Parse((sender as Button).Content.ToString());
            UpdateTextBox(buttonValue);
        }

        private void UpdateTextBox(int buttonValue)
        {
            if (string.IsNullOrEmpty(operation))
            {
                number1 = (number1 * 10) + buttonValue;
                TxtDisplay.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 * 10) + buttonValue;
                TxtDisplay.Text = number1.ToString();
            }
        }

        private void BtnOperator_Click(object sender, RoutedEventArgs e)
        {
            //Conversions are fun :)
            var buttonValue = (sender as Button).Content.ToString();
            UpdateOperator(buttonValue);
        }

        private void UpdateOperator(string @Operator)
        {
            operation = Operator;
            TxtDisplay.Text = Operator;
        }

        private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {
            //Maybe if/else is better but I like how this looks more
            //I've heard ~5 if/elses is where the overhead of switch is worth it
            switch (operation)
            {
                case "+":
                    TxtDisplay.Text = (number1 + number2).ToString();
                    break;

                case "-":
                    TxtDisplay.Text = (number1 - number2).ToString();
                    break;
                        
                case "*":
                    TxtDisplay.Text = (number1 * number2).ToString();
                    break;

                case "/":
                    TxtDisplay.Text = (number1 / number2).ToString();
                    break;
            }
        }

        private void BtnCE_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(operation))
            {
                number1 = 0;
                TxtDisplay.Text = "0";
            }
            else
            {
                number2 = 0;
            }

            TxtDisplay.Text = "0";
        }

        private void BtnC_Click(object sender, RoutedEventArgs e)
        {
            number1 = 0;
            number2 = 0;
            operation = string.Empty;
            TxtDisplay.Text = "0";
        }

        private void BtnBackspace_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(operation))
            {
                number1 /= 10;
                TxtDisplay.Text = number1.ToString();
            }
            else
            {
                number2 /= 10;
                TxtDisplay.Text = number2.ToString();
            }
        }

        private void BtnPositiveNegative_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(operation))
            {
                number1 *= -1;
                TxtDisplay.Text = number1.ToString();
            }
            else
            {
                number2 *= -1;
                TxtDisplay.Text = number2.ToString();
            }
        }
    }
}
