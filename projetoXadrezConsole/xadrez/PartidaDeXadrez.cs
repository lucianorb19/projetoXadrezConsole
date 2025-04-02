using System;
using tabuleiro;
using xadrez;

namespace projetoXadrezConsole.xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        private int turno; // A CADA JOGADA UM TURNO, 1,2,3....
        private Cor jogadorAtual;

        //CONSTRUTORES
        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;//REGRA - A PARTIDA SEMPRE INICIA PELO JOGADOR PEÇAS BRANCAS
            colocarPecas(); //ADICIONA AS PEÇAS INICIAIS DA PARTIDA
        }

        //MÉTODO QUE INSERE AS PEÇAS NO TABULEIRO
        private void colocarPecas()
        {
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 1).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('d', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 1).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('d', 1).toPosicao());

            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 8).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('d', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 8).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 7).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('d', 8).toPosicao());
        }

        //DEMAIS MÉTODOS
        //MÉTODO QUE MOVIMENTA A PEÇA NO TABULEIRO
        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);//PEÇA SAI DA POSIÇÃO ORIGINAL DO TABULEIRO. SALVA EM p
            p.incrementarQtdMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);//PEÇA "COMIDA" É SALVA EM pecaCapturada
            tab.colocarPeca(p, destino);//PEÇA p COLOCADA NA POSIÇÃO DESTINO
        }








    }
}
