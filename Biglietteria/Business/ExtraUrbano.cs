using System;
using System.Collections.Generic;
using System.Text;

namespace Biglietteria.Business
{
    public abstract class ExtraUrbano : Mezzo
    {
        public ExtraUrbano(string codice) : base(codice) { }

    }
}
