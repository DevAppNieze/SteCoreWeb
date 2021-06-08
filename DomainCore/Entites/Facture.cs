using System;
using System.Collections.Generic;

#nullable disable

namespace DomainCore.Entites
{
    public partial class Facture
    {
        public Facture()
        {
            BonDeLivraisons = new HashSet<BonDeLivraison>();
        }

        public int Num { get; set; }
        public int IdClient { get; set; }
        public DateTime Date { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual ICollection<BonDeLivraison> BonDeLivraisons { get; set; }
    }
}
