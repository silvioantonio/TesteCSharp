using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    partial class Program
    {
        static void UsandoStreamEntrada()
        {
            using (var fluxoDeEntrada = Console.OpenStandardInput())
            using(var fileStream = new FileStream("../entradaConsole.txt", FileMode.Create))
            {
                var buffer = new byte[1024];

                while (true)
                {
                    var bytesLidos = fluxoDeEntrada.Read(buffer, 0, 1024);

                    fileStream.Write(buffer, 0, bytesLidos);

                    fileStream.Flush();

                    Out.PrintLn($"Bytes lidos da Console {bytesLidos}");
                }

            }
        }
    }
}
