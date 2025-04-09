# PROJETO XADREZCONSOLE :chess_pawn: :desktop_computer:

Jogo de xadrez, via console, construído na linguagem **_C#_**, no **_Visual Studio_**, seguindo as orientações do professor [Nélio Alves](https://www.udemy.com/course/programacao-orientada-a-objetos-csharp/?couponCode=ST13MT80425G3).


## CLASSES DO PROJETO :books:

* tabuleiro
    * Cor.cs
    * Peca.cs
    * Posicao.cs
    * Tabuleiro.cs
    * TabuleiroException.cs
* xadrez
    * Bispo.cs
    * Cavalo.cs
    * Dama.cs
    * ParidaDeXadrez.cs
    * Peao.cs
    * PosicaoXadrez.cs
    * Rei.cs
    * Torre.cs
* Program.cs
* Tela.cs

## OBSERVAÇÕES :bookmark_tabs:

Em relação ao projeto original, foram feitas alterações na maneira como a tela é mostrada ao usuário. Uma abordagem mais amigável.
E também foram feitas verificação na entrada do usuário, utilizando os métodos lerPosicaoXadrez() e processaEntrada(), que garante:
* Entrada do usuário precisa ser uma posição do tabuleiro no formato coluna+linha (Ex: a2, b7, c8, A3, D5, H4);
* Coluna informada entre A e H;
* Linha informada entre 1 e 8;
* Entrada não pode ser vazia;
* Espaços antes e depois são retirados;

:scroll:
```
private static string processaEntrada()
{
    //COLUNAS E LINHAS POSSÍVEIS EM DUAS LISTAS
    List<char> colunas = new List<char>();
    colunas.Add('a'); colunas.Add('b'); colunas.Add('c'); colunas.Add('d');
    colunas.Add('e'); colunas.Add('f'); colunas.Add('g'); colunas.Add('h');
    List<int> linhas = new List<int>();
    linhas.Add(1); linhas.Add(2); linhas.Add(3); linhas.Add(4);
    linhas.Add(5); linhas.Add(6); linhas.Add(7); linhas.Add(8);

    bool valida = false;
    while(valida == false)
    {
        string entrada = Console.ReadLine();

        if (entrada.Length == 2 && //TAMANHO 2
        !(String.IsNullOrEmpty(entrada)) && //NÃO ESTÁ VAZIA OU NULL
        Char.IsLetter(entrada[0]) && //COLUNA É LETRA
        Char.IsNumber(entrada[1])) // LINHA PODE SER CONVERTIDO PARA INTEIRO
        {
            entrada = entrada.Trim();//RETIRA ESPAÇOS ANTES E DEPOIS
            char coluna = Char.ToLower(entrada[0]);//SE FOR MAIÚSCULO, É TRANSFORMADO EM MINÚSCULO
            entrada = $"{coluna}" + $"{entrada[1]}";

            char linha = entrada[1];//AUXILIARES PARA ESCREVER MENOS
            int int_linha = linha - '0';//-----MACETE - CONVERTER A LINHA PARA INTEIRO, '2' vira 2

            foreach (char c in colunas)
            {
                if (c == coluna)//HAVENDO UMA COLUNA VÁLIDA
                {
                    foreach (int l in linhas)
                    {
                        if (l == int_linha)//HAVENDO UMA LINHA VÁLIDA
                        {
                            valida = true;//CONDIÇÃO PARA SAIR DO LAÇO
                            return entrada; //RETORNO A ENTRADA PROCESSADA
                        }
                    }
                }
            }
        }
        else//CASO NÃO SEJA ENTRADA VÁLIDA - TENTAR NOVAMENTE
        {
            Console.Write("Entrada inválida. Tente novamente\n--> ");
        }
    }//APÓS ENTRADA SER VÁLIDA - (EM TEORIA, NEM CHEGA AQUI NUNCA, MAS SE NÃO HOUVER ESSE RETURN, INDICA ERRO)
    return null;
}
```
