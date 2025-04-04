namespace VideoGameStore.Core.Models
{
    public class VideoGame
    {
        public const int MAX_TITLE_LENGTH = 250;

        private VideoGame() { }

        private VideoGame(Guid id, string title, string platform, string developer, decimal price)
        {
            Id = id;
            Title = title;
            Platform = platform;
            Developer = developer;
            Price = price;
        }

        public Guid Id { get; }
        public string? Title { get; }
        public string? Platform { get; }
        public string? Developer { get; }
        public decimal Price { get; }

        public static (VideoGame VideoGame, string Error) Create(Guid id, string title, string platform, string developer, decimal price)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                error = "Title can not be empty or longer then 250 symbols";
            }

            var videoGame = new VideoGame(id, title, platform, developer, price);

            return (videoGame, error);
        }
    }
}
