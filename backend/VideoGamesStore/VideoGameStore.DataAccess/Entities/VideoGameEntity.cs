namespace VideoGameStore.DataAccess.Entities
{
    public class VideoGameEntity
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Platform { get; set; }
        public string? Developer { get; set; }
        public decimal Price { get; set; }
    }
}
