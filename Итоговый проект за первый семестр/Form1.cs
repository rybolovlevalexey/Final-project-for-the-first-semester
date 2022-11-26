using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Итоговый_проект_за_первый_семестр
{
    public partial class Form1 : Form
    {
        public Random rnd = new Random();
        static int size = 4;
        Btn2048[,] field = new Btn2048[size, size];
        static int btn_size = 450 / size - 3;
        static Dictionary<int, Color> colors = new Dictionary<int, Color>(){
            {2, Color.DarkGray}, {4, Color.Gray}, {8, Color.DarkOrange}, {16, Color.Orange},
            {32, Color.OrangeRed}, {64, Color.Red}, {128, Color.Yellow}, {256, Color.YellowGreen}
        };
        
        public class Btn2048 : Button
        {
            public int value = 0;
            public Btn2048()
            {
                this.BackColor = Color.LightSteelBlue;
                this.Enabled = false;
                this.Width = btn_size;
                this.Height = btn_size;
                this.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular,
                        System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            }
        }

        public Form1()
        {
            InitializeComponent();
            int first_index = rnd.Next(1, 16), second_index = rnd.Next(1, 16), n = 1;
            while (second_index == first_index)
                second_index = rnd.Next(1, 16);

            for (int i = 0; i < 4; i += 1)
            {
                for (int j = 0; j < 4; j += 1)
                {
                    Btn2048 btn = new Btn2048();
                    btn.Location = new Point(j * btn_size, i * btn_size + 200);
                    this.Controls.Add(btn);
                    field[i, j] = btn;
                    if (n == first_index || n == second_index)
                    {
                        btn.value = 2;
                    }
                    n += 1;
                }
            }
            check_field();
            this.KeyDown += new KeyEventHandler(_keybordEvent);
        }

        private void _keybordEvent(object Sender, KeyEventArgs arg)
        {
            switch (arg.KeyCode.ToString())
            {
                case "Up":
                    for (int i = 0; i < size; i += 1)
                    {
                        for (int j = 0; j < size; j += 1)
                        {
                            // проход по каждой клетке 
                            if (field[i, j].value == 0)
                                continue;
                            int ind_i = i, ind_j = j;
                            while (ind_i > 0 && field[ind_i - 1, ind_j].value == 0)
                            {
                                field[ind_i - 1, ind_j].value = field[ind_i, ind_j].value;
                                field[ind_i, ind_j].value = 0;
                                ind_i -= 1;
                            }
                            if (ind_i <= 0)
                                continue;
                            if (field[ind_i - 1, ind_j].value == field[ind_i, ind_j].value)
                            {
                                field[ind_i - 1, ind_j].value *= 2;
                                field[ind_i, ind_j].value = 0;
                            }
                        }
                    }
                    check_field();
                    break;
                case "Down":
                    for (int i = size - 1; i >= 0; i -= 1)
                    {
                        for (int j = 0; j < size; j += 1)
                        {
                            // проход по каждой клетке 
                            if (field[i, j].value == 0)
                                continue;
                            int ind_i = i, ind_j = j;
                            while (ind_i + 1 < size && field[ind_i + 1, ind_j].value == 0)
                            {
                                field[ind_i + 1, ind_j].value = field[ind_i, ind_j].value;
                                field[ind_i, ind_j].value = 0;
                                ind_i += 1;
                            }
                            if (ind_i + 1 == size)
                                continue;
                            if (field[ind_i + 1, ind_j].value == field[ind_i, ind_j].value)
                            {
                                field[ind_i + 1, ind_j].value *= 2;
                                field[ind_i, ind_j].value = 0;
                            }
                        }
                    }
                    check_field();
                    break;
                case "Left":
                    for (int i = 0; i < size; i += 1)
                    {
                        for (int j = 0; j < size; j += 1)
                        {
                            // проход по каждой клетке 
                            if (field[i, j].value == 0)
                                continue;
                            int ind_i = i, ind_j = j;
                            while (ind_j - 1 >= 0 && field[ind_i, ind_j - 1].value == 0)
                            {
                                field[ind_i, ind_j - 1].value = field[ind_i, ind_j].value;
                                field[ind_i, ind_j].value = 0;
                                ind_j -= 1;
                            }
                            if (ind_j <= 0)
                                continue;
                            if (field[ind_i, ind_j - 1].value == field[ind_i, ind_j].value)
                            {
                                field[ind_i, ind_j - 1].value *= 2;
                                field[ind_i, ind_j].value = 0;
                            }
                        }
                    }
                    check_field();
                    break;
                case "Right":
                    for (int i = 0; i < size; i += 1)
                    {
                        for (int j = size - 1; j >= 0; j -= 1)
                        {
                            // проход по каждой клетке 
                            if (field[i, j].value == 0)
                                continue;
                            int ind_i = i, ind_j = j;
                            while (ind_j + 1 < size && field[ind_i, ind_j + 1].value == 0)
                            {
                                field[ind_i, ind_j + 1].value = field[ind_i, ind_j].value;
                                field[ind_i, ind_j].value = 0;
                                ind_j += 1;
                            }
                            if (ind_j + 1 == size)
                                continue;
                            if (field[ind_i, ind_j + 1].value == field[ind_i, ind_j].value)
                            {
                                field[ind_i, ind_j + 1].value *= 2;
                                field[ind_i, ind_j].value = 0;
                            }
                        }
                    }
                    check_field();
                    break;
            }
            int new_num_index = rnd.Next(1, 16);
            bool flag_about_new_index = check_new_index(new_num_index);
            while (!flag_about_new_index)
            {
                new_num_index = rnd.Next(1, 16);
                flag_about_new_index = check_new_index(new_num_index);
            }
            int n = 1;
            for (int i = 0; i < size; i += 1)
            {
                for (int j = 0; j < size; j += 1)
                {
                    if (n == new_num_index)
                    {
                        if (rnd.Next(1, 5) == 2)
                            field[i, j].value = 4;
                        else
                            field[i, j].value = 2;
                        break;
                    }
                    n += 1;
                }
            }
            check_field();
        }

        // проверка - можно ли на указанное место доавлять новое число
        private bool check_new_index(int ind)
        {
            bool flag = true;
            int n = 1;
            for (int i = 0; i < size; i += 1)
                for (int j = 0; j < size; j += 1)
                    if (n == ind && field[i, j].value > 0)
                        flag = false;
            return flag;
        }
        // проверка поля и изменение цвета у клеточек в случае необходимости
        private void check_field()
        {
            for (int i = 0; i < size; i += 1)
            {
                for (int j = 0; j < size; j += 1)
                {
                    if (field[i, j].value > 0)
                    {
                        field[i, j].Text = field[i, j].value.ToString();
                        try
                        {
                            field[i, j].BackColor = colors[field[i, j].value];
                        }
                        catch(KeyNotFoundException)
                        {
                            MessageBox.Show("Достигнуто предельно возможное число");
                        }
                    } else
                    {
                        field[i, j].Text = "";
                        field[i, j].BackColor = Color.LightSteelBlue;
                    }
                }
            }
        }
    }
}
