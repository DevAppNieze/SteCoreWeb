using System;
using System.Collections.Generic;

#nullable disable

namespace DomainCore.Entites
{
    public partial class EcheanceDesFournisseur
    {
        public int Id { get; set; }
        public DateTime DateEcheance { get; set; }
        public long NumCheque { get; set; }
        public decimal Montant { get; set; }
        public int FournisseurId { get; set; }

        public virtual Fournisseur Fournisseur { get; set; }
    }
}
