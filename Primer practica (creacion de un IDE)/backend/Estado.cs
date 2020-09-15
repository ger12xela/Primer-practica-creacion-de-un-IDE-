using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primer_practica__creacion_de_un_IDE_.backend
{
    class Estado
    {
        public int tipo { get; set; }
        public int estado { get; set; }
        public char caracter { get; set; }
        public int siguiente { get; set; }


        public Estado (int estado, char caracter, int siguiente)
        {
            this.estado = estado;
            this.caracter = caracter;
            this.siguiente = siguiente;
        }

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
