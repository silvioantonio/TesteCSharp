using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos;

namespace ByteBank.SistemaAgencia
{
    class ListaDeContaCorrente : ListaDeObject
    {
        private ContaCorrente[] _itens;
        private int _proximaPosicao;

        public int Tamanho
        {
            get
            {
                return _proximaPosicao;
            }
        }

        public ListaDeContaCorrente()
        {
            _itens = new ContaCorrente[5];
            _proximaPosicao = 0;
        }

        public void Adicionar(ContaCorrente item)
        {
            VerificaCapacidade(_proximaPosicao + 1);

            _itens[_proximaPosicao] = item;
            Console.WriteLine($"Adicionando item na posicao {_proximaPosicao}");
            _proximaPosicao++;
        }

        // O params entede que varios parametros sao aceitaveis
        public void AdicionarVarios(params ContaCorrente[] itens)
        {
            foreach(ContaCorrente conta in itens)
            {
                Adicionar(conta);
            }
        }

        public void Remover(ContaCorrente item)
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

        public ContaCorrente GetItemNoIndice(int indice)
        {
            if(indice < 0 || indice >= _proximaPosicao)
                throw new ArgumentOutOfRangeException(nameof(indice));
            return _itens[indice];
        }

        public ContaCorrente this[int indice]
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
            ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];

            for (int i = 0; i < _itens.Length; i++)
            {
                novoArray[i] = _itens[i];
            }
            _itens = novoArray;
        }

        
    }
}
