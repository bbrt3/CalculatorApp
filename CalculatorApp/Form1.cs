using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Calculator : Form
    {
        private static string memoryValue;
        private static string firstNumber;
        private static string currentOperator;
        public Calculator()
        {
            InitializeComponent();
            textBoxCalculations.Text = "0";
        }

        private void AddNumber(string num)
        {
            if (textBoxCalculations.Text.Length != textBoxCalculations.MaxLength - 1)
            {
                if (textBoxCalculations.Text.First() == '0' && textBoxCalculations.TextLength == 1)
                {
                    textBoxCalculations.Text = num;
                }
                else
                    textBoxCalculations.Text += num;
            }
        }

        private void StartOperation(string op)
        {
            firstNumber = textBoxCalculations.Text;
            textBoxCalculations.Text = "0";
            currentOperator = op;
        }

        private void DeleteLast()
        {
            if (textBoxCalculations.Text.First() != '0' && textBoxCalculations.Text.Length >= 1)
            {
                textBoxCalculations.Text = textBoxCalculations.Text.Substring(0, textBoxCalculations.Text.Length - 1);
            }
            else
            {
                textBoxCalculations.Text = textBoxCalculations.Text.Substring(0, textBoxCalculations.Text.Length - 1);
            }

            if (textBoxCalculations.Text.Length == 0)
            {
                textBoxCalculations.Text = "0";
            }
            //else
            //{
            //    MessageBox.Show("No values to delete", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void ClearAll()
        {
            textBoxCalculations.Text = "0";
        }

        private void OperationFraction()
        {
            if (textBoxCalculations.Text.Length >= 1)
            {
                try
                {
                    textBoxCalculations.Text = (1.0f / float.Parse(textBoxCalculations.Text)).ToString();
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("ERROR", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    textBoxCalculations.Text = "0";
                }
                if (textBoxCalculations.Text.Length >= textBoxCalculations.MaxLength)
                {
                    textBoxCalculations.Text = textBoxCalculations.Text.Substring(0, textBoxCalculations.MaxLength - 1);
                }
            }
        }

        private void OperationSquareRoot()
        {
            if (textBoxCalculations.Text.Length > 0)
                textBoxCalculations.Text = Math.Sqrt(float.Parse(textBoxCalculations.Text)).ToString();

            if (textBoxCalculations.Text.Length >= textBoxCalculations.MaxLength)
            {
                textBoxCalculations.Text = textBoxCalculations.Text.Substring(0, textBoxCalculations.MaxLength - 1);
            }
        }

        private void PositiveOrNegative()
        {
            if (textBoxCalculations.Text != "0")
            {

                if (textBoxCalculations.Text.First() == '-')
                {
                    textBoxCalculations.Text = textBoxCalculations.Text.Substring(1, textBoxCalculations.Text.Length - 1);
                }
                else
                {
                    textBoxCalculations.Text = '-' + textBoxCalculations.Text;
                }
            }
        }

        private void DotInserter()
        {
            bool isComma = false;

            foreach (char x in textBoxCalculations.Text)
            {
                if (x == ',')
                    isComma = true;
            }

            if (!isComma)
            {
                textBoxCalculations.Text += ',';
            }
        }

        private void MemoryClear()
        {
            memoryValue = "0";
        }

        private void MemoryRecall()
        {
            // MEMORY RECALL
            if (memoryValue != null)
            {
                //operationCopy = textBoxCalculations.Text;
                textBoxCalculations.Text = memoryValue;
            }
            else
            {
                textBoxCalculations.Text = "0";
            }
        }

        private void MemoryStore()
        {
            memoryValue = textBoxCalculations.Text;
            textBoxCalculations.Text = "0";
        }

        private void MemoryPlus()
        {
            try
            {
                memoryValue = (int.Parse(textBoxCalculations.Text) + int.Parse(memoryValue)).ToString();
            }
            catch
            {
                MessageBox.Show("There is no value in memory.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MemoryMinus()
        {
            try
            {
                memoryValue = (int.Parse(textBoxCalculations.Text) - int.Parse(memoryValue)).ToString();
            }
            catch
            {
                MessageBox.Show("There is no value in memory.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OperatorEquals()
        {
            string secondNumber = textBoxCalculations.Text;
            double result;

            switch (currentOperator)
            {
                case "+":
                    result = float.Parse(firstNumber) + float.Parse(secondNumber);
                    if (result.ToString().Length > textBoxCalculations.MaxLength) { textBoxCalculations.Text = result.ToString().Substring(0, textBoxCalculations.MaxLength - 1); }
                    else { textBoxCalculations.Text = result.ToString(); }
                    firstNumber = result.ToString();
                    currentOperator = "";
                    break;
                case "-":
                    result = float.Parse(firstNumber) - float.Parse(secondNumber);
                    if (result.ToString().Length > textBoxCalculations.MaxLength) { textBoxCalculations.Text = result.ToString().Substring(0, textBoxCalculations.MaxLength - 1); }
                    else { textBoxCalculations.Text = result.ToString(); }
                    firstNumber = result.ToString();
                    currentOperator = "";
                    break;
                case "*":
                    result = float.Parse(firstNumber) * float.Parse(secondNumber);
                    if (result.ToString().Length > textBoxCalculations.MaxLength) { textBoxCalculations.Text = result.ToString().Substring(0, textBoxCalculations.MaxLength - 1); }
                    else { textBoxCalculations.Text = result.ToString(); }
                    firstNumber = result.ToString();
                    currentOperator = "";
                    break;
                case "/":
                    if (secondNumber != "0")
                    {
                        result = float.Parse(firstNumber) / float.Parse(secondNumber);
                        if (result.ToString().Length > textBoxCalculations.MaxLength) { textBoxCalculations.Text = result.ToString().Substring(0, textBoxCalculations.MaxLength - 1); }
                        else { textBoxCalculations.Text = result.ToString(); }
                        firstNumber = result.ToString();
                        currentOperator = "";
                    }
                    else
                    {
                        textBoxCalculations.Text = firstNumber = secondNumber = "0";
                        result = 0;
                        currentOperator = "";
                    }
                    break;
                case "%":
                    result = float.Parse(firstNumber) % float.Parse(secondNumber);
                    if (result.ToString().Length > textBoxCalculations.MaxLength) { textBoxCalculations.Text = result.ToString().Substring(0, textBoxCalculations.MaxLength - 1); }
                    else { textBoxCalculations.Text = result.ToString(); }
                    firstNumber = result.ToString();
                    break;

                default:
                    break;
            }
        }

        private void ClearEntry()
        {
            if (currentOperator != null)
            {
                textBoxCalculations.Text = "0";
            }
        }

        private void btnZero_Click(object sender, EventArgs e) => AddNumber("0");
        private void btnOne_Click(object sender, EventArgs e) => AddNumber("1");
        private void btnTwo_Click(object sender, EventArgs e) => AddNumber("2");
        private void btnThree_Click(object sender, EventArgs e) => AddNumber("3");
        private void btnFour_Click(object sender, EventArgs e) => AddNumber("4");
        private void btnFive_Click(object sender, EventArgs e) => AddNumber("5");
        private void btnSix_Click(object sender, EventArgs e) => AddNumber("6");
        private void btnSeven_Click(object sender, EventArgs e) => AddNumber("7");
        private void btnEight_Click(object sender, EventArgs e) => AddNumber("8");
        private void btnNine_Click(object sender, EventArgs e) => AddNumber("9");

        private void btnOperatorDeleteLast_Click(object sender, EventArgs e)
        {
            DeleteLast();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnOperationFraction_Click(object sender, EventArgs e)
        {
            OperationFraction();
        }

        private void btnOperatorSquareRoot_Click(object sender, EventArgs e)
        {
            OperationSquareRoot();
        }

        private void btnPlusOrNegative_Click(object sender, EventArgs e)
        {
            PositiveOrNegative();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            DotInserter();
        }

        private void btnMemoryClear_Click(object sender, EventArgs e)
        {
            MemoryClear();
        }

        private void btnMemoryR_Click(object sender, EventArgs e)
        {
            MemoryRecall();
        }

        private void btnMemoryStore_Click(object sender, EventArgs e)
        {
            MemoryStore();
        }

        private void btnMemoryPlusValue_Click(object sender, EventArgs e)
        {
            MemoryPlus();
        }

        private void btnMemoryMinusValue_Click(object sender, EventArgs e)
        {
            MemoryMinus();
        }

        private void btnOperatorEquals_Click(object sender, EventArgs e)
        {
            OperatorEquals();
        }

        private void btnOperatorPlus_Click(object sender, EventArgs e)
        {
            StartOperation("+");
        }

        private void btnOperatorMinus_Click(object sender, EventArgs e)
        {
            StartOperation("-");
        }

        private void btnOperatorMultiplication_Click(object sender, EventArgs e)
        {
            StartOperation("*");
        }

        private void btnOperatorDivision_Click(object sender, EventArgs e)
        {
            StartOperation("/");
        }

        private void btnOpeartorModulo_Click(object sender, EventArgs e)
        {
            StartOperation("%");
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            ClearEntry();
        }

        private void textBoxCalculations_TextChanged(object sender, EventArgs e)
        {
            if (float.Parse(textBoxCalculations.Text) > 9999999999.0f)
            {
                textBoxCalculations.Text = "9999999999";
                MessageBox.Show("Your calculations were too big!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.D0 || keyData == Keys.NumPad0)
                AddNumber("0");
            if (keyData == Keys.D1 || keyData == Keys.NumPad1)
                AddNumber("1");
            if (keyData == Keys.D2 || keyData == Keys.NumPad2)
                AddNumber("2");
            if (keyData == Keys.D3 || keyData == Keys.NumPad3)
                AddNumber("3");
            if (keyData == Keys.D4 || keyData == Keys.NumPad4)
                AddNumber("4");
            if (keyData == Keys.D5 || keyData == Keys.NumPad5)
                AddNumber("5");
            if (keyData == Keys.D6 || keyData == Keys.NumPad6)
                AddNumber("6");
            if (keyData == Keys.D7 || keyData == Keys.NumPad7)
                AddNumber("7");
            if (keyData == Keys.D8 || keyData == Keys.NumPad8)
                AddNumber("8");
            if (keyData == Keys.D9 || keyData == Keys.NumPad9)
                AddNumber("9");
            //if (keyData == Keys.Oemcomma)
            //{
            //    bool isComma = false;

            //    foreach (char x in textBoxCalculations.Text)
            //    {
            //        if (x == ',')
            //            isComma = true;
            //    }

            //    if (!isComma)
            //    {
            //        textBoxCalculations.Text += ',';
            //    }
            //}
            //if (keyData == Keys.Escape)
            //    textBoxCalculations.Text = "0";
            //if (keyData == Keys.Oemplus)
            //    StartOperation("+");
            //if (keyData == Keys.OemMinus)
            //    StartOperation("-");
            //if (keyData == Keys.Multiply)
            //    StartOperation("*");
            //if (keyData == Keys.Divide)
            //    StartOperation("/");
            //// Modulo
            //if ((int)keyData == 37)
            //    StartOperation("%");
            //if ((int)keyData == 61)
            //    OperatorEquals();
                

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
