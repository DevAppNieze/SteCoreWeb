using System;
using System.Collections.Generic;

#nullable disable

namespace DomainCore.Entites
{
    public partial class Devi
    {
        public Devi()
        {
            LigneDevis = new HashSet<LigneDevi>();
        }

        public int Num { get; set; }
        public int IdClient { get; set; }
        public DateTime Date { get; set; }
        public decimal TotHTva { get; set; }
        public decimal TotTva { get; set; }
        public decimal TotTtc { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual ICollection<LigneDevi> LigneDevis { get; set; }
    }
}
