// A class that has two methods for converting input to an integer or a double

public class ConvertingInput
{
    public int ConvertToInt(string message)
    {
        bool validInput = false;
        int result = 0;

        while (!validInput)
        {
            Console.WriteLine("=====================================");
            Console.WriteLine(message);
            string input = Console.ReadLine();

            try
            {
                result = Convert.ToInt32(input);
                validInput = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("The input format is invalid. Please enter a valid number.");
            }
        }
        return result;
    }

    public double ConvertToDouble(string message)
    {
        bool validInput = false;
        double result = 0;

        while (!validInput)
        {
            Console.WriteLine("=====================================");
            Console.WriteLine(message);
            string input = Console.ReadLine();

            try
            {
                result = (int)Convert.ToDouble(input);
                validInput = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("The input format is invalid. Please enter a valid number.");
            }
        }
        return result;
    }

}

