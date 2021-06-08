using System;
using System.Collections.Generic;

#nullable disable

namespace DomainCore.Entites
{
    public partial class FactureAvoirFournisseur
    {
        public FactureAvoirFournisseur()
        {
            AvoirFournisseurs = new HashSet<AvoirFournisseur>();
        }

        public int Num { get; set; }
        public int NumFactureAvoirFourSurPage { get; set; }
        public int IdFournisseur { get; set; }
        public DateTime Date { get; set; }
        public int? NumFactureFournisseur { get; set; }

        public virtual Fournisseur IdFournisseurNavigation { get; set; }
        public virtual FactureFournisseur NumFactureFournisseurNavigation { get; set; }
        public virtual ICollection<AvoirFournisseur> AvoirFournisseurs { get; set; }
    }
}
