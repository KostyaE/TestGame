using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Game3
{
    public partial class Form1 : Form
    {
        public int x;
        public int? z = null;
        public int value_x;
        public int a;
        public int b = 1000;
        public int counter;        
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        public string LogicMethod(out int value_x)
        {
            Thread.Sleep(300);
            
            if (counter == 0)
            {
                value_x = random.Next(475, 525);
            }
            else
            {
                if (counter < 4)
                {
                        value_x = ((b - a) / 2) + a;
                }
                else
                {
                    value_x = random.Next(a, b);
                }
            }

            counter++;
            label4.Text = "Попытка:" + counter;
            return Convert.ToString(value_x);
        }

        private void button1_Down(object sender, EventArgs e)
        {
            if (counter > 0)
            {
                if (z < x)
                {
                    b = x - 1;
                    textBox2.Text = LogicMethod(out x);
                }
                else
                    if (z > x)
                    MessageBox.Show("Загаданное число больше!");
                else
                    MessageBox.Show("Число отгадано!\nКоличество попыток: " + Convert.ToString(counter));
            }
            else
                MessageBox.Show("Загадайте число!");
        }

        private void button2_Ok(object sender, EventArgs e)
        {
            if (counter != 0)
            {
                if (x == z)
                    MessageBox.Show("Число отгадано!\nКоличество попыток: " + Convert.ToString(counter));
                else
                    MessageBox.Show("Число не отгадано!");
            }
            else
                MessageBox.Show("Загадайте число!");
        }

        private void button3_Up(object sender, EventArgs e)
        {
            if (counter > 0)
            {
                if (z > x)
                {
                    a = x + 1;
                    textBox2.Text = LogicMethod(out x);
                }
                else
                    if (z < x)
                    MessageBox.Show("Загаданное число меньше!");
                else
                    MessageBox.Show("Число отгадано!\nКоличество попыток: " + Convert.ToString(counter));
            }
            else
                MessageBox.Show("Загадайте число!");
        }

        public void button3_Start(object sender, EventArgs e)
        {
            if (counter == 0)
            {
                if (z != null)
                    textBox2.Text = LogicMethod(out x);
                else
                    MessageBox.Show("Загадайте число!");
            }
            else
                MessageBox.Show("Подсказывайте компьютеру кнопками \"меньше\" или \"больше\", чтобы продолжить игру!");

        }

        private void button5_Cline(object sender, EventArgs e)
        {

        }

        public void textBox1_User(object sender, EventArgs e)
        {
            //if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
            //    e.Handled = true;

            z = Convert.ToInt32(textBox1.Text);


        }

        public void textBox2_Machine(object sender, EventArgs e)
        {
            if (z == x)
            {
                MessageBox.Show("Число отгадано!\nКоличество попыток: " + Convert.ToString(counter));

            }
        }
    }
}
