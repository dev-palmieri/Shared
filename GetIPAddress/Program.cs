using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GetIPAddress
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = "C:\\Temp\\ACS.Portal.ServiceGateway.dll.config"; // Percorso del file XML di input
            string outputFilePath = "c:\\Cert_Ports.txt"; // Percorso del file di output per le porte
                                                          // commento inserito per il test GIT 1


            // commento inserito per il test GIT 5
            try
            {
                // Carica il contenuto XML dal file
                XDocument xmlDoc = XDocument.Load(inputFilePath);

                // HashSet per memorizzare le porte uniche
                HashSet<string> uniquePorts = new HashSet<string>();
                // commento inserito per il test GIT 2
                // Espressione regolare per abbinare solo gli URL https con porte
                Regex regex = new Regex(@"https://[^:/]+:(\d+)");

                foreach (XElement serviceConfiguration in xmlDoc.Descendants("ServiceConfiguration"))
                {
                    string entryPoint = serviceConfiguration.Attribute("EntryPoint")?.Value;
                    if (entryPoint != null)
                    {
                        Match match = regex.Match(entryPoint);
                        if (match.Success)
                        {
                            // Estrai la porta
                            string port = match.Groups[1].Value;

                            // Aggiungi la porta all'HashSet, che eliminerà i duplicati
                            uniquePorts.Add(port);
                        }
                    }
                }
                // commento inserito per il test GIT 2
                // Scrivi le porte uniche nel file di output
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    foreach (string port in uniquePorts)
                    {
                        writer.WriteLine($"Port: {port}");
                    }
                }
                // commento inserito per il test GIT 4
                Console.WriteLine("Le porte HTTPS uniche sono state scritte nel file di output.");
            }
            catch (NullReferenceException nx)
            {
                Console.WriteLine($"Si è verificato un errore: {nx.Message}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Si è verificato un errore: {ex.Message}");
            }

            

        }
        private static string Get()
        {
            return "Ciao";
        }
        private static string Get(string value, int num = 0)
        {
            return "Que";
        }
    }
}
