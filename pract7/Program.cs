using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pract7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {


                try
                {
                    StreamReader inFile = new StreamReader("F.txt");
                    Console.SetIn(inFile);
                    BinaryWriter F = new BinaryWriter(new FileStream("F.txt", FileMode.Create));
                    Random random = new Random();

                    for (int i = 0; i < 12; i++)
                    {
                        double valueWeather = random.Next(20);
                        F.Write(valueWeather);

                    }
                    F.Close();

                    BinaryReader Fread = new BinaryReader(new FileStream("F.txt", FileMode.Open));
                    double[] monthlyTemperatures = new double[12];
                    double sum = 0;

                    for (int i = 0; i < 12; i++)
                    {
                        double temperature = Fread.ReadDouble();
                        monthlyTemperatures[i] = temperature;
                        sum += temperature;
                        Console.WriteLine($"Месяц {i + 1}: {temperature}");
                    }
                    Fread.Close();


                    StreamWriter outFile = new StreamWriter("G.txt");
                    Console.SetOut(outFile);
                    BinaryWriter G = new BinaryWriter(new FileStream("G.txt", FileMode.Create));
                    Console.WriteLine("\nСодержимое файла G.txt (отклонения среднемесячной температуры от среднегодовой):");
                    double averageYearlyTemperature = sum / 12;

                    for (int i = 0; i < 12; i++)
                    {
                        double deviation = monthlyTemperatures[i] - averageYearlyTemperature;
                        G.Write(deviation);

                        Console.WriteLine($"Месяц {i + 1}: {deviation}");
                    }
                    G.Close();
                }
                catch (Exception ex) { }


            }
        }
    }
}