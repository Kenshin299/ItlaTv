using Database.Models;

namespace Application.ViewModels
{
    public class ProducerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Series>? Series { get; set; }
    }
}
