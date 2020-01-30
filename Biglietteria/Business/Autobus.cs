using System;
using System.Collections.Generic;
using System.Text;

namespace Biglietteria.Business
{
    public class Autobus : Urbano
    {
        readonly string inizialeCodice = "A";

        public Autobus(string codice) : base(codice) { }

        public override int GetCosto(int Km)
        {
            return 10;
        }

        public override string SetInizialeCodice()
        {
            return inizialeCodice;
        }
    }
}
