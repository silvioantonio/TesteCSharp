using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using ByteBank.Modelos;
using Humanizer;

namespace ByteBank.SistemaAgencia
{
    partial class Program
    {
        static void Main(string[] args)
        {
            //-----------------------------------MANIPULAÇAO DE DATA-----------------------------------------------------

            TestarManipulacaoDeData();

            //-----------------------------------MANIPULAÇAO DE STRING-----------------------------------

            TestarManipulacaoString();

            //-----------------------------------MANIPULAÇÃO DE STRING USANDO REGEX----------------------

            TestarManipulacaoStringRegex();

            //-----------------------------------ARRAYS---------------------------------------------------

            TestarArray();

            //-----------------------------------LISTAS---------------------------------------------------

            TestarListaDeContaCorrente();

            //-----------------------------------LISTA OBJECT---------------------------------------------

            TestarListaDeObject();

            //-----------------------------------LISTA GENERICA-------------------------------------------

            TestarListaGenerica();

            //-----------------------------------EXTENSAO-------------------------------------------

            TestarExtensao();

            //-----------------------------------EXTENSAO METODO GENERICO-------------------------------------------

            TestarExtensaoComMetodoGenerico();

            //-----------------------------------ORDENAÇÃO DE LISTA-----------------------------

            TestarInterfaceIComparer();

            //-----------------------------------ORDENAÇÃO DE ORDERBY-----------------------------

            TestarIOrderedEnumerable();

            //-----------------------------------LER ARQUIVOS DIRETAMENTE-------------------------------------

            //TestarLidandoFileStreamDiretamente();

            //-----------------------------------LER ARQUIVOS STREAM READER-------------------------------------

            //TestarLerArquivos();

            //-----------------------------------LER ARQUIVOS STREAM READER E CONVERTER-------------------------------------

            TestarLerArquivosEConverter();

            Console.Read();
            
        }

        static void TestarManipulacaoDeData()
        {
            DateTime dataFimPagamento = new DateTime(2020, 10, 15);

            DateTime dataCorrente = DateTime.Now;

            TimeSpan diferenca = dataFimPagamento - dataCorrente;

            string mensagem = "vencimento em " + TimeSpanHumanizeExtensions.Humanize(diferenca);

            Console.WriteLine(mensagem);

            Console.WriteLine("Data corrente: " + dataCorrente);

            ContaCorrente conta = new ContaCorrente(456, 789456);

            Console.WriteLine(conta.ToString());
        }

        static void TestarManipulacaoString()
        {
            string url = "http://www.bytebank.com.br/cambio?moedaOrigem=real&moedaDestino=dolar";

            ExtratorValorArgumentosUrl extrator = new ExtratorValorArgumentosUrl(url);

            string moedaDestino = extrator.GetValor("moedaOrigem");
            string moedaOrigem = extrator.GetValor("moedaDestino");
            Console.WriteLine("Valor de moeda destino: " + moedaDestino);
            Console.WriteLine("Valor de moeda origem: " + moedaOrigem);


            string urlTeste = "http://www.bytebank.com.br/cambio";
            //int indiceByteBank = urlTeste.IndexOf("http://www.bytebank.com.br");

            //Console.WriteLine(indiceByteBank == 0);

            Console.WriteLine(urlTeste.StartsWith("http://www.bytebank.com.br"));
        }

        static void TestarManipulacaoStringRegex()
        {
            string padrao = "[0-9]{4,5}-?[0-9]{4}";
            string textoTexte = "Uma string grande contendo numeros 9988-0078 e outros caracteres @&% por exemplos";

            Match resultado = Regex.Match(textoTexte, padrao);

            Console.WriteLine(resultado);
        }

        static void TestarArray()
        {
            int[] idades = new int[5];

            for (int i = 0; i < 5; i++)
            {
                idades[i] = i * i;
                Console.WriteLine($"Idades[{i}] : {idades[i]}");
            }
        }

        static void TestarListaDeContaCorrente()
        {

            ListaDeContaCorrente lista = new ListaDeContaCorrente();
            lista.Adicionar(new ContaCorrente(123, 123123));
            lista.Adicionar(new ContaCorrente(123, 123123));
            lista.Adicionar(new ContaCorrente(123, 123123));
            lista.Adicionar(new ContaCorrente(123, 123123));
            lista.Adicionar(new ContaCorrente(123, 123123));
            lista.Adicionar(new ContaCorrente(123, 123123));
            lista.Adicionar(new ContaCorrente(123, 123123));
            lista.Adicionar(new ContaCorrente(123, 123123));

            for (int i = 0; i < lista.Tamanho; i++)
            {
                ContaCorrente itemAtual = lista.GetItemNoIndice(i);
                Console.WriteLine($"Item na posicao {i} = conta {itemAtual.Numero}");
            }

        }

