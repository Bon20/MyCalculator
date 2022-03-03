using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace MyCalculator_bderobles
{
    public partial class Form1 : Form
    {
        public bool nValue = false;
        public bool IsequalAgain = false;
        public bool alreadylblDisplay2 = false;
        public bool squared = false;
        public bool x = false;
        public bool fact = false;
        public bool sqr = false;
        public bool sqr10x = false;
        public bool log = false;
        public string lblDisplay1Holder = string.Empty;
        public string operation = string.Empty;
        public string lblDisplay2Holder = string.Empty;
        public double NCalculated = 0;
        public double lblDisplayCalculated = 0;
        public double calculatedAnswer = 0;
        public double lastNumber = 0;
        public ArrayList PlastValue = new ArrayList();
        public ArrayList POperations = new ArrayList();
        public int PCounter = 0;
        public bool needChange = false;

        private void reset(bool lblDisplay1reset = true)
        {
            nValue = false;
            IsequalAgain = false;
            lblDisplay1Holder = string.Empty;
            operation = string.Empty;
            alreadylblDisplay2 = false;
            NCalculated = 0;
            lblDisplayCalculated = 0;
            lastNumber = 0;
            if (lblDisplay1reset)
            {
                lblDisplay1.Text = "0";
            }
            lblDisplay2.Text = null;
            PCounter = 0;
            for (int i = PlastValue.Count; i != 0; i--)
            {
                PlastValue.RemoveAt(PlastValue.Count - 1);
                POperations.RemoveAt(POperations.Count - 1);
            }
        }

        private void btnCe_Click(object sender, EventArgs e)
        {
            if (btnCe.Text == "CE")
            {
                reset();
            }
            else
            {
                lblDisplay2.Text = "0";
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay2.Text.Length <= 1)
            {
                lblDisplay2.Text = "0";
            }
            else
            {
                if (IsequalAgain)
                {
                    string hold = lblDisplay2.Text;
                    reset();
                    lblDisplay2.Text = hold;
                }
                else
                {
                    lblDisplay2.Text = lblDisplay2.Text.Remove(lblDisplay2.Text.Length - 1);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDeg_Click(object sender, EventArgs e)
        {
            if (btnDeg.Text == "DEG")
            {
                btnDeg.Text = "RAD";
            }
            else if (btnDeg.Text == "RAD")
            {
                btnDeg.Text = "GRAD";
            }
            else
            {
                btnDeg.Text = "DEG";
            }
        }

        private void btnHyp_Click(object sender, EventArgs e)
        {
            Button[] buttons = new Button[] {btnSin, btnCos, btnTan,
                btnSec, btnCsc, btnCot };
            if (!buttons[0].Text.Contains('h'))
            {
                if (buttons[0].Text.Contains("⁻¹"))
                {
                    for (int i = 0; i < buttons.Length; i++)
                    {
                        buttons[i].Text = buttons[i].Text.Remove(buttons[i].Text.Length - 2) + "h⁻¹";
                    }
                }
                else
                {
                    for (int i = 0; i < buttons.Length; i++)
                    {
                        buttons[i].Text += "h";
                    }
                }
            }
            else
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Text = buttons[i].Text.Replace("h", String.Empty);
                }
            }
        }

        private void btn2nd_Click(object sender, EventArgs e)
        {
            Button[] buttons = new Button[] { btnSin, btnCos, btnTan,
                btnSec, btnCsc, btnCot };
            if (buttons[0].Text.Contains("⁻¹"))
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Text = buttons[i].Text.Remove(buttons[i].Text.Length - 2);
                }
            }
            else
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Text += "⁻¹";
                }
            }

        }
        private void ButtonPressed(string selectedNumber)
        {
            if (lblDisplay1.Text == "0" || nValue || IsequalAgain || squared)
            {
                if (nValue)
                {
                    nValue = false;
                }
                if (IsequalAgain)
                {
                    lblDisplay2.Text = null;
                    operation = string.Empty;
                    lblDisplay1Holder = string.Empty;
                    NCalculated = 0;
                    lastNumber = 0;
                }
                lblDisplay1.Text = string.Empty;
                IsequalAgain = false;
                squared = false;
            }
            lblDisplay1.Text += selectedNumber;
        }

        private double GettrigoVal(string angle, double value)
        {
            switch (angle)
            {
                case "sin":
                    return Math.Sin(value);
                case "cos":
                    return Math.Cos(value);
                case "tan":
                    return Math.Tan(value);
                case "sec":
                    return 1 / Math.Cos(value);
                case "csc":
                    return 1 / Math.Sin(value);
                case "cot":
                    return 1 / Math.Tan(value);
                case "sin⁻¹":
                    return Math.Asin(value);
                case "cos⁻¹":
                    return Math.Acos(value);
                case "tan⁻¹":
                    return Math.Atan(value);
                case "sec⁻¹":
                    return 1 / Math.Acos(value);
                case "csc⁻¹":
                    return 1 / Math.Asin(value);
                case "cot⁻¹":
                    return 1 / Math.Atan(value);
                case "sinh":
                    return Math.Sinh(value);
                case "cosh":
                    return Math.Cosh(value);
                case "tanh":
                    return Math.Tanh(value);
                case "sech":
                    return 1 / Math.Cosh(value);
                case "csch":
                    return 1 / Math.Sinh(value);
                case "coth":
                    return 1 / Math.Tanh(value);
            }
            return 0;
        }

        private void trigoBranch(string angle)
        {
            double trigoholder = 0;
            if (btnDeg.Text == "DEG")
            {
                lblDisplay2.Text += $"{angle}₀({lblDisplay1.Text})";
                trigoholder = Math.Round(GettrigoVal(angle, double.Parse(lblDisplay1.Text)));
                lblDisplay1.Text = (trigoholder * (Math.PI / 180)).ToString();
            }
            else if (btnDeg.Text == "RAD")
            {
                lblDisplay2.Text += $"{angle}ᵣ({lblDisplay1.Text})";
                trigoholder = Math.Round(GettrigoVal(angle, double.Parse(lblDisplay1.Text)), 11);
                lblDisplay2.Text = trigoholder.ToString();
            }
            else
            {
                lblDisplay2.Text += $"{angle}₉({lblDisplay1.Text})";
                trigoholder = Math.Round(GettrigoVal(angle, double.Parse(lblDisplay1.Text) *
                     Math.PI / 200), 11);
                lblDisplay1.Text = trigoholder.ToString();
            }
            alreadylblDisplay2 = true;
        }

        private void btnSin_Click(object sender, EventArgs e)
        {
            trigoBranch(btnSin.Text);
        }

        private void btnTan_Click(object sender, EventArgs e)
        {
            trigoBranch(btnTan.Text);
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            trigoBranch(btnCos.Text);
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            trigoBranch(btnSec.Text);
        }

        private void btnCsc_Click(object sender, EventArgs e)
        {
            trigoBranch(btnCsc.Text);
        }

        private void btnCot_Click(object sender, EventArgs e)
        {
            trigoBranch(btnCot.Text);
        }
        private void x2items()
        {
            lblDisplay1.Text = NCalculated.ToString();
            nValue = false;
            squared = true;
        }
        private void x2otherItems(double toThe = 2)
        {
            if (operation == "add")
            {
                NCalculated += Math.Pow(double.Parse(lblDisplay1.Text), 2);
                lblDisplay2.Text += $" sqr({lblDisplay2.Text})";
                x2items();
            }
            else if (operation == "minus")
            {
                NCalculated -= Math.Pow(double.Parse(lblDisplay1.Text), 2);
                lblDisplay2.Text += $" sqr({lblDisplay1.Text})";
                x2items();
            }
            else if (operation == "divide")
            {
                NCalculated /= Math.Pow(double.Parse(lblDisplay1.Text), 2);
                lblDisplay2.Text += $" sqr({lblDisplay1.Text})";
                x2items();
            }
            else if (operation == "multiply")
            {
                NCalculated *= Math.Pow(double.Parse(lblDisplay1.Text), 2);
                lblDisplay2.Text += $" sqr({lblDisplay1.Text})";
                x2items();
            }
            else
            {
                lblDisplay2.Text += $"sqr({lblDisplay1.Text})";
                NCalculated = Math.Pow(double.Parse(lblDisplay1.Text), 2);
                x2items();
            }
        }

        private void btnx2_Click(object sender, EventArgs e)
        {
            x2otherItems();
        }
        private void XItems()
        {
            lblDisplay2.Text += $" |{lblDisplay1.Text}|";
            lblDisplay1.Text = NCalculated.ToString();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            double hold = 0;
            if (double.Parse(lblDisplay1.Text) < 0)
            {
                hold = double.Parse(lblDisplay1.Text) * -1;
            }
            else
            {
                hold = double.Parse(lblDisplay1.Text);
            }
            switch (operation)
            {
                case "add":
                    NCalculated += hold;
                    XItems();
                    break;
                case "minus":
                    NCalculated -= hold;
                    XItems();
                    break;
                case "multiply":
                    NCalculated *= hold;
                    XItems();
                    break;
                case "divide":
                    NCalculated /= hold;
                    XItems();
                    break;
                default:
                    NCalculated = hold;
                    XItems();
                    break;
            }
            x = true;
        }
        private double N (double n)
        {
            if (n == 1)
            {
                return n;
            }
            else if (n < 1)
            {
                return Math.Acos(5);
            }
            else
            {
                return n * N(n - 1);
            }
        }
        private void NItems()
        {
            lblDisplay2.Text += $" fact({lblDisplay1.Text})";
            lblDisplay1.Text = NCalculated.ToString();
        }

        private void btnN_Click(object sender, EventArgs e)
        {
            double hold = N(double.Parse(lblDisplay1.Text));
            switch (operation)
            {
                case "add":
                    NCalculated += hold;
                    NItems();
                    break;
                case "minus":
                    NCalculated -= hold;
                    NItems();
                    break;
                case "multiply":
                    NCalculated *= hold;
                    NItems();
                    break;
                case "divide":
                    NCalculated /= hold;
                    NItems();
                    break;
                default:
                    NCalculated = hold;
                    NItems();
                    break;
            }
        }
        private void SqrItems()
        {
            lblDisplay2.Text += $" √({lblDisplay1.Text})";
            lblDisplay1.Text = NCalculated.ToString();
        }

        private void btnSqr_Click(object sender, EventArgs e)
        {
            double hold = Math.Sqrt(double.Parse(lblDisplay1.Text));
            switch (operation)
            {
                case "add":
                    NCalculated += hold;
                    SqrItems();
                    break;
                case "minus":
                    NCalculated -= hold;
                    SqrItems();
                    break;
                case "multiply":
                    NCalculated *= hold;
                    SqrItems();
                    break;
                case "divide":
                    NCalculated /= hold;
                    SqrItems();
                    break;
                default:
                    NCalculated = hold;
                    SqrItems();
                    break;
            }
            sqr = true;
        }
        private void x10Items()
        {
            lblDisplay2.Text += $" 10^{lblDisplay1.Text}";
            lblDisplay1.Text = NCalculated.ToString();
        }

        private void btn10x_Click(object sender, EventArgs e)
        {
            double hold = Math.Pow(10, double.Parse(lblDisplay1.Text));
            switch (operation)
            {
                case "add":
                    NCalculated += hold;
                    x10Items();
                    break;
                case "minus":
                    NCalculated -= hold;
                    x10Items();
                    break;
                case "multiply":
                    NCalculated *= hold;
                    x10Items();
                    break;
                case "divide":
                    NCalculated /= hold;
                    x10Items();
                    break;
                default:
                    NCalculated = hold;
                    x10Items();
                    break;
            }
            sqr10x = true;
        }
        private void logItems()
        {
            lblDisplay2.Text += $" log({lblDisplay1.Text})";
            lblDisplay1.Text = NCalculated.ToString();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            double hold = Math.Log(double.Parse(lblDisplay1.Text), 10);
            switch (operation)
            {
                case "add":
                    NCalculated += hold;
                    logItems();
                    break;
                case "minus":
                    NCalculated -= hold;
                    logItems();
                    break;
                case "multiply":
                    NCalculated *= hold;
                    logItems();
                    break;
                case "divide":
                    NCalculated /= hold;
                    logItems();
                    break;
                default:
                    NCalculated = hold;
                    logItems();
                    break;
            }
            log = true;
        }
        private void LNItems()
        {
            lblDisplay2.Text += $" ln({lblDisplay1.Text})";
            lblDisplay1.Text = NCalculated.ToString();
        }

        private void btnln_Click(object sender, EventArgs e)
        {
            double hold = Math.Log(double.Parse(lblDisplay1.Text));
            switch (operation)
            {
                case "add":
                    NCalculated += hold;
                    LNItems();
                    break;
                case "minus":
                    NCalculated -= hold;
                    LNItems();
                    break;
                case "multiply":
                    NCalculated *= hold;
                    LNItems();
                    break;
                case "divide":
                    NCalculated /= hold;
                    LNItems();
                    break;
                default:
                    NCalculated = hold;
                    LNItems();
                    break;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            ButtonPressed("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            ButtonPressed("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            ButtonPressed("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            ButtonPressed("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            ButtonPressed("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            ButtonPressed("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            ButtonPressed("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            ButtonPressed("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            ButtonPressed("9");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            ButtonPressed("0");
        }

        private void btndot_Click(object sender, EventArgs e)
        {
            if (!lblDisplay1.Text.Contains("."))
            {
                lblDisplay1.Text += ".";
            }
        }
        private void Disp2HolderOperation(string previewSymbol)
        {
            if (alreadylblDisplay2)
            {
                lblDisplay2Holder = lblDisplay2.Text + $" {previewSymbol} ";
                alreadylblDisplay2 = false;
            }
            else
            {
                lblDisplay2Holder = lblDisplay2.Text + lblDisplay1.Text + $" {previewSymbol} ";
            }
        }
        private void Operational(string whatOperation, string DisplaySymbol)
        {

            if (lblDisplay2.Text.Length > 1)
            {
               
                if (IsequalAgain)
                {
                    lblDisplay2Holder = lblDisplay1.Text + $" {DisplaySymbol} ";
                    lblDisplayCalculated = NCalculated;
                    IsequalAgain = false;
                }
                else if (nValue)
                {
                    lblDisplay2Holder = lblDisplay2.Text.Remove(lblDisplay2.Text.Length - 3) + $" {DisplaySymbol} ";
                    lblDisplayCalculated = NCalculated;
                }
                else
                {
                    if (operation == "minus")
                    {
                        if (squared)
                        {
                            lblDisplayCalculated = NCalculated;
                            lblDisplay2Holder = lblDisplay2.Text + " +";
                            squared = false;
                        }
                        else
                        {
                            lblDisplayCalculated = NCalculated - double.Parse(lblDisplay2.Text);
                            Disp2HolderOperation(DisplaySymbol);
                        }
                    }
                    else if (operation == "divide")
                    {
                        if (squared)
                        {
                            lblDisplayCalculated = NCalculated;
                            lblDisplay2Holder = lblDisplay2.Text + " +";
                            squared = false;
                        }
                        else
                        {
                            lblDisplayCalculated = NCalculated / double.Parse(lblDisplay1.Text);
                            Disp2HolderOperation(DisplaySymbol);
                        }
                    }
                    else if (operation == "multiply")
                    {
                        if (squared)
                        {
                            lblDisplayCalculated = NCalculated;
                            lblDisplay2Holder = lblDisplay2.Text + " +";
                            squared = false;
                        }
                        else
                        {
                            lblDisplayCalculated = NCalculated * double.Parse(lblDisplay1.Text);
                            Disp2HolderOperation(DisplaySymbol);
                        }
                    }
                    else if (operation == "add")
                    {
                        if (squared)
                        {
                            lblDisplayCalculated = NCalculated;
                            lblDisplay2Holder = lblDisplay2.Text + " +";
                            squared = false;
                        }
                        else
                        {
                            lblDisplayCalculated = NCalculated + double.Parse(lblDisplay1.Text);
                            Disp2HolderOperation(DisplaySymbol);
                        }
                    }
                    else if (operation == "pClose")
                    {
                        if (PCounter == 0 && POperations.Count != 0)
                        {
                            for (int i = POperations.Count; i != 0; i--)
                            {
                                PEqual();
                            }
                            lblDisplayCalculated = NCalculated;
                            lblDisplay2Holder = lblDisplay2.Text + $" {DisplaySymbol} ";
                        }
                        else
                        {
                            lblDisplayCalculated = double.Parse(lblDisplay1.Text);
                            lblDisplay2Holder = lblDisplay2.Text + $" {DisplaySymbol} ";
                        }
                    }
                    else if (operation == "openParan")
                    {
                        lblDisplayCalculated = double.Parse(lblDisplay1.Text);
                        Disp2HolderOperation(DisplaySymbol);
                    }
                    else
                    {
                        lblDisplayCalculated = double.Parse(lblDisplay1.Text);
                        Disp2HolderOperation(DisplaySymbol);
                    }
                }
            }
            else
            {
                lblDisplayCalculated = double.Parse(lblDisplay1.Text);
                lblDisplay2Holder = lblDisplay1.Text + $" {DisplaySymbol} ";
            }
            lblDisplay2.Text = lblDisplay2Holder;
            NCalculated = lblDisplayCalculated;
            lblDisplay1.Text = lblDisplayCalculated.ToString();
            nValue = true;
            operation = whatOperation;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Operational("add", "+");
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            Operational("minus", "-");
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            Operational("divide", "÷");
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            Operational("multiply", "×");
        }
        private void AfterEqual()
        {
            for (int i = POperations.Count; i != 0; i--)
            {
                PEqual();
            }
            calculatedAnswer = NCalculated;
            if (alreadylblDisplay2)
            {
                lblDisplay2.Text = lblDisplay2.Text;
                alreadylblDisplay2 = false;
            }
            else
            {
                if (!squared)
                {
                    lblDisplay2.Text = lblDisplay2.Text + lastNumber.ToString();
                }
            }
            CloseP();
            lblDisplay2.Text += " =";
            lblDisplay1.Text = calculatedAnswer.ToString();
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (squared || x || fact || sqr || sqr10x || log)
            {

                if (x || fact || sqr || sqr10x || log)
                {
                    if (!IsequalAgain)
                    {
                        lblDisplay2.Text += "=";
                        x = false;
                        fact = false;
                        sqr = false;
                        sqr10x = false;
                        log = false;
                    }
                    else
                    {
                        lblDisplay2.Text = lblDisplay1.Text + "=";
                        lblDisplay1.Text = NCalculated.ToString();
                    }
                }
                else if (squared)
                {
                    if (!IsequalAgain)
                    {
                        AfterEqual();
                    }
                    else
                    {
                        lblDisplay2.Text = lblDisplay2.Text + "=";
                        lblDisplay1.Text = NCalculated.ToString();
                    }
                }
            }
            else if (operation == "add")
            {
                if (!IsequalAgain)
                {
                    lastNumber = double.Parse(lblDisplay1.Text);
                    NCalculated = NCalculated + lastNumber;
                    AfterEqual();
                }
                else
                {
                    calculatedAnswer = NCalculated + lastNumber;
                    NCalculated = calculatedAnswer;
                    lblDisplay2.Text = lblDisplay1.Text + " + " + lastNumber.ToString() + " =";
                    lblDisplay1.Text = calculatedAnswer.ToString();
                }
            }
            else if (operation == "minus")
            {
                if (!IsequalAgain)
                {
                    lastNumber = double.Parse(lblDisplay1.Text);
                    NCalculated = NCalculated - lastNumber;
                    AfterEqual();
                }
                else
                {
                    calculatedAnswer = NCalculated - lastNumber;
                    NCalculated = calculatedAnswer;
                    lblDisplay2.Text = lblDisplay1.Text + " - " + lastNumber.ToString() + " =";
                    lblDisplay1.Text = calculatedAnswer.ToString();
                }
            }
            else if (operation == "divide")
            {
                if (!IsequalAgain)
                {
                    lastNumber = double.Parse(lblDisplay1.Text);
                    NCalculated = NCalculated / lastNumber;
                    AfterEqual();
                }
                else
                {
                    calculatedAnswer = NCalculated / lastNumber;
                    NCalculated = calculatedAnswer;
                    lblDisplay1.Text = lblDisplay2.Text + " / " + lastNumber.ToString() + " =";
                    lblDisplay2.Text = calculatedAnswer.ToString();
                }
            }
            else if (operation == "multiply")
            {
                if (!IsequalAgain)
                {
                    lastNumber = double.Parse(lblDisplay1.Text);
                    NCalculated = NCalculated * lastNumber;
                    AfterEqual();
                }
                else
                {
                    calculatedAnswer = NCalculated * lastNumber;
                    NCalculated = calculatedAnswer;
                    lblDisplay1.Text = lblDisplay2.Text + " * " + lastNumber.ToString() + " =";
                    lblDisplay2.Text = calculatedAnswer.ToString();
                }
            }
            else if (operation == "closingParan")
            {
                for (int i = POperations.Count; i != 0; i--)
                {
                    PEqual();
                }
                calculatedAnswer = NCalculated;
                CloseP();
                lblDisplay1.Text += " =";
                lblDisplay2.Text = calculatedAnswer.ToString();
                operation = string.Empty;
            }
            else if (operation == "openParan")
            {
                NCalculated = double.Parse(lblDisplay2.Text);
                for (int i = POperations.Count; i != 0; i--)
                {
                    PEqual();
                }
                calculatedAnswer = NCalculated;
                lblDisplay1.Text += lblDisplay2.Text;
                CloseP();
                lblDisplay1.Text += " =";
                lblDisplay2.Text = calculatedAnswer.ToString();
                operation = string.Empty;
            }
            else
            {
                lastNumber = double.Parse(lblDisplay2.Text);
                calculatedAnswer = lastNumber;
                NCalculated = calculatedAnswer;
                lblDisplay1.Text = lastNumber + " =";
                lblDisplay2.Text = NCalculated.ToString();
            }
            IsequalAgain = true;
        }

        private void btnPosNeg_Click(object sender, EventArgs e)
        {
            if (lblDisplay1.Text != "0")
            {
                lblDisplay1.Text = (-1 * double.Parse(lblDisplay1.Text)).ToString();
            }
        }
        private void CParen(string whatOperation)
        {
            if (whatOperation == "closingParan")
            {
                lblDisplay2.Text += " ) ";
            }
            else
            {
                lblDisplay2.Text += lblDisplay1.Text + " ) ";
            }
            if (whatOperation == "openParan")
            {
                NCalculated = double.Parse(lblDisplay1.Text);
            }
            else if (whatOperation == "add")
            {
                NCalculated += double.Parse(lblDisplay1.Text);
            }
            else if (whatOperation == "minus")
            {
                NCalculated -= double.Parse(lblDisplay1.Text);
            }
            else if (whatOperation == "divide")
            {
                NCalculated /= double.Parse(lblDisplay1.Text);
            }
            else if (whatOperation == "multiply")
            {
                NCalculated *= double.Parse(lblDisplay1.Text);
            }
            else if (whatOperation == "closingParan")
            {
                string lastPOperation = (string)POperations[POperations.Count - 1];
                double lastPNumber = (double)PlastValue[PlastValue.Count - 1];
                POperations.RemoveAt(POperations.Count - 1);
                PlastValue.RemoveAt(PlastValue.Count - 1);
                if (lastPOperation == "add")
                {
                    NCalculated = lastPNumber + NCalculated;
                }
                else if (lastPOperation == "minus")
                {
                    NCalculated = lastPNumber - NCalculated;
                }
                else if (lastPOperation == "divide")
                {
                    NCalculated = lastPNumber / NCalculated;
                }
                else if (lastPOperation == "multiply")
                {
                    NCalculated = lastPNumber * NCalculated;
                }
            }
            lblDisplay1.Text = NCalculated.ToString();
        }
        private void PEqual()
        {
            string lastPOperation = (string)POperations[POperations.Count - 1];
            double lastPNumber = (double)PlastValue[PlastValue.Count - 1];
            POperations.RemoveAt(POperations.Count - 1);
            PlastValue.RemoveAt(PlastValue.Count - 1);
            if (lastPOperation == "add")
            {
                NCalculated = lastPNumber + NCalculated;
            }
            else if (lastPOperation == "minus")
            {
                NCalculated = lastPNumber - NCalculated;
            }
            else if (lastPOperation == "divide")
            {
                NCalculated = lastPNumber / NCalculated;
            }
            else if (lastPOperation == "multiply")
            {
                NCalculated = lastPNumber * NCalculated;
            }
        }
        private void CloseP()
        {
            if (PCounter != 0)
            {
                for (int i = PCounter; i != 0; i--)
                {
                    lblDisplay2.Text += " ) ";
                }
                operation = string.Empty;
            }
        }

        private void btnOparen_Click(object sender, EventArgs e)
        {
            if (IsequalAgain)
            {
                reset(false);
            }
            if (lblDisplay2.Text.Length > 1)
            {
                if (operation != "openParan" || operation != "closingParan")
                {
                    PlastValue.Add(NCalculated);
                    POperations.Add(operation);
                }
            }
            if (operation == "closingParan")
            {
                lblDisplay2.Text = " ( ";
            }
            else
            {
                lblDisplay2.Text += " ( ";
            }
            if (operation != string.Empty)
            {
                lblDisplay1.Text = "0";
                NCalculated = 0;
            }
            operation = "openParan";
            PCounter++;
        }

        private void btnCparen_Click(object sender, EventArgs e)
        {
            if (PCounter != 0)
            {
                CParen(operation);
                PCounter--;
                operation = "closingParan";
            }
        }

        private void lblDisplay1_TextChanged(object sender, EventArgs e)
        {
            Button[] buttons = new Button[] {btnDeg, btn0, btn1, btn2, btn3, btn4,
            btn5, btn6, btn7, btn8, btn9, btnBack, btn2nd, btnSin,
            btnCos, btnTan, btnSec, btnCsc, btnHyp, btnx2,btn1x,
            btnX, btnSqr, btnOparen,
            btnCparen, btnN, btnDiv, btnMult, btnAdd, btnSub,
            btnEqual, btn10x, btnLog, btnln, btnPosNeg,
            btndot};

            if (lblDisplay1.Text != "0")
            {
                btnCe.Text = "CE";
            }
            else
            {
                btnCe.Text = "CE";
            }
            if (lblDisplay1.Text == "NaN" || lblDisplay1.Text == "∞")
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Enabled = false;
                }
            }
            else
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Enabled = true;
                }
            }
        }
    }
}
