using System;
using System.Collections.Generic;
using System.Text;

namespace Biglietteria.Business
{
    public abstract class Mezzo
    {
        public string Codice { get; set; } = string.Empty;

        public Mezzo(string codice)
        {
            Codice = SetInizialeCodice() + codice;
        }


        public abstract int GetCosto(int Km);

        public abstract string SetInizialeCodice();

    }
}
