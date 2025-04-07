using tabuleiro;

namespace xadrez
{
    class Rei : Peca //Rei HERDA DE Peca
    {
        //ATRIBUTOS
        private PartidaDeXadrez partida;
        
        //CONSTRUTORES
        //CONSTRUTOR - SÓ PEGA AS INFORMAÇÕES DA BASE + INFORMAÇÃO DA PARTIDA (PARA A JOGADA ROQUE)
        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        //DEMAIS MÉTODOS
        public override string ToString()
        {
            return $"R";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);//PEÇA p RECEBE A PEÇA NA POSIÇÃO pos DO TABULEIRO
            return (p == null || p.cor != this.cor);
            //RETORNA TRUE SE NÃO HOUVER PEÇA NA POSIÇÃO OU SE FOR UMA PEÇA ADVERSÁRIA
        }

        //MÉTODO QUE TESTA SE A TORRE ESTÁ ADEQUADA PARA O ROQUE - DADA UM POSIÇÃO DELA
        public bool testeTorreParaRoque(Posicao pos)
        {
            Peca p = tab.peca(pos);
            //RETORNA true SE
            //POSIÇÃO NÃO ESTÁ VAZIA E PEÇA É TORRE E A COR É A MESMA DO REI E
            //PEÇA AINDA NÃO SE MEXEU
            return (p != null && p is Torre && p.cor == this.cor && p.qteMovimentos == 0);
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];//MATRIZ AUXILIAR COM O MESMO TAMANHO DO TABULEIRO

            //TESTE
            Posicao pos = new Posicao(0, 0);

            //posicao ou pos ????

            //ACIMA
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            //SE A POSIÇÃO FOR VÁLIDA (DENTRO DO TABULEIRO) E
            //NÃO HOUVER PEÇA NA POSIÇÃO OU SE FOR UMA PEÇA ADVERSÁRIA
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;//ESSA POSIÇÃO É MARCADA COMO TRUE NA MATRIZ DE BOOL
            }

            //ABAIXO
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //DIREITA
            pos.definirValores(posicao.linha, posicao.coluna+1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //ESQUERDA
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //ACIMA ESQUERDA
            pos.definirValores(posicao.linha-1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //ACIMA DIREITA
            pos.definirValores(posicao.linha-1, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //ABAIXO ESQUERDA
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //ABAIXO DIREITA
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //#JOGADA ESPECIAL - ROQUE PEQUENO
            //ROQUE SÓ OCORRE SE O REI AINDA NÃO SE MOVEU E NÃO ESTÁ EM XEQUE
            if(qteMovimentos == 0 && !(partida.xeque))
            {
                Posicao posTorreRoquePequeno = new Posicao(posicao.linha, posicao.coluna + 3);
                if (testeTorreParaRoque(posTorreRoquePequeno))//SE A TORRE PUDER FAZER O ROQUE
                {
                    //OS DOIS ESPAÇOS ENTRE O REI E A TORRE ESTÃO VAZIOS?
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);
                    if(tab.peca(p1) == null && tab.peca(p2) == null)
                    {
                        mat[posicao.linha, posicao.coluna + 2] = true;//O REI TEM ESSA POSIÇÃO COMO POSSÍVEL
                        //MOVIMENTO DA TORRE EM PartidaDeXadrez -> executaMovimento
                    }
                }
            }

            //#JOGADA ESPECIAL - ROQUE GRANDE
            //ROQUE SÓ OCORRE SE O REI AINDA NÃO SE MOVEU E NÃO ESTÁ EM XEQUE
            if (qteMovimentos == 0 && !(partida.xeque))
            {
                Posicao posTorreRoqueGrande = new Posicao(posicao.linha, posicao.coluna - 4);
                if (testeTorreParaRoque(posTorreRoqueGrande))//SE A TORRE PUDER FAZER O ROQUE
                {
                    //OS TRÊS ESPAÇOS ENTRE O REI E A TORRE ESTÃO VAZIOS?
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);
                    if (tab.peca(p1) == null && tab.peca(p2) == null && tab.peca(p3) == null)
                    {
                        mat[posicao.linha, posicao.coluna - 2] = true;//O REI TEM ESSA POSIÇÃO COMO POSSÍVEL
                        //MOVIMENTO DA TORRE EM PartidaDeXadrez -> executaMovimento
                    }
                }
            }



            return mat;//RETORNO É A MATRIZ COM POSIÇÕES TRUE ONDE A PEÇA PODE SE MOVER
        }


    }
}
