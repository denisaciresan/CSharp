public interface IVideoGamesDeserializer
{
    List<VideoGame> DeserializeFrom(string FileName, string fileContent);
}
