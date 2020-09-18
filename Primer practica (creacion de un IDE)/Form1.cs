using Primer_practica__creacion_de_un_IDE_.backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Primer_practica__creacion_de_un_IDE_
{
    public partial class Form1 : Form
    {
        String archivo;
        private int cadenaAnterior= 0 ;
        private int cadenalargo= 0;
        private DetectarLexema code = new DetectarLexema();
        private String[] palabrasReservadas = { "entero","decimal","cadena","booleano","caracter",
            "SI","SINO","SINO_SI","MIESTRAS",
            "HACER","DESDE","HASTA","INCREMENTO"};
        public Form1()
        {
            InitializeComponent();

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrirArchivo = new OpenFileDialog();
            abrirArchivo.Filter = "Archivo de IDE | *.gt";

            if (abrirArchivo.ShowDialog() == DialogResult.OK)
            {
                archivo = abrirArchivo.FileName;
                using (StreamReader leer = new StreamReader(archivo)) {

                    richTextBox1.Clear();
                    //richTextBox1.Text = leer.ReadToEnd();
                    String escrito = leer.ReadToEnd();
                    PasoAbrir(escrito);

                }
            }
            
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardarArchivo = new SaveFileDialog();
            guardarArchivo.Filter = "Archivo de IDE | *.gt";

            if (archivo != null)
            {
                using (StreamWriter escribir = new StreamWriter(archivo))
                {
                    escribir.Write(richTextBox1.Text);
                }
            }
            else
            {
                if (guardarArchivo.ShowDialog() == DialogResult.OK)
                {
                    archivo = guardarArchivo.FileName;
                    using (StreamWriter escribir = new StreamWriter(guardarArchivo.FileName))
                    {
                        escribir.Write(richTextBox1.Text);
                    }
                }
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != null)
            {
            if (MessageBox.Show("Los cambios no guardados se perderan", "Confimar Nuevo", MessageBoxButtons.YesNo)==DialogResult.Yes) 
            {
                    richTextBox1.Clear();
                    archivo = null;
            }

            }
            else
            {
                MessageBox.Show("La hoja esta vacia", "Informacion"); 
            }
        }

        protected void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            cadenaAnterior = cadenalargo;
            cadenalargo = richTextBox1.Text.Length;
            if (cadenaAnterior>cadenalargo)
            {
                if (richTextBox1.Text.Length >= 1)
                {
                code.borrarcaracterfinal(richTextBox1.Text[richTextBox1.Text.Length-1]);

                }
            }
            Peso1(richTextBox1.Text);
            int Posicion = richTextBox1.SelectionStart;

            int linea = richTextBox1.GetLineFromCharIndex(Posicion);

            int columna = Posicion -richTextBox1.GetFirstCharIndexOfCurrentLine();
            label1.Text = "linea " + linea + ", columna" + columna;


        }

        public void Peso1(String cadena)
        {
            if (cadena.Equals(""))
            {
                code.inicialCero();
            }
            if (cadena.Length > 0)
            {
                String palabra= code.comprobarlexema(cadena[cadena.Length - 1]);
                int numero = palabra.Length;
                Paso2(palabra, numero);
            }

 
        }


        
        public void Paso2(String palabra, int numero)
        {

            int tipo = code.tipo;

            if (tipo == 1)
            {
                richTextBox1.Select(richTextBox1.Text.Length - palabra.Length, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.Violet;

            }
            if (tipo == 2)
            {
                richTextBox1.Select(richTextBox1.Text.Length - numero, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.Gray;

            }
            if (tipo == 3)
            {
                richTextBox1.Select(richTextBox1.Text.Length - numero, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.Cyan;

            }
            if (tipo == 4)
            {
                richTextBox1.Select(richTextBox1.Text.Length - numero, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.Brown;

            }
            if (tipo == 5 && palabra.Length <= 2)
            {
                richTextBox1.Select(richTextBox1.Text.Length - numero, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.DarkBlue;

            }
            if (tipo == 6)
            {
                richTextBox1.Select(richTextBox1.Text.Length - numero, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.HotPink;

            }
            if (tipo == 7 && palabrasReservadas.Contains(palabra.TrimStart()))
            {
                richTextBox1.Select(richTextBox1.Text.Length - numero, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.Green;
            }
            if (tipo == 8)
            {
                richTextBox1.Select(richTextBox1.Text.Length - numero, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.Red;
            }

            if(tipo == 0)
            {
                richTextBox1.Select(richTextBox1.Text.Length - numero, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.Black;
            }
            String[] booleano = { "verdadero", "falso" };
            if (tipo == 7 && booleano.Contains(palabra.TrimStart()))
            {
                richTextBox1.Select(richTextBox1.Text.Length - numero, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.Orange;
            }

            richTextBox1.SelectionStart = richTextBox1.Text.Length;


        }
        public void PasoAbrir(String escrito)

        {
            for (int i = 0; i < escrito.Length; i++)
            {
                richTextBox1.SelectedText = escrito[i].ToString(); 
            }
        }

        private void pegadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String pegado = richTextBox1.Text;
            richTextBox1.Clear();
            PasoAbrir(pegado);
        }

        private void richTextBox1_CursorChanged(object sender, EventArgs e)
        {
            int Posicion = richTextBox1.SelectionStart;

            int linea = richTextBox1.GetLineFromCharIndex(Posicion);

            int columna = richTextBox1.GetFirstCharIndexOfCurrentLine();
            label1.Text = "linea " + linea + ", columna" + columna;
        }
    }
        
}
