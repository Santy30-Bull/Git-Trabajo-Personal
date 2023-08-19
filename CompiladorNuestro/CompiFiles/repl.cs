using System;
using CompiFiles.lexer; // Replace with the actual namespace of your lexer
using CompiFiles.Token; // Replace with the actual namespace of your tokens

namespace CompiFiles
{
    class Program
    {   static void RunRepl()
        {
            Token EOF_TOKEN = new Token(TokenType.EOF, "");

            while (true)
            {
                Console.Write(">> ");
                string source = Console.ReadLine();

                if (source == "salir()")
                    break;

                Lexer lexer = new Lexer(source);

                Token token;
                do
                {
                    token = lexer.NextToken();
                    Console.WriteLine(token);
                } while (token != EOF_TOKEN);
            }
        }
    }
}

