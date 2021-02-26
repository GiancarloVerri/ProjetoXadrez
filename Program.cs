using System;
using Projeto_Xadrez.tabuleiro;
using Projeto_Xadrez.Xadrez;
using Projeto_Xadrez.tabuleiro.Exceptions;

namespace Projeto_Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada)
                {
                    try
                    {
                        System.Console.Clear();

                        Tela.ImprimirPartida(partida);
                        System.Console.WriteLine();
                        System.Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoOrigem(origem);

                        bool[,] posicoesPossiveis = partida.Tabuleiro.Peca(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);

                        System.Console.WriteLine();
                        System.Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoDestino(origem, destino);

                        partida.RealizaJogada(origem, destino);
                    }
                    catch (TabuleiroExeception e)
                    {
                        System.Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }

            catch (TabuleiroExeception e)
            {
                System.Console.WriteLine(e.Message);
            }
            catch (System.IO.IOException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}
