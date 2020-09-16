using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primer_practica__creacion_de_un_IDE_.backend
{
    class EstadoComplejodoble: EstadoComplejo
    {
        public int rangoBajodos { get; set; }
        public int rangoAltodos { get; set; }
        int Rrangobajo;
        int RrangoAlto;


        public EstadoComplejodoble(int estado,int siguiente,int rangoBajo,int rangoAlto,int rangoBajodos,int rangoAltodos)
            :base(estado,siguiente,rangoBajo,rangoAlto)
        {
            this.rangoBajodos = rangoBajodos;
            this.rangoAltodos = rangoAltodos;
            this.Rrangobajo = rangoBajo;
            this.RrangoAlto = rangoAlto;

        }

        public override Boolean encontrarCamino(Char letra)
        {
            Boolean movido = false;
            int valorletra = (int)letra;

            if (valorletra >= this.rangoBajodos && valorletra <= this.rangoAltodos)
            {
                movido = true;
            }

            if (valorletra >= this.rangoBajo && valorletra <= this.rangoAlto)
            {
                movido = true;
            }

            return movido;
        }
    }
}
