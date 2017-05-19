using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhorcadoPalabras;

namespace ahorcado
{
    class Program
    {
        static void Main(string[] args)
        {

            string palabra = new AhorcadoPalabras.GeneradorPalabras().SiguientePalabra;

            string[] palabraFinal = new string[palabra.Length];

            Console.WriteLine(palabra);

            for (int i = 0; i < palabra.Length; i++)
            {
                palabraFinal[i] = "_ "; 
            }


            Console.WriteLine("La palabra contiene: ");
            foreach (string a in palabraFinal)
            {
                Console.Write(a);
            }

            Console.WriteLine("");

            int errores = 0;

            string ultimo = "";
            Boolean iguales = false;

            while(errores < 6 && iguales != true){

                Console.WriteLine("Ingrese una letra: ");
                char letra = char.Parse(Console.ReadLine());


                int cont = 0;

                for (int j = 0; j < palabra.Length; j++)
                {

                    if (palabra[j].Equals(letra))
                    {
                        palabraFinal[j] = letra + "";
                    }
                    else {
                        cont++;
                    }


                }

                foreach (string str in palabraFinal)
                {
                    Console.Write(str);
                }

                Console.WriteLine("");
                Console.WriteLine("-----------------------");

                if (cont == palabra.Length)
                {
                    errores++;
                }

                Console.WriteLine(errores);

                foreach (string k in palabraFinal)
                {
                    ultimo = ultimo + k;
                }

                int cont3 = 0;
                for (int i = 0; i < palabraFinal.Length; i++)
                {
                    if (palabraFinal[i].Equals(ultimo[i]))
                    {
                        cont3++;
                    }
                }

                if (cont3 == palabraFinal.Length)
                {
                    iguales = true;
                }

            }

            int cont2 = 0;
            foreach (string x in palabraFinal)
            {
                if (!x.Equals("_ "))
                {
                    cont2++;
                }

            }

            Console.WriteLine("cont2: " + cont2);

            if (cont2 == palabraFinal.Length)
            {
                Console.WriteLine("ganaste");
            }
            else if (errores == 6) {
                Console.WriteLine("Perdiste");
            }



            Console.WriteLine(palabra);




            Console.ReadKey();
        }
    }
}
