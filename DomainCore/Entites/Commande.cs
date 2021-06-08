using System;
using System.Collections.Generic;

#nullable disable

namespace DomainCore.Entites
{
    public partial class Commande
    {
        public Commande()
        {
            LigneCommandes = new HashSet<LigneCommande>();
        }

        public int Num { get; set; }
        public DateTime Date { get; set; }
        public int? FournisseurId { get; set; }

        public virtual Fournisseur Fournisseur { get; set; }
        public virtual ICollection<LigneCommande> LigneCommandes { get; set; }
    }
}
