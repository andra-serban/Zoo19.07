using System;
using System.Collections.Generic;

namespace Zoo19._07.Models
{
    public partial class Individ
    {
        public Individ()
        {
            Main = new HashSet<Main>();
            MainHistory = new HashSet<MainHistory>();
        }

        public int Id { get; set; }
        public int Idanimal { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }

        public virtual IndividImages IdNavigation { get; set; }
        public virtual Animal IdanimalNavigation { get; set; }
        public virtual ICollection<Main> Main { get; set; }
        public virtual ICollection<MainHistory> MainHistory { get; set; }
    }
}
