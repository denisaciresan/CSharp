public class GameDataParserApp
{
    private readonly IUserInterface _userInteractor;
    private readonly IGamePrinter _gamesPrinter;
    private readonly IVideoGamesDeserializer _videoGamesDeserializer;
    private readonly IFileReader _fileReader;

    public GameDataParserApp(IUserInterface userInteractor, IGamePrinter gamesPrinter, IVideoGamesDeserializer videoGamesDeserializer, IFileReader fileReader)
    {
        _gamesPrinter = gamesPrinter;
        _userInteractor = userInteractor;
        _videoGamesDeserializer = videoGamesDeserializer;
        _fileReader = fileReader;
    }

    public void Run()
    {
        string fileName = _userInteractor.ReadValidFilePath();
        var fileContent = _fileReader.Read(fileName);
        var videoGames = _videoGamesDeserializer.DeserializeFrom(fileName, fileContent);
        _gamesPrinter.Print(videoGames);
    }
}
