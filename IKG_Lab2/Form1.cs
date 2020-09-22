using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IKG_Lab2
{
    public partial class Form1 : Form
    {
        // Объявляем объект "g" класса Graphics
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            // Предоставляем объекту "g" класса Graphics
            // возможность рисования на pictureBox1:
            g = pictureBox1.CreateGraphics();
        }

        // ********* Стандарт страничного пространства – Pixel ********
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // экранные координаты
            int ex = 0, ey = 0, old_ex = 0, old_ey = 0;
            // математические значения
            double x = 0, y = 0;
            // цвет осей и рамки
            Pen axesPen = new Pen(Color.Aquamarine, 1);
            // цвет графика
            Pen graphicsPen = new Pen(Color.MidnightBlue);
            // Устанавливаем фон pictureBox1 в именованный цвет
            pictureBox1.BackColor = Color.FromName("Azure");
            pictureBox1.Refresh();
            // Стандарт страничного пространства в Pixel
            g.PageUnit = GraphicsUnit.Pixel;
            //Рисуем прямоугольник:
            g.DrawRectangle(axesPen, 0, 0,
            pictureBox1.Size.Width - 1, pictureBox1.Size.Height - 1);
            // Рисуем оси
            g.DrawLine(axesPen, 0, (pictureBox1.Size.Height - 1) / 2,
            pictureBox1.Size.Width - 1, (pictureBox1.Size.Height - 1) / 2);
            g.DrawLine(axesPen, (pictureBox1.Size.Width - 1) / 2, 0,
            (pictureBox1.Size.Width - 1) / 2, pictureBox1.Size.Height - 1);
            // Рисуем график функции y=x*x*x+2*x*x+x
            x = -2;
            for (ex = 0; ex <= (pictureBox1.Size.Width - 1); ex++)
            {
                y = x * x * x + 2 * x * x + x;
                ey = (pictureBox1.Size.Height - 1)/2 - (Convert.ToInt16(y*80));
                if (ex != 0) { g.DrawLine(graphicsPen, old_ex, old_ey, ex, ey); }
                old_ex = ex; old_ey = ey;
                x = x + 4.0/(pictureBox1.Size.Width - 1);
            }
        }

        // ******** Стандарт страничного пространства – Millimeter *****
        private void button2_Click(object sender, EventArgs e)
        {
            int ex = 0, ey = 0, old_ex = 0, old_ey = 0;
            double x = 0, y = 0;
            // Стандарт страничного пространства Millimeter
            g.PageUnit = GraphicsUnit.Millimeter;
            Pen axesPen = new Pen(Color.Coral, 0.1f);
            Pen graphicsPen = new Pen(Color.FromArgb(0, 0, 255), 0.1f);
            // Устанавливаем фон pictureBox1 в именованный цвет
            pictureBox1.BackColor = Color.FromKnownColor(KnownColor.MistyRose);
            pictureBox1.Refresh();
            //Получаем ширину и высоту прямоугольника в миллиметрах

            int WidthInMM = Convert.ToInt16((pictureBox1.Size.Width - 1) /
            g.DpiX * 25.4);
            int HeightInMM = Convert.ToInt16((pictureBox1.Size.Height - 2) /
            g.DpiY * 25.4);

            //Рисуем прямоугольник
            g.DrawRectangle(axesPen, 0, 0, WidthInMM, HeightInMM);
            // Рисуем оси
            g.DrawLine(axesPen, 0, HeightInMM / 2, WidthInMM, HeightInMM / 2);
            g.DrawLine(axesPen, WidthInMM / 2, 0, WidthInMM / 2, HeightInMM);
            // Рисуем график функции y=x*x*x+2*x*x+x
            x = -2;
            for (ex = 0; ex <= WidthInMM; ex++)
            {
                y = x * x * x + 2 * x * x + x;
                ey = HeightInMM/2 - (Convert.ToInt16(y * Convert.ToSingle(82 / g.DpiX * 25.4)));
                if (ex != 0) { g.DrawLine(graphicsPen, old_ex, old_ey, ex, ey); }
                old_ex = ex; old_ey = ey;
                x = x + 4.0 / WidthInMM;
            }
        }
        // ********** Стандарт страничного пространства – Inch ******
        private void button3_Click(object sender, EventArgs e)
        {
            float ex = 0, old_ex = 0, ey = 0, old_ey = 0, x = 0, y = 0, shag = 0;
            // Стандарт страничного пространства Inch
            g.PageUnit = GraphicsUnit.Inch;
            Pen axesPen = new Pen(Color.Orange, 0.01f);
            Pen graphicsPen = new Pen(Color.FromArgb(255, 0, 0), 0.01f);
            // Устанавливаем фон pictureBox1 в именованный цвет
            pictureBox1.BackColor = Color.FromName("LightCyan");
            pictureBox1.Refresh();
            // Получаем ширину и высоту прямоугольника в дюймах
            float WidthInInches = (pictureBox1.Size.Width - 1) / g.DpiX;
            float HeightInInches = (pictureBox1.Size.Height - 1) / g.DpiY;
            // Рисуем прямоугольник:
            g.DrawRectangle(axesPen, 0, 0, WidthInInches, HeightInInches);
            // Рисуем оси
            g.DrawLine(axesPen, 0, HeightInInches / 2, WidthInInches, HeightInInches / 2);
            g.DrawLine(axesPen, WidthInInches / 2, 0, WidthInInches / 2, HeightInInches);

            // Рисуем график функции y=x*x*x+2*x*x+x
            x = -2;
            while (ex <= WidthInInches)
            {
                y = Convert.ToSingle(x * x * x + 2 * x * x + x);
                ey = HeightInInches / 2 - Convert.ToSingle(y/1.18);
                Console.WriteLine(Convert.ToSingle(y));
                if (ex != 0) { g.DrawLine(graphicsPen, old_ex, old_ey, ex, ey); }
                old_ex = ex; old_ey = ey;
                ex = ex + 1;
                x = x + 4.0f / WidthInInches;
            }
        }
    }
}
