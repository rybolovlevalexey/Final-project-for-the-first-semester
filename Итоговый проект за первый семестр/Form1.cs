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
                        btn.value = 128;
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
                            
                        }
                    }
                    break;
                case "Down":
                    MessageBox.Show(arg.KeyCode.ToString());
                    break;
                case "Left":
                    MessageBox.Show(arg.KeyCode.ToString());
                    break;
                case "Right":
                    MessageBox.Show(arg.KeyCode.ToString());
                    break;
            }
        }

        private void check_field()
        {
            for (int i = 0; i < size; i += 1)
            {
                for (int j = 0; j < size; j += 1)
                {
                    if (field[i, j].value > 0)
                    {
                        field[i, j].Text = field[i, j].value.ToString();
                        field[i, j].BackColor = colors[field[i, j].value];
                    }
                }
            }
        }
    }
}
