namespace tabuleiro
{
    class Posicao
    {
        public int linha { get; set; }
        public int coluna { get; set; }

        //CONSTRUTORES
        public Posicao()
        {
        }
        public Posicao(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
        }


        //DEMAIS MÉTODOS
        public override string ToString()
        {
            return $"{linha},{coluna}";
        }

        //MÉTODO QUE DEFINE OS VALORES DE LINHA E COLUNA DE UM OBJETO POSICAO - USADO EM CADA PEÇA
        public void definirValores(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
        }



    }
}
