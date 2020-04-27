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
    public partial class Form1 : Form
    {
        public static int x1;
        public static bool fill;
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e) //botón graficar
        {
            
            x1 = (int)numericUpDown1.Value; //input del usuario

            if (x1 <= 0)
            {
                MessageBox.Show("Por favor,ingrese una cantidad de posiciones mayor a 0."); //cuando el número de posiciones sea inferior a 1
            }
            else
            {
                Form2 frm2 = new Form2(); //objeto form2 para abrir la forma 2
                DialogResult dr = MessageBox.Show("¿Desea rellenar el vector manualmente?","Aviso", MessageBoxButtons.YesNo);
                switch (dr) //switch para rellenar o no
                {
                    case DialogResult.No:
                        fill = true;
                        frm2.ShowDialog();
                        break;
                    case DialogResult.Yes:
                        fill = false;
                        frm2.ShowDialog();
                        break;
                }


            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) //validar al apretar Enter
        {
            if(e.KeyCode == Keys.Enter)
            {
                x1 = (int)numericUpDown1.Value; //input del usuario

                if (x1 <= 0)
                {
                    MessageBox.Show("Por favor,ingrese una cantidad de posiciones mayor a 0."); //cuando el número de posiciones sea inferior a 1
                }
                else
                {
                    Form2 frm2 = new Form2(); //objeto form2 para abrir la forma 2
                    DialogResult dr = MessageBox.Show("¿Desea rellenar el vector manualmente?", "Aviso", MessageBoxButtons.YesNo);
                    switch (dr) //switch para rellenar o no
                    {
                        case DialogResult.No:
                            fill = true;
                            frm2.ShowDialog();
                            break;
                        case DialogResult.Yes:
                            fill = false;
                            frm2.ShowDialog();
                            break;
                    }


                }

            }
        }


        //-----------------------Cosas estéticas------------------------//


        private void pictureBox1_Click(object sender, EventArgs e) 
        {
            Form2 fm2 = new Form2();
            this.Close();
            fm2.Close();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            Size size = new Size(40,40);
            pictureBox1.Size = size;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            Size size = new Size(30,30);
            pictureBox1.Size = size;
        }

    }
}
