using System;
using System.Collections.Generic;

#nullable disable

namespace DomainCore.Entites
{
    public partial class Transaction
    {
        public int NumBl { get; set; }
        public int Type { get; set; }
        public DateTime DateTr { get; set; }
        public decimal Montant { get; set; }

        public virtual BonDeLivraison NumBlNavigation { get; set; }
    }
}
