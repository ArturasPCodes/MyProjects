using MiniWindowsCalculator.Models;
using System;
using System.Windows;

namespace MiniWindowsCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private OperationType currentOperationType { get; set; }

        private double rightSideNumber = 0;
        private double leftSideNumber = 0;
        private bool wasEqualsPressed = false;
        private bool firstTimeOperation = true;
        private OperationType previousOperationType = OperationType.None;
        private bool wasPreviousOperationCalculated = false;

        private void btnCE_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBlock.Text = string.Empty;
            currentOperationType = OperationType.None;
            rightSideNumber = 0;
        }

        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            ResetCalculator();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var index = ResultTextBlock.Text.Length - 1;

                if (index < 0)
                {
                    throw new Exception("There is nothing to delete!");
                }

                ResultTextBlock.Text = ResultTextBlock.Text.Remove(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Input Symbols

        private void btnZero_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBlock.Text += "0";
        }

        private void btnOne_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBlock.Text += "1";
        }

        private void btnTwo_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBlock.Text += "2";
        }

        private void btnThree_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBlock.Text += "3";
        }

        private void btnFour_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBlock.Text += "4";
        }

        private void btnFive_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBlock.Text += "5";
        }

        private void btnSix_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBlock.Text += "6";
        }

        private void btnSeven_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBlock.Text += "7";
        }

        private void btnEight_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBlock.Text += "8";
        }

        private void btnNine_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBlock.Text += "9";
        }

        private void btnPlusMinus_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(ResultTextBlock.Text, out int number))
            {
                return;
            }

            string temp = ResultTextBlock.Text;
            ResultTextBlock.Text = string.Empty;

            if (number == 0)
            {
                ResultTextBlock.Text = temp;
                return;
            }
            else if (number > 0)
            {
                ResultTextBlock.Text = "-" + temp;
                leftSideNumber *= -1;
            }
            else if (number < 0)
            {
                ResultTextBlock.Text = temp.Remove(0, 1);
                leftSideNumber *= -1;
            }
        }

        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBlock.Text += ".";
        }

        #endregion

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            PerformOperation(OperationType.Addition);
        }

        private void btnSubstract_Click(object sender, RoutedEventArgs e)
        {
            PerformOperation(OperationType.Substraction);
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            PerformOperation(OperationType.Division);
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {
            PerformOperation(OperationType.Multiplication);
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            //If the number changed, this means that you should get the new number
            //If the number stayed the same, you will perform the last operation, so no need for new input
            if (leftSideNumber.ToString() != ResultTextBlock.Text)
            {
                GetCurrentNumber();
            }

            //Calculate and set parameter that equation was calculated
            wasEqualsPressed = true;
            CalculateEquation();
            wasPreviousOperationCalculated = false;

            ResultTextBlock.Text = Math.Round(leftSideNumber, 2).ToString();
        }

        /// <summary>
        /// Reads the current number in the textbox
        /// </summary>
        private void GetCurrentNumber()
        {

            if (!double.TryParse(ResultTextBlock.Text, out rightSideNumber))
            {
                return;
            }

            ResultTextBlock.Text = string.Empty;
        }

        private void CalculateEquation()
        {
            switch (currentOperationType)
            {
                case OperationType.Addition:
                    leftSideNumber += rightSideNumber;
                    break;

                case OperationType.Substraction:
                    leftSideNumber -= rightSideNumber;
                    break;

                case OperationType.Multiplication:
                    leftSideNumber *= rightSideNumber;
                    break;

                case OperationType.Division:
                    leftSideNumber /= rightSideNumber;
                    break;
            }
        }

        /// <summary>
        /// Resets the parameters of calculator to default values
        /// </summary>
        private void ResetCalculator()
        {
            ResultTextBlock.Text = string.Empty;
            rightSideNumber = 0;
            leftSideNumber = 0;
            wasEqualsPressed = false;
            firstTimeOperation = true;
            previousOperationType = OperationType.None;
            wasPreviousOperationCalculated = false;
        }

        /// <summary>
        /// Performs the calculation based on operation type
        /// </summary>
        /// <param name="operationType"></param>
        private void PerformOperation(OperationType operationType)
        {
            //Setting the operation type
            currentOperationType = operationType;

            //If equal was pressed, you don't need to get the current number as we already have it in leftSideNumber
            if (wasEqualsPressed)
            {
                previousOperationType = operationType;
                ResultTextBlock.Text = string.Empty;
                wasEqualsPressed = false;
                return;
            }

            GetCurrentNumber();

            //If its your first input, you dont need to calculate anything, just assign the number
            if (firstTimeOperation)
            {
                leftSideNumber = rightSideNumber;
                firstTimeOperation = false;

                //Store the information what operation was not done
                previousOperationType = currentOperationType;
                return;
            }

            //This part is executed when you perform more than one operation in a row.
            //For example 2+3-1, so it executes the 2+3
            if (!wasPreviousOperationCalculated)
            {
                currentOperationType = previousOperationType;
                CalculateEquation();
                wasPreviousOperationCalculated = true;
                currentOperationType = operationType;
                return;
            }

            CalculateEquation();
        }
    }
}
