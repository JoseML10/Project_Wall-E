using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Wall_E
{

    public class Circle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }

        public Circle(int x, int y, int radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public void Dibujar(Graphics g)
        {
            Circle circle = new Circle(100, 100, 100);

            // Dibuja el círculo
            g.DrawEllipse(Pens.Black, circle.X, circle.Y, circle.Radius * 2, circle.Radius * 2);

            // Dibuja el punto medio del círculo
            g.FillEllipse(Brushes.Black , circle.X + circle.Radius, circle.Y + circle.Radius,  5,5);

            // Dibuja un punto sobre el círculo
            g.FillEllipse(Brushes.Black , circle.X + circle.Radius, circle.Y, 5, 5);

           
        }
    }
}

