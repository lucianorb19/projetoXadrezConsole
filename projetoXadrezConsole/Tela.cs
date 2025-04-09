using xadrez;
using System;
using tabuleiro;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
            string s = processaEntrada();//ENTRADA É PROCESSADA PARA Q SEJA VÁLIDA
            char coluna = Char.ToLower(s[0]);//ACEITA COLUNA TANTO MAIÚSCULA QUANTO MINÚSCULA
            int linha = s[1]-'0';//-----MACETE - CONVERTER A LINHA PARA INTEIRO - '2' VIRA 2
            return new PosicaoXadrez(coluna, linha);
        }

        //MÉTODO QU PROCESSA A ENTRADA DA POSIÇÃO PELO USUÁRIO - RETORNA A ENTRADA SE VÁLIDA, SE NÃO, REPETE
        //ENTRADA DO USUÁRIO PRECISA SER DE TAMANHO 2
        //FORMATO LETRA+NÚMERO SENDO
        //LETRA DE a A h (MAIÚSCULO OU MINÚSCULO)
        //NÚMERO INTEIRO DE 1 A 8
        //ENTRADA NÃO PODE SER VAZIA
        //SEM ESPAÇOS ANTES E DEPOIS
        private static string processaEntrada()
        {
            //COLUNAS E LINHAS POSSÍVEIS EM DUAS LISTAS
            List<char> colunas = new List<char>();
            colunas.Add('a'); colunas.Add('b'); colunas.Add('c'); colunas.Add('d');
            colunas.Add('e'); colunas.Add('f'); colunas.Add('g'); colunas.Add('h');
            List<int> linhas = new List<int>();
            linhas.Add(1); linhas.Add(2); linhas.Add(3); linhas.Add(4);
            linhas.Add(5); linhas.Add(6); linhas.Add(7); linhas.Add(8);

            bool valida = false;
            while(valida == false)
            {
                string entrada = Console.ReadLine();

                if (entrada.Length == 2 && //TAMANHO 2
                !(String.IsNullOrEmpty(entrada)) && //NÃO ESTÁ VAZIA OU NULL
                Char.IsLetter(entrada[0]) && //COLUNA É LETRA
                Char.IsNumber(entrada[1])) // LINHA PODE SER CONVERTIDO PARA INTEIRO
                {
                    entrada = entrada.Trim();//RETIRA ESPAÇOS ANTES E DEPOIS
                    char coluna = Char.ToLower(entrada[0]);//SE FOR MAIÚSCULO, É TRANSFORMADO EM MINÚSCULO
                    entrada = $"{coluna}" + $"{entrada[1]}";

                    char linha = entrada[1];//AUXILIARES PARA ESCREVER MENOS
                    int int_linha = linha - '0';//-----MACETE - CONVERTER A LINHA PARA INTEIRO, '2' vira 2

                    foreach (char c in colunas)
                    {
                        if (c == coluna)//HAVENDO UMA COLUNA VÁLIDA
                        {
                            foreach (int l in linhas)
                            {
                                if (l == int_linha)//HAVENDO UMA LINHA VÁLIDA
                                {
                                    valida = true;//CONDIÇÃO PARA SAIR DO LAÇO
                                    return entrada; //RETORNO A ENTRADA PROCESSADA
                                }
                            }
                        }
                    }
                }
                else//CASO NÃO SEJA ENTRADA VÁLIDA - TENTAR NOVAMENTE
                {
                    Console.Write("Entrada inválida. Tente novamente\n--> ");
                }
            }//APÓS ENTRADA SER VÁLIDA - (EM TEORIA, NEM CHEGA AQUI NUNCA, MAS SE NÃO HOUVER ESSE RETURN, INDICA ERRO)
            return null;
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
