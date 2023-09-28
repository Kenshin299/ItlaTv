using Database.Models;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class SaveGenreViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar el nombre de la productura")]
        public string Name { get; set; }
    }
}
