using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Primer_practica__creacion_de_un_IDE_.backend
{
    class DirectorioAutomatas
    {

        char[] lista;
        public DirectorioAutomatas()
        {
        }

        public int ingresar(String lista)
        {
            TiposDatosPrimitivos datoPrimitivo = new TiposDatosPrimitivos(lista);
            
            int tipo = datoPrimitivo.Tipo;
            return tipo;
        }

    }
}
