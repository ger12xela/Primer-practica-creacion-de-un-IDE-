using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primer_practica__creacion_de_un_IDE_.backend
{
    class DetectarLexema
    {
        public DetectarLexema()
        {

        }

        public int tipo { get; set; }
        private int estadoActual = 0;
        private int error= 0;
        private String palabraRetorno = "";
        private int[] haceptacion = { 1, 2, 6, 5, 4, 8, 9, 11, 12, 13,14,15,16,17,18};

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
            (new Estado(0, '=', 9)),
            (new Estado(0, ';', 9)),
            (new Estado(9, '=', 8)),
            (new Estado(0, ' ', 7)),
            (new Estado(10, ' ', 11)),
            (new Estado(0, '/', 13)),
            (new Estado(13, '/', 14)),
            (new Estado(13, '*', 15)),
            (new Estado(16, '*', 17)),
            (new Estado(17, '/', 18)),
            (new Estado(15, '*', 17)),
            (new EstadoComplejodoble(15,16,0,41,43,255)),//exepto asterisco (*)
            (new EstadoComplejodoble(16,16,0,41,43,255)),//exepto asterisco (*)
            (new EstadoComplejodoble(17,16,0,47,49,255)),//exepto asterisco (*)
            (new EstadoComplejodoble(14,14,0,9,11,255)),
            (new EstadoComplejodoble(7,10,65,90,97,122)),// rango para caracteres tipo letra
            (new EstadoComplejodoble(0,10,65,90,97,122)),// rango para caracteres tipo letra
            (new EstadoComplejodoble(10,12,65,90,97,122)),
            (new EstadoComplejodoble(12,12,65,90,97,122)),
            (new EstadoComplejo(1, 2, 48, 57)),
            (new EstadoComplejo(2, 2, 48, 57)), // termina entero haceptados 
            (new Estado(2, '.', 3)),
            (new EstadoComplejo(3, 4, 48, 57)), //  48  57 el rango para digitos en ascii 
            (new Estado(0, '"', 5)),
            (new EstadoComplejodoble(5, 5, 1, 33,35,255)),
            (new Estado(5, '"', 6)),
            (new EstadoComplejo(4, 4, 48, 57)),
         };

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
                            estadoColor(estadoActual);
                        }

                    }

                }
            }

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
                if (estadoActual == 14) estadoActual = 0;
                palabraRetorno = "";
            }
        }
        public void inicialCero()
        {
            estadoActual = 0;
            palabraRetorno = "";
            this.tipo = 0;
        }


        int[] matrizVioleta = { 2 };
        int[] matrizGris = { 6,5 };
        int[] matrizceleste = { 4 };
        int[] matrizCafe = { 11 };
        int[] matrizAzuloscuro = { 1, 8,13 };
        int[] matrizRosa = { 9};
        int[] matrizVerde = { 12 };
        int[] matrizRoja = { 14, 15, 16, 17, 18 };

        public void estadoColor(int estado)
        {
            if (matrizVioleta.Contains(estado)) tipo = 1;
            if (matrizGris.Contains(estado)) tipo = 2;
            if (matrizceleste.Contains(estado)) tipo = 3;
            if (matrizCafe.Contains(estado)) tipo = 4;
            if (matrizAzuloscuro.Contains(estado)) tipo = 5;
            if (matrizRosa.Contains(estado)) tipo = 6;
            if (matrizVerde.Contains(estado)) tipo = 7;
            if (matrizRoja.Contains(estado)) tipo = 8;
        }
    }
}
