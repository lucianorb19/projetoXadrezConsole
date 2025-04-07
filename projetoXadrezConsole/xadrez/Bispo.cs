using tabuleiro;

namespace xadrez
{
    class Bispo : Peca
    {

        //CONSTRUTORES
        public Bispo(Tabuleiro tab, Cor cor) : base(tab, cor){ }

        //DEMAIS MÉTODOS
        public override string ToString()
        {
            return "B";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return (p == null || p.cor != this.cor);
        }


        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];//MATRIZ AUXILIAR COM O MESMO TAMANHO DO TABULEIRO

            //TESTE
            Posicao pos = new Posicao(0, 0);

            //DIAGONAL - ACIMA ESQUERDA
            pos.definirValores(posicao.linha-1, posicao.coluna - 1);
            while (tab.posicaoValida(pos)
                   && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null
                && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.linha = pos.linha - 1;
                pos.coluna = pos.coluna - 1;
            }

            //DIAGONAL - ACIMA DIREITA
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            while (tab.posicaoValida(pos)
                   && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null
                && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.linha = pos.linha - 1;
                pos.coluna = pos.coluna + 1;
            }

            //DIAGONAL - ABAIXO ESQUERDA
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            while (tab.posicaoValida(pos)
                   && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null
                && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.linha = pos.linha + 1;
                pos.coluna = pos.coluna - 1;
            }

            //DIAGONAL - ABAIXO DIREITA
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            while (tab.posicaoValida(pos)
                   && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null
                && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.linha = pos.linha + 1;
                pos.coluna = pos.coluna + 1;
            }



            return mat;

        }






    }
}
