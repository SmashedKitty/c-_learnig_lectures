using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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



            // Задание радиуса и центра окружности
            float radius = 2.5f; // Радиус окружности
            float centerX = 0;   // Центр по оси X
            float centerY = 0;   // Центр по оси Y

            // Перевод координат в клиентскую область формы
            // Учитывая, что (0,0) в графике формы находится в левом верхнем углу
            float clientCenterX = this.ClientSize.Width / 2;
           float clientCenterY = this.ClientSize.Height / 2;

           // Преобразование радиуса в пиксели (допустим, 100 пикселей = 1 единица)
            float scale = 50f;
            float pixelRadius = radius * scale;

            // Прямоугольник для отрисовки окружности
            RectangleF circleRect = new RectangleF(
                clientCenterX - pixelRadius,
                clientCenterY - pixelRadius,
                pixelRadius * 2,
                pixelRadius * 2
            );

            // Рисование окружности
            Pen pen = new Pen(Color.Black, 2); // Чёрная линия толщиной 2 пикселя
            SolidBrush brush = new SolidBrush(Color.FromArgb(100, 0, 255, 0));
            g.DrawEllipse(pen, circleRect);
            g.FillEllipse(brush, circleRect);

            // Полуоси эллипса
            float semiMajorAxis = 3f; // b = 3 (по оси Y)
            float semiMinorAxis = 2f; // a = 2 (по оси X)

            // Перевод центра эллипса в клиентскую область формы
            float clientCenterX2 = this.ClientSize.Width / 2;
            float clientCenterY2 = this.ClientSize.Height / 2;

            // Преобразование единиц измерения в пиксели (например, 100 пикселей = 1 единица)
            float scale1 = 50f;
            float pixelSemiMajorAxis = semiMajorAxis * scale;
            float pixelSemiMinorAxis = semiMinorAxis * scale;

            // Прямоугольник для отрисовки эллипса
            RectangleF ellipseRect2 = new RectangleF(
                clientCenterX2 - pixelSemiMinorAxis,
                clientCenterY2 - pixelSemiMajorAxis,
                pixelSemiMinorAxis * 2,
                pixelSemiMajorAxis * 2
            );

            // Рисование эллипса
            Pen pen2 = new Pen(Color.Black, 2); // Чёрная линия толщиной 2 пикселя
            g.DrawEllipse(pen2, ellipseRect2);
            SolidBrush brush2 = new SolidBrush(Color.FromArgb(100, 0, 255, 0));
            g.FillEllipse(brush2, ellipseRect2);

            //здесь рисуется сим разность
            // Создание путей для круга и эллипса
            GraphicsPath circlePath = new GraphicsPath();
            circlePath.AddEllipse(circleRect);

            GraphicsPath ellipsePath = new GraphicsPath();
            ellipsePath.AddEllipse(ellipseRect2);

            // Определение пересечения
            Region circleRegion = new Region(circlePath);
            Region ellipseRegion = new Region(ellipsePath);
            circleRegion.Intersect(ellipseRegion);

            // Отрисовка области пересечения
            using (Brush intersectBrush = new SolidBrush(Color.FromArgb(255, 255, 255, 255)))
            {
                g.FillRegion(intersectBrush, circleRegion);
            }
        }

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