using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ExtratorValorArgumentosUrl
    {
        private readonly string _argumentos;
        public string URL { get; }
        
        public ExtratorValorArgumentosUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("O argumento nao pode ser nulo ou vazio",nameof(url));
            }
            URL = url;

            int indiceInterrogacao = url.IndexOf('?');
            _argumentos = url.Substring(indiceInterrogacao);
        }

        public string GetValor(string nomeDoParametro)
        {
            string termo = nomeDoParametro + "=";
            int indiceTermo = _argumentos.IndexOf(termo);

            string resultado = _argumentos.Substring(indiceTermo + termo.Length);
            int indiceEComercial = resultado.IndexOf('&');

            if (indiceEComercial == -1)
            {
                return resultado;
            }

            return resultado.Remove(indiceEComercial);
        }
    }
}
