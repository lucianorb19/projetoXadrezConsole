namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;//MATRIZ BIDIMENSIONAL DE PEÇAS

        //CONSTRUTORES
        public Tabuleiro()
        {
        }
        //MATRIZ DE PEÇAS DO TABULEIRO TEM TAMANHO linhas X colunas
        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        //DEMAIS MÉTODOS
        //MÉTODO QUE ACESSA UMA PEÇA DADA A LINHA E COLUNA
        public Peca peca (int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        //MESMO MÉTODO DE CIMA, MAS USANDO UM OBJETO Posicao
        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }

        //MÉTODO QUE ADICIONA UMA PEÇA AO TABULEIRO - NUMA POSIÇÃO VAZIA E VÁLIDA
        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException($"Já existe uma peça nessa posição ({pos.linha},{pos.coluna})");
            }
            pecas[pos.linha, pos.coluna] = p;//MATRIZ RECEBE A PEÇA NA POSIÇÃO ESPECÍFICA
            p.posicao = pos;//ESSA PEÇA GUARDA A INFORMAÇÃO DE SEU LOCAL
        }

        //MÉTODO QUE RETIRA UMA PEÇA DO TABULEIRO DADA UMA POSIÇÃO COM PEÇA
        public Peca retirarPeca(Posicao pos)
        {
            if(peca(pos) == null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.linha, pos.coluna] = null;
            return aux;//PEÇA É RETIRADA DO TABULEIRO, MAS O MÉTODO RETONA A PEÇA.
        }

        //MÉTODO BOOL QUE VALIDA UMA POSIÇÃO - AUXILIAR DO MÉTODO ABAIXO
        public bool posicaoValida(Posicao pos)
        {
            if(pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
        }

        //MÉTODO QUE VALIDA A POSIÇÃO - UMA EXCEÇÃO PERSONALIZADA
        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException($"Posição inválida! ({pos.linha},{pos.coluna})");
            }
        }

        //MÉTODO BOOL - AVALIA SE HÁ UMA PEÇA NUMA POSIÇÃO VÁLIDA
        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }



    }
}
