using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Wall_E
{
    public class Segmento : Linea
    {
        public Segmento(Point punto1, Point punto2) : base(punto1, punto2)
        {
        }

        public override void Dibujar(Graphics g, Pen pen)
        {
            Point punto1 = new Point(100, 100);
            Point punto2 = new Point(200, 200);

            // Dibuja el segmento desde Punto1 hasta Punto2.
            g.DrawLine(pen, punto1, punto2);
            g.FillEllipse(Brushes.Black, punto1.X, punto1.Y, 5, 5);

            // Dibuja el punto 2 de la linea
            g.FillEllipse(Brushes.Black, punto2.X, punto2.Y, 5, 5);
        }
    }
}