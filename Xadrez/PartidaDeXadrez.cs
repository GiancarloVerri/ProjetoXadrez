using Projeto_Xadrez.tabuleiro;
using Projeto_Xadrez.tabuleiro.Enums;
using Projeto_Xadrez.tabuleiro.Exceptions;
using System.Collections.Generic;
namespace Projeto_Xadrez.Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.White;
            Terminada = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarQtdMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(peca, destino);

            if (pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }

        public void ValidarPosicaoOrigem(Posicao posicao)
        {
            if (Tabuleiro.Peca(posicao) == null)
            {
                throw new TabuleiroExeception("Não existe peça na posição de origem escolhida!");
            }
            if (JogadorAtual != Tabuleiro.Peca(posicao).Cor)
            {
                throw new TabuleiroExeception("Peça escolhida não é sua!");
            }
            if (!Tabuleiro.Peca(posicao).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroExeception("Não existem movimentos possiveis desta peça!");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.Peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroExeception("Posição de destino inválida!");
            }
        }

        private void MudaJogador()
        {
            if (JogadorAtual == Cor.White)
            {
                JogadorAtual = Cor.Black;
            }
            else
            {
                JogadorAtual = Cor.White;
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca x in Capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca x in Pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }

            aux.ExceptWith(PecasCapturadas(cor));

            return aux;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);

        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('c', 1, new Torre(Cor.White, Tabuleiro));
            ColocarNovaPeca('c', 2, new Torre(Cor.White, Tabuleiro));
            ColocarNovaPeca('d', 2, new Torre(Cor.White, Tabuleiro));
            ColocarNovaPeca('e', 2, new Torre(Cor.White, Tabuleiro));
            ColocarNovaPeca('e', 1, new Torre(Cor.White, Tabuleiro));
            ColocarNovaPeca('d', 1, new Rei(Cor.White, Tabuleiro));

            ColocarNovaPeca('c', 7, new Torre(Cor.Black, Tabuleiro));
            ColocarNovaPeca('c', 8, new Torre(Cor.Black, Tabuleiro));
            ColocarNovaPeca('d', 7, new Torre(Cor.Black, Tabuleiro));
            ColocarNovaPeca('e', 7, new Torre(Cor.Black, Tabuleiro));
            ColocarNovaPeca('e', 8, new Torre(Cor.Black, Tabuleiro));
            ColocarNovaPeca('d', 8, new Rei(Cor.Black, Tabuleiro));
        }
    }
}