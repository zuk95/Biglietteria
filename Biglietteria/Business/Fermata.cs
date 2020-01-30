using System;
using System.Collections.Generic;
using System.Text;

namespace Biglietteria.Business
{
    public class Fermata
    {
        public string Nome { get; set; } = string.Empty;

        public string Codice { get; set; } = string.Empty;

        public int Distanza { get; set; } = -1;

        public Fermata(string nome,string codice,int distanza)
        {
            Nome = nome;
            Codice = codice;
            Distanza = distanza;
        }

    }
}
