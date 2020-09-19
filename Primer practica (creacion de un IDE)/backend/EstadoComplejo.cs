using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primer_practica__creacion_de_un_IDE_.backend
{

    /// <summary>
    /// hereda de la clase estado, agreaga un rango para verificar el caracter en codigo ascii
    /// </summary>
    class EstadoComplejo : Estado
    {
        public int rangoBajo { get; set; }
        public int rangoAlto { get; set; }

        /// <summary>
        /// constructor 
        /// </summary>
        /// <param name="estado"></param>
        /// <param name="siguiente"></param>
        /// <param name="rangoBajo"></param>
        /// <param name="rangoAlto"></param>
        public EstadoComplejo(int estado, int siguiente, int rangoBajo, int rangoAlto)
            :base(estado,' ',siguiente)
        {
            this.rangoBajo = rangoBajo;
            this.rangoAlto = rangoAlto;
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
            if (valorletra >= this.rangoBajo && valorletra<= this.rangoAlto)
            {
                movido = true;
            }
            return movido;
        }

    }
}
