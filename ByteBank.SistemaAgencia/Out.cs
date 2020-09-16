using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public static class Out
    {
        public static void PrintLn(this object obj){
            Console.WriteLine(obj);
        }

        public static void Print(this object obj)
        {
            Console.Write(obj);
        }
    }
}
