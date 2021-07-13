using System;
using System.Collections.Generic;

#nullable disable

namespace EwidencjaUrlopow.Model
{
    public partial class Kalendarz
    {
        public DateTime DzienRoku { get; set; }
        public bool DzienWolny { get; set; }

        internal List<Kalendarz> ToList()
        {
            throw new NotImplementedException();
        }
    }
}
