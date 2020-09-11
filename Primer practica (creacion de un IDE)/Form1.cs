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

        protected void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            Peso1(richTextBox1.Text);

        }

        public String Peso1(String cadena)
        {
            String palabra = "";
            String retorno = " ";
            char espacio = ' ';
            int numero = 0;
            for (int i = 0; i < cadena.Length; i++)
            {
            
                if (cadena[i].Equals(espacio))
                {

                Console.WriteLine(cadena);
                    numero = i-palabra.Length;
                    Paso2(palabra, numero);
                    palabra = "";
                }
                else
                {
                    palabra += cadena[i].ToString();
                    numero++;
                }
            }
            retorno = palabra;
            palabra = "";
            return retorno;
        }
        public void Paso2(String palabra, int numero)
        {
            Console.WriteLine("aqui");
            if (palabra.Equals("hola"))
            {
                richTextBox1.Select(numero, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.Orange;
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.SelectionColor = Color.Black;


            }
            else
            {
                richTextBox1.Select(numero, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.Blue;
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                //richTextBox1.Select(richTextBox1.Text.Length - 1, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = Color.Black;
            }

            richTextBox1.SelectionStart = richTextBox1.Text.Length;


        }
    }
        
}
