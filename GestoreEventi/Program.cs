namespace GestoreEventi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Creazione del programma eventi
            ProgrammaEventi GruppoEvento = new ProgrammaEventi("Evento Assurdo");
            ProgrammaEventi nuovoGruppoEvento = null;


            // Creazione degli eventi
            Evento evento1 = new Evento("Titolo evento 1", new DateTime(2023, 4, 18), 2500);
            Evento evento2 = new Evento("Titolo evento 2", new DateTime(2023, 4, 19), 500);
            Evento evento3 = new Evento("Titolo evento 3", new DateTime(2023, 4, 19), 17900);

            // Aggiunta degli eventi al programma
            GruppoEvento.AggiungiEvento(evento1);
            GruppoEvento.AggiungiEvento(evento2);
            GruppoEvento.AggiungiEvento(evento3);

            bool continua = true;

            while (continua)
            {
                Console.WriteLine("Scegli fra le seguenti opzioni:");

                Console.WriteLine("1 -> creare un gruppo di eventi e aggiungere eventi");
                Console.WriteLine("2 -> guardare la lista di eventi esistenti");

                Console.WriteLine("Se invece vuoi uscire dal programma basta digitare 0 \n");

                Console.Write("Scelta:");
                int scelta = Convert.ToInt32(Console.ReadLine());

                switch (scelta)
                {
                    case 0:
                        Console.WriteLine("Hai scelto di uscire dal programma.");
                        continua = false;
                        break;



                    case 1:

                        Console.WriteLine("-- CREAZIONE DI UN NUOVO GRUPPO EVENTO --");
                        Console.WriteLine("Inserisci il nome del nuovo gruppo evento:");
                        string nomeGruppo = Console.ReadLine();
                        nuovoGruppoEvento = new ProgrammaEventi(nomeGruppo);

                        Console.WriteLine("Inserisci il numero di eventi da creare:");
                        int numEventi = int.Parse(Console.ReadLine());
                            for (int i = 1; i <= numEventi; i++)
                            {
                                Console.WriteLine($"-- CREAZIONE DELL'EVENTO {i} --");

                                Console.WriteLine("Inserisci il titolo dell'evento:");
                                string titolo = Console.ReadLine();

                                Console.WriteLine("Inserisci la data dell'evento (formato dd/mm/yyyy):");
                                DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                                Console.WriteLine("Inserisci la capienza massima dell'evento:");
                                int capienzaMassima = int.Parse(Console.ReadLine());

                                Evento nuovoEvento = new Evento(titolo, data, capienzaMassima);

                                Console.WriteLine("Vuoi prenotare dei posti per l'evento? (si/no)");
                                string risposta = Console.ReadLine();

                                try
                                {
                                    while (risposta.ToLower() == "si")
                                    {
                                        Console.WriteLine("Inserisci il numero di posti da prenotare:");
                                        int numPosti = int.Parse(Console.ReadLine());

                                        try
                                        {
                                            nuovoEvento.PrenotaPosti(numPosti);
                                            Console.WriteLine("Prenotazione effettuata con successo");
                                            Console.WriteLine($"Posti prenotati: {nuovoEvento.PostiPrenotati}, posti disponibili: {nuovoEvento.PostiDisponibili}");
                                        }
                                        catch (ArgumentException ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                            continue; // chiediamo nuovamente l'input
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("Si è verificato un errore durante la prenotazione dei posti: " + ex.Message);
                                            continue;
                                        }

                                        Console.WriteLine("Vuoi prenotare altri posti? (si/no)");
                                        risposta = Console.ReadLine();
                                    }

                                    Console.WriteLine("Vuoi disdire dei posti per l'evento? (si/no)");
                                    risposta = Console.ReadLine();

                                    while (risposta.ToLower() == "si")
                                    {
                                            Console.WriteLine("Inserisci il numero di posti da disdire:");
                                            int numPosti = int.Parse(Console.ReadLine());

                                            try
                                            {
                                                nuovoEvento.DisdiciPosti(numPosti);
                                                Console.WriteLine("Disdetta effettuata con successo");
                                                Console.WriteLine($"Posti prenotati: {nuovoEvento.PostiPrenotati}, posti disponibili: {nuovoEvento.PostiDisponibili}");
                                            }
                                            catch (ArgumentException ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                                continue; // chiediamo nuovamente l'input
                                            }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("Si è verificato un errore durante la disdetta dei posti: " + ex.Message);
                                            break; // usciamo dal ciclo while
                                        }

                                        Console.WriteLine("Vuoi disdire altri posti? (si/no)");
                                        risposta = Console.ReadLine();
                                    }

                                    Console.WriteLine("Riassunto evento:");
                                    Console.WriteLine($"Titolo: {nuovoEvento.Titolo}");
                                    Console.WriteLine($"Data: {nuovoEvento.Data.ToString("dd/MM/yyyy")}");
                                    Console.WriteLine($"Posti prenotati: {nuovoEvento.PostiPrenotati}");
                                    Console.WriteLine($"Posti disponibili: {nuovoEvento.PostiDisponibili} \n");

                                    Console.WriteLine("L'evento è stato salvato con successo!");
                                    Evento nuovo_evento = new Evento(nuovoEvento.Titolo, nuovoEvento.Data, nuovoEvento.CapienzaMassima);
                                    nuovoGruppoEvento.AggiungiEvento(nuovo_evento);

                            }

                            catch (Exception ex)
                                {
                                    Console.WriteLine("Si è verificato un errore: " + ex.Message);
                                }
                            }

                        break;


                    case 2:
                        Console.WriteLine("-- LISTA EVENTI --");

                            // Stampare tutti gli eventi in una certa data
                            DateTime dataRicerca = new DateTime(2023, 4, 19);
                            List<Evento> eventiInData = GruppoEvento.EventiInData(dataRicerca);
                            string rappresentazioneEventiInData = ProgrammaEventi.RappresentazioneInStringa(eventiInData);
                            Console.WriteLine("Eventi in data " + dataRicerca.ToShortDateString() + ":\n" + rappresentazioneEventiInData);

                            // Stampare il numero totale di eventi nel programma
                            int numeroEventi = GruppoEvento.NumeroEventi();
                            Console.WriteLine("Numero totale di eventi: " + numeroEventi);

                            // Stampa del programma completo di eventi
                            Console.WriteLine(GruppoEvento);
                            Console.WriteLine(nuovoGruppoEvento);


                            break;
                      



                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        break;
                }



                // Svuotare la lista di eventi
                //GruppoEvento.SvuotaEventi();
                //Console.WriteLine("Numero totale di eventi dopo svuotamento: " + GruppoEvento.NumeroEventi());


            }
        }
    }
}