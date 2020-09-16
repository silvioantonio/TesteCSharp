using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ListaDeObject
    {
        private Object[] _itens;
        private int _proximaPosicao;

        public int Tamanho
        {
            get
            {
                return _proximaPosicao;
            }
        }

        public ListaDeObject()
        {
            _itens = new Object[5];
            _proximaPosicao = 0;
        }

        public void Adicionar(Object item)
        {
            VerificaCapacidade(_proximaPosicao + 1);

            _itens[_proximaPosicao] = item;
            Console.WriteLine($"Adicionando item na posicao {_proximaPosicao}");
            _proximaPosicao++;
        }

        // O params entede que varios parametros sao aceitaveis
        public void AdicionarVarios(params Object[] itens)
        {
            foreach (Object conta in itens)
            {
                Adicionar(conta);
            }
        }

        public void Remover(Object item)
        {
            int indiceItem = -1;

            for (int i = 0; i < _proximaPosicao; i++)
            {
                if (_itens.Equals(item))
                {
                    indiceItem = i;
                    break;
                }
            }

            for (int i = indiceItem; i < _proximaPosicao - 1; i++)
            {
                _itens[i] = _itens[i + 1];
            }
            _proximaPosicao--;
            _itens[_proximaPosicao] = null;
        }

        public Object GetItemNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
                throw new ArgumentOutOfRangeException(nameof(indice));
            return _itens[indice];
        }

        public Object this[int indice]
        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }

        private void VerificaCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
                return;
            Object[] novoArray = new Object[tamanhoNecessario];

            for (int i = 0; i < _itens.Length; i++)
            {
                novoArray[i] = _itens[i];
            }
            _itens = novoArray;
        }

    }
}
