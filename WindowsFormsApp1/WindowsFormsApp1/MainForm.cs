using System.Drawing;
using ClassLibrary1;
using System;
using System.Numerics;
using System.Windows.Forms;
using Wall_E;
using System.Collections.Generic;


namespace Wall_E
{
    

    public partial class Formulario :Form
    {
      
        private Button botonDibujar;
        private Button botonCompilar;
        private RichTextBox entradaUsuario;
        private RichTextBox errores;
        private PictureBox areaGrafica;
        private List<Figura> figuras;

        
        

        
        public Formulario()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.botonDibujar = new Button();
            this.botonCompilar = new Button();
            this.entradaUsuario = new RichTextBox();
            this.errores = new RichTextBox();
            this.areaGrafica = new PictureBox();

            // Configuración del botón Dibujar
            this.botonDibujar.Text = "Dibujar";
            this.botonDibujar.Location = new System.Drawing.Point(10, 10);
            this.botonDibujar.Size = new Size(150, 75);
            this.botonDibujar.Font = new Font("Arial", 16, FontStyle.Bold);
            this.botonDibujar.BackColor = Color.LightBlue;
            this.botonDibujar.FlatStyle = FlatStyle.Popup;
            this.botonDibujar.Click += DrawButton_Click;

            // Configuración del botón Compilar
            this.botonCompilar.Text = "Compilar";
            this.botonCompilar.Location = new System.Drawing.Point(170, 10);
            this.botonCompilar.Size = new Size(150, 75);
            this.botonCompilar.Font = new Font("Arial", 16, FontStyle.Bold);
            this.botonCompilar.BackColor = Color.LightGreen;
            this.botonCompilar.FlatStyle = FlatStyle.Popup;
            this.botonCompilar.Click += CompileButton_Click;

            // Configuración de la entrada del usuario
            this.entradaUsuario.Location = new System.Drawing.Point(10, 100);
            this.entradaUsuario.Size = new Size(600, 300);
            this.entradaUsuario.Font = new Font("Arial", 14);
            this.entradaUsuario.BackColor = Color.LightYellow;
            this.entradaUsuario.BorderStyle = BorderStyle.Fixed3D;
            string valoringresado = this.entradaUsuario.Text;
            this.entradaUsuario.Enter += CajaTexto_Enter;
            //this.entradaUsuario.Leave += CajaTexto_Leave;


            // Configuración de la caja de errores
            this.errores.Location = new System.Drawing.Point(10, 410);
            this.errores.Size = new Size(600, 260);
            this.errores.Font = new Font("Arial", 14);
            this.errores.BackColor = Color.LightCoral;
            this.errores.BorderStyle = BorderStyle.Fixed3D;
            this.errores.ReadOnly = true;
            this.errores.Enabled = false;

            // Configuración del área gráfica
            this.areaGrafica.Location = new System.Drawing.Point(620, 10);
            this.areaGrafica.Size = new Size(730, 660);
            this.areaGrafica.BorderStyle = BorderStyle.Fixed3D;
            this.areaGrafica.BackColor = Color.LightGray;

            // Añadir los controles al formulario
            this.Controls.Add(this.botonDibujar);
            this.Controls.Add(this.botonCompilar);
            this.Controls.Add(this.entradaUsuario);
            this.Controls.Add(this.errores);
            this.Controls.Add(this.areaGrafica);

            // Configuración del formulario
            this.Text = "Mi Formulario";
            this.BackColor = Color.White;
            this.Size = new Size(1240, 550);

           
        }

       
        private void DrawButton_Click(object sender, EventArgs e)
        {
            
            // AST ast = sintaxis.Analizar();
            //  object resultado = ast.Evaluar(entorno);
            // Aqui el parser debe devolver una List<Figuras> que se le pasa como parametro al metodo
            // DibujarFiguras
            //DibujarFiguras();
            
        }

        private void CompileButton_Click(object sender, EventArgs e )
        {
            //List < Figura > figuras= new List<Figura>();
            //Coord cor = new Coord(100, 100);

            //ClassLibrary1.Point punto = new ClassLibrary1.Point("p1");
            //figuras.Add(punto);
            string hola = ObtenerValorCajaTexto();
            figuras = Compilar(hola);
            DibujarFiguras(figuras);
        }

