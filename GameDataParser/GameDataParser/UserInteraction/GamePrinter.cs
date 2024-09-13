public class GamePrinter : IGamePrinter
{
    private readonly IUserInterface _userInteractor;

    public GamePrinter(IUserInterface userInteractor)
    {
        _userInteractor = userInteractor;
    }

    public void Print(List<VideoGame> videoGames)
    {
        if (videoGames.Count > 0)
        {
            _userInteractor.PrintMessage(Environment.NewLine + "Loaded games are:");
            foreach (var game in videoGames)
            {
                _userInteractor.PrintMessage(game.ToString());
            }
        }
        else
        {
            _userInteractor.PrintMessage("No games are present in the input file.");
        }
    }
}
