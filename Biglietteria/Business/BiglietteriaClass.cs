using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biglietteria.Business
{
    public class BiglietteriaClass
    {
        public List<Percorso> Percorsi { get; set; } = new List<Percorso>();

        public BiglietteriaClass(List<Percorso> percorsi)
        {
            Percorsi = percorsi;
        }

        public List<Percorso> GetPercorsiByTipoMezzo(string inizialeMezzo)
        {
            return Percorsi.Where(percorso => percorso.Mezzo.Codice.StartsWith(inizialeMezzo)).ToList();
        }

        public List<Percorso> RicercaFermata(string nomeFermata)
        {
            List<Percorso> percorsiConFermata = new List<Percorso>();
            foreach (Percorso percorso in Percorsi)
            {
                if (percorso.FermataIsInPercorso(nomeFermata))
                    percorsiConFermata.Add(percorso);
            }

            return percorsiConFermata;
        }

        public List<Percorso> RicercaTratta(string nomeFermata1, string nomeFermata2)
        {
            List<Percorso> percorsiConTratta = new List<Percorso>();
            foreach (Percorso percorso in Percorsi)
            {
                if (percorso.TrattaIsInPercorso(nomeFermata1, nomeFermata2))
                {
                    percorso.DistanzaTratta = percorso.CalcolaDistanzaTraDueFermate(nomeFermata1, nomeFermata2);
                    percorso.CostoTratta = percorso.CalcolaCosto(percorso.DistanzaTratta);
                    percorsiConTratta.Add(percorso);
                }
            }

            return percorsiConTratta.OrderBy(x => x.CostoTratta).ToList();
        }

    }
}
