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
            toolTip1.SetToolTip(button3, "Editar los valores del vector directamente,dando doble click en cada celda.");
            Vectors vectorImp = new Vectors(); //crear objeto de la clase vector
            vectorImp.vectorMain(); //llamar método main
            label9.Text = "Cantidad de posiciones: " + vectorImp.x.ToString(); //mostrar cantidad de posiciones del vector
            aleatorio.Maximum = Form1.x1; //poner el valor máximo de los numericUpDown
            pos1.Maximum = Form1.x1;
            pos2.Maximum = Form1.x1;
            cellPos.Maximum = Form1.x1;

            if (Form1.fill == true) //si el usuario desea llenar el vector con aleatorio
            {
                proceed = true; //booleano que afirma si el vector está bien definido
                displayOptions(); //método para activar las opciones de modificación del vector
            }

        }

        private void button1_Click(object sender, EventArgs e) //cerrar form2
        {
            this.Hide(); 
        }

        Image no = Practica_4.Properties.Resources.no; //imagen de X roja
        Image yes = Practica_4.Properties.Resources.yes; //imagen de listo verde
        bool proceed = false;

        private void button2_Click(object sender, EventArgs e) //comprobaciones del vector
        {

            int errorVar=-1; //posición en la que hay un error
            try
            {

                float test; //variable auxiliar

                for (int i = 0; i < Form1.x1; i++) //ciclo para comprobar el dato de cada celda del vector
                {
                    errorVar = i;
                    readyCheck.BackgroundImage = no; //imagen de chequeo a no listo
                    if (vector1.Rows[0].Cells[i].Value.ToString().Trim() == "") //si el vector está vacío 
                    {
                        //preguntar al usuario si desea llenar campos vacíos con ceros
                        DialogResult dr = MessageBox.Show("El vector tiene campos vacíos, ¿Desea que sean llenados automáticamente con ceros?", "Aviso", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.No)
                        {
                            //si dice que no, hacer que lo arregle y no dejarlo proceder
                            MessageBox.Show("Por favor, ingrese un número en la posición " + (errorVar + 1) + " del vector.");
                            proceed = false;
                            break;
                        }
                        else
                        {
                          
                            refillEmptyCells("0"); //si dice que si, llamar al método para llenar espacios vacíos
                        }
                    }
                    //si tiene valores distintos de letras
                    if (float.TryParse(vector1.Rows[0].Cells[i].Value.ToString().Trim(), out test) == false) 
                    {
                        //decirle que ponga números en la posición
                        MessageBox.Show("Por favor, ingrese un número en la posición " + (i + 1) + " del vector.");
                        vector1.Rows[0].Cells[i].Value = ""; //borrar lo que haya escrito el usuario ahí
                        proceed = false;
                        break;
                    }
                    else //si todo está bien, proceder
                    {
                        proceed = true;
                    }
                }
                displayOptions(); //método para desplegar las opciones de modificación, sólo cuando variable proceed sea verdadera
            }
            catch 
                //en caso de errores por nulos u otro tipo
            {
                //preguntar si quiere que sean llenados o no
                DialogResult dr = MessageBox.Show("El vector tiene campos vacíos, ¿Desea que sean llenados automáticamente?", "Aviso", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No)
                {
                    MessageBox.Show("Por favor, ingrese un número en la posición " + (errorVar+1) + " del vector.");
                }
                else
                    //si dice que si, se llamará el método especial para contar y llenar los espacios nulos
                {
                    List<int> setEmpty = nullHandler(); //método para recoger posiciones nulas
                    refillEmptyCells("0",setEmpty); //método sobrecargado para llenar los valores nulos
                }

                
            }
            

        }

        private void displayOptions() //mostrar las opciones de modificación del vector
        {
            if (proceed == true)
            {
                button3.Enabled = true;
                button3.BackColor = Color.LightSkyBlue;
                readyCheck.BackgroundImage = yes; //cambiar imagen de chequeo a listo
                vector1.ReadOnly = true;
                panel3.Enabled = true;
                panel1.Enabled = true;
                button2.Enabled = false;
                button2.BackColor = Color.Gray;
                proceed = false;
            }
        }

        private void refillEmptyCells(string fill) //llenar los espacios vacíos
        {
            for (int i = 0; i < Form1.x1;i++) 
            {
                if(vector1.Rows[0].Cells[i].Value.ToString().Trim()=="") //si el espacio es vacío, llenar con cero
                {
                vector1.Rows[0].Cells[i].Value = fill;
                }
            }
        }

        private void refillEmptyCells(string fill,List<int> list) //llenar los nulos
        {
            foreach (int item in list) //para cada posición nula, se llena con cero
            {
                if (item != -1)
                {
                vector1.Rows[0].Cells[item].Value = fill;
                }
            }
        }

        private List<int> nullHandler() //manejo de los nulos
        {
            int pos=0,i=0;
            List<int> nullPos = new List<int>{}; //lista que recogerá posiciones nulas
            do
            {
                try
                {
                    if (vector1.Rows[0].Cells[i].Value.ToString().Trim() == "") //recoger posiciones vacías no nulas
                    {
                        nullPos.Add(i); //añadir posición a lista
                        pos++; //sumar una posición
                    }
                    else
                    {
                    string w = vector1.Rows[0].Cells[i].Value.ToString(); //asignación que va generar error si la celda es nula
                    }
                }
                    //al generarse ese error, saltará al catch, el cuál recogerá la posición actual que generó el error
                catch
                    
                {
                    nullPos.Add(i); //añadir posición a lista
                    pos++; //sumar una posición
                }
                i++;
            } while (i != Form1.x1); //ciclo que recorre el datagripview
            return nullPos; //retornar la lista de posiciones nulas / vacías
        }


        private void button3_Click(object sender, EventArgs e) //habilitar edición del datagripview y deshabilitar panel
        {
            button3.Enabled = false;
            vector1.ReadOnly = false;
            panel3.Enabled = false;
            panel1.Enabled = false;
            button2.Enabled = true;
            button2.BackColor = Color.Lime;
            button3.BackColor = Color.Gray;
        }

        
        private void button4_Click(object sender, EventArgs e) //lenar posición con número aleatorio
        {
            int a =(int)aleatorio.Value-1;
            Random rd = new Random();
            vector1.Rows[0].Cells[a].Value = rd.Next(0, 100).ToString();
        }

        private void button5_Click(object sender, EventArgs e) //cambiar posición 1 con posición 2
        {
            int p1 =(int)pos1.Value-1; //recoge la posición 1
            int p2 =(int)pos2.Value-1;//recoge la posición 2
            string aux = vector1.Rows[0].Cells[p1].Value.ToString(); //añade el valor celda 1 a variable auxiliar
            vector1.Rows[0].Cells[p1].Value = vector1.Rows[0].Cells[p2].Value.ToString(); //valor celda 2 a valor celda 1
            vector1.Rows[0].Cells[p2].Value = aux; //valor celda 1 a valor celda 2
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
            float menor = float.Parse(vector1.Rows[0].Cells[x].Value.ToString());
            int posMenor=x;
            int m = Form1.x1;

            for (int i = (x + 1); i < m; i++)
            {
                if (menor > float.Parse(vector1.Rows[0].Cells[i].Value.ToString()))
                {
                    menor = float.Parse(vector1.Rows[0].Cells[i].Value.ToString());
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

        private void button10_Click(object sender, EventArgs e) //botón para cambiar valores manualmente
        {
            int posC = (int)cellPos.Value-1;
            string newPos = newCell.Value.ToString();
            vector1.Rows[0].Cells[posC].Value = newPos;
        }
    }
}
