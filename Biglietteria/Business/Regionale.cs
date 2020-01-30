using System;
using System.Collections.Generic;
using System.Text;

namespace Biglietteria.Business
{
    public class Regionale : Treno
    {
        readonly string inizialeCodice = "R";

        public Regionale(string codice) : base(codice) { }

        public override int GetCosto(int Km)
        {
            return Km * 5;
        }

        public override string SetInizialeCodice()
        {
            return inizialeCodice;
        }
    }
}
