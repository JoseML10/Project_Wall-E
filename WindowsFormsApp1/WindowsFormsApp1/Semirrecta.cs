using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Wall_E
{

    public class Semirrecta
    {
        public Point Inicio { get; set; }
        public float Angulo { get; set; }

        public Semirrecta(Point inicio, float angulo)
        {
            Inicio = inicio;
            Angulo = angulo;
        }
    }

}

