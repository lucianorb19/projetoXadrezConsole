using System;
using tabuleiro;
using xadrez;

namespace projetoXadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //INSTANCIAÇÃO TABULEIRO VAZIO
            Tabuleiro tab = new Tabuleiro(8, 8);

            //ADICIONANDO PEÇAS AO TABULEIRO
            tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
            tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
            tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(2, 4));

            Tela.imprimirTabuleiro(tab);

        }
    }
}
