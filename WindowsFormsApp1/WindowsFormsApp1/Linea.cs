using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Drawing;

namespace Wall_E
{
  
    public class Linea
    {
        public Point Punto1 { get; set; }
        public Point Punto2 { get; set; }

        public Linea(Point punto1, Point punto2)
        {
            Punto1 = punto1;
            Punto2 = punto2;
        }

        public virtual void Dibujar(Graphics g, Pen pen)
        {
            //Point punto1 = new Point(100, 100);
            //Point punto2 = new Point(200, 200);

            //// Calcula el vector que va del punto1 al punto2
            //Vector2 direccion = new Vector2(punto2.X - punto1.X, punto2.Y - punto1.Y);

            //// Normaliza el vector para obtener un vector unitario
            //direccion = Vector2.Normalize(direccion);

            //// Calcula los puntos en los bordes del área de dibujo
            //Point punto3 = new Point((int)(punto1.X + direccion.X * g.VisibleClipBounds.Width), (int)(punto1.Y + direccion.Y * g.VisibleClipBounds.Height));
            //Point punto4 = new Point((int)(punto1.X - direccion.X * g.VisibleClipBounds.Width), (int)(punto1.Y - direccion.Y * g.VisibleClipBounds.Height));

            //// Dibuja las líneas
            //g.DrawLine(pen, punto1, punto3);
            //g.DrawLine(pen, punto1, punto4);


            //g.FillEllipse(Brushes.Black, punto1.X, punto1.Y, 5, 5);

            //// Dibuja el punto 2 de la linea
            //g.FillEllipse(Brushes.Black, punto2.X, punto2.Y, 5, 5);


            //Point punto1 = new Point(100, 100);
            //            Point punto2 = new Point(200, 200);

            //            // Calculate the vector from punto1 to punto2
            //            Vector2 direccion = new Vector2(punto2.X - punto1.X, punto2.Y - punto1.Y);

            //            // Normalize the vector to get a unit vector
            //            direccion = Vector2.Normalize(direccion);

            //            // Calculate the points at the edges of the drawing area
            //            Point punto3 = new Point((int)(punto1.X + direccion.X * g.VisibleClipBounds.Width), (int)(punto1.Y + direccion.Y * g.VisibleClipBounds.Height));
            //            Point punto4 = new Point((int)(punto1.X - direccion.X * g.VisibleClipBounds.Width), (int)(punto1.Y - direccion.Y * g.VisibleClipBounds.Height));

            //            // Draw the lines
            //            g.DrawLine(pen, punto1, punto3);
            //            g.DrawLine(pen, punto1, punto4);

            //            // Draw the punto1 of the line
            //            g.FillEllipse(Brushes.Black, punto1.X - 2, punto1.Y - 2, 5, 5);

            //            // Draw the punto2 of the line
            //            g.FillEllipse(Brushes.Black, punto2.X - 2, punto2.Y - 2, 5, 5);

            //Point punto1 = new Point(100, 100);
            //Point punto2 = new Point(200, 200);

            //// Calcula el vector que va del punto1 al punto2
            //Vector2 direccion = new Vector2(punto2.X - punto1.X, punto2.Y - punto1.Y);

            //// Normaliza el vector para obtener un vector unitario
            //direccion = Vector2.Normalize(direccion);

            //// Calcula los puntos en los bordes del área de dibujo
            //Point punto3 = new Point((int)(punto1.X + direccion.X * areaGrafica.Width), (int)(punto1.Y + direccion.Y * areaGrafica.Height));
            //Point punto4 = new Point((int)(punto1.X - direccion.X * areaGrafica.Width), (int)(punto1.Y - direccion.Y * areaGrafica.Height));

            //// Dibuja las líneas
            //g.DrawLine(pen, punto1, punto3);
            //g.DrawLine(pen, punto1, punto4);

            //// Dibuja el punto1 de la línea
            //g.FillEllipse(Brushes.Black, punto1.X - 2, punto1.Y - 2, 5, 5);

            //// Dibuja el punto2 de la línea
            //g.FillEllipse(Brushes.Black, punto2.X - 2, punto2.Y - 2, 5, 5);
        }
    }

}

