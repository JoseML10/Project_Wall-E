using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Numerics;

namespace Wall_E
{
    public class Rayo : Linea
    {
        public Rayo(Point punto1, Point punto2) : base(punto1, punto2)
        {
        }

        public override void Dibujar(Graphics g, Pen pen)
        {

            Point punto1 = new Point(100, 100);
            Point punto2 = new Point(200, 200);

            Vector2 direccion = new Vector2(punto2.X - punto1.X, punto2.Y - punto1.Y);

            Point punto3 = new Point((int)(punto1.X + direccion.X * g.VisibleClipBounds.Width), (int)(punto1.Y + direccion.Y * g.VisibleClipBounds.Height));

            // Dibuja el rayo desde Punto1 hasta el borde del formulario.
            g.DrawLine(pen, punto1,punto3);

            g.FillEllipse(Brushes.Black, punto1.X, punto1.Y, 5, 5);

            // Dibuja el punto 2 de la linea
            g.FillEllipse(Brushes.Black, punto2.X, punto2.Y, 5, 5);
        }
    }
}

