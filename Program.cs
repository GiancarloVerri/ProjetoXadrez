using System;
using Projeto_Xadrez.tabuleiro;
using Projeto_Xadrez.Xadrez;

namespace Projeto_Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.ColocarPeca(new Torre(tabuleiro.Enums.Cor.Black, tab), new Posicao(0, 0));
            tab.ColocarPeca(new Torre(tabuleiro.Enums.Cor.Black, tab), new Posicao(1, 3));
            tab.ColocarPeca(new Rei(tabuleiro.Enums.Cor.Black, tab), new Posicao(2, 4));

            Tela.imprimirTabuleiro(tab);
        }
    }
}
