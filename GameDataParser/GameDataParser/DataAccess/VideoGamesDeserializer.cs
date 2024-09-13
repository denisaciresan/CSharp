using System.Text.Json;

public class VideoGamesDeserializer : IVideoGamesDeserializer
{
    private readonly IUserInterface _userInteractor;

    public VideoGamesDeserializer(IUserInterface userInteractor)
    {
        _userInteractor = userInteractor;
    }

    public List<VideoGame> DeserializeFrom(string FileName, string fileContent)
    {
        try
        {
            return JsonSerializer.Deserialize<List<VideoGame>>(fileContent);
        }
        catch (JsonException ex)
        {
            _userInteractor.PrintError($"JSON in the {FileName}  was not in a valid format. JSON body:");
            _userInteractor.PrintError(fileContent);

            throw new JsonException($"{ex.Message} The File is: {fileContent}", ex);
        }
    }
}
