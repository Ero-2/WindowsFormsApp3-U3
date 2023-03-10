using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private int personas = 0;
        private int registrados = 0;
        private int cantidad = 0;
        private contacto[] arreglo;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((registrados < cantidad))
            {
                var nuevocontacto = new contacto();

                nuevocontacto.FechaDenacimiento_ = DTPPE.value;
                nuevocontacto.Nombre_ = txtnombre.Text;
                nuevocontacto.telefono_ = txttelefono.Text;
                nuevocontacto.Correo = txtcorreo.Text;
                arreglo[registrados] = nuevocontacto;
                registrados = registrados + 1;
                string nuevaLinea = nuevocontacto.Nombre_ + ", " + nuevocontacto.Edad.ToString() + ", " + nuevocontacto.telefono_.ToString() + ", " + nuevocontacto.Correo.ToString() + Environment.NewLine;
                lbl1.Text = lbl1.Text + nuevaLinea;


            }
            else
            {
                MessageBox.Show("No se pueden registrar más personas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int valor;
            if (int.TryParse(txtnombre.Text, out valor))
            {
                cantidad = valor;
                registrados = 0;
                arreglo = new contacto[cantidad + 1];
            }
            else
            {
                MessageBox.Show("Debe ingresar un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtnombre.Text = "";
                cantidad = 0;
                registrados = 0;
                arreglo = new contacto[cantidad + 1];
            }
        }

        private void DTPP_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog lector = new OpenFileDialog();
            lector.Filter = "Nombre del Archivo|*.txt";
            if (lector.ShowDialog() == DialogResult.OK)
            {
                StreamReader abrir = new StreamReader(lector.FileName);
                lbl1.Text = abrir.ReadToEnd();
                abrir.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardarArchivo = new SaveFileDialog();


            guardarArchivo.Filter = "Archivos de texto|*.txt";
            guardarArchivo.Title = "Guardar archivo de contactos";
            guardarArchivo.FileName = "contactos.txt";


            if (guardarArchivo.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter archivo = new StreamWriter(guardarArchivo.FileName))
                {

                    for (int i = 0; i < registrados; i++)
                    {
                        archivo.WriteLine(arreglo[i].Nombre_ + "," + arreglo[i].Edad.ToString() + "," + arreglo[i].telefono_ + "," + arreglo[i].Correo);
                    }
                }
            }
        }
    }
 
}

