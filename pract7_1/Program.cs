using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const uint numberscount = 10;
            try
            {
                BinaryWriter file = new BinaryWriter(new FileStream("binary.dat", FileMode.Create));
                Random rand = new Random();
                for (int i = 0; i < numberscount; i++)
                {
                    file.Write(rand.Next(100) + rand.Next(100) / 100.0d);
                }
                file.Close();
                Console.WriteLine("Файл был заполнен:");

            }
            catch { }

            double[] array = new double[10];
            try
            {
                BinaryReader read = new BinaryReader(new FileStream("binary.dat", FileMode.Open, FileAccess.Read));
                for (int i = 0; i < numberscount; i++)
                {
                    array[i] = read.ReadDouble();
                    Console.WriteLine(array[i]);
                }
                read.Close();
            }
            catch { }


            try
            {
                Console.WriteLine("Введите вещественное число:");
                double input = double.Parse(Console.ReadLine());


                BinaryWriter binaryWriter = new BinaryWriter(new FileStream("binary.dat", FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.Seek(0, SeekOrigin.End);



                for (int i = 0; i < numberscount; i++)
                {
                    if (array[i] > input)
                    {
                        binaryWriter.Write(array[i]);
                    }
                }
                binaryWriter.Close();


                Console.WriteLine("Измененный файл: ");
                BinaryReader binaryreader = new BinaryReader(new FileStream("binary.dat", FileMode.Open, FileAccess.Read));
                try
                {
                    while (true)
                    {
                        Console.WriteLine(binaryreader.ReadDouble());
                        Console.WriteLine("\t");
                    }
                }
                catch { }
                binaryreader.Close();

            }
            catch { }

        }
    }
}
