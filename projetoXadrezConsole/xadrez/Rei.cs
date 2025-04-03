using tabuleiro;

namespace xadrez
{
    class Rei : Peca //Rei HERDA DE Peca
    {
        
        //CONSTRUTORES
        public Rei()
        {
        }

        //CONSTRUTOR - SÓ PEGA AS INFORMAÇÕES DA BASE
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor) {}

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

            return mat;//RETORNO É A MATRIZ COM POSIÇÕES TRUE ONDE A PEÇA PODE SE MOVER
        }


    }
}
