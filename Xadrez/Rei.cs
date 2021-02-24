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

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);

            return p == null || p.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicao = new Posicao(0, 0);

            posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna);

            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna + 1);

            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.DefinirValores(posicao.Linha, posicao.Coluna + 1);

            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna + 1);

            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna);

            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna - 1);

            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.DefinirValores(posicao.Linha, posicao.Coluna - 1);

            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna - 1);

            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            return mat;

        }
    }
}