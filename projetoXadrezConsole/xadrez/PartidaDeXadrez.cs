using System;
using tabuleiro;
using xadrez;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; } // A CADA JOGADA UM TURNO, 1,2,3....
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        public bool xeque { get; private set; }//ADVERSÁRIO ESTÁ EM XEQUE ?
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;


        //CONSTRUTORES
        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;//REGRA - A PARTIDA SEMPRE INICIA PELO JOGADOR PEÇAS BRANCAS
            terminada = false;
            xeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas(); //ADICIONA AS PEÇAS INICIAIS DA PARTIDA
                            //COLOCADO NO CONSTRUTOR APÓS A INICIALIZAÇÃO DOS CONJUNTOS pecas E capturadas
                            //SE NÃO GERA REFERÊNCIA null
        }

        //DEMAIS MÉTODOS
        //MÉTODO QUE INSERE AS PEÇAS INICIAIS NO TABULEIRO
        private void colocarPecas()
        {
            /*
            colocarNovaPeca('c', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('c', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('e', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('e', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 1, new Rei(tab, Cor.Branca));
            colocarNovaPeca('c', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('c', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('d', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('e', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('e', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('d', 8, new Rei(tab, Cor.Preta));
            */

            /*
            colocarNovaPeca('c', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 1, new Rei(tab, Cor.Branca));
            colocarNovaPeca('h', 7, new Torre(tab, Cor.Branca));
            colocarNovaPeca('a', 8, new Rei(tab, Cor.Preta));
            colocarNovaPeca('b', 8, new Torre(tab, Cor.Preta));
            */

            colocarNovaPeca('a',2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('b',2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('c',2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('d',2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('e',2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('f',2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('g',2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('h',2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('a',1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('b',1, new Cavalo(tab, Cor.Branca));
            colocarNovaPeca('c',1, new Bispo(tab, Cor.Branca));
            colocarNovaPeca('d',1, new Dama(tab, Cor.Branca));
            //CONSTRUTOR DE REI PRECISA DA PARTIDA COMO ARGUMENTO
            colocarNovaPeca('e',1, new Rei(tab, Cor.Branca, this));
            colocarNovaPeca('f',1, new Bispo(tab, Cor.Branca));
            colocarNovaPeca('g',1, new Cavalo(tab, Cor.Branca));
            colocarNovaPeca('h',1, new Torre(tab, Cor.Branca));

            colocarNovaPeca('a', 7, new Peao(tab, Cor.Preta));
            colocarNovaPeca('b', 7, new Peao(tab, Cor.Preta));
            colocarNovaPeca('c', 7, new Peao(tab, Cor.Preta));
            colocarNovaPeca('d', 7, new Peao(tab, Cor.Preta));
            colocarNovaPeca('e', 7, new Peao(tab, Cor.Preta));
            colocarNovaPeca('f', 7, new Peao(tab, Cor.Preta));
            colocarNovaPeca('g', 7, new Peao(tab, Cor.Preta));
            colocarNovaPeca('h', 7, new Peao(tab, Cor.Preta));
            colocarNovaPeca('a', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('b', 8, new Cavalo(tab, Cor.Preta));
            colocarNovaPeca('c', 8, new Bispo(tab, Cor.Preta));
            colocarNovaPeca('d', 8, new Dama(tab, Cor.Preta));
            //CONSTRUTOR DE REI PRECISA DA PARTIDA COMO ARGUMENTO
            colocarNovaPeca('e', 8, new Rei(tab, Cor.Preta, this));
            colocarNovaPeca('f', 8, new Bispo(tab, Cor.Preta));
            colocarNovaPeca('g', 8, new Cavalo(tab, Cor.Preta));
            colocarNovaPeca('h', 8, new Torre(tab, Cor.Preta));

        }
        
        //MÉTODO QUE ADICIONA UMA PEÇA NUMA POSIÇÃO DO TABULEIRO
        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);

        }

        //MÉTODO QUE RETORNA A COLEÇÃO DE PEÇAS CAPTURDAS DADA UMA COR
        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        //MÉTODO QUE RETORNA A COLEÇÃO DE PEÇAS EM JOGO (TODAS - CAPTURADAS)
        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));//RETIRA DO CONJUNTO TOTAL DE PEÇAS, AS CAPTURADAS
            return aux;
        }

        //MÉTODO QUE DEFINE QUAL É A COR DAS PEÇAS ADVERSÁRIAS, DADA UMA COR
        private Cor adversaria(Cor cor)
        {
            if(cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        //MÉTODO QUE RETORNA UMA PEÇA REI EM JOGO, DADA UMA COR
        private Peca rei(Cor cor)
        {
            foreach(Peca x in pecasEmJogo(cor))
            {
                if(x is Rei)
                {
                    return x;
                }
            }
            return null;//PRA NÃO GERAR ERRO - SEGURANÇA - EM TESE, NUNCA VAI OCORRER
        }

        //MÉTODO QUE VERIFICA SE O REI DE UMA DADA COR ESTÁ EM XEQUE
        public bool estaEmXeque(Cor cor)
        {
            Peca meuRei = rei(cor);//PEÇA REI DA COR DADA
            //SEGURANÇA - EM TESE, NUNCA VAI OCORRER
            if(meuRei == null)
            {
                throw new TabuleiroException($"Sem rei da cor {cor}");
            }

            foreach(Peca x in pecasEmJogo(adversaria(cor)))//PARA CADA PEÇA EM JOGO DA COR ADVERSÁRIA
            {
                //SALVO OS MOVIMENTOS POSSÍVEIS DESSA PEÇA
                bool[,] mat = x.movimentosPossiveis();
                //SE, DENTRE OS MOVIMENTOS POSSÍVEIS DESSA PEÇA, ESTIVER O REI EM ALGUMA DESSAS POSIÇÕES
                if (mat[meuRei.posicao.linha, meuRei.posicao.coluna] == true)
                {
                    return true;
                }
            }

            //SE CASO NÃO HOUVER O REI EM XEQUE, PARA NENHUMA PEÇA ADVERSÁRIA, false
            return false;
        }

        //MÉTODO QUE VERIFICA SE O REI DE UMA DADA COR ESTÁ EM XEQUE MATE
        public bool testeXequeMate(Cor cor)
        {
            //SE NÃO ESTIVER EM XEQUE, É IMPOSSÍVEL ESTAR EM XEQUE MATE
            if (!estaEmXeque(cor))
            {
                return false;
            }
            //VERIFICAR SE É POSSÍVEL SAIR DO XEQUE COLOCANDO ALGUMA PEÇA NO CAMINHO
            foreach(Peca x in pecasEmJogo(cor))
            {
                bool[,] mat = x.movimentosPossiveis();//MOVIMENTOS POSSÍVEIS DA PEÇA
                for(int i = 0; i < tab.linhas; i++)
                {
                    for(int j = 0; j < tab.colunas; j++)
                    {
                        if (mat[i, j])//PERCORRENDO TODAS SUAS POSIÇÕES POSSÍVEIS
                        {
                            Posicao origem = x.posicao;
                            Posicao destino = new Posicao(i, j);//AUXILIAR - PRA ONDE A PEÇA PRECISA IR PRA SALVAR O REI

                            Peca pecaCapturada = executaMovimento(origem, destino);
                            bool testeXeque = estaEmXeque(cor);
                            desfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;//CASO ALGUM MOVIMENTO POSSÍVEL CONSIGA TIRAR DO XEQUE, NÃO É XEQUE MATE
                            }
                        }
                    }
                }
            }
            return true;//SE MESMO COM QUALQUER MOVIMENTO, AINDA CONTINUE EM XEQUE, XEQUE MATE!
        }

        //MÉTODO QUE REALIZA A JOGADA MOVIMENTANDO A PEÇA E MUDANDO A COR DO JOGADOR ATUAL
        public void realizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = executaMovimento(origem, destino);//EXECUÇÃO DA JOGADA

            //APÓS A JOGADA, AVALIAR SE O JOGADOR ADVERSÁRIO ESTÁ EM XEQUE OU XEQUE MATE

            //SE SUA JOGADA DEIXOU VC EM XEQUE, APÓS O MOVIMENTO, A JOGADA É DESFEITA
            if (estaEmXeque(jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Voce não pode se colocar em xeque!");
            }

            //SE O JOGADOR ADVERSÁRIO ESTÁ EM XEQUE - NA PRÓXIMA ITERAÇÃO DO WHILE ELE APARECERÁ COMO "XEQUE"
            if (estaEmXeque(adversaria(jogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }

            //SE O JOGADOR ADVERSÁRIO ESTÁ EM XEQUE MATE - ACABA LAÇO WHILE - FIM DO JOGO
            if (testeXequeMate(adversaria(jogadorAtual)))
            {
                terminada = true;
            }
            else//SE NÃO HÁ XEQUE MATE, JOGO CONTINUA NORMALMENTE
            {
                turno++;
                mudaJogador();
            }

                
        }

        //MÉTODO QUE VALIDA A POSIÇÃO DA PEÇA DE ORIGEM ESCOLHIDA
        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if(tab.peca(pos) == null)//NÃO PODE SER UMA POSIÇÃO SEM PEÇA
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida");
            }
            if (jogadorAtual != tab.peca(pos).cor)//NÃO PODE SER PEÇA DA COR DIFERENTE DO TURNO
            {
                throw new TabuleiroException("A peça escolhida não é sua");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis())//PRECISA TER MOVIMENTOS POSSÍVEIS PARA A PEÇA
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça escolhida");
            }
        }

        //MÉTODO QUE VALIDA A POSIÇÃO DE DESTINO, DADA SUA ORIGEM E SEUS POSSÍVEIS MOVIMENTOS
        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).movimentoPossivel(destino))//SE NÃO PUDER SE MOVER PARA O DESTINO
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        //MÉTODO QUE MOVIMENTA A PEÇA NO TABULEIRO
        public Peca executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);//PEÇA SAI DA POSIÇÃO ORIGINAL DO TABULEIRO. SALVA EM p
            p.incrementarQtdMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);//PEÇA "COMIDA" É SALVA EM pecaCapturada
            tab.colocarPeca(p, destino);//PEÇA p COLOCADA NA POSIÇÃO DESTINO

            //PEÇA CAPTURADA ADICIONADA AO CONJUNTO DE CAPTURADAS
            if(pecaCapturada!= null)
            {
                capturadas.Add(pecaCapturada);
            }

            //#JOGADA ESPECIAL - ROQUE PEQUENO
            if(p is Rei && destino.coluna == origem.coluna + 2)//SE ESTIVER MOVENDO O REI DUAS CASAS PARA DIREITA
            {
                Posicao origemTorre = new Posicao(origem.linha, origem.coluna + 3);//IDENTIFICADO ONDE ESTÁ A TORRE PARA ROQUE
                Posicao destinoTorre = new Posicao(origem.linha, origem.coluna + 1);//ONDE A TORRE DEVE FICAR APÓS O ROQUE
                //FAZENDO O MOVIMENTO DA TORRE
                Peca torre = tab.retirarPeca(origemTorre);
                torre.incrementarQtdMovimentos();
                tab.colocarPeca(torre, destinoTorre);
            }

            //#JOGADA ESPECIAL - ROQUE GRANDE
            if (p is Rei && destino.coluna == origem.coluna - 2)//SE ESTIVER MOVENDO O REI DUAS CASAS PARA ESQUERDA
            {
                Posicao origemTorre = new Posicao(origem.linha, origem.coluna - 4);//IDENTIFICADO ONDE ESTÁ A TORRE PARA ROQUE
                Posicao destinoTorre = new Posicao(origem.linha, origem.coluna -1);//ONDE A TORRE DEVE FICAR APÓS O ROQUE
                //FAZENDO O MOVIMENTO DA TORRE
                Peca torre = tab.retirarPeca(origemTorre);
                torre.incrementarQtdMovimentos();
                tab.colocarPeca(torre, destinoTorre);
            }



            return pecaCapturada;
        }

        //MÉTODO QUE DESFAZ O MOVIMENTO DE UMA PEÇA
        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.retirarPeca(destino);//PEÇA NO DESTINO É RETIRADA DO TABULEIRO E SALVA EM p
            p.decrementarQtdMovimentos();

            if(pecaCapturada != null)//SE HOUVE ALGUMA PEÇA CAPTURADA NESSE MOVIMENTO ILEGAL
            {
                tab.colocarPeca(pecaCapturada, destino);//RETORNO A PEÇA AO TABULEIRO
                capturadas.Remove(pecaCapturada);//TIRO DA LISTA DE CAPTURADAS
            }
            tab.colocarPeca(p, origem);//COLOCO A PEÇA QUE SE MOVIMENTOU DE VOLTA NA ORIGEM


            //DESFAZER O ROQUE PEQUENO
            //#JOGADA ESPECIAL - ROQUE PEQUENO
            if (p is Rei && destino.coluna == origem.coluna + 2)//SE ESTIVER MOVENDO O REI DUAS CASAS PARA DIREITA
            {
                Posicao origemTorre = new Posicao(origem.linha, origem.coluna + 3);//IDENTIFICADO ONDE ESTÁ A TORRE PARA ROQUE
                Posicao destinoTorre = new Posicao(origem.linha, origem.coluna + 1);//ONDE A TORRE DEVE FICAR APÓS O ROQUE
                //DESFAZENDO O MOVIMENTO DA TORRE
                Peca torre = tab.retirarPeca(destinoTorre);
                torre.decrementarQtdMovimentos();
                tab.colocarPeca(torre, origemTorre);
            }

            //DESFAZER O ROQUE GRANDE
            //#JOGADA ESPECIAL - ROQUE PEQUENO
            if (p is Rei && destino.coluna == origem.coluna - 2)//SE ESTIVER MOVENDO O REI DUAS CASAS PARA ESQUERDA
            {
                Posicao origemTorre = new Posicao(origem.linha, origem.coluna - 4);//IDENTIFICADO ONDE ESTÁ A TORRE PARA ROQUE
                Posicao destinoTorre = new Posicao(origem.linha, origem.coluna - 1);//ONDE A TORRE DEVE FICAR APÓS O ROQUE
                //FAZENDO O MOVIMENTO DA TORRE
                Peca torre = tab.retirarPeca(destinoTorre);
                torre.decrementarQtdMovimentos();
                tab.colocarPeca(torre, origemTorre);
            }

        }

        //MÉTODO QUE MUDA A COR DO JOGADOR ATUAL
        private void mudaJogador()
        {
            if(jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }








    }
}
