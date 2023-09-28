using Database.Models;

namespace Application.ViewModels
{
    public class SeriesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public ICollection<Genre>? Genres { get; set; }
        public Producer? Producer { get; set; }
        public string VideoLink { get; set; }
    }
}
