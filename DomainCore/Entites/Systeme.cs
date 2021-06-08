using System;
using System.Collections.Generic;

#nullable disable

namespace DomainCore.Entites
{
    public partial class Systeme
    {
        public int Id { get; set; }
        public string NomSociete { get; set; }
        public decimal Timbre { get; set; }
        public string Adresse { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string MatriculeFiscale { get; set; }
        public string CodeTva { get; set; }
        public string CodeCategorie { get; set; }
        public string EtbSecondaire { get; set; }
        public decimal PourcentageFodec { get; set; }
        public string AdresseRetenu { get; set; }
        public double PourcentageRetenu { get; set; }
    }
}
