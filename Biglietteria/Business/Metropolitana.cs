using System;
using System.Collections.Generic;
using System.Text;

namespace Biglietteria.Business
{
    public class Metropolitana : Urbano
    {
        public Metropolitana(string codice) : base(codice) { }


        readonly string inizialeCodice = "M";
        public override int GetCosto(int Km)
        {
            return 5;
        }

        public override string SetInizialeCodice()
        {
            return inizialeCodice;
        }

    }
}
