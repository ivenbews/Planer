namespace Planer.Domain
{
    public class Note
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
