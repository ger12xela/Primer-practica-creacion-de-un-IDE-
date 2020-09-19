using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primer_practica__creacion_de_un_IDE_.backend
{
    /// <summary>
    /// hereda de la clase EstadoComplejo, agrega un rango mas en codigo ascii para 
    /// poder hacer mas comparacienoes del caracter 
    /// </summary>
    class EstadoComplejodoble: EstadoComplejo
    {
        public int rangoBajodos { get; set; }
        public int rangoAltodos { get; set; }


        /// <summary>
        /// contructor
        /// </summary>
        /// <param name="estado"></param>
        /// <param name="siguiente"></param>
        /// <param name="rangoBajo"></param>
        /// <param name="rangoAlto"></param>
        /// <param name="rangoBajodos"></param>
        /// <param name="rangoAltodos"></param>
        public EstadoComplejodoble(int estado,int siguiente,int rangoBajo,int rangoAlto,int rangoBajodos,int rangoAltodos)
            :base(estado,siguiente,rangoBajo,rangoAlto)
        {
            this.rangoBajodos = rangoBajodos;
            this.rangoAltodos = rangoAltodos;
A

        }
        /// <summary>
        /// metodo que verifica si huvo movimiento o si fue un error el caracter sobre carga del padre
        /// los rangos son de codigo ascii
        /// </summary>
        /// <param name="letra"></param>
        /// <returns></returns>
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
