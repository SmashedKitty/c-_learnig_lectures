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

        static List<string> slova = new List<string>();

        static void one()
        {
            for (int i = 0; i < slova.Count(); i++)
            {
                string[] name = slova[i].Split(' ', '.', ',', ':', ';', '!', '?', '\r', '\n');
                for (int j = 0; j < name.Count(); j++)
                    Console.Write(name[j] + " ");
                Console.WriteLine();
            }
        }

        static void one_reverse()
        {
            for (int i = 0; i < slova.Count(); i++)
            {
                string[] name = slova[i].Split(' ', '.', ',', ':', ';', '!', '?', '\r', '\n');
                for (int j = name.Count() - 1; j >= 0; j--)
                    Console.Write(name[j] + " ");
                Console.WriteLine();
            }
        }

        static void AddNew(string path)
        {
            string AdditionalContent = "Only hommies can be homies";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(AdditionalContent);
            }
        }
        static void Main(string[] args)
        {
            
                Console.WriteLine("Input template symbol: \n");

                var x = Console.ReadKey().KeyChar;
                Console.WriteLine();


            try
            {
                FileStream file = new FileStream("C:\\Users\\admin\\Desktop\\c-_learnig_lectures-main\\fail\\1.txt", FileMode.Open);
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

