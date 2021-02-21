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
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.ColocarPeca(new Torre(Projeto_Xadrez.tabuleiro.Enums.Cor.Black, tab), new Posicao(0, 0));
                tab.ColocarPeca(new Torre(Projeto_Xadrez.tabuleiro.Enums.Cor.Black, tab), new Posicao(1, 3));
                tab.ColocarPeca(new Rei(Projeto_Xadrez.tabuleiro.Enums.Cor.Black, tab), new Posicao(0, 2));

                tab.ColocarPeca(new Rei(Projeto_Xadrez.tabuleiro.Enums.Cor.White, tab), new Posicao(2, 3));
                tab.ColocarPeca(new Torre(Projeto_Xadrez.tabuleiro.Enums.Cor.White, tab), new Posicao(3, 3));

                Tela.imprimirTabuleiro(tab);
            }

            catch (TabuleiroExeception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}
