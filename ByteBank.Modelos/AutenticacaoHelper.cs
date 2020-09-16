using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    internal class AutenticacaoHelper
    {
        public bool CompararSenhas(string senhaerdadeira, string senhaTentativa)
        {
            return senhaerdadeira == senhaTentativa;
        }
    }
}
