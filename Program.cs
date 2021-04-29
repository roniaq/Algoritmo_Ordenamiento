using System;

namespace Algoritmo_Ordenamiento
{
   class Program
   {

      static void Main(string[] args)
      {
         int[] vector = { 12,4,11,5,8,10};
         Console.WriteLine("12,4,11,5,8,10\n");
         Console.WriteLine("Vector ordenado:");
         //Console.WriteLine(string.Join(",", Shell(vector)));
         //Quicksort(vector, 0, vector.Length - 1);
         //Console.WriteLine(string.Join(",", (vector)));
         //BusquedaBinaria(vector, 10);

         Console.WriteLine(BusquedaSecuencias(vector,8));
         Console.WriteLine("Presiona una tecla para salir.");


      }

      //====Ordenamiento burbuja======
      private static int[] Burbuja(int[] vector)
      {
         int auxiliar;

         for (int i = 0; i < vector.Length; i++)
         {
            for (int j = 0; j < vector.Length - i - 1; j++)
            {
               if ( vector[j] > vector[j + 1])
               {
                  auxiliar = vector[j + 1];
                  vector[j + 1] = vector[j];
                  vector[j] = auxiliar;                  
               }
            }
         }

         return vector;
      }

      //====Ordenamiento por seleccion====
      private static int[] Seleccion(int[] vector)
      {
         int menor, posicion, auxiliar;

         for (int i = 0; i < vector.Length - 1; i++)
         {
            menor = vector[i];
            posicion = i;

            for (int j = i + 1; j < vector.Length; j++)
            {
               if (vector[j] < menor)
               {
                  menor = vector[j];
                  posicion = j;
               }
            }

            if (posicion != i)
            {
               auxiliar = vector[i];
               vector[i] = vector[posicion];
               vector[posicion] = auxiliar;
            }
         }

         return vector;
      }

      //====Ordenamiento por  inserción===
      private static int[] Insercion(int[] vector)
      {
         int auxiliar;

         for (int i = 1; i < vector.Length; i++)
         {
            auxiliar = vector[i];

            for (int j = i - 1; j >= 0 && vector[j] > auxiliar; j--)
            {
               vector[j + 1] = vector[j];
               vector[j] = auxiliar;
            }
         }

         return vector;
      }

      //====Ordenamiento shell =========
      private static int[] Shell(int[] vector)
      {
         int k, aux, j, mitad;
         mitad = vector.Length/2;
         while (mitad > 0)
         {
            for (int i = mitad; i < vector.Length; i++)
            {
               j = i - mitad;
               while (j >=0)
               {
                  k = j + mitad;                  
                  if (vector[j] <= vector[k])
                  {
                     j = -1;
                  }
                  else
                  {
                     aux = vector[j];
                     vector[j] = vector[k];
                     vector[k] = aux;                     
                  }
                  j = j - mitad;
               }
            }            
           mitad = mitad / 2;
         }
         return vector;
      }

      //====Ordenamiento Quicksort ====
      public static void Quicksort(int[] vector, int inicio, int fin)
      {
         int i = inicio, f = fin;
         int pivote = vector[(inicio + fin) / 2];
         while (i <= f)
         {
            while (vector[i] < pivote)   i++;            
            while ( pivote < vector[f])  f--;           
            if (i <=f)
            {               
               int aux = vector[i];
               vector[i] = vector[f];
               vector[f] = aux;
               i++;
               f--;
            }
         }
         if (inicio < f)    Quicksort(vector, inicio, f);
         if (i < fin)   Quicksort(vector, i, fin);         
      }

      //====Busqueda secuencial
      public static int BusquedaSecuencias(int[] vector, int n=0)
      {
         //int menor = vector[0];
         //for (int i = 1; i < vector.Length; i++)
         //   if (menor > vector[i])
         //      menor = vector[i];
         //return menor;

         //int mayor = vector[0];
         //for (int i = 1; i < vector.Length; i++)
         //   if (mayor < vector[i])
         //      mayor = vector[i];
         //return mayor;

         int encontrado = -1;
         for (int i = 0; i < vector.Length; i++)
            if (vector[i] == n)
               encontrado = i;
         return encontrado;
      }



      //======Busqueda Binaria =========
      public static void BusquedaBinaria(int[] vector, int num)
      {
         int min = 0, max = vector.Length-1;
         int centro = 0;
         bool encontrado = false;

         while (min <= max && encontrado == false)
         {
            centro = (min + max) / 2;
            if (vector[centro] == num)
               encontrado = true;
            if (vector[centro] > num)
               max = centro - 1;
            else
               min = centro + 1;
         }
         if (encontrado == false)
         { Console.Write("\nEl elemento {0} no esta en el arreglo", num); }
         else
         { Console.Write("\nEl elemento {0} esta en la posicion: {1}", num, centro + 1); }
      }
      //=====================
   }
}
