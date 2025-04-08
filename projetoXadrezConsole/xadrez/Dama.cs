using tabuleiro;

namespace xadrez
{
    class Dama : Peca
    {
        //CONSTRUTORES
        public Dama(Tabuleiro tab, Cor cor) : base(tab, cor) { }

        //DEMAIS MÉTODOS
        public override string ToString()
        {
            return $"D";
        }

        //MÉTODO QUE VERIFICA SE UMA DADA POSIÇÃO É PASSÍVEL DE RECEBER UMA PEÇA
        //SEJA PORQUE ESTÁ VAZIA OU PORQUE A PEÇA VAI SER COMIDA
        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);//PEÇA p RECEBE A PEÇA NA POSIÇÃO pos DO TABULEIRO
            return (p == null || p.cor != this.cor);
            //RETORNA TRUE SE NÃO HOUVER PEÇA NA POSIÇÃO OU SE FOR UMA PEÇA ADVERSÁRIA
        }

        //MECÂNICA DE MOVIMENTOS DA DAMA
        public override bool[,] movimentosPossiveis()
        {
            //MOVIMENTOS DA TORRE + MOVIMENTOS DO BISPO
            bool[,] mat = new bool[tab.linhas, tab.colunas];//MATRIZ AUXILIAR COM O MESMO TAMANHO DO TABULEIRO

            //TESTE
            Posicao pos = new Posicao(0, 0);

            //DA TORRE
            //ACIMA
            pos.definirValores(posicao.linha - 1, posicao.coluna);//POS RECEBE A PRÓXIMA POSICÃO A FRENTE - PARA SER AVALIADA
            while (tab.posicaoValida(pos)//ENQUANTO FOR UMA POSICAO VALIDA 
                   && podeMover(pos))//E PUDER SE MOVER PARA ELA
            {
                mat[pos.linha, pos.coluna] = true;//ESSA POSIÇÃO É MARCADA COMO TRUE
                if (tab.peca(pos) != null //SE NÃO ESTIVER VAZIA 
                && tab.peca(pos).cor != cor)//E A PEÇA FOR UMA ADVERSÁRIA - A PEÇA SERÁ COMIDA E O MOVIMENTO CESSARÁ
                {
                    break;
                }
                pos.linha = pos.linha - 1;//INCREMENTO - PRÓXIMA POSIÇÃO
            }

            //ABAIXO
            pos.definirValores(posicao.linha + 1, posicao.coluna);
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
            }

            //DIREITA
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            while (tab.posicaoValida(pos)
                   && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null
                && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna = pos.coluna + 1;
            }

            //ESQUERDA
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            while (tab.posicaoValida(pos)
                   && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null
                && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna = pos.coluna - 1;
            }

            //DO BISPO
            //DIAGONAL - ACIMA ESQUERDA
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
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
