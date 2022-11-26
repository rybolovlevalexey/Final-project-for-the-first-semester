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
        static int size = 4;
        Btn2048[,] field = new Btn2048[size, size];
        static int btn_size = 500 / size - 5;
        static Dictionary<int, Color> colors = new Dictionary<int, Color>(){
            {0, Color.DarkGray},
            {2, Color.LightYellow}, {4, Color.Gray}, {8, Color.DarkOrange}, {16, Color.Orange},
            {32, Color.OrangeRed}, {64, Color.Red}, {128, Color.Yellow}, {256, Color.YellowGreen}
        };
        
        public class Btn2048 : Button
        {
            public Btn2048()
            {
                int value = 0;
                this.BackColor = colors[0];
                this.Enabled = false;
                this.Width = btn_size;
                this.Height = btn_size;
                this.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular,
                        System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                
            }
        }

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 4; i += 1)
            {
                for (int j = 0; j < 4; j += 1)
                {
                    Btn2048 btn = new Btn2048();
                    btn.Location = new Point(j * btn_size, i * btn_size + 200);
                    this.Controls.Add(btn);
                    field[i, j] = btn;
                }
            }
            this.KeyDown += new KeyEventHandler(_keybordEvent);
        }

        private void _keybordEvent(object Sender, KeyEventArgs arg)
        {
            switch (arg.KeyCode.ToString())
            {
                case "Up":
                    MessageBox.Show(arg.KeyCode.ToString());
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
    }
}
