using System;
using System.Collections.Generic;

#nullable disable

namespace DomainCore.Entites
{
    public partial class Avoir
    {
        public Avoir()
        {
            LigneAvoirs = new HashSet<LigneAvoir>();
        }

        public int Num { get; set; }
        public DateTime Date { get; set; }
        public int? ClientId { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<LigneAvoir> LigneAvoirs { get; set; }
    }
}
