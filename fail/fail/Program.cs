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
            //try
            //{
                string PathToAdd = "C:\\Users\\a.medkov\\Desktop\\fail\\test.txt";

                FileStream file = new FileStream("C:\\Users\\a.medkov\\Desktop\\fail\\spisok.txt", FileMode.Open);

               // FileStream file = new FileStream("${Environment.CurrentDirectory}\\spisok.txt", FileMode.Open);
                //FileStream file = new FileStream($"{Environment.CurrentDirectory}\\spisok.txt", FileMode.Open);
                StreamReader sr = new StreamReader(file);

                

                while (!sr.EndOfStream)
                    slova.Add(sr.ReadLine());
                Console.ReadKey();
                one_reverse();
                AddNew(PathToAdd);
                Console.WriteLine();
                Console.ReadKey();
            //}
            /*catch
            {
                string s = Environment.CurrentDirectory; 
                Console.WriteLine(s);
                Console.WriteLine("Обработка исключения");
                Console.ReadKey();
            }*/
        }
    }
}

