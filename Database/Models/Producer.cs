namespace Database.Models
{
    public class Producer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Series>? Series { get; set; }
    }
}
