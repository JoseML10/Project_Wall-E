

namespace Wall_E;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Text;

public enum TipoToken
{
    PalabraReservada,

    Funcion,
    Identificador,
    Numero,
    OperadorAritmético,
    OperadorLógico,
    OperadorAsignación,
    OpeningParenthesis,
   ClosingParenthesis,
   OpeningBrace,
   ClosingBrace,

    
    Math,
    Comillas,
    PuntoComa,
    Coma,

    Desconocido,

    Flecha,

    Cadena,

    Concatenador,

   
}






 public class Token 
{    
      
    



    public Token(TipoToken tipo, string valor)
    {
        Tipo = tipo;
        Valor = valor;
    }
    public  TipoToken Tipo { get; }
    public string Valor { get; }  

    
} 


class Program
{
    static void Main(string[] args)
    {
      while(true) 
      {
        string codigo = Console.ReadLine();                        


        AnalizadorLéxico lex = new AnalizadorLéxico(codigo);
        List<Token> tokens = lex.ObtenerTokens();
        foreach (Token token in tokens)
        {
            Console.WriteLine(token.Valor + " " + token.Tipo);
            Console.WriteLine("*****");
        }
      } 
    }
public class AnalizadorLéxico
{
        string codigoFuente;
    int indice;
    
     Dictionary <string, TipoToken> palabrasReservadas = new Dictionary<string, TipoToken>
        {
            { "print", TipoToken.PalabraReservada },
            { "function", TipoToken.PalabraReservada },
            { "let", TipoToken.PalabraReservada },
            { "in", TipoToken.PalabraReservada },
            { "if", TipoToken.PalabraReservada },
            { "else", TipoToken.PalabraReservada },
            { "draw", TipoToken.PalabraReservada },
            { "measure", TipoToken.PalabraReservada },
            { "color", TipoToken.PalabraReservada },
            { "restore", TipoToken.PalabraReservada },
            { "import", TipoToken.PalabraReservada },
            { "circle", TipoToken.PalabraReservada },
            { "line", TipoToken.PalabraReservada },
            { "segment", TipoToken.PalabraReservada },
            { "ray", TipoToken.PalabraReservada },
            { "arc", TipoToken.PalabraReservada },
            { "randoms", TipoToken.PalabraReservada},
            { "points", TipoToken.PalabraReservada },
            { "samples", TipoToken.PalabraReservada },
          
            
        };

   Dictionary<string, TipoToken> Math = new Dictionary<string, TipoToken>
        {
            { "sin", TipoToken.Math},
            { "cos", TipoToken.Math},
            { "log", TipoToken.Math},
            { "PI", TipoToken.Math},

            
        };    
   
  
    

    public AnalizadorLéxico(string codigoFuente)
    {
        this.codigoFuente = codigoFuente;
        indice = 0;
        

      
       
      
    }

    

