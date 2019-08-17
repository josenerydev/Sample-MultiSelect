using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Sample_MultiSelect.Web.ViewModels
{
    public class CreatePlayerViewModel
    {
        [Required]
        [Display(Name = "Player Name")]
        [StringLength(128, ErrorMessage = "Player's name can only be 128 characters in length.")]
        public string Name { get; set; }

        public List<string> TeamIds { get; set; }

        [Display(Name = "Teams")]
        public MultiSelectList Teams { get; set; }
    }

    public class EditPlayerViewModel : CreatePlayerViewModel
    {
        public string Id { get; set; }
    }
}