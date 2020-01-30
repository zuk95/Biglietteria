using Biglietteria.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biglietteria.Controller
{
    /// <summary>
    /// Classe che rappresenta l'accesso al sistema di business
    /// I comandi dalle interfacce dovranno passare di qui
    /// </summary>
    public class BiglietteriaController
    {
        List<object> result = new List<object>();
        BiglietteriaClass biglietteria;

        public BiglietteriaController(List<Percorso> percorsi)
        {
            biglietteria = new BiglietteriaClass(percorsi);
        }

        public List<object> GetPercorsiByTipoMezzo(string inizialeMezzo)
        {
            try
            {
                List<Percorso> percorsiRisultanti = biglietteria.GetPercorsiByTipoMezzo(inizialeMezzo);

                result.Add("OK");
                result.Add(percorsiRisultanti);
                return result;
            }
            catch (Exception ex)
            {
                result.Add("KO");
                result.Add($"{ex.Message}");
                return result;
            }
        }

        public List<object> RicercaFermata(string nomeFermata)
        {
            try
            {
                List<Percorso> percorsiRisultanti = biglietteria.RicercaFermata(nomeFermata);

                result.Add("OK");
                result.Add(percorsiRisultanti);
                return result;
            }
            catch (Exception ex)
            {
                result.Add("KO");
                result.Add($"{ex.Message}");
                return result;
            }
        }

        public List<object> RicercaTratta(string nomeFermata1, string nomeFermata2)
        {
            try
            {
                List<Percorso> percorsiConTratta = biglietteria.RicercaTratta(nomeFermata1,nomeFermata2);

                result.Add("OK");
                result.Add(percorsiConTratta);
                return result;
            }
            catch (Exception ex)
            {
                result.Add("KO");
                result.Add($"{ex.Message}");
                return result;
            }
        }

    }
}
