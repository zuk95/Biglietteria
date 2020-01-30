using System;
using System.Collections.Generic;
using System.Text;

namespace Biglietteria.Business
{
    public abstract class Treno : ExtraUrbano
    {
        public Treno(string codice) : base(codice) { }


    }
}
