using System;
using System.Collections.Generic;
using TestWeek6.Entities;

namespace TestWeek6
{
    public class ContiManager
    {
        public static Conto conto = new(); //per lavorare su un solo conto lo creo static
        //se volessi dare la possibilità all'utente di aprire più conti creerei una lista di conti

        public static void CreaConto()
        {
            Random random = new Random();
            conto.NumeroConto = random.Next(1, 100);
            //se avessi una lista di conti inserirei il controllo che non esista già un conto con quel numero di conto
                
            Console.WriteLine("Inserisci il nome della banca: ");
            conto.NomeBanca = Console.ReadLine();

            Console.WriteLine("Inserisci il saldo: ");
            conto.Saldo = CheckDecimal();

            conto.DataUltimaOperazione = DateTime.Today;

            conto.Movimenti = new List<Movimento>();
        }

        private static decimal CheckDecimal()
        {
            decimal saldo;
            while(!decimal.TryParse(Console.ReadLine(),out saldo))
            {
                Console.WriteLine("Cifra non valida, riprova.");
            }
            return saldo;
        }

        public static void EffettuaMovimenti()
        {
            //se avessi una lista di conti, inserirei prima la scelta del conto tramite il suo numero
            if (conto.NumeroConto == 0)
                Console.WriteLine("Non è presente nessun conto.");
            else
            {
                Console.WriteLine("Se si tratta di un versamento premere 'v', se si tratta di un prelievo premere 'p': ");
                bool isVersamento = SceltaVersamentoPrelievo();

                Console.WriteLine("Inserisci l'importo: ");
                decimal importo = CheckDecimal();

                try
                {
                    conto.ModificaSaldo(isVersamento, importo);
                    bool continua = false;
                    do
                    {
                        Console.WriteLine("Gestione Movimento");
                        Console.WriteLine("[1] Effettua un cash movement");
                        Console.WriteLine("[2] Effettua un transfert movement");
                        Console.WriteLine("[3] Effettua un credit card movement");
                        string scelta = Console.ReadLine();

                        switch (scelta)
                        {
                            case "1":
                                CashMovement cashM = CreaCashMovement(importo, isVersamento);
                                conto.Movimenti.Add(cashM);
                                break;
                            case "2":
                                TransfertMovement transfertM = CreaTransfertMovement(importo, isVersamento);
                                conto.Movimenti.Add(transfertM);
                                break;
                            case "3":
                                CreditcardMovement creditcardM = CreaCreditCardMovement(importo, isVersamento);
                                conto.Movimenti.Add(creditcardM);
                                break;
                            default:
                                Console.WriteLine("Scelta non valida!");
                                continua = true;
                                break;
                        }
                    } while (continua);
                }
                catch (ImportoNonValidoException ex)
                {
                    Console.WriteLine("Errore: " + ex.Message);
                    Console.WriteLine($"Modifica l'importo inserito {ex.ImportoNonValido}.");
                }
            }
        }

        private static bool SceltaVersamentoPrelievo()
        {
            string scelta = Console.ReadLine();
            bool isVersamento = false;
            do
            {
                switch (scelta)
                {
                    case "v":
                        isVersamento = true;
                        break;
                    case "p":
                        isVersamento = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida, riprova: ");
                        break;
                };
            } while (!(scelta == "v" || scelta == "p"));
            return isVersamento;
        }

        private static CreditcardMovement CreaCreditCardMovement(decimal importo, bool isVersamento)
        {
            CreditcardMovement creditCardM = new();

            creditCardM.DataMovimento = DateTime.Today;
            creditCardM.Importo = importo;
            creditCardM.IsVersamento = isVersamento;

            Console.WriteLine("Inserisci il numero di Carta: ");
            creditCardM.NumeroCarta = Console.ReadLine();
            Console.WriteLine("Inserisci il tipo di Carta: ");
            creditCardM.Tipo = ScegliTipo();

            return creditCardM;
        }

        private static TipoCarta ScegliTipo()
        {
            bool isInt = false;
            int tipo = 0;
            do
            {
                Console.WriteLine($"Premi {(int)TipoCarta.VISA} per {TipoCarta.VISA}");
                Console.WriteLine($"Premi {(int)TipoCarta.Mastercard} per {TipoCarta.Mastercard}");
                Console.WriteLine($"Premi {(int)TipoCarta.AmericanExpress} per {TipoCarta.AmericanExpress}");
                Console.WriteLine($"Premi {(int)TipoCarta.Altro} per {TipoCarta.Altro}");

                isInt = int.TryParse(Console.ReadLine(), out tipo);
            } while (!isInt || tipo < 0 || tipo > 3);

            return (TipoCarta)tipo;
        }

        private static TransfertMovement CreaTransfertMovement(decimal importo, bool isVersamento)
        {
            TransfertMovement transfertM = new();

            transfertM.DataMovimento = DateTime.Today;
            transfertM.Importo = importo;
            transfertM.IsVersamento = isVersamento;

            Console.WriteLine("Inserisci la banca di origine: ");
            transfertM.BancaOrigine = Console.ReadLine();
            Console.WriteLine("Inserisci la banca di destinazione: ");
            transfertM.BancaDestinazione = Console.ReadLine();

            return transfertM;
        }

        private static CashMovement CreaCashMovement(decimal importo, bool isVersamento)
        {
            CashMovement cashM = new();

            cashM.DataMovimento = DateTime.Today;
            cashM.Importo = importo;
            cashM.IsVersamento = isVersamento;

            Console.WriteLine("Inserisci l'esecutore: ");
            cashM.Esecutore=Console.ReadLine();

            return cashM;
        }

        //si potrebbe far scegliere all'utente di stampare solo i dati del conto o solo i movimenti,
        //in tal caso si potrebbe inserire uno switch in Stampa e separare il Console.WriteLine dal foreach nell'else
        public static void Stampa()
        {
            //se avessi una lista di conti, inserirei prima la scelta del conto tramite il suo numero
            if (conto.NumeroConto == 0)
                Console.WriteLine("Non è presente nessun conto.");
            else
            {
                Console.WriteLine($"[Numero Conto] {conto.NumeroConto}, [Nome Banca] {conto.NomeBanca}, " +
                    $"[Saldo] {conto.Saldo}, [Data Ultima Operazione] {conto.DataUltimaOperazione.ToString("dd/MM/yyyy")}");
                foreach (var movimento in conto.Movimenti)
                {
                    Console.WriteLine(movimento);
                }
            }
        }
    }
}