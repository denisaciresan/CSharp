
public class ConsoleUserInteractor : IUserInterface
{
    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void PrintError(string message)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = originalColor;
    }

    public string ReadValidFilePath()
    {
        bool isFilePathValid = false;
        string FileName = default;

        do
        {
            Console.WriteLine("Enter the name of the file you want to read: ");
            FileName = Console.ReadLine();

            if (FileName is null)
            {
                Console.WriteLine($"File name cannot be null.");
            }
            else if (FileName == string.Empty)
            {
                Console.WriteLine("The file name cannot be empty.");
            }
            else if (!File.Exists(FileName))
            {
                Console.WriteLine("File not found.");
            }
            else
            {
                isFilePathValid = true;
            }
        }
        while (!isFilePathValid);
        return FileName;
    }
}