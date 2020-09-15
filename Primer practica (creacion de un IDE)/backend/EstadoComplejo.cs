using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primer_practica__creacion_de_un_IDE_.backend
{
    class EstadoComplejo : Estado
    {
        public int rangoBajo { get; set; }
        public int rangoAlto { get; set; }
        public EstadoComplejo(int estado, int siguiente, int rangoBajo, int rangoAlto)
            :base(estado,' ',siguiente)
        {
            this.rangoBajo = rangoBajo;
            this.rangoAlto = rangoAlto;
        }

        public override Boolean encontrarCamino(Char letra)
        {
            Boolean movido = false;
            int valorletra = (int)letra;
            if (valorletra >= this.rangoBajo && valorletra<= this.rangoAlto)
            {
                movido = true;
            }
            return movido;
        }

    }
}
