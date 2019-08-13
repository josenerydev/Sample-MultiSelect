using System;
using System.Collections.Generic;

namespace Sample_MultiSelect.Data.Models
{
    public class Player
    {
        public Player()
        {
            Teams = new HashSet<Team>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
