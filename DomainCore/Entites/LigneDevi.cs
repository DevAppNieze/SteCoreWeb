using System;
using System.Collections.Generic;

#nullable disable

namespace DomainCore.Entites
{
    public partial class LigneDevi
    {
        public int IdLi { get; set; }
        public int NumDevis { get; set; }
        public string RefProduit { get; set; }
        public string DesignationLi { get; set; }
        public int QteLi { get; set; }
        public decimal PrixHt { get; set; }
        public double Remise { get; set; }
        public decimal TotHt { get; set; }
        public double Tva { get; set; }
        public decimal TotTtc { get; set; }

        public virtual Devi NumDevisNavigation { get; set; }
        public virtual Produit RefProduitNavigation { get; set; }
    }
}
