using System;
using System.Collections.Generic;

#nullable disable

namespace DomainCore.Entites
{
    public partial class Fournisseur
    {
        public Fournisseur()
        {
            AvoirFournisseurs = new HashSet<AvoirFournisseur>();
            BonDeReceptions = new HashSet<BonDeReception>();
            Commandes = new HashSet<Commande>();
            EcheanceDesFournisseurs = new HashSet<EcheanceDesFournisseur>();
            FactureAvoirFournisseurs = new HashSet<FactureAvoirFournisseur>();
            FactureFournisseurs = new HashSet<FactureFournisseur>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Matricule { get; set; }
        public string Code { get; set; }
        public string CodeCat { get; set; }
        public string EtbSec { get; set; }
        public string Mail { get; set; }
        public string MailDeux { get; set; }
        public bool Constructeur { get; set; }
        public string Adresse { get; set; }

        public virtual ICollection<AvoirFournisseur> AvoirFournisseurs { get; set; }
        public virtual ICollection<BonDeReception> BonDeReceptions { get; set; }
        public virtual ICollection<Commande> Commandes { get; set; }
        public virtual ICollection<EcheanceDesFournisseur> EcheanceDesFournisseurs { get; set; }
        public virtual ICollection<FactureAvoirFournisseur> FactureAvoirFournisseurs { get; set; }
        public virtual ICollection<FactureFournisseur> FactureFournisseurs { get; set; }
    }
}
