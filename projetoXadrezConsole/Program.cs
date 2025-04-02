using System;
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
                //INSTANCIAÇÃO TABULEIRO VAZIO
                Tabuleiro tab = new Tabuleiro(8, 8);

                //ADICIONANDO PEÇAS AO TABULEIRO
                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 5));
                tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 2));

                Tela.imprimirTabuleiro(tab);

            }
            catch (TabuleiroException e)
            {
                Console.WriteLine($"Erro. {e.Message}");
            }
            
        }
    }
}
