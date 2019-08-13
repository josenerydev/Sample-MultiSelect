using System;
using System.ComponentModel.DataAnnotations;

namespace Sample_MultiSelect.Web.ViewModels
{
    public class CreateTeamViewModel
    {
        [Required]
        [Display(Name = "Team Name")]
        public string Name { get; set; }
    }

    public class EditTeamViewModel : CreateTeamViewModel
    {
        public Guid Id { get; set; }
    }
}