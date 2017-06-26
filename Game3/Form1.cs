using System;
using System.Windows.Forms;
using System.Threading;

namespace Game3
{
    public partial class Form1 : Form
    {
        public int x;
        public int? z = null;
        public int value_x;
        public string value;
        public int a;
        public int b = 999;
        public int counter;        
        Random random = new Random();
        DialogResult dialogResult;

        public Form1()
        {
            InitializeComponent();
        }

        public void ClearMethod()
        {
         x = 0;
         z = null;
         value_x = 0;
         a = 0;
         b = 999;
         counter = 0;
            textBox1.Text = null;
            textBox1.Clear();
            textBox2.Clear();
            label4.Text = null;

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
            if (z != x)
            {
                if (counter > 0)
                {
                    if (z < x)
                    {
                        b = x - 1;
                        textBox2.Text = LogicMethod(out x);
                    }
                    else
                    {
                        if (z > x)
                        {
                            dialogResult = MessageBox.Show("Конец игры!\nИнформация: Загаданное число было больше.\n\nИграть заново?", "Обман!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                            if (dialogResult == DialogResult.Yes)
                            {
                                ClearMethod();
                            }
                            else
                            {
                                if (dialogResult == DialogResult.No)
                                {
                                    Application.Exit();
                                }
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Загадайте число!");
            }
            else
            {
                MessageBox.Show("Число отгадано!\nКоличество попыток: " + Convert.ToString(counter));
            }
        }

        private void button2_Ok(object sender, EventArgs e)
        {
            if (counter != 0)
            {
                if (x == z)
                {
                    dialogResult = MessageBox.Show("Количество попыток: " + Convert.ToString(counter) + "\n\nИграть заново ? ", "Число отгадано!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        ClearMethod();
                    }
                    else
                    {
                        if (dialogResult == DialogResult.No)
                        {
                            Application.Exit();
                        }
                    }
                }
                else
                {
                    //dialogResult = MessageBox.Show("Победа засчитывается компьютеру!\n\nИграть заново?", "Обман!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    //if (dialogResult == DialogResult.Yes)
                    //{
                    //    ClearMethod();
                    //}
                    dialogResult = MessageBox.Show("Конец игры!\nИнформация: Вы пытались обмануть компьютер.\n\nИграть заново?", "Обман!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.Yes)
                    {
                        ClearMethod();
                    }
                    else
                    {
                        if (dialogResult == DialogResult.No)
                        {
                            Application.Exit();
                        }
                    }
                }


            }
            else
                MessageBox.Show("Загадайте число!");
        }

        private void button3_Up(object sender, EventArgs e)
        {
            if (x != z)
            {
                if (counter > 0)
                {
                    if (z > x)
                    {
                        a = x + 1;
                        textBox2.Text = LogicMethod(out x);
                    }
                    else
                    {
                        if (z < x)
                        {
                            dialogResult = MessageBox.Show("Конец игры!\nИнформация: Загаданное число было меньше.\n\nИграть заново?", "Обман!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                            if (dialogResult == DialogResult.Yes)
                            {
                                ClearMethod();
                            }
                            else
                            {
                                if (dialogResult == DialogResult.No)
                                {
                                    Application.Exit();
                                }
                            }
                        }                        
                    }
                }
                else
                    MessageBox.Show("Загадайте число!");
            }
            else
            {
                MessageBox.Show("Число отгадано!\nКоличество попыток: " + Convert.ToString(counter));
            }
        }

        public void button3_Start(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == "")
                MessageBox.Show("Загадайте число!");
            else
                z = Convert.ToInt32(textBox1.Text);


            if (counter == 0)
            {
                if (z != null)
                    textBox2.Text = LogicMethod(out x);
                else
                    MessageBox.Show("Загадайте число!");
            }
            else
            {
                if (z == x)
                    MessageBox.Show("Число отгадано!\nКоличество попыток: " + Convert.ToString(counter));
                else
                    MessageBox.Show("Подсказывайте компьютеру кнопками \"меньше\" или \"больше\", чтобы продолжить игру!");
            }
        }

        private void button5_Cline(object sender, EventArgs e)
        {
            ClearMethod();
        }

        public void textBox2_Machine(object sender, EventArgs e)
        {
            if (z == x)
            {
                dialogResult = MessageBox.Show("Количество попыток: " + Convert.ToString(counter) + "\n\nИграть заново?", "Число отгадано!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    ClearMethod();
                }
                else
                {
                    if (dialogResult == DialogResult.No)
                    {
                        Application.Exit();
                    }
                }
                //MessageBox.Show("Число отгадано!\nКоличество попыток: " + Convert.ToString(counter));

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1.MaxLength = 3;

            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
