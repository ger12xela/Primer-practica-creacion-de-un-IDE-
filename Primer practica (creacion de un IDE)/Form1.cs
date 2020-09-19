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

    /// <summary>
    /// clase principal del IDE (contiene los metodos principales y el arranque grafico
    /// </summary>
    public partial class Form1 : Form
    {
        String archivo;
        private int cadenaAnterior= 0 ;
        private int cadenalargo= 0;
        private DetectarLexema code = new DetectarLexema();
        private String[] palabrasReservadas = { "entero","decimal","cadena","booleano","caracter",
            "SI","SINO","SINO_SI","MIESTRAS",
            "HACER","DESDE","HASTA","INCREMENTO"};
        
        /// <summary>
        /// lanza la interfas grafica.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

        }
        /// <summary>
        /// EVento---- este sucede cuando se da click en el boton abrir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Evento ---- Este sucede cuando se da click en el bontón Guardar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Evento---- este sucede cuando se da click en el bontón "Nuevo"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Evento ---- este sucede cuando sucede un cambio en el texto del RichtextBox principal "richtextBox1"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            // da la posicion del curson en el momento
            int Posicion = richTextBox1.SelectionStart;

            int linea = richTextBox1.GetLineFromCharIndex(Posicion);

            int columna = Posicion -richTextBox1.GetFirstCharIndexOfCurrentLine();
            label1.Text = "linea " + linea + ", columna" + columna;


        }
        /// <summary>
        /// Metodo ---- este es el en cargado de enviar caracter por caracter a la clase que lo revisa
        /// </summary>
        /// <param name="cadena"></param>
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
        /// <summary>
        /// Metodo ---- encardado de dar color dependiendo del tipo de lexema
        /// </summary>
        /// <param name="palabra"></param>
        /// <param name="numero"></param>
        public void Paso2(String palabra, int numero)
        {

            int tipo = code.tipo;

            if (tipo == 1)
            {
                //para los enteros 
                richTextBox1.Select(richTextBox1.Text.Length - palabra.Length, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.Violet;

            }
            if (tipo == 2)
            {
                // para los "String"
                richTextBox1.Select(richTextBox1.Text.Length - numero, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.Gray;

            }
            if (tipo == 3)
            {
                // para los decimales 
                richTextBox1.Select(richTextBox1.Text.Length - numero, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.Cyan;

            }
            if (tipo == 4)
            {
                // para los char
                richTextBox1.Select(richTextBox1.Text.Length - numero, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.Brown;

            }
            if (tipo == 5 && palabra.Length <= 2)
            {
                // para los simbolos 
                richTextBox1.Select(richTextBox1.Text.Length - numero, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.DarkBlue;

            }
            if (tipo == 6)
            {
                // para Final de cadena
                richTextBox1.Select(richTextBox1.Text.Length - numero, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.HotPink;

            }
            if (tipo == 7 && palabrasReservadas.Contains(palabra.TrimStart()))
            {  
                // para las palabras reservadas
                richTextBox1.Select(richTextBox1.Text.Length - numero, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.Green;
            }
            if (tipo == 8)
            {
                // para los comentarios 
                richTextBox1.Select(richTextBox1.Text.Length - numero, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.Red;
            }

            if(tipo == 0)
            {
                // para los errores 
                richTextBox1.Select(richTextBox1.Text.Length - numero, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.Black;
            }
            String[] booleano = { "verdadero", "falso" };
            if (tipo == 7 && booleano.Contains(palabra.TrimStart()))
            {  
                // para "booleanos"
                richTextBox1.Select(richTextBox1.Text.Length - numero, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.Orange;
            }

            richTextBox1.SelectionStart = richTextBox1.Text.Length;


        }
        /// <summary>
        /// se encarga de separar caracter por caracter y enviar a la clase que lo examina cuando se abre un documento
        /// </summary>
        /// <param name="escrito"></param>
        public void PasoAbrir(String escrito)

        {
            for (int i = 0; i < escrito.Length; i++)
            {
                richTextBox1.SelectedText = escrito[i].ToString(); 
            }
        }
        /// <summary>
        /// se encarga de separar caracter por caracter y enviar a la clase que lo examina cuando se pega un texto 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pegadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String pegado = richTextBox1.Text;
            richTextBox1.Clear();
            PasoAbrir(pegado);
        }
        /// <summary>
        /// se encarga de mostrar la ubicacion del cursor 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBox1_CursorChanged(object sender, EventArgs e)
        {
            int Posicion = richTextBox1.SelectionStart;

            int linea = richTextBox1.GetLineFromCharIndex(Posicion);

            int columna = richTextBox1.GetFirstCharIndexOfCurrentLine();
            label1.Text = "linea " + linea + ", columna" + columna;
        }
    }
        
}
