using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog3_12_5_2017
{
    class Program
    {
        static void Main(string[] args)
        {

            //string a = "Mb fcyb dhrqb zbFgéñégr yñ dhRégñ, gi rérf ehüra yñ gÜrar ehr ñgéñjrFñé. Üvxaéalaosevélv vjvk vd vdvyaüg.";
            string texto = "Mb fcyb dhrqb zbFgéñégr yñ dhRégñ, gi rérf ehüra yñ gÜrar ehr ñgéñjrFñé.";
            string texto2 = "Üvxaéalaosevélv vjvk vd vdvyaüg.";
            int clave = 16;
            int clave2 = 10;

            Desencriptar(texto, clave);
            Desencriptar(texto2, clave2);

            Console.ReadKey();

        }

        static void Desencriptar(string texto,int clave) {

            string texto1 = texto.ToLower();

            for (int i = 0; i < texto1.Length; i++)
            {
                //string[] aux = { "a", "á", "b", "c", "d", "e", "é", "f", "g", "h", "i", "í", "j",
                //                   "k", "l", "m", "n", "o","ó", "p", "q", "r", "s", "t", "u","ú", "v", "w", "x", "y", "z" }; äëïöü
                string aux1 = "aábcdeéfghiíjklmnñoópqrstuúüvwxyz";
                string aux2 = "AÁBCDEÉFGHIÍJKLMNÑOÓPQRSTUÚÜVWXYZ";
                if (aux1.Contains(texto1[i]))
                {

                    int index = aux1.IndexOf(texto1[i]);

                    int claveFinal = index + clave;

                    while (claveFinal >= aux1.Length)
                    {
                        claveFinal = claveFinal - aux1.Length;
                    }

                    //Console.WriteLine(texto1[i]+" -> tiene");
                    Console.Write("{0}",aux1[claveFinal]);

                }
                else if (aux2.Contains(texto1[i]))
                {

                    int index = aux2.IndexOf(texto1[i]);

                    int claveFinal = index + clave;

                    while (claveFinal >= aux1.Length)
                    {
                        claveFinal = claveFinal - aux1.Length;
                    }

                    //Console.WriteLine(texto1[i]+" -> tiene");
                    Console.Write("{0}", aux2[claveFinal]);

                }
                else {
                    //Console.WriteLine("no tiene");
                    Console.Write("{0}", texto1[i]);
                }

            }
        }
    }
}
