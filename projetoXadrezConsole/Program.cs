using projetoXadrezConsole.xadrez;
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
                PartidaDeXadrez partida = new PartidaDeXadrez();
                Tela.imprimirTabuleiro(partida.tab);


            }
            catch (TabuleiroException e)
            {
                Console.WriteLine($"Erro. {e.Message}");
            }
            
        }
    }
}
