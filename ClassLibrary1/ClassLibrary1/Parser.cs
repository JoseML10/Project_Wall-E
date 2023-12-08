using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class AnalizadorSintáctico
    {
        private List<Token> tokens;

        private int indice;
        private Token tokenActual;
        private Token ultimoToken;


        private static List<string> Nombrefunciones = new List<string>();

        public AnalizadorSintáctico(List<Token> tokens)
        {
            this.tokens = tokens;
            indice = 0;
            if (tokens.Count != 0)
            {


                tokenActual = tokens[0];
                ultimoToken = tokens[tokens.Count - 1];

            }


        }

        public void siguienteToken()
        {
            if (indice < tokens.Count - 1)
            {
                indice++;
                tokenActual = tokens[indice];
            }
        }

        public Token NextToken()
        {
            Token valor = tokens[indice];
            indice++;
               
            

            return valor;
        }

        List<Instruccion> instructions = new List<Instruccion>();

        public List<Instruccion> ParseInstructions()
        {
            while (tokenActual != ultimoToken)
            {
                Instruccion line = Analize();
                
                instructions.Add(line);
                siguienteToken();
                
            }

            return instructions;
        }
        public Instruccion Analize()
        {
            Instruccion nodo = AnalizeExpresion();
            return nodo;
        }

        private Instruccion AnalizeExpresion()
        {
            if (tokenActual.Tipo == TipoToken.Identificador && tokenActual.Valor == "point")
            { 
                return AnalizePoint();
            }
            else if (tokenActual.Tipo == TipoToken.Identificador && tokenActual.Valor == "line")
            {
                return AnalizeLine();
            }

            else if (tokenActual.Tipo == TipoToken.PalabraReservada && tokenActual.Valor == "draw")
            {   
                return AnalizeDraw();
            }
            else if (tokenActual.Tipo == TipoToken.Identificador && tokenActual.Valor == "circle")
            {
                return AnalizeCircle();
            }
            else if (tokenActual.Tipo == TipoToken.Identificador && tokenActual.Valor == "ray")
            {
                return AnalizeRay();
            }
            else if (tokenActual.Tipo == TipoToken.Identificador && tokenActual.Valor == "segment")
            {
               return AnalizeLine();
            }

            else if (tokenActual.Tipo == TipoToken.PalabraReservada && tokenActual.Valor =="line")
            {
                return AnalizeLineFunction();
            }

            else if (tokenActual.Tipo == TipoToken.PalabraReservada && tokenActual.Valor=="circle")
            {
                return AnalizeCircleFunction();
            }

            else if (tokenActual.Tipo == TipoToken.PalabraReservada && tokenActual.Valor=="segment")
            {
                return AnalizeSegmentFunction();
            }
            else if (tokenActual.Tipo == TipoToken.PalabraReservada && tokenActual.Valor=="ray")
            {
                return AnalizeRayFunction();
            }
            else if (tokenActual.Tipo == TipoToken.PalabraReservada && tokenActual.Valor=="arc")
            {
                return AnalizeArcFunction();
            }




            else if (tokenActual.Tipo == TipoToken.Identificador)
            { 
                return AnalizeIdentifier();
                
            }









            // else if (tokenActual.Tipo == TipoToken.PalabraReservada && tokenActual.Valor == "segment")
            // {
            //     instructions.Add(AnalizeLine());
            // }

            // else if (tokenActual.Tipo == TipoToken.PointSecuence)
            // {
            //     instructions.Add(AnalizePointSecuence());
            // }




            // else if (tokenActual.Tipo == TipoToken.IntersectFunction)
            // {
            //     instructions.Add(AnalizeIntersectFunction());
            // }
            // else if (tokenActual.Tipo == TipoToken.MeasureFunction)
            // {
            //     instructions.Add(AnalizeMeasureFunction());
            // }

            // else if (tokenActual.Tipo == TipoToken.Identificador)
            // {
            //     instructions.Add(AnalizeIdentificador());
            // }




            throw new Exception("madafaka");


        }

        private Instruccion AnalizeIdentifier()
        {   
            
            return new Identifier(tokenActual.Valor);
          
           
        }

        private Instruccion AnalizeDraw()
        {
            siguienteToken();
           
           Instruccion ToDraw = AnalizeExpresion();
           
            siguienteToken();
            
            return new Draw(ToDraw);

        }

        public ArcFunction AnalizeArcFunction()
        {
            siguienteToken();
            siguienteToken();

            Point p1 = AnalizePoint();
            Point p2 = AnalizePoint();
            Point p3 = AnalizePoint();
            double m = double.Parse(NextToken().Valor);

            siguienteToken();





            return new ArcFunction(p1, p2, p3, m);

        }

        public FunctionLine AnalizeLineFunction()
        {
            siguienteToken();
            siguienteToken();

            Point p1 = AnalizePoint();  

            siguienteToken();

            Point p2 = AnalizePoint();

            siguienteToken();

            return new FunctionLine(p1, p2);

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

        public CircleFunction AnalizeCircleFunction()
        {
            siguienteToken();
            siguienteToken();

            Point p1 = AnalizePoint();

            double m = double.Parse(NextToken().Valor);

            siguienteToken();

            return new CircleFunction(p1, m);

        }

        public SegmentFunction AnalizeSegmentFunction()
        {
            siguienteToken();
            siguienteToken();

            Point p1 = AnalizePoint();

            siguienteToken();

            Point p2 = AnalizePoint();

            siguienteToken();

            return new SegmentFunction(p1, p2);

        }
        public RayFunction AnalizeRayFunction()
        {
            siguienteToken();
            siguienteToken();

            Point p1 = AnalizePoint();

            siguienteToken();

            Point p2 = AnalizePoint();

            siguienteToken();

            return new RayFunction(p1, p2);

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

    }

}

//       public PointSecuence AnalizePointSecuence()
//          {
//             siguienteToken();
//             siguienteToken();
//             string id = tokenActual.Valor;
//             siguienteToken();
//             return new PointSecuence(id);

//         } 

//         public LineSecuence AnalizeLineSecuence()
//         {
//             siguienteToken();
//             siguienteToken();
//             string id = tokenActual.Valor;
//             siguienteToken();
//             return new LineSecuence(id);

//         }








//         public MeasureFunction AnalizeMeasureFunction()
//         {
//             siguienteToken();
//             siguienteToken();

//             Point p1 = AnalizePoint();

//             siguienteToken();

//             Point p2 = AnalizePoint();

//             siguienteToken();

//             return new MeasureFunction(p1, p2);

//         }






//         public IntersectFunction AnalizeIntersectFunction()
//         {
//             siguienteToken();
//             siguienteToken();

//             Figura f1 = (Figura)AnalizeExpresion();

//             siguienteToken();

//             Figura f2 = (Figura)AnalizeExpresion();

//             siguienteToken();

//             siguienteToken();

//             return new IntersectFunction(f1, f2);

//         }

//         private DeclaracionIdentificador AnalizeIdentificador()
//         {


//             List<string> variables = new List<string>();
//             while (tokenActual.Tipo != AsignationOperator)
//             {
//                 if (tokenActual.Tipo != TipoToken.Identificador)

//                 {
//                     throw new Exception("Error: Se esperaba un identificador.");
//                 }

//                 variables.Add(tokenActual.Valor);
//                 siguienteToken();

//                 if (tokenActual.Tipo != TipoToken.Coma || tokenActual.Tipo != TipoToken.AsignationOperator)
//                 {
//                     throw new Exception("Error: Se esperaba una coma o un operador de asignacion.");

//                 }

//                 siguienteToken();

//             }



//             Instruccion values = AnalizeExpresion();

//             return new DeclaracionIdentificador(variables, values);

//         }




//         public IfElseExpression AnalizarIfElse()
//         {

//             siguienteToken();



//             Instruccion IfExpression = AnalizeExpresion();


//             if (tokenActual.Tipo != TipoToken.ThenKeyWord)
//             {
//                 throw new Exception("Error: Se esperaba la expresion ¨Then¨.");

//             }


//             Instruccion ThenExpression = AnalizeExpresion();

//             if (tokenActual.Tipo != TipoToken.ElseKeyWord)
//             {
//                 throw new Exception("Error: Se esperaba la expresion ¨Else¨.");

//             }

//             Instruccion ElseExpression = AnalizeExpresion();




//             return new IfElseExpression(IfExpression, ThenExpression, ElseExpression);
//         }


//         private FunctionDeclaration AnalizeFunction()
//         {

//             string FunctionName = tokenActual.Valor;
//             Nombrefunciones.Add(FunctionName);
//             siguienteToken();

//             if (tokenActual.Tipo != TipoToken.OpeningParenthesis)
//                 throw new Exception("Error: Se esperaba un paréntesis abierto.");

//             siguienteToken();

//             List<string> parameters = new List<string>();
//             while (tokenActual.Tipo != TipoToken.ClosingParenthesis)
//             {
//                 if (tokenActual.Tipo != TipoToken.Identificador)

//                 {
//                     throw new Exception("Error: Se esperaba un identificador.");
//                 }

//                 parameters.Add(tokenActual.Valor);
//                 siguienteToken();

//                 if (tokenActual.Tipo == TipoToken.Coma)
//                 {
//                     siguienteToken();
//                 }





//             }

//             siguienteToken();





//             Instruccion body = AnalizeExpresion();

//             return new FunctionDeclaration(FunctionName, parameters, body);
//         }
//     }
// }
