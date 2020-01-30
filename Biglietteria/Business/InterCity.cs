using System;
using System.Collections.Generic;
using System.Text;

namespace Biglietteria.Business
{
    public class InterCity : Treno
    {
        readonly string inizialeCodice = "I";

        public InterCity(string codice) : base(codice) { }

        public override int GetCosto(int Km)
        {
            return Km * 10;
        }

        public override string SetInizialeCodice()
        {
            return inizialeCodice;
        }

    }
}
