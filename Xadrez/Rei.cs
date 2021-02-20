using Projeto_Xadrez.tabuleiro;
using Projeto_Xadrez.tabuleiro.Enums;
namespace Projeto_Xadrez.Xadrez
{
    class Rei : Peca
    {
        public Rei(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {

        }

        public override string ToString()
        {
            return "R";
        }
    }
}