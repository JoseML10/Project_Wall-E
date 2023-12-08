using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace Wall_E
{
    public class Arco
    {
        public float Radio { get; set; }
        public Point Centro { get; }
        public Point Punto2 { get; }
        public Point Punto3 { get; }
        public double Medida { get; }

        public Arco (Point centro , Point punto2 , Point punto3 , double medida)
        {
            Centro = centro;
            Punto2 = punto2;
            Punto3 = punto3;
            Medida = medida;
        }

        public void Dibujar(Graphics g, Pen pen)
        {
            Point centro = new Point(200, 200);
            Point punto2=new Point(100, 100);
            Point punto3 = new Point(300, 300);
            int radio = 99;
                
          
                // Calcula los ángulos de las semirrectas
                float angulo1 = (float)Math.Atan2(punto2.Y - centro.Y, punto2.X - centro.X);
                float angulo2 = (float)Math.Atan2(punto3.Y - centro.Y, punto3.X - centro.X);

                // Convierte los ángulos a grados
                angulo1 = angulo1 * 180 / (float)Math.PI;
                angulo2 = angulo2 * 180 / (float)Math.PI;

                // Asegura que el arco se dibuje en dirección contraria a las manecillas del reloj
                if (angulo1 < angulo2)
                {
                    angulo1 += 360;
                }

                // Calcula la amplitud del arco
                float amplitud = angulo1 - angulo2;

            Vector2 direccion = new Vector2(punto2.X - centro.X, punto2.Y - centro.Y);


            Point punto4 = new Point((int)(centro.X + direccion.X -20 /** g.VisibleClipBounds.Width*/), (int)(centro.Y + direccion.Y -20/** g.VisibleClipBounds.Height*/));

            // Dibuja el rayo desde Punto1 hasta el borde del formulario.
            g.DrawLine(pen, centro, punto4);

            Vector2 direccion1 = new Vector2(punto3.X - centro.X, punto3.Y - centro.Y);

            Point punto5 = new Point((int)(centro.X + direccion1.X +20 /** g.VisibleClipBounds.Width*/), (int)(centro.Y + direccion1.Y +20/* * g.VisibleClipBounds.Height*/));

            // Dibuja el rayo desde Punto1 hasta el borde del formulario.
            g.DrawLine(pen, centro, punto5);

            // Dibuja el arco
            g.FillEllipse(Brushes.Black, 100,100, 5, 5);
            g.FillEllipse(Brushes.Black, 200, 200, 5, 5);
            g.FillEllipse(Brushes.Black, 300, 300, 5, 5);
            g.DrawArc(pen, centro.X - radio, centro.Y - radio, radio * 2, radio * 2, angulo2, amplitud);
            
        }
    }
}