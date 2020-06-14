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
        public double e, sum = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void Sum_Calculation() // Подсчет суммы ряда
        {
            double current_term = 0; // Текущий член ряда
            sum = 0; // Текущая сумма
            int i = 1; // Текущая степень
            do
            {
                current_term = 1 / (Math.Pow(i, 2)); // Вычисление текущего члена ряда
                sum += current_term; // Прибавление к сумме
                i++; // Увеличение степени
            } while (Math.Abs(current_term) >= e); // Пока текущий член по модулю не меньше е
            SumOutput.Text = sum.ToString();
            eInput.Focus();
        }

        private void eInput_TextChanged(object sender, EventArgs e)
        {
            if (SumOutput.Text != string.Empty) // Очистка вывода
            {
                label2.Visible = false;
                SumOutput.Visible = false;
                SumOutput.Text = string.Empty;
            }
        }

        private void eInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Нажат энтер
            {
                if (SumOutput.Text != string.Empty) // Очистка формы
                {
                    label2.Visible = false;
                    SumOutput.Visible = false;
                    SumOutput.Text = string.Empty;
                }
                eInput.Text = eInput.Text.Replace('.', ','); // Замена точки на запятую для корректного парса строки
                if (double.TryParse(eInput.Text, out this.e)) // Проверка, введено ли вещественное число
                {
                    if (this.e > 0) // е больше нуля
                    {
                        if (this.e > 1) this.e = 1; // Если е больше 1, то вычисления будут такими же, как при е = 1
                        label2.Visible = true;
                        SumOutput.Visible = true;
                        Sum_Calculation(); // Подсчет
                    }
                    else MessageBox.Show("Введите положительное число!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Введите положительное число!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
