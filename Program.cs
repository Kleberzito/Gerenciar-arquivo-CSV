using Gerenciar_arquivo_CSV.Entities;
using System;
using System.Globalization;
using System.IO;

namespace Gerenciar_arquivo_CSV
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Entre com o nomer do arquivo: ");
            string sourceFile = Console.ReadLine();

            string path = @"D:\Projetos - C#\Gerenciar arquivo CSV\Gerenciar arquivo CSV\Aquivo";

            try
            {
                string[] lines = File.ReadAllLines(path + @"\" + sourceFile + ".csv");

                string targetFolderPath = path + @"\out";
                string targetFilePath = targetFolderPath + @"\summary.csv";

                Directory.CreateDirectory(targetFolderPath);

                using (StreamWriter sw = File.AppendText(targetFilePath))
                {
                    foreach(string s in lines)
                    {
                        string[] fields = s.Split(';');
                        string name = fields[0];
                        double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(fields[2]);

                        Product pro = new Product(name, price, quantity);                        

                        sw.WriteLine(pro.Name + ";" + pro.Total().ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}
