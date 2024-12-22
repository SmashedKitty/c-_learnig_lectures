using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Даны квадрат (0<=x<=1, 0<=y<=1) и радиус (r<sqrt(2)). Найти из объединение

namespace Program1
{
    public partial class Form4 : Form
    {
        private float minx, maxx, miny, maxy, W, H, W1, H1, dx, dy, h;

        //координаты
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            double x = (e.X - W1) / dx;
            double y = (H1 - e.Y) / dy;
            string text = string.Format("X: {0}; Y: {1}", x, y);
            label2.Text = text;
        }

        //мое

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

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


            // Масштаб для перевода единиц в пиксели
            float scale = 100f; // 1 единица = 100 пикселей

            // Центр клиентской области формы
            float clientCenterX = this.ClientSize.Width / 2;
            float clientCenterY = this.ClientSize.Height / 2;

            // Параметры квадрата
            float squareSize = 1f; // Длина стороны квадрата
            float pixelSquareSize = squareSize * scale;

            // Прямоугольник для квадрата
            RectangleF squareRect = new RectangleF(
                clientCenterX - pixelSquareSize / 2,
                clientCenterY - pixelSquareSize / 2,
                pixelSquareSize,
                pixelSquareSize
            );

            // Параметры окружности
            float circleRadius = (float)Math.Sqrt(2); // Радиус окружности
            float pixelCircleRadius = circleRadius * scale;

            // Прямоугольник для окружности
            RectangleF circleRect = new RectangleF(
                clientCenterX - pixelCircleRadius,
                clientCenterY - pixelCircleRadius,
                pixelCircleRadius * 2,
                pixelCircleRadius * 2
            );

            // Рисование квадрата
            Pen squarePen = new Pen(Color.Blue, 2); // Квадрат синим цветом
            SolidBrush brush = new SolidBrush(Color.FromArgb(100, 0, 255, 0));
            g.DrawRectangle(squarePen, squareRect.X, squareRect.Y, squareRect.Width, squareRect.Height);
            g.FillRectangle(brush, squareRect);

            // Рисование окружности
            Pen circlePen = new Pen(Color.Red, 2); // Окружность красным цветом
            g.DrawEllipse(circlePen, circleRect);
            g.FillEllipse(brush, circleRect);

        }

        //Тани
        //private void pictureBox1_Paint(object sender, PaintEventArgs e)
        //{
        //    Graphics g = e.Graphics;

        //    //рисуем оси
        //    e.Graphics.DrawLine(Pens.Black, W1, 0, W1, H);
        //    e.Graphics.DrawLine(Pens.Black, 0, H1, W, H1);

        //    //подпись осей
        //    Font Fon = new Font("Arial", 9, FontStyle.Regular);
        //    Brush Br = Brushes.Black;
        //    e.Graphics.DrawString("X", Fon, Br, W - 15, H1 + 10);
        //    e.Graphics.DrawString("Y", Fon, Br, W1 - 20, 10);

        //    //стрелки
        //    e.Graphics.DrawLine(Pens.Black, W - 10, H1 - 3, W, H1);
        //    e.Graphics.DrawLine(Pens.Black, W - 10, H1 + 3, W, H1);
        //    e.Graphics.DrawLine(Pens.Black, W1, 0, W1 - 3, 10);
        //    e.Graphics.DrawLine(Pens.Black, W1, 0, W1 + 3, 10);

        //    ////линейка
        //    //Font Fon1 = new Font("Arial", 6, FontStyle.Regular);
        //    //for (int i = (int)miny; i < maxy; i++)
        //    //{
        //    //    e.Graphics.DrawLine(Pens.Black, W - 1, H + dy * i, W + 1, H + dy * i);
        //    //    e.Graphics.DrawString(((float)(-i)).ToString(), Fon1, Br, W1 - 15, H1 + dy * i);
        //    //}
        //    //for (int i = (int)minx; i < maxx; i++)
        //    //{
        //    //    e.Graphics.DrawLine(Pens.Black, W1 + dx * i, H1 + 1, W1 + dx * i, H1 - 1);
        //    //    if (i != 0)
        //    //        e.Graphics.DrawString(i.ToString(), Fon1, Br, W1 + dx * i - 10, H1 + 10);
        //    //}


        //    // Задание радиуса и центра окружности
        //    float radius = 2.5f; // Радиус окружности
        //    float centerX = 0;   // Центр по оси X
        //    float centerY = 0;   // Центр по оси Y

        //    // Перевод координат в клиентскую область формы
        //    // Учитывая, что (0,0) в графике формы находится в левом верхнем углу
        //    float clientCenterX = this.ClientSize.Width / 2;
        //    float clientCenterY = this.ClientSize.Height / 2;

        //    // Преобразование радиуса в пиксели (допустим, 100 пикселей = 1 единица)
        //    float scale = 50f;
        //    float pixelRadius = radius * scale;

        //    // Прямоугольник для отрисовки окружности
        //    RectangleF circleRect = new RectangleF(
        //        clientCenterX - pixelRadius,
        //        clientCenterY - pixelRadius,
        //        pixelRadius * 2,
        //        pixelRadius * 2
        //    );

        //    // Рисование окружности
        //    Pen pen = new Pen(Color.Black, 2); // Чёрная линия толщиной 2 пикселя
        //    SolidBrush brush = new SolidBrush(Color.FromArgb(100, 0, 255, 0));
        //    g.DrawEllipse(pen, circleRect);
        //    g.FillEllipse(brush, circleRect);

        //    // Полуоси эллипса
        //    float semiMajorAxis = 3f; // b = 3 (по оси Y)
        //    float semiMinorAxis = 2f; // a = 2 (по оси X)

        //    // Перевод центра эллипса в клиентскую область формы
        //    float clientCenterX2 = this.ClientSize.Width / 2;
        //    float clientCenterY2 = this.ClientSize.Height / 2;

        //    // Преобразование единиц измерения в пиксели (например, 100 пикселей = 1 единица)
        //    float scale1 = 50f;
        //    float pixelSemiMajorAxis = semiMajorAxis * scale;
        //    float pixelSemiMinorAxis = semiMinorAxis * scale;

        //    // Прямоугольник для отрисовки эллипса
        //    RectangleF ellipseRect2 = new RectangleF(
        //        clientCenterX2 - pixelSemiMinorAxis,
        //        clientCenterY2 - pixelSemiMajorAxis,
        //        pixelSemiMinorAxis * 2,
        //        pixelSemiMajorAxis * 2
        //    );

        //    // Рисование эллипса
        //    Pen pen2 = new Pen(Color.Black, 2); // Чёрная линия толщиной 2 пикселя
        //    g.DrawEllipse(pen2, ellipseRect2);
        //    SolidBrush brush2 = new SolidBrush(Color.FromArgb(100, 0, 255, 0));
        //    g.FillEllipse(brush2, ellipseRect2);
        //}

        private void Form4_Load(object sender, EventArgs e)
        {
            W = pictureBox1.Width;
            H = pictureBox1.Height;
            W1 = W / 2;
            H1 = H / 2;
            miny = -2;
            maxy = 2;
            minx = -2;
            maxx = 2;
            h = 0.001f;
            dx = W / (Math.Abs(maxx - minx));
            dy = H / (Math.Abs(maxy - miny));
        }
        public Form4()
        {
            InitializeComponent();
        }
    }
}