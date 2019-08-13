using System;
using System.Collections.Generic;

namespace Sample_MultiSelect.Data.Models
{
    public class Team
    {
        public Team()
        {
            Players = new HashSet<Player>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}