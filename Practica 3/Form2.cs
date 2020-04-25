using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_4
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Vectors vectorImp = new Vectors(); //crear objeto de la clase vector
            vectorImp.vectorMain(); //llamar método main
            label9.Text = "Cantidad de posiciones: " + vectorImp.x.ToString(); //mostrar cantidad de posiciones del vector
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
