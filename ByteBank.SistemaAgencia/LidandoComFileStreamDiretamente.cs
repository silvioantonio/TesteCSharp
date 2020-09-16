using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    // declaração de classe separada, sera unida atravez da palavra 'partial'
    partial class Program
    {
        static void TestarLidandoFileStreamDiretamente()
        {
            //var enderecoDoArquivo = "C:\Users\silvio.junior\source\repos\ByteBankk\contas.txt";
            var enderecoDoArquivo = "../contas.txt"; // Ira verificar no diretorio da solução do executavel

            // Utilizando 'using' é possivel utilizar o recurso criado e ao final caso nao gere exception, ele ira chamar o 'close()' do recurso.
            using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                var buffer = new byte[1024]; // 1kb

                var numerosDeBytesLidos = -1;

                while (numerosDeBytesLidos != 0)
                {
                    //---------------------Atualiza o conteudo do buffer
                    numerosDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);

                    EscreverBuffer(buffer, numerosDeBytesLidos);
                }
            }

            void EscreverBuffer(byte[] buff, int bytesLidos)
            {
                //var utf8 = new UTF8Encoding();
                var utf8 = Encoding.UTF8;

                // utf8.GetString(buff, 0, bytesLidos) recebe o buffer e iniciando de 0 lê apenas a quantidade de BytesLidos
                var texto = utf8.GetString(buff, 0, bytesLidos);

                Console.Write(texto);

                //foreach (var item in texto)
                //{
                //    Out.Print(item);
                //    Out.Print(" ");
                //}
            }
        }
    }
}

