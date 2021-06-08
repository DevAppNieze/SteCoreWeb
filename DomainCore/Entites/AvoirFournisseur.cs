using System;
using System.Collections.Generic;

#nullable disable

namespace DomainCore.Entites
{
    public partial class AvoirFournisseur
    {
        public AvoirFournisseur()
        {
            LigneAvoirFournisseurs = new HashSet<LigneAvoirFournisseur>();
        }

        public int Num { get; set; }
        public DateTime Date { get; set; }
        public int? FournisseurId { get; set; }
        public int? NumFactureAvoirFournisseur { get; set; }
        public int NumAvoirFournisseur { get; set; }

        public virtual Fournisseur Fournisseur { get; set; }
        public virtual FactureAvoirFournisseur NumFactureAvoirFournisseurNavigation { get; set; }
        public virtual ICollection<LigneAvoirFournisseur> LigneAvoirFournisseurs { get; set; }
    }
}
