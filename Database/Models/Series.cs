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
        public Producer? Producer { get; set; } 

        public ICollection<Genre>? Genres { get; set; }
        public ICollection<SeriesGenre>? SeriesGenres { get; set; }
        public string VideoLink { get; set; }
    }
}
