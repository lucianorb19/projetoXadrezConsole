using tabuleiro;
using System;

namespace xadrez
{
    class PosicaoXadrez
    {
        public char coluna { get; set; }
        public int linha { get; set; }

        //CONSTRUTORES
        public PosicaoXadrez(char coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;
        }

        //DEMAIS MÉTODOS
        //MÉTODO QUE CONVERTE AS POSIÇÕES DO XADREZ PARA POSICÕES DA MATRIZ - OBJETOS Posicao
        // (A2) - (6,0)
        // (D4) - (4,3)
        public Posicao toPosicao()
        {
            return new Posicao(8 - linha, coluna - 'a'); //---------------MACETE---------------
            //LETRA PRECISA SER MINÚSCULO
        }


        public override string ToString()
        {
            return $" {coluna}{linha}";
        }
    }
}
