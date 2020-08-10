using System;
using System.Collections.Generic;

namespace Zoo.Models
{
    public partial class Individ
    {
        public int Id { get; set; }
        public int? Idanimal { get; set; }
        public string Nume { get; set; }
        public string Bio { get; set; }
    }
}
