using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Primer_practica__creacion_de_un_IDE_.backend
{
    class DirectorioAutomatas
    {

        char[] lista;
        public DirectorioAutomatas()
        {
        }

        public void ingresar(String lista)
        {
            this.lista = lista.ToCharArray();
            Console.WriteLine(this.lista);
            Form1 Principal = new Form1();
            Principal.richTextBox1.Text = "hola2";
            Principal.Update();
        }

        public string regresar()
        {
            String regreso = new String(lista);
            return regreso;
        }
    }
}
