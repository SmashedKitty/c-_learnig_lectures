/*
Добавление ZedGraph:
1)В обозревателе решений перейдите во вкладку ссылки, нажмите правой кнопкой мыши на папке, выберете  "Добавить ссылку...".
  При помощи кнопки "Обзор"  выберете  файл ZedGraph.dll

2)Перейдите в конструктор формы. На панели элементов нажмите правой кнопкой мыши, из всплывающего меню выберете "Выбрать элементы..." 
  Во вкладке  "Компоненты .Net Framework" при помощи кнопки "Обзор" добавьте файл ZedGraph.dll, отметьте его галочкой и выделите курсором мыши. 
  Нажмите "Ок", на панели элементов должен появиться новый элемент "ZedGraphControl".

3)Добавьте директиву using ZedGraph;
 */

using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

using ZedGraph; //добавляем ZedGraph


namespace Program1
{
    public partial class Form3 : Form
    {
        private readonly double min = -10, max = 10, h = 0.2f; //начальные параметры, min - минимальное значение х, max - максимальное, h - шаг

        //функция

        public double F1(double x)
        {
            return -(2 * x - Math.Tan(x));
        }

        public double F21(double x)
        {
            if(x > 0)
                return 2 - 1 / (Math.Pow(Math.Cos(x), 2));
            return 0;

        }
        public double F22(double x)
        {
            return 2 - 1 / (Math.Pow(Math.Cos(x), 2));

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            CreateGraph(zedGraphControl1); //прорисовка графика
            SetSize(); //установление размера ZedGraphControl (заполняет всю форму)
            this.label1.Location = new Point(0, this.Height - this.label1.Height - 40);
        }

        public Form3()
        {
            InitializeComponent();
        }

        //размер ZedGraphControl подстраивается под изменение размера формы
        private void Form1_Resize(object sender, EventArgs e)
        {
            SetSize();
            this.label1.Location = new Point(0, this.Height - this.label1.Height - 40);
        }

        //коорди
        private void zedGraphControl1_MouseMove(object sender, MouseEventArgs e)
        {
            double x, y;
            zedGraphControl1.GraphPane.ReverseTransform(e.Location, out x, out y);
            string text = "Точки экстремума: 1 - П/2 (min), -1 + П/2 (max)";
            label1.Text = text;
        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }




        
        private void CreateGraph(ZedGraphControl zgc)
        {
        //    получим панель для рисования
            GraphPane myPane = zgc.GraphPane;

        //    заголовок и подписи осей
            myPane.Title.Text = "График";
            myPane.XAxis.Title.Text = "X";
            myPane.YAxis.Title.Text = "Y";

            double x1, y1;
            double x2, y2;  //точки, по которым будет рисоваться график
            double x3, y3;  //точки, по которым будет рисоваться график

            PointPairList list1 = new PointPairList(); //список точек
            PointPairList list2 = new PointPairList(); //список точек
            PointPairList list3 = new PointPairList(); //список точек


        //    заполнение списка
            for (double i = min; i < max; i++)
            {
                x1 = i + h;
                y1 = F1(x1);
                list1.Add(x1, y1);
            }

            for (double i = min; i < 0; i++)
            {
                x2 = i + h;
                y2 = F22(x2);
                list2.Add(x2, y2);
            }
            for (double i = 0; i < max; i++)
            {
                x3 = i + h;
                if (x3 < 0)
                {

                    y3 = F22(x3);
                    list3.Add(x3, y3);
                }
            }

            LineItem myCurve1 = myPane.AddCurve("Функция", list1, Color.Green, SymbolType.Star); //прорисовка графика по списку точек
            LineItem myCurve2 = myPane.AddCurve("Производная", list2, Color.Blue, SymbolType.Star); //прорисовка графика по списку точек
            LineItem myCurve3 = myPane.AddCurve("Производная", list3, Color.Blue, SymbolType.Star); //прорисовка графика по списку точек

            zgc.AxisChange(); //обновляем данные об осях, иначе на рисунке будет показана только та часть графика, которая умещается в интервалы по осям, установленные по умолчанию
        }

        private void SetSize()
        {
            zedGraphControl1.Location = new Point(10, 10);
            zedGraphControl1.Size = new Size(ClientRectangle.Width - 20,
                                    ClientRectangle.Height - 20);
        }
    }
}
