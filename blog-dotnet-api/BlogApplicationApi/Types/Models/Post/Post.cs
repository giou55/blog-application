namespace Types.Models.Post
{
    public class Post
    {
        public int? Id { get; set; }
        public string? Author { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; } = string.Empty;
    }
}