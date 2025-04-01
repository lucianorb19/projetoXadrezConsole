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
        public Peca(Posicao posicao, Tabuleiro tab, Cor cor)
        {
            this.posicao = posicao;
            this.tab = tab;
            this.cor = cor;
            this.qteMovimentos = 0;//PEÇA INICIA COM 0 MOVIMENTOS
        }


    }
}
