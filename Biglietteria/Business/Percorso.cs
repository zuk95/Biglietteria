using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biglietteria.Business
{
    public class Percorso
    {
        public string Codice { get; set; } = string.Empty;

        public List<Fermata> Fermate { get; set; } = new List<Fermata>();

        public Mezzo Mezzo { get; set; }

        /// <summary>
        /// Costo totale si riferisce al costo dell'intero percorso
        /// </summary>
        public int CostoTotale { get; set; } = -1;

        /// <summary>
        /// Costo tratta si riferisce al costo di una tratta specificata
        /// </summary>
        public int CostoTratta { get; set; } = -1;

        public int DistanzaTratta { get; set; } = -1;

        public int DistanzaTotale { get; set; }

        public Percorso(string codice, List<Fermata> fermate , Mezzo mezzo)
        {
            Codice = codice;
            Fermate = fermate;
            Mezzo = mezzo;

            CalcolaDistanzaTotale();
            CostoTotale = CalcolaCosto(DistanzaTotale);
        }

        private void CalcolaDistanzaTotale()
        {
            foreach(Fermata f in Fermate)
            {
                this.DistanzaTotale += f.Distanza;
            }
        }

        public int CalcolaCosto(int distanza)
        {
            return Mezzo.GetCosto(distanza);
        }

        public bool TrattaIsInPercorso(string nomeFermata1, string nomeFermata2)
        {
            if(FermataIsInPercorso(nomeFermata1) && FermataIsInPercorso(nomeFermata2))
            {

                int indexFermata1 = Fermate.FindIndex(x => x.Nome == nomeFermata1);
                int indexFermata2 = Fermate.FindIndex(x => x.Nome == nomeFermata2);

                if (indexFermata1 < indexFermata2)
                { 
                    return true;
                }

            }

            return false;
        }

        public int CalcolaDistanzaTraDueFermate(string nomeFermata1, string nomeFermata2)
        {
            List<Fermata> fermateDaSommare = new List<Fermata>();
            bool primaFermataTrovata = false;
            bool secondaFermataTrovata = false;
            foreach (Fermata fermata in Fermate)
            {
                if (primaFermataTrovata && !secondaFermataTrovata)
                {
                    fermateDaSommare.Add(fermata);
                }

                if(fermata.Nome == nomeFermata1)
                {
                    primaFermataTrovata = true;
                }
                if (fermata.Nome == nomeFermata2)
                {
                    secondaFermataTrovata = true;
                }
            }

            return fermateDaSommare.Sum(x => x.Distanza);
        }

        public bool FermataIsInPercorso(string nomeFermata)
        {
            foreach (Fermata fermata in Fermate)
            {
                if (fermata.Nome == nomeFermata)
                    return true;
            }

            return false;
        }

    }
}
