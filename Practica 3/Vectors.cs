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
            paintArray(); //metodo para poner vectores en las tablas
            }
            else if(fill==false)
            {
                gridV1 = fillEmpty(x);
                displayEmptyArray();
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



        private void paintArray() //poner vector en las tablas
        {
                //ciclo para llenar el datagripview 1
                vector1.ColumnCount = x; //número de columnas del datagripview
                vector1.Rows.Add(1); //agregar una fila al datagripview
                int i=0;
                do
                {
                    vector1.Columns[i].Name = (i + 1).ToString(); //agregar número de posición al datagripview de 1 a x
                    vector1.Rows[0].Cells[i].Value = gridV1[i]; //agregar un número aleatorio a cada celda del datagripview
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

        public string sumEachNum(int[] vectorSum) //sumar cada posición del vector
        {
            int sum = 0;
            foreach (int item in vectorSum)
            {
                sum = sum + item;
            }
            return ("La suma de cada uno de los datos del vector da como resultado: "+sum.ToString()+".");
        }



        private int[] intercambioPosicion(int[] vectorIn, int x, int y) //intercambiar posición
        {
	        int dato = vectorIn[x];
	        vectorIn[x]=vectorIn[y];
	        vectorIn[y]=dato;
	        return (vectorIn);
        }

        private int buscarMenor(int[] vectorMe, int x) //buscar el menor
        {
            int menor = vectorMe[x];
            int posMenor=x;
            int m=vectorMe.Length;

            for (int i=(x+1);i < m;i++)
            {
                if(menor>vectorMe[i])
                {
                    menor=vectorMe[i];
                    posMenor=i;
                }
            }
            return (posMenor);
        }

        private int buscarMayor(int[] vectorMa, int x) //buscar el mayor
        {
            int menor = vectorMa[x];
            int posMenor = x;
            int m = vectorMa.Length;

            for (int i = (x + 1); i < m; i++)
            {
                if (menor < vectorMa[i])
                {
                    menor = vectorMa[i];
                    posMenor = i;
                }
            }
            return (posMenor);
        }

        private int[] setAscendant(int[] vectorAs,int x) //organizar el vector de forma ascendente
        {
            int posMenor;
            for (int i = 0; i < (x - 1); i++)
            {
                posMenor = buscarMenor(vectorAs, i);
                vectorAs = intercambioPosicion(vectorAs, i, posMenor);
            }
            return vectorAs;
        } 
        

        private int[] setFalling(int[] vectorDes,int x) //organizar el vector de forma ascendente
        {
            int posMayor;
            for (int i = 0; i < (x - 1); i++)
            {
                posMayor = buscarMayor(vectorDes, i);
                vectorDes = intercambioPosicion(vectorDes, i, posMayor);
            }
            return vectorDes;
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

        public string searchEven(int[] vectorPar) //hallar y mostrar pares
        {
            int sumPar = 0,count=0;
            int[] pares = new int[vectorPar.Length];
            for (int i = 0; i < vectorPar.Length; i++)
            {
                if(vectorPar[i]%2==0){
                    pares[count] = (vectorPar[i]);
                    count++;
                    sumPar++;
                }
            }
            if (sumPar == 0)
            {
                return ("En el vector no hay números pares.");
            }
            else
            {
                if (sumPar == 1)
                {
                    return ("En el vector hay 1 número par,el cual es: " + showArray(pares, sumPar));
                }
                else
                {
                    return ("En el vector hay " + sumPar + " números pares,los cuales son: " + showArray(pares, sumPar));
                }
            }

        }

        public string searchOdd(int[] vectorimPar) //hallar y mostrar pares
        {
            int sumimPar = 0, count = 0;
            int[] impares = new int[vectorimPar.Length];
            for (int i = 0; i < vectorimPar.Length; i++)
            {
                if (vectorimPar[i] % 2 != 0)
                {
                    impares[count] = (vectorimPar[i]);
                    count++;
                    sumimPar++;
                }
            }
            if (sumimPar == 0)
            {
                return ("En el vector no hay números impares.");
            }
            else
            {
                if (sumimPar == 1)
                {
                    return ("En el vector hay 1 números impar,el cual es: " + showArray(impares, sumimPar));
                }
                else
                {
                    return ("En el vector hay " + sumimPar + " números impares,los cuales son: " + showArray(impares, sumimPar));
                }
            }

        }

        public string searchPrime(int[] vectorPr) //hallar númueros primos
        {
            int count = 0,indexPr=0,prCount=0;
            int[] primos = new int[vectorPr.Length];
            for (int j = 0; j < vectorPr.Length;j++ )
            {
                if (vectorPr[j] > 0 && (vectorPr[j]%2)!=0 && vectorPr[j]!=2)
                {
                    for (int i = 3; i < vectorPr[j]; i = i + 2)
                    {
                        if (vectorPr[j] % i == 0)
                        {
                            count = count + 1;
                            break;
                        }
                    }
                if (count == 0)
                {
                    primos[indexPr] = vectorPr[j];
                    indexPr++;
                    prCount++;
                }
                }
                else if(vectorPr[j]==2)
                {
                    primos[indexPr] = vectorPr[j];
                    indexPr++;
                    prCount++;
                }

            }
            if (prCount == 0)
            {
                return ("En el vector no hay números primos.");
            }
            else
            {
                if (prCount == 1)
                {
                return ("En el vector hay 1 número primo,el cual es: " + showArray(primos, prCount));
                }
                else
                {
                return ("En el vector hay " + prCount + " números primos,los cuales son: " + showArray(primos, prCount));
                }

            }
        }
    }
}
