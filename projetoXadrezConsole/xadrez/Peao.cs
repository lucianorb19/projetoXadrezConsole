using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        //ATRIBUTOS
        private PartidaDeXadrez partida;

        //CONSTRUTORES
        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        //DEMAIS MÉTODOS
        public override string ToString()
        {
            return $"P";
        }

        //MÉTODO BOOL - RETORNA TRUE CASO HAJA UMA PEÇA INIMIGA NA POSIÇÃO DADA
        private bool existeInimigo(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return (p != null && p.cor != this.cor);
        }

        //MÉTODO BOOL - RETORNA TRUE CASO NÃO HAJA PEÇA NA POSIÇÃO DADA
        private bool livre(Posicao pos)
        {
            return (tab.peca(pos) == null);
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);

            //O PEÃO BRANCO SÓ VAI EM DIREÇÃO ÀS PEÇAS PRETA
            //O PEÃO PRETO SÓ VAI EM DIREÇÃO ÀS PEÇAS BRANCAS
            if (this.cor == Cor.Branca)
            {
                //PRIMEIRO MOVIMENTO DO PEÃO - PODE ANDAR DUAS CASAS
                pos.definirValores(posicao.linha - 2, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //ANDAR PARA UMA CASA A FRENTE VAZIA
                pos.definirValores(posicao.linha - 1, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //COMER UMA PEÇA - DIAGONAL ESQUERDA
                pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //COMER UMA PEÇA - DIAGONAL DIREITA
                pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //#JOGADA ESPECIAL - EN PASSANT - ESSE PEÃO COME OUTRO QUE ESTÁ VULNERÁVEL AO EN PASSANT
                //PEÃO BRANCO COME
                if (posicao.linha == 3)//
                {
                    //PEÃO BRANCO COME PEÃO À ESQUERDA
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);//POSICÃO A ESQUERDA DESSE PEÃO
                    //SE POSIÇÃO FOR VÁLIDA E EXISTE INIMIGO NELA E É UM PEÃO VULNERÁVEL AO PASSANT
                    if (tab.posicaoValida(esquerda) && existeInimigo(esquerda)
                        && tab.peca(esquerda) == partida.vulneravelEnPassant)
                    {
                        //ESSA POSIÇÃO DO PEÃO VULNERÁVEL É MARCADA COMO POSSÍVEL MOVIMENTO
                        mat[esquerda.linha-1, esquerda.coluna] = true;
                    }

                    //PEÃO BRANCO COME PEÃO À DIREITA
                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tab.posicaoValida(direita) && existeInimigo(direita)
                        && tab.peca(direita) == partida.vulneravelEnPassant)
                    {
                        mat[direita.linha-1, direita.coluna] = true;
                    }
                }
            }
            else//PARA OS PEÕES PRETOS - MESMA COISA, COM VALORES DE LINHA INVERTIDOS
            {
                //PRIMEIRO MOVIMENTO DO PEÃO - PODE ANDAR DUAS CASAS
                pos.definirValores(posicao.linha + 2, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //ANDAR PARA UMA CASA A FRENTE VAZIA
                pos.definirValores(posicao.linha + 1, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //COMER UMA PEÇA - DIAGONAL ESQUERDA
                pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //COMER UMA PEÇA - DIAGONAL DIREITA
                pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //#JOGADA ESPECIAL - EN PASSANT - ESSE PEÃO COME OUTRO QUE ESTÁ VULNERÁVEL AO EN PASSANT
                //PEÃO PRETO COME
                if (posicao.linha == 4)//
                {
                    //PEÃO PRETO COME PEÃO À ESQUERDA
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);//POSICÃO A ESQUERDA DESSE PEÃO
                    //SE POSIÇÃO FOR VÁLIDA E EXISTE INIMIGO NELA E É UM PEÃO VULNERÁVEL AO PASSANT
                    if (tab.posicaoValida(esquerda) && existeInimigo(esquerda)
                        && tab.peca(esquerda) == partida.vulneravelEnPassant)
                    {
                        //ESSA POSIÇÃO DO PEÃO VULNERÁVEL É MARCADA COMO POSSÍVEL MOVIMENTO
                        mat[esquerda.linha + 1, esquerda.coluna] = true;
                    }

                    //PEÃO PRETO COME PEÃO À DIREITA
                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tab.posicaoValida(direita) && existeInimigo(direita)
                        && tab.peca(direita) == partida.vulneravelEnPassant)
                    {
                        mat[direita.linha + 1, direita.coluna] = true;
                    }
                }

            }
            return mat;
        }







    }
}