        public string ObtenerValorCajaTexto()
        {
            // Este método retorna el valor de la caja de texto
            return entradaUsuario.Text;
        }

        public List<Figura> Compilar(string parametro)
        {
            AnalizadorLéxico lex = new AnalizadorLéxico(parametro);
            List<Token> tokens = lex.ObtenerTokens();

            AnalizadorSintáctico sintaxis = new AnalizadorSintáctico(tokens);
            List<Instruccion> instruccions = sintaxis.ParseInstructions();
            Entorno entorno = new Entorno();

            foreach (Instruccion i in instruccions)
            {
                i.Evaluate(entorno);
            }

            return entorno.figuras;
        }

        public void DibujarFiguras(List<Figura> figuras)
        {
           
            var g = areaGrafica.CreateGraphics();
            Pen p = new Pen(Color.Black);
            System.Drawing.Point punto1 = new System.Drawing.Point(100, 100);
            System.Drawing.Point punto2 = new System.Drawing.Point(200, 200);
            Linea line = new Linea(punto1, punto2);

            MessageBox.Show($"{figuras.Count}");
            MessageBox.Show($"{figuras[0].nombre}");

            foreach (var item in figuras)
            {

                switch (item.GetType().ToString())
                {

                    case "ClassLibrary1.Point":
                        DibujarPunto(g, ((ClassLibrary1.Point)item));
                        break;
                    case "ClassLibrary1.Circle":
                        DibujarCirculo(g, ((ClassLibrary1.Circle)item));
                        break;
                    case "ClassLibrary1.CircleFunction":
                        DibujarFuncionCirculo(g, ((ClassLibrary1.CircleFunction)item));
                        break;
                    case "ClassLibrary1.ArcFunction":
                        DibujarArco(g, p, ((ClassLibrary1.ArcFunction)item));
                        break;
                    case "ClassLibrary1.Line":
                        DibujarLinea(g, p, ((ClassLibrary1.Line)item));
                        break;
                    case "ClassLibrary1.FunctionLine":
                        DibujarFuncionLinea(g, p, ((ClassLibrary1.FunctionLine)item));
                        break;
                    case "ClassLibrary1.Ray":
                        DibujarRayo(g,p, ((ClassLibrary1.Ray)item));
                        break;
                    case "ClassLibrary1.RayFunction":
                        DibujarFuncionRayo(g, p, ((ClassLibrary1.RayFunction)item));
                        break;
                    case "ClassLibrary1.Segment":
                        DibujarSegmento(g, p , ((ClassLibrary1.Segment)item));
                        break;
                    case "ClassLibrary1.SegmentFunction":
                        DibujarFuncionSegmento(g, p, ((ClassLibrary1.SegmentFunction)item));
                        break;



                    default: throw new Exception("G");
                        
                     
                }
               
            }
            
        }

        private void CajaTexto_Enter(object sender, EventArgs e)
        {
            // Si el texto de la caja es el predeterminado, lo borra
            if (entradaUsuario.Text == "Escribe aquí tu texto")
            {
                entradaUsuario.Text = "";
            }
        }

        //private void CajaTexto_Leave(object sender, EventArgs e)
        //{
        //    valoringresado = this.entradaUsuario.Text;
        //    MessageBox.Show(valoringresado);
        //}

        public void DibujarPunto(Graphics g , ClassLibrary1.Point p)
        {
            //Punto hola = new Punto(300, 300);
            g.FillEllipse(Brushes.Black, p.Coord.X, p.Coord.Y, 7, 7);
        }

        public void DibujarCirculo(Graphics g , ClassLibrary1.Circle c)
        {
            //Circle circle = new Circle(100, 100, 100);

            // Dibuja el círculo
            g.DrawEllipse(Pens.Black, c.Centro.Coord.X, c.Centro.Coord.Y, c.Radio * 2, c.Radio * 2);

            // Dibuja el punto medio del círculo
            //g.FillEllipse(Brushes.Black, circle.X + circle.Radius, circle.Y + circle.Radius, 5, 5);

            //// Dibuja un punto sobre el círculo
            //g.FillEllipse(Brushes.Black, circle.X + circle.Radius, circle.Y, 5, 5);


        }

