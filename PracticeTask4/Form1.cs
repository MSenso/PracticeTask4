using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeTask4
{
    public partial class Form1 : Form
    {
        double e, sum = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        void Sum_Calculation()
        {
            double current_term = 0;
            sum = 0;
            int i = 1;
            do
            {
                current_term = 1 / (Math.Pow(i, 2));
                sum += current_term;
                i++;
            } while (Math.Abs(current_term) >= e);
            SumOutput.Text = sum.ToString();
            int rounding = 10;
            if (SumOutput.Location.X + SumOutput.Size.Width >= this.Width)
            {
                sum = Math.Round(sum, rounding);
                SumOutput.Text = sum.ToString();
            }
            SumOutput.Focus();
        }

        private void eInput_TextChanged(object sender, EventArgs e)
        {
            if (SumOutput.Text != string.Empty)
            {
                label2.Visible = false;
                SumOutput.Visible = false;
                SumOutput.Text = string.Empty;
            }
        }

        private void eInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (SumOutput.Text != string.Empty)
                {
                    label2.Visible = false;
                    SumOutput.Visible = false;
                    SumOutput.Text = string.Empty;
                }
                eInput.Text = eInput.Text.Replace('.', ',');
                if (double.TryParse(eInput.Text, out this.e))
                {
                    if (this.e > 0)
                    {
                        label2.Visible = true;
                        SumOutput.Visible = true;
                        Sum_Calculation();
                    }
                    else MessageBox.Show("Введите положительное число!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Введите положительное число!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
