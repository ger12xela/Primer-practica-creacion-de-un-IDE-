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
        int[] haceptacion = { 2 };
        string palabraControl = "";
        
        public String comprobarlexema(char letra)
        {
            if (this.estadoActual == 0) 
            {

                Console.WriteLine("estado 0");
            }
            tipo = 0;
            
            Boolean movido = false;

            Estado[] sito = new Estado[6];
            sito[0] = new EstadoComplejo(0,2,48,57);
            sito[1] = new Estado(0, '-', 1);
            sito[2] = new EstadoComplejo(1, 2, 48, 57);
            sito[3] = new EstadoComplejo(2, 2, 48, 57);
            sito[4] = new Estado(5, 'r', 6);
            sito[5] = new Estado(6, 'o', 7);


            for (int i = 0; i < sito.Length; i++)
            {
                if (sito[i].estado == estadoActual)
                {
                    if (sito[i].encontrarCamino(letra))
                    {
                        estadoActual = sito[i].siguiente;
                        movido = true;
                        Console.WriteLine(palabraControl+" antes de");
                        palabraControl += letra.ToString();

                        i = sito.Length; 
                        Console.WriteLine(palabraControl+ " despues de ");
                        if (haceptacion.Contains(estadoActual))
                        {
                            Console.WriteLine("haceptado haci mero ");
                            switch (estadoActual)
                            {
                                case 2:
                                    tipo = 1;
                                    break;
                                case 0:
                                    Console.WriteLine("Case 2");
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
                palabraControl = "";
            }
            palabraRetorno = palabraControl;
            return palabraRetorno;
        }
    }
}