        public void DibujarFuncionCirculo(Graphics g, ClassLibrary1.CircleFunction c)
        {
            //Circle circle = new Circle(100, 100, 100);

            // Dibuja el círculo
            g.DrawEllipse(Pens.Black, c.P1.Coord.X, c.P1.Coord.Y, (int) c.Measure * 2, (int)c.Measure * 2);

            // Dibuja el punto medio del círculo
            //g.FillEllipse(Brushes.Black, circle.X + circle.Radius, circle.Y + circle.Radius, 5, 5);

            //// Dibuja un punto sobre el círculo
            //g.FillEllipse(Brushes.Black, circle.X + circle.Radius, circle.Y, 5, 5);


        }

        public void DibujarArco(Graphics g, Pen pen, ClassLibrary1.ArcFunction arc)
        {


           

            double distanciaMaxima = (Math.Sqrt(Math.Pow(areaGrafica.Width - arc.Centro.Coord.X, 2) + Math.Pow(areaGrafica.Height - arc.Centro.Coord.Y, 2)) * 10000);



            //Calcula los ángulos de las semirrectas
            float angulo1 = (float)Math.Atan2(arc.Punto2.Coord.Y - arc.Centro.Coord.Y, arc.Punto2.Coord.X - arc.Centro.Coord.X);
            float angulo2 = (float)Math.Atan2(arc.Punto3.Coord.Y - arc.Centro.Coord.Y, arc.Punto3.Coord.X - arc.Centro.Coord.X);

            //Convierte los ángulos a grados
            angulo1 = angulo1 * 180 / (float)Math.PI;
            angulo2 = angulo2 * 180 / (float)Math.PI;

            //Asegura que el arco se dibuje en dirección contraria a las manecillas del reloj
            if (angulo1 < angulo2)
            {
                angulo1 += 360;
            }

            //Calcula la amplitud del arco
            float amplitud = angulo1 - angulo2;

            Vector2 direccion = new Vector2(arc.Punto2.Coord.X - arc.Centro.Coord.X, arc.Punto2.Coord.Y - arc.Centro.Coord.Y);

            System.Drawing.Point punto4 = new System.Drawing.Point((int)(arc.Centro.Coord.X + direccion.X * distanciaMaxima), (int)(arc.Centro.Coord.Y + direccion.Y * distanciaMaxima));

            System.Drawing.Point centro = new System.Drawing.Point(arc.Centro.Coord.X, arc.Centro.Coord.Y);
            //Dibuja el rayo desde Punto1 hasta el borde del formulario.
            //g.DrawLine(pen, centro, punto4);

            Vector2 direccion1 = new Vector2(arc.Punto3.Coord.X - arc.Centro.Coord.X, arc.Punto3.Coord.Y - arc.Centro.Coord.Y);



            System.Drawing.Point punto5 = new System.Drawing.Point((int)(arc.Centro.Coord.X + direccion1.X * distanciaMaxima), (int)(arc.Centro.Coord.Y + direccion1.Y * distanciaMaxima));

            //Dibuja el rayo desde Punto1 hasta el borde del formulario.
            //g.DrawLine(pen, centro, punto5);

            //DibujarLinea(g, pen, linea1);
            //DibujarLinea(g, pen, linea2);
            //Dibuja el arco
            g.DrawArc(pen,(int) arc.Centro.Coord.X - (int)arc.Measure, (int)arc.Centro.Coord.Y -(int) arc.Measure,(int) arc.Measure * 2,(int)arc.Measure * 2, angulo2, amplitud);

        }

