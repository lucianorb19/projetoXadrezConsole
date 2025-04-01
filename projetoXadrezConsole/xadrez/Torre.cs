using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {

        //CONSTRUTORES
        public Torre()
        {
        }

        //CONSTRUTOR - SÓ PEGA AS INFORMAÇÕES DA BASE
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor) { }

        //DEMAIS MÉTODOS
        public override string ToString()
        {
            return $"T";
        }



    }
}
