using System;


namespace tabuleiro
{
    class TabuleiroException : Exception //HERDA DE EXCEPTION - CLASSE PARA PERSONALIZAR EXCEÇÕES
    {
        public TabuleiroException(string msg) : base(msg){}//CONTRUTOR QUE USA O CONSTRUTOR DA CLASSE BASE
    }
}
