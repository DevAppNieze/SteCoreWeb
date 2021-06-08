using System;
using System.Collections.Generic;

#nullable disable

namespace DomainCore.Entites
{
    public partial class FactureFournisseur
    {
        public FactureFournisseur()
        {
            BonDeReceptions = new HashSet<BonDeReception>();
            FactureAvoirFournisseurs = new HashSet<FactureAvoirFournisseur>();
        }

        public int Num { get; set; }
        public int IdFournisseur { get; set; }
        public bool Paye { get; set; }
        public long NumFactureFournisseur { get; set; }
        public DateTime DateFacturationFournisseur { get; set; }
        public DateTime Date { get; set; }

        public virtual Fournisseur IdFournisseurNavigation { get; set; }
        public virtual AvoirFinancierFournisseur AvoirFinancierFournisseur { get; set; }
        public virtual ICollection<BonDeReception> BonDeReceptions { get; set; }
        public virtual ICollection<FactureAvoirFournisseur> FactureAvoirFournisseurs { get; set; }
    }
}
