using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Wall_E
{
   
    public class Punto
    {
        public Punto (int x , int y)
        {
            X = x;
            Y = y;


        }

        public int X { get; }
        public int Y { get; }
        public void Dibujar(Graphics g)
        {
            Punto hola = new Punto(300, 300);
            g.FillEllipse(Brushes.Black, hola.X, hola.Y, 7, 7);
        }

    }
    
       
    
}