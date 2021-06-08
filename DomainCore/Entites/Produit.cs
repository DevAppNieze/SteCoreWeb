using System;
using System.Collections.Generic;

#nullable disable

namespace DomainCore.Entites
{
    public partial class Produit
    {
        public Produit()
        {
            LigneAvoirFournisseurs = new HashSet<LigneAvoirFournisseur>();
            LigneAvoirs = new HashSet<LigneAvoir>();
            LigneBls = new HashSet<LigneBl>();
            LigneBonReceptions = new HashSet<LigneBonReception>();
            LigneCommandes = new HashSet<LigneCommande>();
            LigneDevis = new HashSet<LigneDevi>();
        }

        public string Refe { get; set; }
        public string Nom { get; set; }
        public int Qte { get; set; }
        public int QteLimite { get; set; }
        public double Remise { get; set; }
        public double RemiseAchat { get; set; }
        public double Tva { get; set; }
        public decimal Prix { get; set; }
        public decimal PrixAchat { get; set; }
        public bool Visibilite { get; set; }

        public virtual ICollection<LigneAvoirFournisseur> LigneAvoirFournisseurs { get; set; }
        public virtual ICollection<LigneAvoir> LigneAvoirs { get; set; }
        public virtual ICollection<LigneBl> LigneBls { get; set; }
        public virtual ICollection<LigneBonReception> LigneBonReceptions { get; set; }
        public virtual ICollection<LigneCommande> LigneCommandes { get; set; }
        public virtual ICollection<LigneDevi> LigneDevis { get; set; }
    }
}
