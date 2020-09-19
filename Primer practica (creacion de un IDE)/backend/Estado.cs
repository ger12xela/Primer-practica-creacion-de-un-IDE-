using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primer_practica__creacion_de_un_IDE_.backend
{
    /// <summary>
    /// clase metodo contienen este esta comuesto del estado que representa 
    /// el siguiente estado y el caracter que va a vericar y comprobar
    /// </summary>
    class Estado
    {
        public int tipo { get; set; }
        public int estado { get; set; }
        public char caracter { get; set; }
        public int siguiente { get; set; }

        /// <summary>
        /// constructor 
        /// </summary>
        /// <param name="estado"></param>
        /// <param name="caracter"></param>
        /// <param name="siguiente"></param>
        public Estado (int estado, char caracter, int siguiente)
        {
            this.estado = estado;
            this.caracter = caracter;
            this.siguiente = siguiente;
        }
        /// <summary>
        /// metodo que verifica si huvo movimiento o si fue un error el caracter
        /// </summary>
        /// <param name="letra"></param>
        /// <returns></returns>
        public virtual Boolean encontrarCamino(Char letra)
        {
            Boolean movido = false;
            if (caracter.Equals(letra))
            {
                movido = true;

            }
            return movido;
        }

    }
}
