namespace Wall_E;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
public abstract class Instruccion
{

}



public abstract class Funcion : Instruccion
{

}


public sealed class FunctionLine : Funcion
{

    public Point P1 { get; }
    public Point P2 { get; }

    public FunctionLine(Point P1, Point P2)
    {

        this.P1 = P1;
        this.P2 = P2;

    }
}

public sealed class SegmentFunction : Funcion
{

    public Point P1 { get; }
    public Point P2 { get; }

    public SegmentFunction(Point P1, Point P2)
    {

        this.P1 = P1;
        this.P2 = P2;

    }
}

public sealed class RayFunction : Funcion
{

    public Point P1 { get; }
    public Point P2 { get; }

    public RayFunction(Point P1, Point P2)
    {

        this.P1 = P1;
        this.P2 = P2;

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
}

public sealed class ArcFunction : Funcion
{

    public Point P1 { get; }
    public Point P2 { get; }

    public Point P3 { get; }
    public double Measure { get; }

    public ArcFunction(Point P1, Point P2, Point P3, double Measure)
    {

        this.P1 = P1;
        this.P2 = P2;
        this.P3 = P3;
        this.Measure = Measure;

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
}

public class Draw
{
    public Token Nombre { get; }
    public string Label { get; }

    public Figura Figura { get; }

    public Draw(Token Nombre, Figura Figura) : this(Nombre, Figura, null) { }
    public Draw(Token Nombre, Figura Figura, string Label)
    {
        this.Nombre = Nombre;
        this.Label = Label;
        this.Figura = Figura;

    }
}


public abstract class Figura : Instruccion
{


    public abstract string nombre { get; }

}
public sealed class CircleFunction : Funcion
{

    public Point P1 { get; }

    public double Measure { get; }

    public CircleFunction(Point P1, double Measure)
    {

        this.P1 = P1;
        this.Measure = Measure;

    }
}





public sealed class PointsFunction : Funcion
{

    public Figura Figure1 { get; }

    public PointsFunction(Figura Figure1)
    {
        this.Figure1 = Figure1;

    }
}

public sealed class Samples : Funcion
{



}






public sealed class Point : Figura
{

    public Point(string nombre)
    {

        this.nombre = nombre;

    }


    public override string nombre { get; }

}

public sealed class Circle : Figura
{

    public Circle(string nombre)
    {

        this.nombre = nombre;

    }


    public override string nombre { get; }

}

public sealed class Line : Figura
{

    public Line(string nombre)
    {

        this.nombre = nombre;

    }


    public override string nombre { get; }

}

public sealed class Ray : Figura
{

    public Ray(string nombre)
    {

        this.nombre = nombre;

    }


    public override string nombre { get; }

}


public sealed class Segment : Figura
{

    public Segment(string nombre)
    {

        this.nombre = nombre;

    }


    public override string nombre { get; }

}

public abstract class Secuence<T> : Figura where T : Figura
{
    public abstract List<T> SecuenceItems { get; }


     
        
}

public sealed class PointSecuence : Secuence<Point>
{
    public override string nombre { get; }

    public override List<Point> SecuenceItems { get; }

    public PointSecuence(string nombre, List<Point> secuenceItems)
    {
        this.nombre = nombre;
        this.SecuenceItems = secuenceItems;
    }
}


public sealed class LineSecuence : Secuence<Line>
{


    public override string nombre { get; }

    public override List<Line> SecuenceItems { get; }

    public LineSecuence(string nombre, List<Line> secuenceItems)
    {

        this.nombre = nombre;
        this.SecuenceItems = secuenceItems;

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

    public override object Evaluar(Entorno entorno)
    {
        Instruccion condition = Condicion.Evaluar(entorno);

        if (!condition.Equals(0) || !condition.Equals(0) || !condition.Equals(0))

        {
            return ExpresionIf.Evaluar(entorno);
        }




        else
        {
            return ExpresionElse.Evaluar(entorno);
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

    public override object Evaluar(Entorno entorno)
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
                    entorno.DefinirVariable(new Variable(Nombre[i], new Undefined()));
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
                foreach (var nombre in Nombre)
                {
                    
                        entorno.DefinirVariable(new Variable(nombre, Value));
                }
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
        public override object Evaluar(Entorno entorno)
        {

            entorno.DefinirFuncion(this);


            return null;
        }

    }


    public class Entorno
    {
        public Dictionary<string, Variable> variables = new Dictionary<string, Variable>();

        public void DefinirVariable(Variable variable)
        {
            variables[variable.Name] = variable;
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



