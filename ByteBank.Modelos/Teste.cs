using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    class Teste
    {
        public Teste()
        {
            ModificadoresTeste teste = new ModificadoresTeste();
            teste.MetodoPublico();
            teste.MetodoInternal();
        }

    }
    public class ModificadoresTeste
    {
        public void MetodoPublico()
        {
            
        }

        private void MetodoPrivate()
        {

        }

        protected void MetodoProtected()
        {

        }

        internal void MetodoInternal()
        {

        }
    }
}
