using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace ClassLibrary1
{
    public abstract class Instruccion
    {
        public abstract object Evaluate(Entorno entorno);
    }

    public sealed class Identifier : Instruccion
    {
        public string name {get;}

        public Identifier(string name)
        {
            this.name = name ;
        }
        public override object Evaluate(Entorno entorno)
        {
           return entorno.BuscarVariable(name).Value;
        }
    }

    public sealed class Draw : Instruccion

    {   
        public Instruccion ToDraw {get;}

        public Draw( Instruccion ToDraw)
        {
           this.ToDraw = ToDraw;
        }
        public override object Evaluate(Entorno entorno)
        {
            
            entorno.figuras.Add((Figura)ToDraw.Evaluate(entorno));
            
            return null;


        }
    }



    public abstract class Funcion : Instruccion
    {

    }


    public sealed class FunctionLine : Figura
    {

        public Point Punto1 { get; }
        public Point Punto2 { get; }

        public override string nombre { get; set; }

        public FunctionLine(Point P1, Point P2)
        {

            this.Punto1 = P1;
            this.Punto2 = P2;

        }

        public override object Evaluate(Entorno entorno)
        {
            //this.nombre = "line";
            //var point = new Variable(nombre, this);
            //entorno.DefinirVariable(point);
            //entorno.figuras.Add((Figura)this);
            return this;

        }
    }

    public sealed class SegmentFunction : Figura
    {

        public Point Punto1 { get; }
        public Point Punto2 { get; }
        public override string nombre { get; set ; }

        public SegmentFunction(Point P1, Point P2)
        {

            this.Punto1 = P1;
            this.Punto2 = P2;

        }

        public override object Evaluate(Entorno entorno)
        {
            return this;
        }
    }

    public sealed class RayFunction : Figura
    {

        public Point Punto1 { get; }
        public Point Punto2 { get; }
        public override string nombre { get; set; }

        public RayFunction(Point P1, Point P2)
        {

            this.Punto1 = P1;
            this.Punto2 = P2;

        }

        public override object Evaluate(Entorno entorno)
        {
            return this;
        }
    }


    public sealed class MeasureFunction : Funcion
    {

        public Point P1 { get; }
        public Point P2 { get; }

        public MeasureFunction(Point P1, Point P2)
        {

            this.P1 = P1;
            this.P2 = P2;

        }

        public override object Evaluate(Entorno entorno)
        {
            throw new NotImplementedException();
        }
    }

    public sealed class ArcFunction : Figura
    {

        public override string  nombre { get; set ;}

        public Point Centro { get; }
        public Point Punto2 { get; }

        public Point Punto3 { get; }
        public double Measure { get; }

        public ArcFunction(Point P1, Point P2, Point P3, double Measure)
        {

            Centro = P1;
            this.Punto2 = P2;
            this.Punto3 = P3;
            this.Measure = Measure;

        }

        public override object Evaluate(Entorno entorno)
        {
            return this;
        }

        
    }

    public sealed class IntersectFunction : Funcion
    {

        public Figura Figure1 { get; }
        public Figura Figure2 { get; }


        public IntersectFunction(Figura Figure1, Figura Figure2)
        {

            this.Figure1 = Figure1;
            this.Figure2 = Figure2;


        }

        public override object Evaluate(Entorno entorno)
        {
            throw new NotImplementedException();
        }
    }

    // public class Draw
    // {
    //     public Token Nombre { get; }
    //     public string Label { get; }

    //     public Figura Figura { get; }

    //     public Draw(Token Nombre, Figura Figura) : this(Nombre, Figura, null) { }
    //     public Draw(Token Nombre, Figura Figura, string Label)
    //     {
    //         this.Nombre = Nombre;
    //         this.Label = Label;
    //         this.Figura = Figura;

    //     }
    // }


    public abstract class Figura : Instruccion
    {


        public abstract string nombre { get; set; }

    }
    public sealed class CircleFunction : Figura
    {

        public Point P1 { get; }

        public double Measure { get; }

        public override string nombre { get; set; }

        public CircleFunction(Point P1, double Measure)
        {

            this.P1 = P1;
            this.Measure = Measure;

        }

        public override object Evaluate(Entorno entorno)
        {
            return this;
        }
    }





    public sealed class PointsFunction : Funcion
    {

        public Figura Figure1 { get; }

        public PointsFunction(Figura Figure1)
        {
            this.Figure1 = Figure1;

        }

        public override object Evaluate(Entorno entorno)
        {
            throw new NotImplementedException();
        }
    }

    public sealed class Samples : Funcion
    {
        public override object Evaluate(Entorno entorno)
        {
            throw new NotImplementedException();
        }
    }



    public sealed class Coord
    {
         public int X { get; set; }
        public int Y { get; set; }

        public Coord(int x , int y )
        {
             
                X=x;
                Y=y;
        }
    } 


    public sealed class Point: Figura
    { 
        public Coord Coord {get;}

        public override string nombre  { get; set; }

        private static Random r = new Random();



        public Point(string nombre )
        {
           
           this.nombre= nombre;
            
            int  x = r.Next(1, 300);
            int y = r.Next(1, 300);
            Coord cor = new Coord(x, y);
            Coord = cor;
            
        }


      

        
        public override object Evaluate(Entorno entorno)
        {  
             var point = new Variable(nombre,this);
             entorno.DefinirVariable(point);
             return null;
        }
    }



    public sealed class Circle : Figura
    {
        public Point Centro { get; }
        public int Radio { get; }
        public Circle(string nombre)
        {
            Point p1 = new Point("p1");
            Centro = p1;
            Random r = new Random();
            Radio = r.Next(1, 100);


            
            this.nombre = nombre;

        }


        public override string nombre { get; set; }

        public override object Evaluate(Entorno entorno)
        {
            var cirlce = new Variable(nombre,this);
             entorno.DefinirVariable(cirlce);
             return null;
        }
    }

    public sealed class Line : Figura
    {
        public Point Punto1 { get; }
        public Point Punto2 { get; }
        public Line(string nombre)
        {
            Point p2 = new Point("p1");
            Point p1 = new Point("p2");

            Punto1 = p1;
            Punto2 = p2;
            this.nombre = nombre;

        }


        public override string nombre { get; set; }

        public override object Evaluate(Entorno entorno)
        {
            var line = new Variable(nombre,this);
             entorno.DefinirVariable(line);
             return null;
        }
    }

    public sealed class Ray : Figura
    {
        public Point Punto1 { get; }
        public Point Punto2 { get; }

        public Ray(string nombre)
        {
            Point p1 = new Point("p1");
            Point p2 = new Point("p2");

            

            Punto1 = p1;
            Punto2 = p2;

            this.nombre = nombre;

        }


        public override string nombre { get; set; }

        public override object Evaluate(Entorno entorno)
        {
            var ray = new Variable(nombre,this);
             entorno.DefinirVariable(ray);
             return null;
        }
    }


    public sealed class Segment : Figura
    {

        public Point Punto1 { get; }
        public Point Punto2 { get; }

        public Segment(string nombre)
        {
            Point p1 = new Point("p1");
            Point p2 = new Point("p2");


            Punto1 = p1;
            Punto2 = p2;

            this.nombre = nombre;

        }


        public override string nombre { get; set; }

        public override object Evaluate(Entorno entorno)
        {
           var segment = new Variable(nombre,this);
             entorno.DefinirVariable(segment);
             return null;
        }
    }

    public abstract class Secuence<T> : Figura where T : Figura
    {
        public abstract List<T> SecuenceItems { get; }




    }

    public sealed class PointSecuence : Secuence<Point>
    {
        public override string nombre { get; set; }

        public override List<Point> SecuenceItems { get; }

        public PointSecuence(string nombre, List<Point> secuenceItems)
        {
            this.nombre = nombre;
            this.SecuenceItems = secuenceItems;
        }

        public override object Evaluate(Entorno entorno)
        {
            throw new NotImplementedException();
        }
    }


    public sealed class LineSecuence : Secuence<Line>
    {


        public override string nombre { get; set; }

        public override List<Line> SecuenceItems { get; }

        public LineSecuence(string nombre, List<Line> secuenceItems)
        {

            this.nombre = nombre;
            this.SecuenceItems = secuenceItems;

        }

        public override object Evaluate(Entorno entorno)
        {
            throw new NotImplementedException();
        }
    }


    public class Variable
    {
        public string Name { get; private set; }
        public object Value { get; private set; }

        public Variable(string name, object value)
        {
            Name = name;
            Value = value;
        }


    }

}

    public class IfElseExpression : Instruccion
    {
        public Instruccion Condicion { get; }
        public Instruccion ExpresionIf { get; }
        public Instruccion ExpresionElse { get; }

        public IfElseExpression(Instruccion condicion, Instruccion expresionIf, Instruccion expresionElse)
        {
            Condicion = condicion;
            ExpresionIf = expresionIf;
            ExpresionElse = expresionElse;
        }

        public override object Evaluate(Entorno entorno)
        {
            Instruccion condition =(Instruccion) Condicion.Evaluate(entorno);

            if (!condition.Equals(0) || !condition.Equals(0) || !condition.Equals(0))

            {
                return ExpresionIf.Evaluate(entorno);
            }




            else
            {
                return ExpresionElse.Evaluate(entorno);
            }
        }
    }

    public class DeclaracionIdentificador : Instruccion
    {
        public List<string> Nombre { get; }
        public Instruccion Value { get; }

        public DeclaracionIdentificador(List<string> nombre, Instruccion value)
        {
            Nombre = nombre;
            Value = value;
        }

        public override object Evaluate(Entorno entorno)
        {
            // Si Value es una secuencia 
            if (Value is Secuence<Figura> secuencia)
            {
                var valores = secuencia;

                for (int i = 0; i < Nombre.Count; i++)
                {
                    // Si se usa "_" como uno de los nombres de la variable, se ignora la asignación correspondiente
                    if (Nombre[i] == "_")
                        continue;

                    // Si se piden valores inexistentes a una secuencia, se guarda en la variable un tipo undefined
                    if (i >= valores.SecuenceItems.Count())
                    {
                        //entorno.DefinirVariable(new Variable(Nombre[i], new Undefined()));
                        continue;
                    }

                    // Si el elemento de Nombres es el último de la lista, se le asigna el resto de la secuencia
                    if (i == Nombre.Count - 1)
                    {
                        var resto = valores.SecuenceItems.Skip(i).ToList();


                        // Determina el tipo de los elementos en la lista 'resto'
                        var tipo = resto[0].GetType();

                        if (tipo == typeof(Point))
                        {

                            entorno.DefinirVariable(new Variable(Nombre[i], new PointSecuence(Nombre[i], resto.Cast<Point>().ToList())));
                            break;
                        }



                        else if (tipo == typeof(Line))
                        {

                            entorno.DefinirVariable(new Variable(Nombre[i], new LineSecuence(Nombre[i], resto.Cast<Line>().ToList())));
                            break;
                        }

                    }

                    // Se asigna uno con uno cada variable a cada valor de la secuencia
                    entorno.DefinirVariable(new Variable(Nombre[i], valores.SecuenceItems[i]));

                }
            }

            else
            {
                // Si Value no es una secuencia, se asigna el valor a todas las variables
                //foreach (var nombre in Nombre)
                //{

                //    entorno.DefinirVariable(new Variable(nombre, Value));
                //}
            }

            return null;
        }


    }

    public class FunctionDeclaration : Instruccion
    {
        public string Nombre { get; }
        public List<string> Parametros { get; }
        public Instruccion Cuerpo { get; }

        public FunctionDeclaration(string nombre, List<string> parametros, Instruccion cuerpo)
        {
            Nombre = nombre;
            Parametros = parametros;
            Cuerpo = cuerpo;

        }

        public override object Evaluate(Entorno entorno)
    {

    


    return null;
    }
    }


        

    


    public class Entorno
{
    public Dictionary<string, Variable> variables = new Dictionary<string, Variable>();
    public Dictionary<string, FunctionDeclaration> funciones= new Dictionary<string, FunctionDeclaration>();

    public List<Figura> figuras = new List<Figura>();

    public void DefinirVariable(Variable variable)
    {
        variables[variable.Name] = variable;
    }

    public void DefinirFuncion(FunctionDeclaration funcion)
    {
        funciones[funcion.Nombre] = funcion;
    }

    public Variable BuscarVariable(string nombre)
    {
        if (variables.TryGetValue(nombre, out var variable))
        {
            return variable;
        }
        else
        {
           return null;
        }
    }
}
