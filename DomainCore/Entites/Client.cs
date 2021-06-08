using System;
using System.Collections.Generic;

#nullable disable

namespace DomainCore.Entites
{
    public partial class Client
    {
        public Client()
        {
            Avoirs = new HashSet<Avoir>();
            BonDeLivraisons = new HashSet<BonDeLivraison>();
            Devis = new HashSet<Devi>();
            Factures = new HashSet<Facture>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Tel { get; set; }
        public string Adresse { get; set; }
        public string Matricule { get; set; }
        public string Code { get; set; }
        public string CodeCat { get; set; }
        public string EtbSec { get; set; }
        public string Mail { get; set; }

        public virtual ICollection<Avoir> Avoirs { get; set; }
        public virtual ICollection<BonDeLivraison> BonDeLivraisons { get; set; }
        public virtual ICollection<Devi> Devis { get; set; }
        public virtual ICollection<Facture> Factures { get; set; }
    }
}
