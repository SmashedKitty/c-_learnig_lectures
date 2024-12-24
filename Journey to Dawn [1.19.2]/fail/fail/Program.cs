using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace laba2
{
    class Class1
    {

        static void Main(string[] args)
        {
            
                Console.WriteLine("Input template symbol: \n");

                var x = Console.ReadKey().KeyChar;
                Console.WriteLine();

            
            try
            {
                //требуется указать путь к файлу
                FileStream file = new FileStream("\\1.txt", FileMode.Open);
                StreamReader line = new StreamReader(file);
                string sline;
                var Dlaines = new List<string>();

                while ((sline = line.ReadLine()) != null)
                {
                    foreach(char a in sline)
                    {
                        if (a == x)
                            Console.Write(" ");
                        Console.Write(a);

                    }
                    Console.WriteLine();
                    //Dlaines.Add(line.ReadLine());
                }
                Console.ReadKey();


            }
            catch
            {
                string s = Environment.CurrentDirectory; 
                Console.WriteLine(s);
                Console.WriteLine("Обработка исключения");
                Console.ReadKey();
            }
        }
    }
}

