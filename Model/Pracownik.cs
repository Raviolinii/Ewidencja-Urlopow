using System;
using System.Collections.Generic;

#nullable disable

namespace EwidencjaUrlopow.Model
{
    public partial class Pracownik
    {
        public Pracownik()
        {
            Urlops = new HashSet<Urlop>();
        }

        public int IdPracownika { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string StanowiskoPracy { get; set; }
        public int LataPracy { get; set; }
        public int? DostepnyUrlop { get; set; }

        public virtual ICollection<Urlop> Urlops { get; set; }
    }
}
