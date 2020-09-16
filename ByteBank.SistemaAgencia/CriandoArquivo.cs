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
        static void CriarArquivoTratandoBytes()
        {
            var caminhoNovoArquivo = "../contasExportadas.csv";

            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            {
                var contaComString = "123,987312,524.00,Fulano da Silva";

                var encoding = Encoding.UTF8;

                var bytes = encoding.GetBytes(contaComString);

                fluxoDeArquivo.Write(bytes, 0, bytes.Length);

            }
            Out.PrintLn("Operação para gerar arquivos finaizado...");
        }

        static void CriarArquivoComWriter()
        {
            var caminhoNovoArquivo = "../contasExportadasComWriter.csv";

            //-------------------------------------------------------------Utilizando Create, sera substituido(caso houver) o arquivo
            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            using (var escritor = new StreamWriter(fluxoDeArquivo))
            {
                escritor.Write("123,987312,524.00,Ciclano da Silva");

            }
            Out.PrintLn("Operação para gerar arquivos finaizado...");
        }

        static void TesteFLUSHCriarArquivoComWriter()
        {
            var caminhoNovoArquivo = "../testeFlush.txt";

            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            using (var escritor = new StreamWriter(fluxoDeArquivo))
            {
                for (int i = 0; i < 100; i++)
                {
                    escritor.Write($"Linha {i}");

                    escritor.Flush(); // Despeja a informação do buffer e manda pro file stream (torna o processo um pouco mais lento)

                    Out.PrintLn($"Linha {i} foi escrita no arquivo. Tecle enter para continuar...");
                    Console.ReadLine();
                }

            }
            Out.PrintLn("Operação para gerar arquivos finaizado...");
        }

        static void TesteEscreverArquivoBinario()
        {
            var caminhoNovoArquivo = "../arquivoBinario.txt";

            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            using (var escritor = new BinaryWriter(fluxoDeArquivo))
            {
                escritor.Write(098); // numero da agencia
                escritor.Write(51142); // numero da conta
                escritor.Write(6899.55); // saldo
                escritor.Write("Fulano");

            }
        }

        static void TesteLerArquivoBinario()
        {
            var caminhoNovoArquivo = "../arquivoBinario.txt";

            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            using (var leitor = new BinaryReader(fluxoDeArquivo))
            {
                var agencia = leitor.ReadInt32();
                var numeroConta = leitor.ReadInt32();
                var saldo = leitor.ReadDouble();
                var titular = leitor.ReadString();

                Out.PrintLn($"{agencia}/{numeroConta} {titular} {saldo}");
            }
        }
    }
}
