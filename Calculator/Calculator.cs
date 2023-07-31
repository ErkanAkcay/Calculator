using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {

        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;
        private bool isCalculatorOn = false;

      

        public Calculator()    // Constructor , formu başlatıp makineyi devredışı bıraktık 
        {
            InitializeComponent();
            DisableCalculator();
            // this.Text = "Calculator";
         
        }
        private void btnNumber_Click(object sender, EventArgs e)  // 0-9 ve , event i 
        {
            if (isCalculatorOn)
            {
                if ((txtBox_Result.Text == "0") || (isOperationPerformed))   //Açıldığında anlamsız olan 0 ı siler 
                    txtBox_Result.Clear();

                isOperationPerformed = false;
                Button btn = (Button)sender;

                if (btn.Text == ",")                                        // Bir sayıda tek virgül olmasını kontrol eder   
                {
                    if (!txtBox_Result.Text.Contains(","))      
                    {
                        txtBox_Result.Text += btn.Text;
                        labelCurrentOperation.Text += btn.Text;
                    }
                }
                else
                {
                    txtBox_Result.Text += btn.Text;
                    labelCurrentOperation.Text += btn.Text;
                }

            }
        }

        private void btnOperation_Click(object sender, EventArgs e) // (+, -, *, /) işlemlerini yapar önceden sakalanan işlemi
                                                                    // gerçekleştirir  ve o anki label ı günceller .
        {
            if (isCalculatorOn)
            {
                Button btn = (Button)sender;
                if (!string.IsNullOrEmpty(operationPerformed))
                {
                    performTheOperation();
                    labelCurrentOperation.Text = resultValue.ToString() + " " + btn.Text;
                }
                else
                {
                    resultValue = Double.Parse(txtBox_Result.Text);
                    labelCurrentOperation.Text = resultValue.ToString() + " " + btn.Text;
                }
                operationPerformed = btn.Text;
                isOperationPerformed = true;
            }
        }

       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            if (isCalculatorOn)
            {
                this.Text = "Calculator";                           // Form başlık çubuğu metnini düzenleme
                
            }
           


        }
        private void button6_Click(object sender, EventArgs e)  // C Butonu  Girilmiş son karakteri siler 
        {
            if (txtBox_Result.Text.Length > 0)
            {
                txtBox_Result.Text = txtBox_Result.Text.Substring(0, txtBox_Result.Text.Length - 1);
                labelCurrentOperation.Text = labelCurrentOperation.Text.Substring(0, labelCurrentOperation.Text.Length - 1);
            }
        }

        private void Result_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)  // AC Butonu , her şeyi sıfırlar 
        {
            if (isCalculatorOn)
            {
                txtBox_Result.Text = "0";
                labelCurrentOperation.Text = "";
            }
        }

        private void button8_Click(object sender, EventArgs e)  // = Butonu 
        {
            if (isCalculatorOn && !string.IsNullOrEmpty(operationPerformed))
            {
                performTheOperation();
                operationPerformed = "";
                isOperationPerformed = false;
            }
        }

        private void performTheOperation()  // Aritmetik işlemi yapar. Sonuç değerini günceller 
        {
            double currentOperand = Double.Parse(txtBox_Result.Text);
            switch (operationPerformed)
            {
                case "+":
                    resultValue += currentOperand;
                    break;
                case "-":
                    resultValue -= currentOperand;
                    break;
                case "*":
                    resultValue *= currentOperand;
                    break;
                case "/":
                    if (currentOperand == 0)
                    {
                        txtBox_Result.Text = "Error:Cannot divide 0";
                        isCalculatorOn = false;
                        return;
                    }
                    resultValue /= currentOperand;
                    break;
                default:
                    break;
            }
            txtBox_Result.Text = resultValue.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)  // ON-Off Butonu   
        {
            if (isCalculatorOn)
            {
                isCalculatorOn = false;
                txtBox_Result.Text = string.Empty;
                labelCurrentOperation.Text = "";
                operationPerformed = "";
                resultValue = 0;
            }
            else
            {
                isCalculatorOn = true;
                txtBox_Result.Text = "0";
                labelCurrentOperation.Text = "";
            }
        }

        //private void EnableCalculator()
        //{
        //}

        private void DisableCalculator()
        {
        }

    }
}