        public virtual void DibujarLinea(Graphics g, Pen pen,  ClassLibrary1.Line linea)
        {

            // Calculate the vector from punto1 to punto2
            Vector2 direccion = new Vector2(linea.Punto2.Coord.X - linea.Punto1.Coord.X, linea.Punto2.Coord.Y - linea.Punto1.Coord.Y);

            // Normalize the vector to get a unit vector
            direccion = Vector2.Normalize(direccion);

            // Calculate the points on the edges of the drawing area
            double distanciaMaxima = (Math.Sqrt(Math.Pow(areaGrafica.Width - linea.Punto1.Coord.X, 2) + Math.Pow(areaGrafica.Height - linea.Punto1.Coord.Y, 2)) * 10000);

            // Calculate the points on the edges of the drawing area
            System.Drawing.Point punto3 = new System.Drawing.Point((int)(linea.Punto1.Coord.X + direccion.X * distanciaMaxima), (int)(linea.Punto1.Coord.Y + direccion.Y * distanciaMaxima));
            System.Drawing.Point punto4 = new System.Drawing.Point((int)(linea.Punto1.Coord.X - direccion.X * distanciaMaxima), (int)(linea.Punto1.Coord.Y - direccion.Y * distanciaMaxima));

            // Draw the points of the line
            g.FillEllipse(Brushes.Black, linea.Punto1.Coord.X - 2, linea.Punto1.Coord.Y - 2, 5, 5);
            g.FillEllipse(Brushes.Black, linea.Punto2.Coord.X - 2, linea.Punto2.Coord.Y - 2, 5, 5);
           
            // Draw the lines

            System.Drawing.Point punto1=new System.Drawing.Point((int)linea.Punto1.Coord.X,(int)linea.Punto1.Coord.Y);

            g.DrawLine(pen, punto1, punto4);
            g.DrawLine(pen, punto1, punto3);



        }

        public virtual void DibujarFuncionLinea(Graphics g, Pen pen, ClassLibrary1.FunctionLine linea)
        {

            // Calculate the vector from punto1 to punto2
            Vector2 direccion = new Vector2(linea.Punto2.Coord.X - linea.Punto1.Coord.X, linea.Punto2.Coord.Y - linea.Punto1.Coord.Y);

            // Normalize the vector to get a unit vector
            direccion = Vector2.Normalize(direccion);

            // Calculate the points on the edges of the drawing area
            double distanciaMaxima = (Math.Sqrt(Math.Pow(areaGrafica.Width - linea.Punto1.Coord.X, 2) + Math.Pow(areaGrafica.Height - linea.Punto1.Coord.Y, 2)) * 10000);

            // Calculate the points on the edges of the drawing area
            System.Drawing.Point punto3 = new System.Drawing.Point((int)(linea.Punto1.Coord.X + direccion.X * distanciaMaxima), (int)(linea.Punto1.Coord.Y + direccion.Y * distanciaMaxima));
            System.Drawing.Point punto4 = new System.Drawing.Point((int)(linea.Punto1.Coord.X - direccion.X * distanciaMaxima), (int)(linea.Punto1.Coord.Y - direccion.Y * distanciaMaxima));

            // Draw the points of the line
            g.FillEllipse(Brushes.Black, linea.Punto1.Coord.X - 2, linea.Punto1.Coord.Y - 2, 5, 5);
            g.FillEllipse(Brushes.Black, linea.Punto2.Coord.X - 2, linea.Punto2.Coord.Y - 2, 5, 5);

            // Draw the lines

            System.Drawing.Point punto1 = new System.Drawing.Point((int)linea.Punto1.Coord.X, (int)linea.Punto1.Coord.Y);

            g.DrawLine(pen, punto1, punto4);
            g.DrawLine(pen, punto1, punto3);



        }
        public void DibujarSegmento(Graphics g, Pen pen , ClassLibrary1.Segment segmento)
        {
            System.Drawing.Point punto1 = new System.Drawing.Point(segmento.Punto1.Coord.X, segmento.Punto1.Coord.Y);
            System.Drawing.Point punto2 = new System.Drawing.Point(segmento.Punto2.Coord.X, segmento.Punto2.Coord.Y);

            // Dibuja el segmento desde Punto1 hasta Punto2.
            g.DrawLine(pen, punto1, punto2);
            g.FillEllipse(Brushes.Black, punto1.X, punto1.Y, 5, 5);

            // Dibuja el punto 2 de la linea
            g.FillEllipse(Brushes.Black, punto2.X, punto2.Y, 5, 5);
        }

