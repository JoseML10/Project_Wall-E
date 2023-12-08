 namespace Wall_E;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Xml;
public class AnalizadorSintáctico
{
    private  List<Token> tokens;
    
    private int indice;
    private Token tokenActual;
     private Token ultimoToken;

     
    private  static List<string> Nombrefunciones = new List<string>();

    public AnalizadorSintáctico(List<Token> tokens)
    {
        this.tokens = tokens;
        indice = 0;
        if (tokens.Count != 0) {
            
            
            tokenActual = tokens[0];
             ultimoToken = tokens[tokens.Count-1];    
              
                }
        
    
    }

    public void siguienteToken() {
        if (indice < tokens.Count - 1) {
            indice++;
            tokenActual = tokens[indice];
        }
    }

    List<Instruccion> instructions = new List<Instruccion>();
        
      
      public Instruccion Analize()
      {        

            

         Instruccion nodo = AnalizeExpresion();
            return nodo;
      }

      private Instruccion AnalizeExpresion()
      {
             if (tokenActual.Tipo == TipoToken.PalabraReservada && tokenActual.Valor == "point")
            {
             instructions.Add(AnalizePoint());
            }

            else if (tokenActual.Tipo == TipoToken.PalabraReservada && tokenActual.Valor == "circle")
            {
             instructions.Add(AnalizeCircle());
            }

             else if (tokenActual.Tipo == TipoToken.PalabraReservada && tokenActual.Valor == "ray")
            {
             instructions.Add(AnalizeRay());
            }

            else if (tokenActual.Tipo == TipoToken.PalabraReservada && tokenActual.Valor == "line")
            {
             instructions.Add(AnalizeLine());
            }

            else if (tokenActual.Tipo == TipoToken.PalabraReservada && tokenActual.Valor == "segment")
            {
             instructions.Add(AnalizeLine());
            }

            else if (tokenActual.Tipo == TipoToken.PalabraReservada && tokenActual.Valor == "segment")
            {
             instructions.Add(AnalizeLine());
            }

           else if (tokenActual.Tipo == TipoToken.PointSecuence )
            {
             instructions.Add(AnalizePointSecuence());
            }
           else if (tokenActual.Tipo == TipoToken.LineFunction)
            {
             instructions.Add(AnalizeLineFunction());
            }

            else if (tokenActual.Tipo == TipoToken.SegmentFunction)
            {
             instructions.Add(AnalizeSegmentFunction());
            }
            else if (tokenActual.Tipo == TipoToken.RayFunction)
            {
             instructions.Add(AnalizeRayFunction());
            }
            else if (tokenActual.Tipo == TipoToken.ArcFunction)
            {
             instructions.Add(AnalizeArcFunction());
            }
            else if (tokenActual.Tipo == TipoToken.IntersectFunction)
            {
             instructions.Add(AnalizeIntersectFunction());
            }
            else if (tokenActual.Tipo == TipoToken.MeasureFunction)
            {
             instructions.Add(AnalizeMeasureFunction());
            }
            else if (tokenActual.Tipo == TipoToken.CircleFunction)
            {
             instructions.Add(AnalizeCircleFunction());
            }
             else if (tokenActual.Tipo == TipoToken.Identificador)
            {
             instructions.Add(AnalizeIdentificador());
            }

           

           
                throw new Exception ("madafaka");
           
          
      }
      


           

    
public Point AnalizePoint()
{
    siguienteToken();
    string id = tokenActual.Valor;
     siguienteToken();
    return new Point(id);
}

public Circle AnalizeCircle()
{
    siguienteToken();
    string id = tokenActual.Valor;
     siguienteToken();
    return new Circle(id);
}

public Ray AnalizeRay()
{
    siguienteToken();
    string id = tokenActual.Valor;
     siguienteToken();
    return new Ray(id);
}

public Line AnalizeLine()
{
    siguienteToken();
    string id = tokenActual.Valor;
     siguienteToken();
    return new Line(id);
}

public Segment AnalizeSegment()
{
    siguienteToken();
    string id = tokenActual.Valor;
    siguienteToken();
    return new Segment(id);
}

public PointSecuence AnalizePointSecuence()
{   siguienteToken();
    siguienteToken();
     string id = tokenActual.Valor;
      siguienteToken();
    return new PointSecuence(id);

}

public LineSecuence AnalizeLineSecuence()
{   siguienteToken();
    siguienteToken();
     string id = tokenActual.Valor;
      siguienteToken();
    return new LineSecuence(id);

}

public FunctionLine AnalizeLineFunction()
{  
    siguienteToken();
   siguienteToken();

    Point p1 = AnalizePoint();

   siguienteToken();
    
    Point p2 = AnalizePoint();

   siguienteToken(); 

   return new FunctionLine(p1,p2); 

}

public SegmentFunction AnalizeSegmentFunction()
{  
    siguienteToken();
    siguienteToken();

    Point p1 = AnalizePoint();

   siguienteToken();
    
    Point p2 = AnalizePoint();

   siguienteToken(); 

   return new SegmentFunction (p1,p2); 

}
public RayFunction AnalizeRayFunction()
{  
    siguienteToken();
    siguienteToken();

    Point p1 = AnalizePoint();

   siguienteToken();
    
    Point p2 = AnalizePoint();

   siguienteToken(); 

   return new RayFunction (p1,p2); 

}
public ArcFunction AnalizeArcFunction()
{  
    siguienteToken();
    siguienteToken();

    Point p1 = (Point)AnalizeExpresion();

   siguienteToken();
                
    Point p2 = (Point)AnalizeExpresion();

   siguienteToken(); 

    Point p3 =(Point)AnalizeExpresion();

    siguienteToken(); 

    double m = 0 ;

   return new ArcFunction (p1,p2,p3,m); 

}

public CircleFunction AnalizeCircleFunction()
{  
    siguienteToken();
    siguienteToken();

    Point p1 =(Point) AnalizeExpresion();

   siguienteToken();
    
    double m  = 0 ;

   siguienteToken(); 

   return new CircleFunction (p1,m); 

}

public MeasureFunction AnalizeMeasureFunction()
{  
    siguienteToken();
    siguienteToken();

    Point p1 = AnalizePoint();

   siguienteToken();
    
    Point p2 = AnalizePoint();

   siguienteToken(); 

   return new MeasureFunction (p1,p2); 

}






public IntersectFunction AnalizeIntersectFunction()
{  
    siguienteToken();
    siguienteToken();

   Figura f1 =  (Figura)AnalizeExpresion();

   siguienteToken();
    
    Figura f2 = (Figura)AnalizeExpresion();

   siguienteToken(); 

     siguienteToken(); 
   
   return new IntersectFunction (f1,f2); 

}

private DeclaracionIdentificador AnalizeIdentificador()
{
    
       
         List<string> variables = new List<string>();
        while (tokenActual.Tipo != AsignationOperator)
    {
        if (tokenActual.Tipo != TipoToken.Identificador)
           
           {
                throw new Exception("Error: Se esperaba un identificador.");
           } 

        variables.Add(tokenActual.Valor);
        siguienteToken();

        if (tokenActual.Tipo != TipoToken.Coma || tokenActual.Tipo != TipoToken.AsignationOperator)
           {  
            throw new Exception("Error: Se esperaba una coma o un operador de asignacion.");
           
           } 
        
        siguienteToken();   

    }   

   

    Instruccion values = AnalizeExpresion();    

    return new DeclaracionIdentificador(variables,values);    
         
}




public IfElseExpression AnalizarIfElse() {
   
    siguienteToken();

    
   
    Instruccion IfExpression = AnalizeExpresion();
   

   if ( tokenActual.Tipo != TipoToken.ThenKeyWord )
           {  
            throw new Exception("Error: Se esperaba la expresion ¨Then¨.");
           
           } 

    
   Instruccion ThenExpression = AnalizeExpresion();
    
    if ( tokenActual.Tipo != TipoToken.ElseKeyWord )
           {  
            throw new Exception("Error: Se esperaba la expresion ¨Else¨.");
           
           } 
   
   Instruccion ElseExpression = AnalizeExpresion();
    
   

  
    return new IfElseExpression(IfExpression, ThenExpression, ElseExpression);
}


private  FunctionDeclaration AnalizeFunction()
{
   
    string FunctionName = tokenActual.Valor;
    Nombrefunciones.Add(FunctionName);
    siguienteToken();

    if (tokenActual.Tipo != TipoToken.OpeningParenthesis)
        throw new Exception("Error: Se esperaba un paréntesis abierto.");

    siguienteToken();

    List<string> parameters = new List<string>();
    while (tokenActual.Tipo != TipoToken.ClosingParenthesis)
    {
        if (tokenActual.Tipo != TipoToken.Identificador)
           
           {
                throw new Exception("Error: Se esperaba un identificador.");
           } 

        parameters.Add(tokenActual.Valor);
        siguienteToken();

        if (tokenActual.Tipo == TipoToken.Coma)
           {  
            siguienteToken();
           } 

            
     
            
          
    }

    siguienteToken();

    

   

    Instruccion body = AnalizeExpresion();

    return new FunctionDeclaration(FunctionName,parameters,body);
}







}
