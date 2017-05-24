using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int x1, y1, x2, y2;
        private double r, a, b, t;
        private Pen pen1 = new Pen(Color.Black, 1);
        float tension = 1.0F; //Значение, определяющее степень изгиба кривой между контрольными точками 
        //EventArgs - это класс, дающий возможность передать какую-нибудь дополнительную информацию обработчику (например, текущие координаты мыши при событии MouseMove). 
        //sender - это объект, который вызвал событие. 

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true; //запуск таймера автоматически 
            x1 = this.Width / 2; //центр рисунка по Х 
            y1 = this.Height / 2; //центр по У 

            a = 1;
            b = 0.1;
            r = a * Math.Exp(b * t);
            t = 1 / b * Math.Log10(r / a);
            //уравнение логарифмической спирали 
            x2 = x1 + (int)(r * Math.Cos(t));
            y2 = y1 - (int)(r * Math.Sin(t));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            t += 0.05;
            r = a * Math.Exp(b * t);
            //уравнение логарифмической спирали 
            x2 = x1 + (int)(r * Math.Cos(t));
            y2 = y1 - (int)(r * Math.Sin(t));
            DrawCurve();

            //метод DrawСurwe для следа 
         }

        void DrawCurve()
        {
            using (Graphics g = this.CreateGraphics())
            {
                //метод DrawCurve - отрисиовка графика по заданым точкам 
                Point point = new Point(x2, y2);
                Point point1 = new Point(x2 + 1, y2);
                Point[] curvePoints = { point, point1 };
                g.DrawCurve(pen1, curvePoints, tension);
            }
        }
    }
}
