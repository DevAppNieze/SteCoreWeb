using System;
using System.Collections.Generic;

#nullable disable

namespace DomainCore.Entites
{
    public partial class BonDeReception
    {
        public BonDeReception()
        {
            LigneBonReceptions = new HashSet<LigneBonReception>();
        }

        public int Num { get; set; }
        public long NumBonFournisseur { get; set; }
        public DateTime DateLivraison { get; set; }
        public int IdFournisseur { get; set; }
        public DateTime Date { get; set; }
        public int? NumFactureFournisseur { get; set; }

        public virtual Fournisseur IdFournisseurNavigation { get; set; }
        public virtual FactureFournisseur NumFactureFournisseurNavigation { get; set; }
        public virtual ICollection<LigneBonReception> LigneBonReceptions { get; set; }
    }
}