        public void DibujarFuncionSegmento(Graphics g, Pen pen, ClassLibrary1.SegmentFunction segmento)
        {
            System.Drawing.Point punto1 = new System.Drawing.Point(segmento.Punto1.Coord.X, segmento.Punto1.Coord.Y);
            System.Drawing.Point punto2 = new System.Drawing.Point(segmento.Punto2.Coord.X, segmento.Punto2.Coord.Y);

            // Dibuja el segmento desde Punto1 hasta Punto2.
            g.DrawLine(pen, punto1, punto2);
            g.FillEllipse(Brushes.Black, punto1.X, punto1.Y, 5, 5);

            // Dibuja el punto 2 de la linea
            g.FillEllipse(Brushes.Black, punto2.X, punto2.Y, 5, 5);
        }




        public void DibujarRayo(Graphics g, Pen pen , ClassLibrary1.Ray rayo)
        {


            Vector2 direccion = new Vector2(rayo.Punto2.Coord.X - rayo.Punto1.Coord.X, rayo.Punto2.Coord.Y - rayo.Punto1.Coord.Y);
            direccion = Vector2.Normalize(direccion);

            double distanciaMaxima = (Math.Sqrt(Math.Pow(areaGrafica.Width - rayo.Punto1.Coord.X, 2) + Math.Pow(areaGrafica.Height - rayo.Punto1.Coord.Y, 2)) * 10000);

            // Calculate the points on the edges of the drawing area
            System.Drawing.Point punto3 = new System.Drawing.Point((int)(rayo.Punto1.Coord.X + direccion.X * distanciaMaxima), (int)(rayo.Punto1.Coord.Y + direccion.Y * distanciaMaxima));


            System.Drawing.Point punto1 = new System.Drawing.Point(rayo.Punto1.Coord.X, rayo.Punto1.Coord.Y);
            // Dibuja el rayo desde Punto1 hasta el borde del formulario.
            g.DrawLine(pen, punto1, punto3);

            g.FillEllipse(Brushes.Black, rayo.Punto1.Coord.X, rayo.Punto1.Coord.Y, 5, 5);

            // Dibuja el punto 2 de la linea
            g.FillEllipse(Brushes.Black, rayo.Punto2.Coord.X, rayo.Punto2.Coord.Y, 5, 5);
        }

        public void DibujarFuncionRayo(Graphics g, Pen pen, ClassLibrary1.RayFunction rayo)
        {


            Vector2 direccion = new Vector2(rayo.Punto2.Coord.X - rayo.Punto1.Coord.X, rayo.Punto2.Coord.Y - rayo.Punto1.Coord.Y);
            direccion = Vector2.Normalize(direccion);

            double distanciaMaxima = (Math.Sqrt(Math.Pow(areaGrafica.Width - rayo.Punto1.Coord.X, 2) + Math.Pow(areaGrafica.Height - rayo.Punto1.Coord.Y, 2)) * 10000);

            // Calculate the points on the edges of the drawing area
            System.Drawing.Point punto3 = new System.Drawing.Point((int)(rayo.Punto1.Coord.X + direccion.X * distanciaMaxima), (int)(rayo.Punto1.Coord.Y + direccion.Y * distanciaMaxima));


            System.Drawing.Point punto1 = new System.Drawing.Point(rayo.Punto1.Coord.X, rayo.Punto1.Coord.Y);
            // Dibuja el rayo desde Punto1 hasta el borde del formulario.
            g.DrawLine(pen, punto1, punto3);

            g.FillEllipse(Brushes.Black, rayo.Punto1.Coord.X, rayo.Punto1.Coord.Y, 5, 5);

            // Dibuja el punto 2 de la linea
            g.FillEllipse(Brushes.Black, rayo.Punto2.Coord.X, rayo.Punto2.Coord.Y, 5, 5);
        }


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Formulario());
        }
    }
    
    
}

