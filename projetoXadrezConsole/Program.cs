using xadrez;
using System;
using System.Data;
using tabuleiro;
using xadrez;

namespace projetoXadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try//TRY PARA QUALQUER PROBLEMA NA INICIALIZAÇÃO DA PARTIDA
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    try//TRY PARA ERRO DURANTE AS JOGADAS - REPETE A JOGADA CASO HAJA ERRO
                    {
                        Console.Clear();//LIMPA O CONSOLE
                        Tela.imprimirPartida(partida);

                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        //MOSTRAR OS MOVIMENTOS POSSÍVEIS
                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizaJogada(origem, destino);
                    }
                    catch(TabuleiroException e)
                    {
                        Console.WriteLine($"Erro. {e.Message}");
                        Console.ReadLine();//ESPERA O USUÁRIO DIGITAR ALGO PARA CONTINUAR O WHILE - REPETIR O TURNO
                    }

                    Console.Clear();//LIMPA O CONSOLE
                    Tela.imprimirPartida(partida);

                }
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine($"Erro. {e.Message}");
            }
            
        }
    }
}
