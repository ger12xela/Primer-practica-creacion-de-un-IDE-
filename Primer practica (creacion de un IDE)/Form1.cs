using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            Console.WriteLine(richTextBox1.Text);
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
    }
}
