using Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SaveProducerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar el nombre de la productura")]
        public string Name { get; set; }
    }
}