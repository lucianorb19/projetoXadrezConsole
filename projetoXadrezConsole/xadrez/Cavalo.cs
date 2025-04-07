using tabuleiro;

namespace xadrez
{
    class Cavalo : Peca
    {
        //CONSTRUTORES
        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor) { }

        //DEMAIS MÉTODOS
        public override string ToString()
        {
            return $"C";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);//PEÇA p RECEBE A PEÇA NA POSIÇÃO pos DO TABULEIRO
            return (p == null || p.cor != this.cor);
            //RETORNA TRUE SE NÃO HOUVER PEÇA NA POSIÇÃO OU SE FOR UMA PEÇA ADVERSÁRIA
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];//MATRIZ AUXILIAR COM O MESMO TAMANHO DO TABULEIRO

            //TESTE
            Posicao pos = new Posicao(0, 0);

            
            pos.definirValores(posicao.linha - 1, posicao.coluna-2);
            //SE A POSIÇÃO FOR VÁLIDA (DENTRO DO TABULEIRO) E
            //NÃO HOUVER PEÇA NA POSIÇÃO OU SE FOR UMA PEÇA ADVERSÁRIA
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;//ESSA POSIÇÃO É MARCADA COMO TRUE NA MATRIZ DE BOOL
            }

            pos.definirValores(posicao.linha - 2, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha - 2, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha - 1, posicao.coluna + 2);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha + 1, posicao.coluna + 2);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha + 2, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha + 2, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            pos.definirValores(posicao.linha + 1, posicao.coluna - 2);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }


            return mat;

        }



    }
}
