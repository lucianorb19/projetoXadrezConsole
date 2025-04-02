using System;
using System.Data;
using tabuleiro;
using xadrez;

namespace projetoXadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PosicaoXadrez pos = new PosicaoXadrez('c', 7);
                Console.WriteLine(pos);
                Console.WriteLine(pos.toPosicao());
                

            }
            catch (TabuleiroException e)
            {
                Console.WriteLine($"Erro. {e.Message}");
            }
            
        }
    }
}
