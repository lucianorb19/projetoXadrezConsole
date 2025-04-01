using System;


namespace tabuleiro
{
    class Posicao
    {
        public int linha { get; set; }//PQ NÃO COMEÇA MAIÚSCULO ?
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



    }
}
