namespace VideoGamesStore.Contracts
{
    public record VideoGamesResponse(Guid Id, string Title, string Platform, string Developer, decimal Price);
}
