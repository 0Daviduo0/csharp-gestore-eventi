using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{

    internal class ProgrammaEventi
    {
        private string Titolo;
        private List<Evento> eventi;

        public ProgrammaEventi(string titolo)
        {
            Titolo = titolo;
            eventi = new List<Evento>();
        }

        public void AggiungiEvento(Evento e)
        {
            eventi.Add(e);
        }

        public List<Evento> EventiInData(DateTime data)
        {
            List<Evento> eventiInData = new List<Evento>();
            foreach (Evento e in eventi)
            {
                if (e.Data == data)
                {
                    eventiInData.Add(e);
                }
            }
            return eventiInData;
        }

        public static string RappresentazioneInStringa(List<Evento> eventi)
        {
            string rappresentazione = "";
            foreach (Evento e in eventi)
            {
                rappresentazione += e.Data.ToShortDateString() + " - " + e.Titolo + "\n";
            }
            return rappresentazione;
        }

        public int NumeroEventi()
        {
            return eventi.Count;
        }

        public void SvuotaEventi()
        {
            eventi.Clear();
        }

        public override string ToString()
        {
            string rappresentazione = $"Nome programma evento:{Titolo}\n";
            foreach (Evento e in eventi)
            {
                rappresentazione += e.Data.ToShortDateString() + " - " + e.Titolo + "\n";
            }
            return rappresentazione;
        }
    }
}
