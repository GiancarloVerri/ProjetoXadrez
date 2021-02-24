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
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.Tabuleiro);

                    System.Console.WriteLine();
                    System.Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                    System.Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                    partida.ExecutaMovimento(origem, destino);
                }
            }

            catch (TabuleiroExeception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}
