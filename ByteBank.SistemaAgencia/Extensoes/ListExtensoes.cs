using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public static class ListExtensoes
    {
        // Metodo de extensao, e estamos indicando que estamos extendendo o tipo List 
        //apenas usando a palavra reservada this antes do nome do primeiro argumento
        // Automagicamente o valor passado para a lista sera identificado e o seu tipo sera atribuido no lugar de <T>.
        public static void AdicionarVarios<T>(this List<T> listaDeInteiros, params T[] itens)
        {
            foreach (T item in itens)
            {
                listaDeInteiros.Add(item);
            }
        }

        // Aqui eu devo dizer qual o tipo generico da classe, ja que o string nao referencia como generico
        public static void TesteGenerico<T2>(this string texto)
        {

        }

        public static void Teste()
        {
            List<int> idades = new List<int>();
            idades.Add(25);
            idades.Add(2);
            idades.Add(5);

            idades.AdicionarVarios(53, 64,12);

            //ListExtensoes<int>.AdicionarVarios(idades, 34, 21);

            List<string> nome = new List<string>();
            nome.Add("Fulano");

            string guilherme = "guilherme";

            guilherme.TesteGenerico<string>();

            //ListExtensoes<string>.AdicionarVarios(nome, "Rau", "paulo");


        }
    }
}
