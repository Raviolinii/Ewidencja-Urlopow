using System;
using System.Collections.Generic;

#nullable disable

namespace EwidencjaUrlopow.Model
{
    public partial class Urlop
    {
        public int IdUrlopu { get; set; }
        public int? DniUrlopu { get; set; }
        public DateTime DataRozpoczeciaUrlopu { get; set; }
        public DateTime DataZakonczeniaUrlopu { get; set; }
        public string OpisUrlopu { get; set; }
        public int IdPracownika { get; set; }

        public virtual Pracownik IdPracownikaNavigation { get; set; }
    }
}
