using Projeto_Xadrez.tabuleiro;
using Projeto_Xadrez.tabuleiro.Enums;
namespace Projeto_Xadrez.Xadrez
{
    class Torre : Peca
    {
        public Torre(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {

        }

        public override string ToString()
        {
            return "T";
        }
    }
}