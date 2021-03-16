using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordDL
{
    class Program
    {
        static void Main(string[] args)
        {
            // D:\zDumps\lists
            // D:\zDumps\download\
            WebClient client = new WebClient();

            string inputPath = Prompt("Input path: ");
            string outputPath = Prompt("Output path: ");

            string[] lines = File.ReadAllLines(inputPath);

            foreach (string line in lines)
            {
                Console.WriteLine(line);
                string[] array = line.Split('/');
                string fPath = @outputPath + array[array.Length - 1];
                try
                {
                    if (!File.Exists(fPath))
                        client.DownloadFile(line, fPath);
                }
                catch (Exception e)
                {
                    PrintStackTrace(e);
                }
            }

            Thread.Sleep(-1);
        }

        static string Prompt(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();  
        }

        static void PrintStackTrace(Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }
    }
}
