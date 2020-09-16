using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primer_practica__creacion_de_un_IDE_.backend
{
    class PruebaAutomataBasico
    {
        public PruebaAutomataBasico()
        {

        }

        public int tipo { get; set; }
        String palabraRetorno = "";
        int estadoActual = 0;
        int[] haceptacion = { 1, 2, 6, 5, 4, 7 , 8, 9};

        Estado[] sito =
        {
            (new EstadoComplejo(0, 2, 48, 57)),
            (new EstadoComplejo(0,8,40,43)),// rango ( (, ), +, * )
            (new Estado(0, '-', 1)),
            (new Estado(0, '&', 8)),
            (new Estado(0, '|', 8)),
            (new Estado(0, '!', 8)),
            (new Estado(0, '<', 8)),
            (new Estado(0, '>', 8)),
            (new Estado(0, '/', 8)),
            (new Estado(0, '=', 9)),
            (new Estado(0, ';', 9)),
            (new EstadoComplejodoble(0,7,65,90,97,122)),// rango para caracteres tipo letra
            (new EstadoComplejodoble(7,7,65,90,97,122)),
            (new EstadoComplejo(1, 2, 48, 57)),
            (new EstadoComplejo(2, 2, 48, 57)), // termina entero haceptados 
            (new Estado(2, '.', 3)),
            (new EstadoComplejo(3, 4, 48, 57)), //  48  57 el rango para digitos en ascii 
            (new Estado(0, '"', 5)),
            (new EstadoComplejodoble(5, 5, 1, 33,35,255)),
            (new Estado(5, '"', 6)),
            (new EstadoComplejo(4, 4, 48, 57)),
         };

        int error= 0;
        public String comprobarlexema(char letra)
        {

            tipo = 0;
            Boolean movido = false;


            for (int i = 0; i < sito.Length; i++)
            {
                if (sito[i].estado == estadoActual)
                {
                    if (sito[i].encontrarCamino(letra))
                    {
                        estadoActual = sito[i].siguiente;
                        movido = true;
                        palabraRetorno += letra.ToString();
                        error = 0;
                        i = sito.Length; 
                        if (haceptacion.Contains(estadoActual))
                        {
                            Console.WriteLine("-------------haceptado haci mero ");
                            switch (estadoActual)
                            {
                                case 2:
                                    tipo = 1;
                                    break;
                                case 6 :
                                    tipo = 2;
                                    break;
                                case 5:
                                    tipo = 2;
                                    break;
                                case 4:
                                    tipo = 3;
                                    break;
                                case 7:
                                    tipo = 4;
                                    break;
                                case 1:
                                    tipo = 5;
                                    break;
                                case 8:
                                    tipo = 5;
                                    break;
                                case 9:
                                    tipo = 6;
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }
                        }

                    }

                }
            }
            Console.WriteLine(estadoActual);

            if (movido == false)
            {
                estadoActual = 0;
                palabraRetorno = "";
                if (error <= 1)
                {
                    error++;
                this.comprobarlexema(letra);
                }
            }
            return palabraRetorno;
        }
        
        public void borrarcaracterfinal(char borrar)
        {
            if (palabraRetorno.Length > 0)
            {
                Console.WriteLine(palabraRetorno + " palabra a borrar");


                palabraRetorno = "";
                Console.WriteLine(palabraRetorno + " palabra eliminada con exiot");
            }
        }
        public void inicialCero()
        {
            estadoActual = 0;
            palabraRetorno = "";
            this.tipo = 0;
        }
    }
}
