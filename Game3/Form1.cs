using System;
using System.Windows.Forms;
using System.Threading;

namespace Game3
{
    public partial class Form1 : Form
    {
        // Переменная принимающая предпологаемое число.
        public int x;
        // Переменная принимающая загаданное число игроком.
        public int? z = null;
        // Переменная метода LogicMethod().
        public int value_x;
        // Переменная принимающая значение нижней границы. 
        public int a;
        // Переменная принимающая значение верхней границы. 
        public int b = 999;
        // Переменная для записи количества попыток .
        public int counter;        
        Random random = new Random();
        DialogResult dialogResult;

        public Form1()
        {
            InitializeComponent();
        }
        //
        // Метод приведения параметров к исходным значениям.
        //
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
        //
        // Метод принимающий значение и возвращает случайное число в заданном диапазоне.
        // 
        public string LogicMethod(out int value_x)
        {
            // Задерзка времени.
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
        //
        // Кнопка "Меньше" выполняющая метод подсказки числа в меньшую сторону.
        //
        private void button1_Down(object sender, EventArgs e)
        {
            if (z != x)
            {
                if (counter > 0)
                {
                    if (z < x)
                    {
                        // Уменьшаем значение на еденицу верхнее граничное число.
                        b = x - 1;
                        textBox2.Text = LogicMethod(out x);
                    }
                    else
                    {
                        if (z > x)
                        {
                            dialogResult = MessageBox.Show("Конец игры!\nИнформация: Загаданное число было больше.\n\nИграть заново?", "Нечестная игра!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
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
                if (z == x)
                {
                    dialogResult = MessageBox.Show("Число уже отгадано!\nКоличество попыток: " + Convert.ToString(counter) + "\n\nИграть заново?", "Нечестная игра!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
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
                    MessageBox.Show("Число отгадано!\nКоличество попыток: " + Convert.ToString(counter));
            }
        }
        //
        // Кнопка "Точно" выполняющая метод подтверждения загаданного числа
        //
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
                    dialogResult = MessageBox.Show("Конец игры!\nИнформация: Вы пытались обмануть компьютер.\n\nИграть заново?", "Нечестная игра!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
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
        //
        // Кнопка "Больше" выполняющая метод подсказки числа в большую сторону.
        //
        private void button3_Up(object sender, EventArgs e)
        {
            if (x != z)
            {
                if (counter > 0)
                {
                    if (z > x)
                    {
                        // Увеличиваем значение на еденицу нижнее граничное число.
                        a = x + 1;
                        textBox2.Text = LogicMethod(out x);
                    }
                    else
                    {
                        if (z < x)
                        {
                            dialogResult = MessageBox.Show("Конец игры!\nИнформация: Загаданное число было меньше.\n\nИграть заново?", "Нечестная игра!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
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
                if (z == x)
                {
                    dialogResult = MessageBox.Show("Число уже отгадано!\nКоличество попыток: " + Convert.ToString(counter) + "\n\nИграть заново?", "Нечестная игра!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
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
                MessageBox.Show("Число отгадано!\nКоличество попыток: " + Convert.ToString(counter));
            }
        }
        //
        // Кнопка "Загадать число" начинает игру вызывая метод LogicMethod()
        //
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
        //
        // Кнопка "Сбросить" выполняет ClearMethod() метод приведения параметров к исходным значениям.
        //
        private void button5_Clear(object sender, EventArgs e)
        {
            ClearMethod();
        }
        //
        // Поле вывода значения после выполнения LogicMethod().
        //
        public void textBox2_Machine(object sender, EventArgs e)
        {

        }
        //
        // Поле ввода загадываемого числа.
        //
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
