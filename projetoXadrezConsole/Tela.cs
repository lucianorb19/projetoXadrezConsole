using System;
using tabuleiro;

namespace projetoXadrezConsole
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for(int i = 0; i < tab.linhas; i++)
            {
                for(int j = 0; j < tab.colunas; j++)
                {
                    if(tab.peca(i,j) == null)//USO MÉTODO peca de Tabuleiro
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write($"{tab.peca(i,j)} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
