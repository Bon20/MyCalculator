using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCalculator_bderobles
{
    public partial class Form1 : Form
    {
        float num1, ans;
        int count;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "9";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "6";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "3";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "0";
        }

        private void btndot_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + ".";
        }

        private void btnSqr_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "√";
        }

        private void btnPL_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "(";
        }

        private void btnPR_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + ")";
        }

        private void btnsin_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "sin(";
        }

        private void btntan_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "tan(";
        }

        private void btncos_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "cos(";
        }

        private void btnpi_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "π";
        }

        private void btnsinh_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "sinh(";
        }

        private void btntanh_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "tanh(";
        }

        private void btncosh_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "cosh(";
        }

        private void btn2pi_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "2π";
        }

        private void btnasinh_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "asinh(";
        }

        private void btnacosh_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "acosh(";
        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "log(";
        }

        private void btnlog2_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "log2(";
        }

        private void btne_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "e";
        }

        private void btnx3_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "x^3";
        }

        private void btnx2_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text == "0")
            {
                txtbxDisplay.Text = "";
            }
            txtbxDisplay.Text = txtbxDisplay.Text + "x^2";
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text != "")

            {
                txtbxDisplay.Text = txtbxDisplay.Text.Substring(0, txtbxDisplay.Text.Length - 1);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(txtbxDisplay.Text);
            txtbxDisplay.Clear();
            txtbxDisplay.Focus();
            count = 2;
        }

        private void btnsub_Click(object sender, EventArgs e)
        {
            if (txtbxDisplay.Text != "")
            {
                num1 = float.Parse(txtbxDisplay.Text);
                txtbxDisplay.Clear();
                txtbxDisplay.Focus();
                count = 1;
            }
        }

        private void btnmult_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(txtbxDisplay.Text);
            txtbxDisplay.Clear();
            txtbxDisplay.Focus();
            count = 3;
        }

        private void btndiv_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(txtbxDisplay.Text);
            txtbxDisplay.Clear();
            txtbxDisplay.Focus();
            count = 4;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            compute(count);
        }

        private void btnclr_Click(object sender, EventArgs e)
        {
            txtbxDisplay.Clear();
            count = 0;
        }

        private void FExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void compute(int count)
        {
            switch (count)
            {
                case 1:
                    ans = num1 - float.Parse(txtbxDisplay.Text);
                    txtbxDisplay.Text = ans.ToString();
                    break;
                case 2:
                    ans = num1 + float.Parse(txtbxDisplay.Text);
                    txtbxDisplay.Text = ans.ToString();
                    break;
                case 3:
                    ans = num1 * float.Parse(txtbxDisplay.Text);
                    txtbxDisplay.Text = ans.ToString();
                    break;
                case 4:
                    ans = num1 / float.Parse(txtbxDisplay.Text);
                    txtbxDisplay.Text = ans.ToString();
                    break;
                default:
                    break;
            }
        }
    }
}
