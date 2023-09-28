using Database.Models;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class SaveSerieViewModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Debe colocar el nombre de la serie")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe colocar una imagen de portada")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Debe colocar el genero primario")]
        public int PrimaryGenreId { get; set; }
        public int SecondaryGenreId { get; set; }

        [Required(ErrorMessage = "Debe colocar el nombre de la productura")]
        public int ProducerId { get; set; }


        [Required(ErrorMessage = "Debe colocar el enlace de la serie")]
        public string VideoLink { get; set; }
    }
}
