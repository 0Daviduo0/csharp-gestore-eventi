namespace GestoreEventi
{
    internal class Program
{
    static void Main(string[] args)
    {

            // Creazione del programma eventi
            ProgrammaEventi GruppoEvento = new ProgrammaEventi("Evento Assurdo");

            // Creazione degli eventi
            Evento evento1 = new Evento("Titolo evento 1", new DateTime(2023, 4, 18), 2500);
            Evento evento2 = new Evento("Titolo evento 2", new DateTime(2023, 4, 19), 500);
            Evento evento3 = new Evento("Titolo evento 3", new DateTime(2023, 4, 19), 17900);

            // Aggiunta degli eventi al programma
            GruppoEvento.AggiungiEvento(evento1);
            GruppoEvento.AggiungiEvento(evento2);
            GruppoEvento.AggiungiEvento(evento3);


        //    // Chiediamo all'utente di inserire i dati per un nuovo evento
        //    Console.WriteLine("Inserisci il titolo dell'evento:");
        //    string titolo = Console.ReadLine();

        //    Console.WriteLine("Inserisci la data dell'evento (formato dd/mm/yyyy):");
        //    DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        //    Console.WriteLine("Inserisci la capienza massima dell'evento:");
        //    int capienzaMassima = int.Parse(Console.ReadLine());

        //    // Istanziamo un nuovo evento con i dati inseriti dall'utente
        //    Evento nuovoEvento = new Evento(titolo, data, capienzaMassima);

        //    // Chiediamo all'utente se vuole prenotare dei posti
        //    Console.WriteLine("Vuoi prenotare dei posti per l'evento? (si/no)");
        //    string risposta = Console.ReadLine();

        //    try
        //    {

        //    while (risposta.ToLower() == "si")
        //    {
        //        Console.WriteLine("Inserisci il numero di posti da prenotare:");
        //        int numPosti = int.Parse(Console.ReadLine());

        //        try
        //        {
        //            nuovoEvento.PrenotaPosti(numPosti);
        //            Console.WriteLine("Prenotazione effettuata con successo");
        //            Console.WriteLine($"Posti prenotati: {nuovoEvento.PostiPrenotati}, posti disponibili: {nuovoEvento.PostiDisponibili}");
        //        }
        //        catch (ArgumentException ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //            continue; // chiediamo nuovamente l'input
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("Si è verificato un errore durante la prenotazione dei posti: " + ex.Message);
        //            continue;
        //        }

        //        Console.WriteLine("Vuoi prenotare altri posti? (si/no)");
        //        risposta = Console.ReadLine();
        //    }

        //    // Chiediamo all'utente se vuole disdire dei posti
        //    Console.WriteLine("Vuoi disdire dei posti per l'evento? (si/no)");
        //    risposta = Console.ReadLine();

        //    while (risposta.ToLower() == "si")
        //    {
        //        Console.WriteLine("Inserisci il numero di posti da disdire:");
        //        int numPosti = int.Parse(Console.ReadLine());

        //        try
        //        {
        //            nuovoEvento.DisdiciPosti(numPosti);
        //            Console.WriteLine("Disdetta effettuata con successo");
        //            Console.WriteLine($"Posti prenotati: {nuovoEvento.PostiPrenotati}, posti disponibili: {nuovoEvento.PostiDisponibili}");
        //        }
        //        catch (ArgumentException ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //            continue; // chiediamo nuovamente l'input
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("Si è verificato un errore durante la disdetta dei posti: " + ex.Message);
        //            break; // usciamo dal ciclo while
        //        }

        //        Console.WriteLine("Vuoi disdire altri posti? (si/no)");
        //        risposta = Console.ReadLine();
        //    }

        //        Console.WriteLine("Riassunto evento:");
        //        Console.WriteLine($"Titolo: {nuovoEvento.Titolo}");
        //        Console.WriteLine($"Data: {nuovoEvento.Data.ToString("dd/MM/yyyy")}");
        //        Console.WriteLine($"Posti prenotati: {nuovoEvento.PostiPrenotati}");
        //        Console.WriteLine($"Posti disponibili: {nuovoEvento.PostiDisponibili}");
        //    }
        //catch (Exception ex)
        //{
        //    Console.WriteLine("Si è verificato un errore: " + ex.Message);
        //}

            // Stampare tutti gli eventi in una certa data
            DateTime dataRicerca = new DateTime(2023, 4, 19);
            List<Evento> eventiInData = GruppoEvento.EventiInData(dataRicerca);
            string rappresentazioneEventiInData = ProgrammaEventi.RappresentazioneInStringa(eventiInData);
            Console.WriteLine("Eventi in data " + dataRicerca.ToShortDateString() + ":\n" + rappresentazioneEventiInData);

            // Stampare il numero totale di eventi nel programma
            int numeroEventi = GruppoEvento.NumeroEventi();
            Console.WriteLine("Numero totale di eventi: " + numeroEventi);

            // Svuotare la lista di eventi
            //GruppoEvento.SvuotaEventi();
            //Console.WriteLine("Numero totale di eventi dopo svuotamento: " + GruppoEvento.NumeroEventi());

            // Stampa del programma completo di eventi
            Console.WriteLine(GruppoEvento);
        }
}
}