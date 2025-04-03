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

                while (!partida.terminada)
                {
                    Console.Clear();//LIMPA O CONSOLE
                    Tela.imprimirTabuleiro(partida.tab);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                    partida.executaMovimento(origem, destino);
                }
                


            }
            catch (TabuleiroException e)
            {
                Console.WriteLine($"Erro. {e.Message}");
            }
            
        }
    }
}
