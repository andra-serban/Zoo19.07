using System;
using System.Collections.Generic;

namespace Zoo19._07.Models
{
    public partial class ZooInfo
    {
        public ZooInfo()
        {
            Main = new HashSet<Main>();
            MainHistory = new HashSet<MainHistory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

        public virtual ICollection<Main> Main { get; set; }
        public virtual ICollection<MainHistory> MainHistory { get; set; }
    }
}
