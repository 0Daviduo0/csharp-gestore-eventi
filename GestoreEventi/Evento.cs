﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    internal class Evento
    {
        private string titolo;
        private DateTime data;
        private int capienzaMassima;
        private int postiPrenotati;

        public string Titolo
        {
            get { return titolo; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Il titolo non può essere vuoto");
                }
                titolo = value;
            }
        }

        public DateTime Data
        {
            get { return data; }
            set
            {
                if (value < DateTime.Now.Date)
                {
                    throw new ArgumentException("La data non può essere passata");
                }
                data = value;
            }
        }

        public int PostiDisponibili
        {
            get { return capienzaMassima - postiPrenotati; }
        }

        public int PostiPrenotati
        {
            get { return postiPrenotati; }
        }

        public Evento(string titolo, DateTime data, int capienzaMassima)
        {
            Titolo = titolo;
            Data = data;
            if (capienzaMassima <= 0)
            {
                throw new ArgumentException("La capienza massima deve essere positiva");
            }
            this.capienzaMassima = capienzaMassima;
            postiPrenotati = 0;
        }

        public void PrenotaPosti(int numPosti)
        {
            if (Data < DateTime.Now.Date)
            {
                throw new Exception("L'evento è già passato");
            }
            if (PostiDisponibili == 0)
            {
                throw new Exception("L'evento è già al completo");
            }
            if (numPosti > PostiDisponibili)
            {
                throw new Exception("Posti insufficienti per la prenotazione richiesta");
            }
            postiPrenotati += numPosti;
        }

        public void DisdiciPosti(int numPosti)
        {
            if (Data < DateTime.Now.Date)
            {
                throw new Exception("L'evento è già passato");
            }
            if (numPosti > postiPrenotati)
            {
                throw new Exception("Non ci sono abbastanza posti prenotati da disdire");
            }
            postiPrenotati -= numPosti;
        }

        public override string ToString()
        {
            return data.ToString("dd/MM/yyyy") + " - " + titolo;
        }
    }
}
