using System;
using System.Collections.Generic;

#nullable disable

namespace DomainCore.Entites
{
    public partial class BonDeLivraison
    {
        public BonDeLivraison()
        {
            LigneBls = new HashSet<LigneBl>();
        }

        public int Num { get; set; }
        public DateTime Date { get; set; }
        public decimal TotHTva { get; set; }
        public decimal TotTva { get; set; }
        public decimal NetPayer { get; set; }
        public TimeSpan TempBl { get; set; }
        public int? NumFacture { get; set; }
        public int? ClientId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Facture NumFactureNavigation { get; set; }
        public virtual Transaction Transaction { get; set; }
        public virtual ICollection<LigneBl> LigneBls { get; set; }
    }
}
