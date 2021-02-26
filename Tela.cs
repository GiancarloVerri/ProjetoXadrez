using Projeto_Xadrez.tabuleiro;
using System;
using Projeto_Xadrez.Xadrez;
using System.Collections.Generic;
namespace Projeto_Xadrez
{
    class Tela
    {

        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            Tela.imprimirTabuleiro(partida.Tabuleiro);
            System.Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            System.Console.WriteLine();
            System.Console.WriteLine("Turno: " + partida.Turno);
            System.Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
        }

        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            System.Console.WriteLine("Peças capturadas: ");
            System.Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(tabuleiro.Enums.Cor.White));
            System.Console.WriteLine();
            System.Console.Write("Pretas: ");
            ImprimirConjunto(partida.PecasCapturadas(tabuleiro.Enums.Cor.Black));
            System.Console.WriteLine();

        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            System.Console.Write("[");
            foreach (Peca peca in conjunto)
            {
                System.Console.Write(peca + " ");
            }
            System.Console.Write("]");
        }
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                System.Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    imprimirPeca(tab.Peca(i, j));
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;
            for (int i = 0; i < tab.Linhas; i++)
            {
                System.Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.Peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");

            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca)
        {

            if (peca == null)
            {
                System.Console.Write("- ");
            }

            else
            {

                if (peca.Cor == tabuleiro.Enums.Cor.White)
                {
                    System.Console.Write(peca);
                }

                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                System.Console.Write(" ");
            }
        }
    }
}