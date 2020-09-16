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

                    richTextBox1.Text = leer.ReadToEnd();
                    
                }
            }

            
        }

        private void label1_Click(object sender, EventArgs e)
        {
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
        int cadenaAnterior= 0 ;
        int cadenalargo= 0;

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


        }
        PruebaAutomataBasico code = new PruebaAutomataBasico();

        public void Peso1(String cadena)
        {
            if (cadena.Equals(""))
            {
                Console.WriteLine("estado cero");
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
            Console.WriteLine(tipo +"-------- "+ palabra);
            if (tipo == 1) 
            {
                richTextBox1.Select(richTextBox1.Text.Length - palabra.Length, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.Violet;
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.SelectionColor = Color.Black;
            }
            if (tipo == 2)
            {
                richTextBox1.Select(richTextBox1.Text.Length - numero, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.Gray;
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.SelectionColor = Color.Black;
            }
            if (tipo == 3)
            {
                richTextBox1.Select(richTextBox1.Text.Length - numero, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.Cyan;
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.SelectionColor = Color.Black;
            }
            if (tipo == 4)
            {
                richTextBox1.Select(richTextBox1.Text.Length - numero, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.Brown;
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.SelectionColor = Color.Black;
            }
            if (tipo == 5)
            {
                richTextBox1.Select(richTextBox1.Text.Length - numero, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.DarkBlue;
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.SelectionColor = Color.Black;
            }
            if (tipo == 6)
            {
                richTextBox1.Select(richTextBox1.Text.Length - numero, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.HotPink;
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.SelectionColor = Color.Black;
            }

            else
            {
                richTextBox1.Select(richTextBox1.Text.Length, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.Blue;
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                //richTextBox1.Select(richTextBox1.Text.Length - 1, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.Black;
            }

            richTextBox1.SelectionStart = richTextBox1.Text.Length;


        }
    }
        
}
