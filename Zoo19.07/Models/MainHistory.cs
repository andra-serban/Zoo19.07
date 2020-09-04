using System;
using System.Collections.Generic;

namespace Zoo19._07.Models
{
    public partial class MainHistory
    {
        public string Anchor { get; set; }
        public int Idindivid { get; set; }
        public int Idzoo { get; set; }
        public string Data { get; set; }

        public virtual Individ Idindiv { get; set; }
        public virtual ZooInfo IdzooNavigation { get; set; }
    }
}