    public List<Token> ObtenerTokens()
    {
        List<Token> tokens = new List<Token>();

        while (indice < codigoFuente.Length)
        {
            char caracterActual = codigoFuente[indice];
            string _caracterActual = codigoFuente[indice].ToString();

           
            if (caracterActual == ' ' || caracterActual == '\n')
            {
                indice++;
                continue;
            }
            
           
            if (caracterActual == '('  )
            {
                tokens.Add(new Token(TipoToken.OpeningParenthesis, caracterActual.ToString()));
                indice++;
                continue;
            }
            if ( caracterActual == ')' )
            {
                tokens.Add(new Token(TipoToken.ClosingParenthesis, caracterActual.ToString()));
                indice++;
                continue;
            }
             if ( caracterActual == '{' )
            {
                tokens.Add(new Token(TipoToken.OpeningBrace, caracterActual.ToString()));
                indice++;
                continue;
            }
            if ( caracterActual == '}' )
            {
                tokens.Add(new Token(TipoToken.ClosingBrace, caracterActual.ToString()));
                indice++;
                continue;
            }
if (caracterActual == '"')
{
    StringBuilder cadena = new StringBuilder();
    indice++;  

    while (indice < codigoFuente.Length && codigoFuente[indice] != '"')
    {
        cadena.Append(codigoFuente[indice]);
        indice++;
    }

    if (indice == codigoFuente.Length)
    {
        throw new Exception("Error: Se esperaba una comilla de cierre.");
    }

    indice++; 

    tokens.Add(new Token(TipoToken.Cadena, cadena.ToString()));
    continue;
}


             if ( caracterActual == ';' )
            {
                tokens.Add(new Token(TipoToken.PuntoComa, caracterActual.ToString()));
                indice++;
                continue;
            }
             if ( caracterActual == ',' )
            {
                tokens.Add(new Token(TipoToken.Coma, caracterActual.ToString()));
                indice++;
                continue;
            }

           
            if (char.IsDigit(caracterActual))
            {
                string numero = "";
                while (indice < codigoFuente.Length && char.IsDigit(codigoFuente[indice]))
                {
                    numero += codigoFuente[indice];
                    indice++;
                }
                tokens.Add(new Token(TipoToken.Numero, numero));
                continue;
            }

          
           if (char.IsLetter(caracterActual) || caracterActual == '_')
            {
                string palabra = "";
                while (indice < codigoFuente.Length && (char.IsLetterOrDigit(codigoFuente[indice]) || codigoFuente[indice] == '_'))
                {
                    palabra += codigoFuente[indice];
                    indice++;
                }

                if (palabrasReservadas.ContainsKey(palabra))
                {
                    tokens.Add(new Token(palabrasReservadas[palabra], palabra));
                }
                else if (Math.ContainsKey(palabra))
                {
                    tokens.Add(new Token(Math[palabra], palabra));
                }
                else
                {
                    tokens.Add(new Token(TipoToken.Identificador, palabra));
                }
                continue;
            }
           
            if (caracterActual == '+' || caracterActual == '-' || caracterActual == '*' 
                ||caracterActual == '^' || caracterActual == '%'
                || caracterActual == '/')
            {
                tokens.Add(new Token(TipoToken.OperadorAritmético, caracterActual.ToString()));
                indice++;
                continue; 
            }
            
             if (
                     caracterActual == '>' || caracterActual == '<' )
            {
                tokens.Add(new Token(TipoToken.OperadorLógico, caracterActual.ToString()));
                indice++;
                continue; 
            }

              if 
                   (  caracterActual == '@' )
            {
                tokens.Add(new Token(TipoToken.Concatenador, caracterActual.ToString()));
                indice++;
                continue; 
            }


           

            
            if (caracterActual == '=')
            {
                if (indice + 1 < codigoFuente.Length && codigoFuente[indice + 1] == '=')
                    {  
                        tokens.Add(new Token(TipoToken.OperadorLógico, "=="));
                        indice += 2;
                        continue;
                    }

                else if (indice + 1 < codigoFuente.Length && codigoFuente[indice + 1] == '>')
                    {  
                        tokens.Add(new Token(TipoToken.Flecha, "=>"));
                        indice += 2;
                        continue;
                    }    
                    else
                 {
                     tokens.Add(new Token(TipoToken.OperadorAsignación, "="));
                    indice++;
                     continue;
                }
            }
             if (caracterActual == '!')
            {
                if (indice + 1 < codigoFuente.Length && codigoFuente[indice + 1] == '=')
                    {  
                        tokens.Add(new Token(TipoToken.OperadorLógico, "!="));
                        indice += 2;
                        continue;
                    }
                    else
                 {
                     tokens.Add(new Token(TipoToken.Desconocido, caracterActual.ToString()));        
                     
                    throw new Exception("Caracter desconocido en : "+ indice);
                    
                }
            }
             tokens.Add(new Token(TipoToken.Desconocido, caracterActual.ToString()));        
           
            throw new Exception("Caracter desconocido en : "+ indice);
          

            
        

        }      
       return tokens;     
             
    }

}
}