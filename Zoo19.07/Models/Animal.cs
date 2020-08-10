using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Zoo.Models
{
    public partial class Animal
    {
        public int Id { get; set; }
        public string NumeComun { get; set; }
        public string Specie { get; set; }
        public int? GreutateMaxima { get; set; }
        public string Poza { get; set; }
    }
}
