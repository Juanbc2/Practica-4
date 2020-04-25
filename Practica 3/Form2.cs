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
            aleatorio.Maximum = Form1.x1;
            pos1.Maximum = Form1.x1;
            pos2.Maximum = Form1.x1;


        }

        private void button1_Click(object sender, EventArgs e) //cerrar form2
        {
            this.Hide();
        }

        Image no = Practica_4.Properties.Resources.no;
        Image yes = Practica_4.Properties.Resources.yes;

        private void button2_Click(object sender, EventArgs e) //comprobaciones
        {
            int errorVar=-1;
            try
            {
                bool proceed=false;
                int test;
                for (int i = 0; i < Form1.x1; i++)
                {
                    errorVar = i;
                    readyCheck.BackgroundImage = no; //imagen de chequeo a no listo
                    if (vector1.Rows[0].Cells[i].Value.ToString().Trim() == "")
                    {
                        DialogResult dr = MessageBox.Show("El vector tiene campos vacíos, ¿Desea que sean llenados automáticamente?", "Aviso", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.No)
                        {
                            MessageBox.Show("Por favor, ingrese un número en la posición " + (errorVar + 1) + " del vector.");
                            proceed = false;
                            break;
                        }
                        else
                        {
                            refillEmptyCells("0");
                        }
                    }
                    if (int.TryParse(vector1.Rows[0].Cells[i].Value.ToString().Trim(), out test) == false)
                    {
                        MessageBox.Show("Por favor, ingrese un número en la posición " + (i + 1) + " del vector.");
                        vector1.Rows[0].Cells[i].Value = "";
                        proceed = false;
                        break;
                    }
                    else
                    {
                        proceed = true;
                    }
                }
                if (proceed == true)
                {
                    readyCheck.BackgroundImage = yes; //cambiar imagen de chequeo a listo
                    vector1.Enabled = false;
                    panel1.Enabled = true;
                    button2.Enabled = false;
                    button2.BackColor = Color.Gray;
                    proceed = false;
                }
            }
            catch
            {
                DialogResult dr = MessageBox.Show("El vector tiene campos vacíos, ¿Desea que sean llenados automáticamente?", "Aviso", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No)
                {
                    MessageBox.Show("Por favor, ingrese un número en la posición " + (errorVar+1) + " del vector.");
                }
                else
                {
                    int[] setEmpty = nullHandler();
                    refillEmptyCells("0",setEmpty);
                }

                
            }
            

        }

        private void refillEmptyCells(string fill) //llenar los nulos
        {
            for (int i = 0; i < Form1.x1;i++)
            {
                if(vector1.Rows[0].Cells[i].Value.ToString().Trim()=="")
                {
                vector1.Rows[0].Cells[i].Value = fill;
                }
            }
        }

        private void refillEmptyCells(string fill,int[] list) //llenar los nulos
        {
            foreach (int item in list)
            {
                vector1.Rows[0].Cells[item].Value = fill;
            }
        }

        private int[] nullHandler() //manejo de los nulos
        {
            int pos=0,i=0;
            int[] nullPos = new int[Form1.x1];
            do
            {
                try
                {
                    if (vector1.Rows[0].Cells[i].Value.ToString().Trim() == "")
                    {
                        nullPos[pos] = i;
                        pos++;
                    }
                    else
                    {
                    string w = vector1.Rows[0].Cells[i].Value.ToString();
                    }
                }
                catch
                {
                    nullPos[pos] = i;
                    pos++;
                }
                i++;
            } while (i != Form1.x1);
            int [] d = deleteEmpty(nullPos);
            return d;
        }

        private int[] deleteEmpty(int[] del)
        {
            int[] aux = new int[del.Length];
            for (int i = 0; i < del.Length; i++)
            {
                aux[i] = del[i];
            }
            return aux;
        }

        private void button3_Click(object sender, EventArgs e) //habilitar edición y deshabilitar panel
        {
            vector1.Enabled = true;
            panel1.Enabled = false;
            button2.Enabled = true;
            button2.BackColor = Color.Lime;
        }

        
        private void button4_Click(object sender, EventArgs e) //lenar posición con número aleatorio
        {
            int a =(int)aleatorio.Value-1;
            Random rd = new Random();
            vector1.Rows[0].Cells[a].Value = rd.Next(0, 100).ToString();
        }

        private void button5_Click(object sender, EventArgs e) //cambiar posición 1 con posición 2
        {
            int p1 =(int)pos1.Value-1;
            int p2 =(int)pos2.Value-1;
            string aux = vector1.Rows[0].Cells[p1].Value.ToString();
            vector1.Rows[0].Cells[p1].Value = vector1.Rows[0].Cells[p2].Value.ToString();
            vector1.Rows[0].Cells[p2].Value = aux;
        }

        private void button6_Click(object sender, EventArgs e)//botón invertir
        { 
            setInverse();
        }

        private void button7_Click(object sender, EventArgs e) //organizar descendente
        {
            setAscendant();
        }

        private void button8_Click(object sender, EventArgs e) //organizar descendente
        {
            setDescendant();
        }

        private void button9_Click(object sender, EventArgs e) //organizar descendente
        {
            setRandom();
        }
        

        private void setInverse() //invertir posiciones actuales
        {
            string aux;
            int j = Form1.x1;
            for(int i = 0;i<j;i++)
            {
                aux = vector1.Rows[0].Cells[i].Value.ToString();
                vector1.Rows[0].Cells[i].Value = vector1.Rows[0].Cells[j-1].Value.ToString();
                vector1.Rows[0].Cells[j-1].Value = aux;
                j--;
            }
        }

        private void setAscendant() //organizar ascendente
        {
            string aux;
            for(int i = 0;i<Form1.x1-1;i++)
            {
                int a = minimum(i);
                aux = vector1.Rows[0].Cells[i].Value.ToString();
                vector1.Rows[0].Cells[i].Value = vector1.Rows[0].Cells[a].Value.ToString();
                vector1.Rows[0].Cells[a].Value = aux;
            }
        }

        private void setDescendant() //organizar descendente
        {
            setAscendant();
            setInverse();
        }

        private int minimum(int x) //encontrar el menor
        {
            int menor = int.Parse(vector1.Rows[0].Cells[x].Value.ToString());
            int posMenor=x;
            int m = Form1.x1;

            for (int i = (x + 1); i < m; i++)
            {
                if (menor > int.Parse(vector1.Rows[0].Cells[i].Value.ToString()))
                {
                    menor = int.Parse(vector1.Rows[0].Cells[i].Value.ToString());
                    posMenor = i;
                }
            }
            return posMenor;
        }

        private void setRandom() //llenar de números aleatorios el vector
        {
            Random random = new Random();
            string aux;
            int a;
            for (int i = 0; i < Form1.x1; i++) //ciclo para agregar número aleatorio a cada posición del vector
            {
                a = random.Next(0, Form1.x1);
                aux = vector1.Rows[0].Cells[i].Value.ToString();
                vector1.Rows[0].Cells[i].Value = vector1.Rows[0].Cells[a].Value.ToString();
                vector1.Rows[0].Cells[a].Value = aux;
            }
        }
    }
}
