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

namespace Calculator
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Methods
            private void CalculateButton_Click(object sender, RoutedEventArgs e)
            {
                double num1, num2, result = 0;
                string operation;
                string calculationDetails = "";

                // Error Handling for Number Parsing
                if (!double.TryParse(FirstNumberTextBox.Text, out num1))
                {
                    MessageBox.Show("Please enter a valid first number.");
                    return;
                }

                if (!double.TryParse(SecondNumberTextBox.Text, out num2))
                {
                    MessageBox.Show("Please enter a valid second number.");
                    return;
                }

                // Error Handling for Operation Selection
                if (OperationComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select an operation.");
                    return;
                }

                operation = (OperationComboBox.SelectedItem as ComboBoxItem).Content.ToString();

                try
                {
                    switch (operation)
                    {
                        case "+":
                            result = num1 + num2;
                            calculationDetails = $"{num1} + {num2} = {result}";
                            break;
                        case "-":
                            result = num1 - num2;
                            calculationDetails = $"{num1} - {num2} = {result}";
                            break;
                        case "*":
                            result = num1 * num2;
                            calculationDetails = $"{num1} * {num2} = {result}";
                            break;
                        case "/":
                            // Error Handling for Division by Zero
                            if (num2 == 0)
                            {
                                MessageBox.Show("Division by zero is not allowed.");
                                return;
                            }
                            result = num1 / num2;
                            calculationDetails = $"{num1} / {num2} = {result}";
                            break;
                        default:
                            throw new InvalidOperationException("Invalid operation selected.");
                    }

                    ResultTextBlock.Text = $"Result: {result}";
                    CalculationDetailsTextBlock.Text = calculationDetails;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }
    }

