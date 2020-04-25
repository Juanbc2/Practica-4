using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_4
{
    public class Vectors
    {

        //acceso a los controles de la forma
        DataGridView vector1 = Application.OpenForms["Form2"].Controls["vector1"] as DataGridView;

        public string[] gridV1; //definición de vectores
        public int x = Form1.x1; //input del usuario
        public bool fill = Form1.fill; //llenar o no el vector aleatoriamente


        public void vectorMain() //main de la clase vector
        {
            if (fill==true)
            {
                gridV1 = fillRandom(x); //metodo llenar vector con números aleatorios aplicado a vector 1
                paintArray(gridV1); //metodo para poner vectores en las tablas
            }
            else if(fill==false)
            {
                gridV1 = fillEmpty(x); //llenar el vector con espacios vacíos
                displayEmptyArray(); //método para mostrar el vector vacío
            }


        }
        private void displayEmptyArray() //mostrar el vector vacío en las tablas
        {
            vector1.ColumnCount = x; //número de columnas del datagripview
            vector1.Rows.Add(1); //agregar una fila al datagripview
            int i = 0;
            do
            {
                vector1.Columns[i].Name = (i + 1).ToString(); //agregar número de posición al datagripview de 1 a x
                vector1.Rows[0].Cells[i].Value = gridV1[i]; //agregar un espacio vacío
                i++;
            } while (i < x);
        }



        public void paintArray(string[] grid) //poner vector en las tablas
        {
            vector1.ColumnCount = x; //número de columnas del datagripview
            vector1.Rows.Add(1); //agregar una fila al datagripview
                //ciclo para llenar el datagripview 1
            int i=0;
            do
            {
                vector1.Columns[i].Name = (i + 1).ToString(); //agregar número de posición al datagripview de 1 a x
                vector1.Rows[0].Cells[i].Value = grid[i]; //agregar un número aleatorio a cada celda del datagripview
                i++;
            } while (i < x);
            
        }

        private string[] fillRandom(int x) // llenar vector con números aleatorios
        {
            Random random = new Random(); //generar número aleatorio
            string[] vector = new string[x]; //crear vector 
            for (int i = 0; i < x; i++) //ciclo para agregar número aleatorio a cada posición del vector
            {
                vector[i] = random.Next(0,100).ToString();
            }
            return vector; //devuelve el vector lleno 
        }

        private string[] fillEmpty(int x) // llenar vector con espacios vacíos
        {

            string[] vector = new string[x]; //crear vector 
            for (int i = 0; i < x; i++) //ciclo para agregar número aleatorio a cada posición del vector
            {
                vector[i] = "";
            }
            return vector; //devuelve el vector lleno 
        }

        private int[] intercambioPosicion(int[] vectorIn, int x, int y) //intercambiar posición
        {
	        int dato = vectorIn[x];
	        vectorIn[x]=vectorIn[y];
	        vectorIn[y]=dato;
	        return (vectorIn);
        }

        private string showArray(int[] vectorSA,int limit) //añadir vector a un string
        {
            string vectorStr = "";
            for(int i=0;i<limit;i++)
            {
                if (i < limit - 1)
                {
                vectorStr = vectorStr + vectorSA[i].ToString()+",";
                }
                else
                {
                vectorStr = vectorStr + vectorSA[i].ToString() + ".";
                }

            }
            return vectorStr;
        }
    }
}
