using System;
using System.Collections.Generic;

namespace Zoo19._07.Models
{
    public partial class IndividImages
    {
        public int Idindivid { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string Image5 { get; set; }
        public string Image6 { get; set; }
        public string Image7 { get; set; }
        public string Image8 { get; set; }
        public string Image9 { get; set; }
        public string Image10 { get; set; }
        public string Description { get; set; }

        public virtual Individ Individ { get; set; }
    }
}
