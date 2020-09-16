using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos;

namespace ByteBank.SistemaAgencia
{
    class ComparadorContaCorrentePorAgencia : IComparer<ContaCorrente>
    {
        public int Compare(ContaCorrente x, ContaCorrente y)
        {

            return x.CompareTo(y);

            //if (x == y)
            //{
            //    return 0;
            //}

            //if (x == null)
            //{
            //    return 1;
            //}
            //if (y == null)
            //{
            //    return -1;
            //}
            //if (x.Agencia < y.Agencia)
            //{
            //    return -1;
            //}
            //if (x.Numero == y.Numero)
            //{
            //    return 0;
            //}
            //return 1;
        }
    }
}
