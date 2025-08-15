namespace NewsAPI.Models
{
    public class Announcement
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
        public string CategoryId { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }

        public Guid Id { get; set; }

        public Announcement()
        {
            Title = "";
            Author = "";
            Description = "";
            Message = "";
            CategoryId = "General";
            ImageUrl = "";
            Category = "";
        }

    }
}
