using System;
using tabuleiro;
using xadrez;

namespace projetoXadrezConsole.xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; } // A CADA JOGADA UM TURNO, 1,2,3....
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; } 

        //CONSTRUTORES
        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;//REGRA - A PARTIDA SEMPRE INICIA PELO JOGADOR PEÇAS BRANCAS
            colocarPecas(); //ADICIONA AS PEÇAS INICIAIS DA PARTIDA
            terminada = false;
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
        //MÉTODO QUE REALIZA A JOGADA MOVIMENTANDO A PEÇA E MUDANDO A COR DO JOGADOR ATUAL
        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }

        //MÉTODO QUE VALIDA A POSIÇÃO DA PEÇA DE ORIGEM ESCOLHIDA
        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if(tab.peca(pos) == null)//NÃO PODE SER UMA POSIÇÃO SEM PEÇA
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida");
            }
            if (jogadorAtual != tab.peca(pos).cor)//NÃO PODE SER PEÇA DA COR DIFERENTE DO TURNO
            {
                throw new TabuleiroException("A peça escolhida não é sua");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis())//PRECISA TER MOVIMENTOS POSSÍVEIS PARA A PEÇA
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça escolhida");
            }
        }

        //MÉTODO QUE VALIDA A POSIÇÃO DE DESTINO, DADA SUA ORIGEM E SEUS POSSÍVEIS MOVIMENTOS
        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).podeMoverPara(destino))//SE NÃO PUDER SE MOVER PARA O DESTINO
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        //MÉTODO QUE MOVIMENTA A PEÇA NO TABULEIRO
        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);//PEÇA SAI DA POSIÇÃO ORIGINAL DO TABULEIRO. SALVA EM p
            p.incrementarQtdMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);//PEÇA "COMIDA" É SALVA EM pecaCapturada
            tab.colocarPeca(p, destino);//PEÇA p COLOCADA NA POSIÇÃO DESTINO
        }

        //MÉTODO QUE MUDA A COR DO JOGADOR ATUAL
        private void mudaJogador()
        {
            if(jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }








    }
}
