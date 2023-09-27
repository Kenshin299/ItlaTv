using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Series
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        // Foreign key to Producer
        public int ProducerId { get; set; }

        // Navigation property to Producer
        public Producer Producer { get; set; } 

        public List<Genre> Genres { get; set; }
    }
}
