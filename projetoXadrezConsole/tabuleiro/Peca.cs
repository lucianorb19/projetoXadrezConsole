namespace tabuleiro
{
    class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }
        //protected - SOMENTE A CLASSE E SUAS SUBCLASSES PODEM MODIFICAR O VALOR DO ATRIBUTO


        //CONSTRUTORES
        public Peca()
        {
        }
        public Peca(Tabuleiro tab, Cor cor)
        {
            this.tab = tab;
            this.cor = cor;
            this.posicao = null;
            this.qteMovimentos = 0;//PEÇA INICIA COM 0 MOVIMENTOS
        }

        //DEMAIS MÉTODOS
        public void incrementarQtdMovimentos()
        {
            this.qteMovimentos++;
        }


    }
}
