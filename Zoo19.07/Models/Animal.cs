using System;
using System.Collections.Generic;

namespace Zoo19._07.Models
{
    public partial class Animal
    {
        public Animal()
        {
            Individ = new HashSet<Individ>();
        }

        public int Id { get; set; }
        public string CommonName { get; set; }
        public string Specie { get; set; }
        public int MaxWeight { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Individ> Individ { get; set; }
    }
}
