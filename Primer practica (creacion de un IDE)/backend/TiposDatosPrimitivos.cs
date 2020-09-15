using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primer_practica__creacion_de_un_IDE_.backend
{
    class TiposDatosPrimitivos
    {
        public int Tipo { get; set; }
        private int contador;
        private char[] letras;
        private bool aceptado;
        public TiposDatosPrimitivos(String palabra)
        {
            contador = 0;
            letras = palabra.ToCharArray();
            aceptado = false;
            S0();
            if (aceptado) Tipo = 1;
        }
        public void S0()
        {
            if (contador < letras.Length)
            {
                if (letras[contador].Equals('e'))
                {
                    contador++;
                    S1();
                }
            }
        }
        public void S1()
        {
            if (contador < letras.Length)
            {
                if (letras[contador].Equals('n'))
                {
                    contador++;
                    S2();
                }
            }
        }
        public void S2()
        {
            if (contador < letras.Length)
            {
                if (letras[contador].Equals('t'))
                {
                    contador++;
                    S3();
                }
            }
        }
        public void S3()
        {
            if (contador < letras.Length)
            {
                if (letras[contador].Equals('e'))
                {
                    contador++;
                    S4();
                }
            }
        }
        public void S4()
        {
            if (contador < letras.Length)
            {
                if (letras[contador].Equals('r'))
                {
                    contador++;
                    S5();
                }
            }
        }
        public void S5()
        {
            aceptado = true;
            Console.WriteLine("haceptado en dato primitivo");

            if (contador < letras.Length)
            {
                if (letras[contador].Equals('o'))
                {
                    contador++;
                    S1();
                }
            }
        }
    }
}
