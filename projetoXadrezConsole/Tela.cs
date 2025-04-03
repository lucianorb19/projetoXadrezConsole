using System;
using tabuleiro;
using xadrez;

namespace projetoXadrezConsole
{
    class Tela
    {
        //MÉTODO QUE IMPRIME O TABULEIRO DE PEÇAS
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for(int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8-i + " ");//MOSTRA O NÚMERO DA LINHA
                for(int j = 0; j < tab.colunas; j++)
                {
                    if(tab.peca(i,j) == null)//USO MÉTODO peca de Tabuleiro
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        imprimirPeca(tab.peca(i, j));//MÉTODO ESTÁTICO DA CLASSE
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        //MÉTODO QUE RECEBE A POSIÇÃO DA PEÇA DO USUÁRIO - PARA INICIAR A MOVIMENTAÇÃO
        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");//------MACETE - FORÇAR A ENTRADA A SER UM STRING ANTES DE CONVERTER PARA INT
            return new PosicaoXadrez(coluna, linha);
        }



        //MÉTODO QUE MOSTRA AS PEÇAS EM CORES DIFERENTES NO MOMENTO DA IMPRESSÃO
        public static void imprimirPeca(Peca peca)
        {
            if(peca.cor == Cor.Branca)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }









    }
}
