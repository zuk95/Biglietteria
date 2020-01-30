using Biglietteria.Business;
using Biglietteria.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BiglietteriaTest
{
    [TestClass]
    public class TestBiglietteria
    {

        [TestMethod]
        public void GetPercorsiByTipoMezzoConAutobusTest()
        {
            Mezzo autobus = new Autobus("sonounautobus"); //Il tipoMezzo deve essere A
            Mezzo interCity = new InterCity("sonounintercity");
            List<Fermata> fermatePercorsoAutobus = new List<Fermata>()
            {
                new Fermata("fermata1","f1",10),
                new Fermata("fermata2","f2",20),
                new Fermata("fermata3","f3",30),
            };
            //mi aspetto una distanzatotale del percorso pari a 10+20+30 = 60
            //(l'autobus ha un costo fisso pari a 10) mi aspetto un costototale del percorso pari al costoFisso dell'autobus cioè 10  

            Percorso percorsoConAutobus = new Percorso("percorsoConAutobus", fermatePercorsoAutobus, autobus);
            Percorso percorsoConInterCity = new Percorso("percorsoConInterCity", new List<Fermata>(), interCity);
            List<Percorso> percorsi = new List<Percorso>();percorsi.Add(percorsoConAutobus);percorsi.Add(percorsoConInterCity);

            BiglietteriaClass biglietteria = new BiglietteriaClass(percorsi);

            //Metto "A" perchè voglio i percorsi con gli autobus
            //mi aspetto che mi venga resituito il percorso di nome percorsoConAutobus
            List<Percorso> percorsiRisultanti = biglietteria.GetPercorsiByTipoMezzo("A");

            Assert.IsNotNull(percorsiRisultanti);
            Assert.AreEqual(1, percorsiRisultanti.Count);
            Assert.IsNotNull(percorsiRisultanti.Find(x => x.Codice == "percorsoConAutobus"));
            Percorso percorsoRisultante = percorsiRisultanti.Find(x => x.Codice == "percorsoConAutobus");
            Assert.AreEqual(60, percorsoRisultante.DistanzaTotale);
            Assert.AreEqual(10, percorsoRisultante.CostoTotale);

        }

        [TestMethod]
        public void GetPercorsiByTipoMezzoConInterCityTest()
        {
            Mezzo autobus = new Autobus("sonounautobus"); //Il tipoMezzo deve essere A
            Mezzo interCity = new InterCity("sonounintercity");
            List<Fermata> fermatePercorsoInterCity = new List<Fermata>()
            {
                new Fermata("fermata1","f1",10),
                new Fermata("fermata2","f2",20),
                new Fermata("fermata3","f3",30),
            };
            //mi aspetto una distanzatotale del percorso pari a 10+20+30 = 60
            //(l'interCity ha un costo in base ai km pari a 10) mi aspetto un costototale del percorso pari a distnzatotale * 10 = 600

            Percorso percorsoConAutobus = new Percorso("percorsoConAutobus", new List<Fermata>(), autobus);
            Percorso percorsoConInterCity = new Percorso("percorsoConInterCity", fermatePercorsoInterCity, interCity);
            List<Percorso> percorsi = new List<Percorso>(); percorsi.Add(percorsoConAutobus); percorsi.Add(percorsoConInterCity);

            BiglietteriaClass biglietteria = new BiglietteriaClass(percorsi);

            //Metto "I" perchè voglio i percorsi con gli interCity
            //mi aspetto che mi venga resituito il percorso di nome percorsoConInterCity
            List<Percorso> percorsiRisultanti = biglietteria.GetPercorsiByTipoMezzo("I");

            Assert.IsNotNull(percorsiRisultanti);
            Assert.AreEqual(1, percorsiRisultanti.Count);
            Assert.IsNotNull(percorsiRisultanti.Find(x => x.Codice == "percorsoConInterCity"));
            Percorso percorsoRisultante = percorsiRisultanti.Find(x => x.Codice == "percorsoConInterCity");
            Assert.AreEqual(60, percorsoRisultante.DistanzaTotale);
            Assert.AreEqual(600, percorsoRisultante.CostoTotale);

        }

        [TestMethod]
        public void RicercaFermataTest()
        {
            Mezzo autobus = new Autobus("sonounautobus"); //Il tipoMezzo deve essere A
            Mezzo interCity = new InterCity("sonounintercity");

            List<Fermata> fermatePercorsoAutobusy = new List<Fermata>()
            {
                new Fermata("fermataInComune","f2",20),
            };

            List<Fermata> fermatePercorsoInterCity = new List<Fermata>()
            {
                new Fermata("fermata1","f1",10),
                new Fermata("fermataInComune","f2",20),
                new Fermata("fermata3","f3",30),
            };
            //se ricerco la fermata di nome "fermataInComune", mi aspetto di trovare i due percorsi come
            //risultato

            Percorso percorsoConAutobus = new Percorso("percorsoConAutobus", fermatePercorsoAutobusy, autobus);
            Percorso percorsoConInterCity = new Percorso("percorsoConInterCity", fermatePercorsoInterCity, interCity);
            List<Percorso> percorsi = new List<Percorso>(); percorsi.Add(percorsoConAutobus); percorsi.Add(percorsoConInterCity);

            BiglietteriaClass biglietteria = new BiglietteriaClass(percorsi);

            //ricerco per nome fermata = fermataInComune
            List<Percorso> percorsiRisultanti = biglietteria.RicercaFermata("fermataInComune");

            Assert.IsNotNull(percorsiRisultanti);
            Assert.AreEqual(2, percorsiRisultanti.Count);
            Assert.IsTrue(percorsiRisultanti.Contains(percorsoConAutobus));
            Assert.IsTrue(percorsiRisultanti.Contains(percorsoConInterCity));

        }

        [TestMethod]
        public void RicercaTrattaTest()
        {
            Mezzo autobus = new Autobus("sonounautobus"); 
            Mezzo interCity = new InterCity("sonounintercity");
            Mezzo metropolitana = new Metropolitana("sonounametro");

            List<Fermata> fermatePercorsoAutobusy = new List<Fermata>()
            {
                new Fermata("fermata3","f3",30),
                new Fermata("fermataInComune","f2",20),
                new Fermata("fermata1","f1",10)
            };

            List<Fermata> fermatePercorsoInterCity = new List<Fermata>()
            {
                //La distanza delle fermate si riferisce rispetto a quella immediatamente precedente
                new Fermata("fermata1","f1",10),
                new Fermata("fermataInComune","f2",50),
                new Fermata("fermata3","f3",30)
            };

            List<Fermata> fermatePercorsoMetropolitana = new List<Fermata>()
            {
                //La distanza delle fermate si riferisce rispetto a quella immediatamente precedente
                new Fermata("fermata1","f1",10),
                new Fermata("fermata3","f3",30)
            };
            //Se ricerco la tratta fermata1 => fermata3, siccome si considera anche l'ordine di ricerca
            //il risultato che mi aspetto è il percorsoConInterCity e percorsoconmetro

            Percorso percorsoConAutobus = new Percorso("percorsoConAutobus", fermatePercorsoAutobusy, autobus);
            Percorso percorsoConInterCity = new Percorso("percorsoConInterCity", fermatePercorsoInterCity, interCity);
            Percorso percorsoConMetropolitana = new Percorso("percorsoConMetropolitana", fermatePercorsoMetropolitana, metropolitana);
            List<Percorso> percorsi = new List<Percorso>(); percorsi.Add(percorsoConAutobus); percorsi.Add(percorsoConInterCity);percorsi.Add(percorsoConMetropolitana);

            BiglietteriaClass biglietteria = new BiglietteriaClass(percorsi);

            //ricerco per tratta fermata1 => fermata3
            List<Percorso> percorsiRisultanti = biglietteria.RicercaTratta("fermata1","fermata3");

            Assert.IsNotNull(percorsiRisultanti);
            Assert.AreEqual(2, percorsiRisultanti.Count);
            Assert.IsFalse(percorsiRisultanti.Contains(percorsoConAutobus));
            Assert.IsTrue(percorsiRisultanti.Contains(percorsoConInterCity));
            Assert.IsTrue(percorsiRisultanti.Contains(percorsoConMetropolitana));

            Percorso percorsoRisultanteInterCity = percorsiRisultanti.Find(x => x.Codice == "percorsoConInterCity");
            Percorso percorsoRisultanteMetropolitana = percorsiRisultanti.Find(x => x.Codice == "percorsoConMetropolitana");

            //Per quanto riguarda il costo della tratta, la distanza tra le due fermate è data da:
            //distanzaSecondaFermata - distanzaPrimaFermata
            //50 + 30 = 80
            //Il costo della tratta (sapendo chel'intercity costa 10 per km) è dato da distanzaTratta * 10 = 800

            //InterCity
            Assert.AreEqual(80, percorsoRisultanteInterCity.DistanzaTratta);
            Assert.AreEqual(800, percorsoRisultanteInterCity.CostoTratta);

            //Metropolitana
            Assert.AreEqual(30, percorsoRisultanteMetropolitana.DistanzaTratta);
            Assert.AreEqual(5, percorsoRisultanteMetropolitana.CostoTratta);

            //Il costo minore è del percorso della metropolitana quindi il primo elemento dei percorsi risultanti
            //deve essere il percorso della metro
            Assert.IsTrue(percorsiRisultanti[0].Codice == "percorsoConMetropolitana");
        }
    }
}
