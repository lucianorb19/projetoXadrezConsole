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
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;


        //CONSTRUTORES
        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;//REGRA - A PARTIDA SEMPRE INICIA PELO JOGADOR PEÇAS BRANCAS
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas(); //ADICIONA AS PEÇAS INICIAIS DA PARTIDA
            terminada = false;
        }

        //DEMAIS MÉTODOS
        //MÉTODO QUE INSERE AS PEÇAS INICIAIS NO TABULEIRO
        private void colocarPecas()
        {
            colocarNovaPeca('c', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('c', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('e', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('e', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 1, new Rei(tab, Cor.Branca));

            colocarNovaPeca('c', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('c', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('d', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('e', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('e', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('d', 8, new Rei(tab, Cor.Preta));
        }
        
        //MÉTODO QUE ADICIONA UMA PEÇA NUMA POSIÇÃO DO TABULEIRO
        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);

        }

        //MÉTODO QUE RETORNA A COLEÇÃO DE PEÇAS CAPTURDAS DADA UMA COR
        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        //MÉTODO QUE RETORNA A COLEÇÃO DE PEÇAS EM JOGO (TODAS - CAPTURADAS)
        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));//RETIRA DO CONJUNTO TOTAL DE PEÇAS, AS CAPTURADAS
            return aux;
        }

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

            //PEÇA CAPTURADA ADICIONADA AO CONJUNTO DE CAPTURADAS
            if(pecaCapturada!= null)
            {
                capturadas.Add(pecaCapturada);
            }
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
