namespace tabuleiro
{
    abstract class Peca
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

        public void decrementarQtdMovimentos()
        {
            this.qteMovimentos--;
        }

        //MÉTODO BOOL - AVALIA SE NA MATRIZ DE MOVIMENTOS POSSÍVEIS HÁ AO MENOS UMA POSIÇÃO TRUE
        //OU SEJA, HÁ ALGUMA MOVIMENTO POSSÍVEL PARA AQUELA PEÇA?
        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for(int i=0; i < tab.linhas; i++)
            {
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (mat[i,j] == true)
                    {
                        return true;
                    }
                }

            }
            return false;//RETORNA FALSE CASO PERCORRA TUDO E NÃO ENCONTRE 1 TRUE
        }


        //MÉTODO BOOL - TRUE SE A POSIÇAO PASSADA COMO PARÂMETRO ESTIVER NO VETOR DE MOVIMENTOS POSSÍVEIS
        //OU SEJA, A POSIÇÃO ESCOLHIDA É PERMITIDA?
        public bool movimentoPossivel(Posicao pos)
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }


        //MÉTODO ABSTRATO QUE SERÁ HERDADO POR CADA PEÇA ESPECÍFICA
        //SEU RETORNO É UMA MATRIZ BIDIMENSIONAL MARCANDO COMO
        //TRUE - TODAS POSIÇÕES POSSÍVEIS PARA MOVIMENTAR
        //FALSE - TODAS POSIÇÕES INDISPONÍVEIS
        public abstract bool[,] movimentosPossiveis();



    }
}
