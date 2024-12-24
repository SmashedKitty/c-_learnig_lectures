using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program1
{
    public partial class Form2 : Form
    {
        private float minx, maxx, miny, maxy, W, H, W1, H1, dx, dy, h;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            double x = (e.X - W1) / dx;
            double y = (H1 - e.Y) / dy;
            string text = "Точки экстремума: 1 - П/2 (min), -1 + П/2 (max)";
            label2.Text = text;
            label2.Text = "extr 0 0";
        }

        //исходная функция

        public double F1(double x)
        {

            return -(2 * x - Math.Tan(x));

        }
        public double F2(double x)
        {

            return 2 - 1 / (Math.Pow(Math.Cos(x), 2));

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
           //рисуем оси
            e.Graphics.DrawLine(Pens.Black, W1, 0, W1, H);
            e.Graphics.DrawLine(Pens.Black, 0, H1, W, H1);

            //подпись осей
            Font Fon = new Font("Arial", 9, FontStyle.Regular);
            Brush Br = Brushes.Black;
            e.Graphics.DrawString("X", Fon, Br, W - 15, H1 + 10);
            e.Graphics.DrawString("Y", Fon, Br, W1 - 20, 10);

            //стрелки
            e.Graphics.DrawLine(Pens.Black, W - 10, H1 - 3, W, H1);
            e.Graphics.DrawLine(Pens.Black, W - 10, H1 + 3, W, H1);
            e.Graphics.DrawLine(Pens.Black, W1, 0, W1 - 3, 10);
            e.Graphics.DrawLine(Pens.Black, W1, 0, W1 + 3, 10);

            //линейка
            Font Fon1 = new Font("Arial", 6, FontStyle.Regular);
            for (int i = (int)miny; i < maxy; i++)
            {
                e.Graphics.DrawLine(Pens.Black, W1 - 1, H1 + dy * i, W1 + 1, H1 + dy * i);
                e.Graphics.DrawString((-(float)(i)).ToString(), Fon1, Br, W1 - 15, H1 + dy * i);
            }
            for (int i = (int)minx; i < maxx; i++)
            {
                e.Graphics.DrawLine(Pens.Black, W1 + dx * i, H1 + 1, W1 + dx * i, H1 - 1);
                if (i != 0)
                    e.Graphics.DrawString(i.ToString(), Fon1, Br, W1 + dx * i - 10, H1 + 10);
            }


            //строим графики
            float ixPrev = minx, iyPrev = (float)F1(ixPrev);              // координаты предыдущей точки функции f
            float x1, y1;

            float ixPrev1 = minx, iyPrev1 = (float)F2(ixPrev1);              // координаты предыдущей точки функции f'
           float x2, y2;

            // проходим по всем точкам на форме, вычисляем x1 и значение функции в точке х1
            for (float ix = ixPrev + h; ix < maxx; ix += h)
            {
                x1 = ix;                //х1, y1 - координаты следующей точки, h - шаг
                y1 = (float)F1(x1);
                e.Graphics.DrawLine(Pens.Green, W1 - dx * ixPrev, H1 - dy * iyPrev, W1 - dx * x1, H1 - dy * y1);    // строим линию, соединяющую 2 точки
                iyPrev = y1;
                ixPrev = x1;
            }

            ixPrev = minx;
            iyPrev = (float)F2(ixPrev);
            for (float ix = ixPrev + h; ix < maxx; ix += h)
            {
                x2 = ix;                //х2 y2 координаты следующей точки, h - шаг
                y2 = (float)F2(x2);
                e.Graphics.DrawLine(Pens.Blue, W1 - dx * ixPrev, H1 - dy * iyPrev, W1 - dx * x2, H1 - dy * y2);    // строим линию, соединяющую 2 точки
                iyPrev = y2;
                ixPrev = x2;
                

            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            W = pictureBox1.Width;
            H = pictureBox1.Height;
            W1 = W / 2;
            H1 = H / 2;
            miny = -10;
            maxy = 10;
            minx = -10;
            maxx = 9;
            h = 0.2f;
            dx = W / (maxx - minx);
            dy = H / (maxy - miny);
        }


        public Form2()
        {
            InitializeComponent();
        }


    }
}
