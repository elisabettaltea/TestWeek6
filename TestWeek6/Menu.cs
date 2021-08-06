using System;

namespace TestWeek6
{
    internal class Menu
    {
        internal static void Start()
        {
            Console.WriteLine("-----Prova Week6-----");

            bool continua = true;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Gestione Conto Bancario");
                Console.WriteLine("[1] Crea un nuovo conto");
                Console.WriteLine("[2] Effettua movimenti");
                Console.WriteLine("[3] Stampa i dati del conto e i movimenti");
                Console.WriteLine("[4] Esci");
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        ContiManager.CreaConto();
                        break;
                    case "2":
                        ContiManager.EffettuaMovimenti();
                        break;
                    case "3":
                        ContiManager.Stampa();
                        break;
                    case "4":
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida!");
                        break;
                }

            } while (continua == true);

            Console.WriteLine("-----Arrivederci-----");
        }
    }
}