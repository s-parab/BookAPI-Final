namespace BookAPI.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = String.Empty;

        public DateTime PublishDate { get; set; }
    }
}
