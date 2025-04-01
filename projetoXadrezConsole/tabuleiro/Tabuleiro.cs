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



    }
}
