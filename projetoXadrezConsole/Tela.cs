using xadrez;
using System;
using tabuleiro;

namespace projetoXadrezConsole
{
    class Tela
    {
        //MÉTODO QUE IMPRIME O TABULEIRO, PEÇAS CAPTURADAS, TURNO DO JOGADOR E AGUARDA JOGADA DO USUARIO
        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine($"Turno: {partida.turno}");
            if (!partida.terminada)//PARTIDA NÃO TERMINADA
            {
                Console.WriteLine($"Aguardando jogada: {partida.jogadorAtual}");
                if (partida.xeque)
                {
                    Console.WriteLine();
                    Console.WriteLine("Xeque!!!!");
                    Console.WriteLine();
                }
            }
            else//SE PARTIDA TERMINADA
            {
                Console.WriteLine();
                Console.WriteLine("Xeque-mate!");
                Console.WriteLine($"Vencedor: {partida.jogadorAtual}");
                Console.WriteLine();
                Console.ReadLine();
            }
            Console.WriteLine();
        }

        //MÉTODO QUE IMPRIME AS DUAS COLEÇÕES DE PEÇAS CAPTURADAS
        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            //PRETAS IMPRESSAS COM COR AMARELA
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
        }

        //MÉTODO QUE IMPRIME UMA COLEÇÃO DE PEÇAS CAPTURADAS
        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[ ");
            foreach(Peca x in conjunto)
            {
                Console.Write($"{x} ");
            }
            Console.Write("]");
            Console.WriteLine();
        }

        //MÉTODO QUE IMPRIME O TABULEIRO DE PEÇAS
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            Console.WriteLine("====================================");
            Console.WriteLine();
            for(int i = 0; i < tab.linhas; i++)
            {
                Console.Write("        ");
                Console.Write(8-i + " ");//MOSTRA O NÚMERO DA LINHA
                for(int j = 0; j < tab.colunas; j++)
                {
                    imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            
            Console.Write("        ");
            Console.WriteLine("  a b c d e f g h");
            Console.WriteLine();
            Console.WriteLine("====================================");

        }

        //MÉTODO QUE IMPRIME O TABULEIRO DE PEÇAS E MOVIMENTOS POSSÍVEIS
        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {

            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            Console.WriteLine("====================================");
            Console.WriteLine();
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write("        ");
                Console.Write(8 - i + " ");//MOSTRA O NÚMERO DA LINHA
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPossiveis[i,j] == true)//SE ESTA FOR UMA POSIÇÃO POSSÍVEL
                    {
                        Console.BackgroundColor = fundoAlterado;//FUNDO CINZA CLARO
                    }
                    else//SE NÃO
                    {
                        Console.BackgroundColor = fundoOriginal;//FUNDO CINZA ESCURO
                    }
                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            
            Console.Write("        ");
            Console.WriteLine("  a b c d e f g h");
            Console.WriteLine();
            Console.WriteLine("====================================");
            Console.BackgroundColor = fundoOriginal;
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
            if (peca == null)
            {
                Console.Write("- ");
            }
            else//CASO HAJA PEÇA
            {
                if (peca.cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    //IMPRIME PEÇAS PRETAS COMO AMARELAS - FUNDO JÁ É PRETO
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
            
        }





    }
}
