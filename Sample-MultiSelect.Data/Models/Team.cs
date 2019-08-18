using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sample_MultiSelect.Data.Models
{
    public class Team
    {
        public Team()
        {
            Players = new HashSet<Player>();
        }

        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Team Name")]
        [StringLength(128, ErrorMessage = "Team Name can only be 128 characters in length.")]
        public string Name { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}