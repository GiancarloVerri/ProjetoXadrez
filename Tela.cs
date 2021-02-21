using Projeto_Xadrez.tabuleiro;
using System;
namespace Projeto_Xadrez
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                System.Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (tab.Peca(i, j) == null)
                    {
                        System.Console.Write("- ");
                    }
                    else
                    {
                        imprimirPeca(tab.Peca(i, j));
                        System.Console.Write(" ");
                    }

                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirPeca(Peca peca)
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
        }
    }
}