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
        public Peca peca (int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        //MÉTODO QUE ADICIONA UMA PEÇA AO TABULEIRO
        public void colocarPeca(Peca p, Posicao pos)
        {
            pecas[pos.linha, pos.coluna] = p;//MATRIZ RECEBE A PEÇA NA POSIÇÃO ESPECÍFICA
            p.posicao = pos;//ESSA PEÇA GUARDA A INFORMAÇÃO DE SEU LOCAL
        }



    }
}
