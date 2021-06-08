using System;
using System.Collections.Generic;

#nullable disable

namespace DomainCore.Entites
{
    public partial class AvoirFinancierFournisseur
    {
        public int Num { get; set; }
        public int NumSurPage { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal TotTtc { get; set; }

        public virtual FactureFournisseur NumNavigation { get; set; }
    }
}
