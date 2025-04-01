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



    }
}
