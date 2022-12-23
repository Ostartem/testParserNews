namespace NewsParser.Models
{
    public class News
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Site { get; set; }
        public DateTime ParseDate { get; set; }
        public DateTime NewsDate { get; set; }
        public string? NewsTime { get; set; }
    }
}