        static void TestarListaDeObject()
        {
            ListaDeObject listaDeIdades = new ListaDeObject();
            listaDeIdades.Adicionar(5);
            listaDeIdades.Adicionar(14);
            listaDeIdades.Adicionar(4);
            listaDeIdades.Adicionar(23);
            listaDeIdades.Adicionar(19);
            listaDeIdades.Adicionar(12);
            listaDeIdades.AdicionarVarios(12, 46, 87);

            for (int i = 0; i < listaDeIdades.Tamanho; i++)
            {
                Console.WriteLine($"Idade : {(int)listaDeIdades[i]}");
            }
        }

        static void TestarListaGenerica()
        {
            Lista<int> listaDeIdades = new Lista<int>();
            listaDeIdades.Adicionar(5);
            listaDeIdades.Adicionar(4);
            listaDeIdades.AdicionarVarios(12, 46, 87);

            for (int i = 0; i < listaDeIdades.Tamanho; i++)
            {
                Console.WriteLine($"Idade : {listaDeIdades[i]}");
            }
        }

        static void TestarExtensao()
        {
            Out.PrintLn("Testando extensao criada estilo JAVA como System.out.PrintLn() :)");
        }

        static void TestarExtensaoComMetodoGenerico()
        {
            List<int> idades = new List<int>();
            idades.Add(25);
            idades.Add(2);
            idades.Add(5);

            idades.AdicionarVarios(53, 64, 12);
        }

        static void TestarInterfaceIComparer()
        {
            var lista = new List<ContaCorrente>()
            {
                new ContaCorrente(123, 123),
                new ContaCorrente(123, 444),
                new ContaCorrente(123, 555),
                new ContaCorrente(123, 666),
                new ContaCorrente(123, 987324),
                new ContaCorrente(123, 98763),
                new ContaCorrente(123, 1234),
                new ContaCorrente(123, 452)
            };
            lista.Sort();

            foreach (var item in lista)
            {
                Out.PrintLn(item.Numero);
            }
        }

        static void TestarIOrderedEnumerable()
        {
            var lista = new List<ContaCorrente>()
            {
                new ContaCorrente(123, 981324),
                new ContaCorrente(123, 871324),
                new ContaCorrente(123, 1234),
                new ContaCorrente(123, 654650),
                new ContaCorrente(123, 8045),
                new ContaCorrente(123, 8),
                new ContaCorrente(123, 1234),
                new ContaCorrente(123, 452)
            };

            var listaSemNulos = new List<ContaCorrente>();

            foreach (var item in lista)
            {
                listaSemNulos.Add(item);
            }

            var contasOrdenadasSemNulo = listaSemNulos.OrderBy(conta => conta.Numero);

            var contasNaoNulas = lista
                .Where(conta => conta != null)
                .OrderBy(conta => conta.Numero);

            IOrderedEnumerable<ContaCorrente> contasOrdenadas = lista.OrderBy(conta => {
                if (conta == null)
                    return int.MaxValue;
                return conta.Numero;
                }
            );

            foreach (var item in contasOrdenadas)
            {
                Out.PrintLn(item.Numero);
            }
        }

        static void TestarLerArquivos()
        {
            var enderecoArquivo = "../contas.txt";

            using (var fluxoDeArquivo = new FileStream(enderecoArquivo, FileMode.Open))
            using (var leitor = new StreamReader(fluxoDeArquivo))
            {
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();

                    Console.WriteLine(linha);
                }
            }
        }

        static void TestarLerArquivosEConverter()
        {
            var enderecoArquivo = "../contas.txt";

            using (var fluxoDeArquivo = new FileStream(enderecoArquivo, FileMode.Open))
            using (var leitor = new StreamReader(fluxoDeArquivo))
            {
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();

                    var contaCorrente = ConverterStringparaContaCorrente(linha);

                    Out.PrintLn($"{contaCorrente.Titular.Nome} -> Conta numero: {contaCorrente.Numero}, ag {contaCorrente.Agencia}, Saldo: {contaCorrente.Saldo}");
                }
            }

            ContaCorrente ConverterStringparaContaCorrente(string linha)
            {
                // Dessa forma eu consigo ler arquivos separados por '<space>', mas caso eu tenha dados como nomes que sao separados por espaços,
                // irei pegar apenas o primeiro nome e descartar o resto...
                // para resolver isso, existe o padrao de arquivos CSV, que sao separados por ',' 
                // SEPARADO POR '<space>'
                //string[] campos = linha.Split(' ');

                // O ARQUIVO .TXT FOI ALTERADO PARA O PADRAO CSV

                // SEPARADO POR ','
                string[] campos = linha.Split(',');

                var agencia = campos[0];
                var numero = campos[1];
                var saldo = campos[2].Replace('.', ',');
                var nomeTitular = campos[3];

                var agenciaComoInt = int.Parse(agencia);
                var numeroComoInt = int.Parse(numero);
                var saldoComoDouble = double.Parse(saldo);

                var titular = new Cliente
                {
                    Nome = nomeTitular
                };

                var resultado = new ContaCorrente(agenciaComoInt, numeroComoInt);
                resultado.Depositar(saldoComoDouble);
                resultado.Titular = titular;

                return resultado;
            }

        }
    }
}
