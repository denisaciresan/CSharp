using System.Text.Json;

public class JsonOperations
{
    private const string filePath = "C:\\Users\\ECIRESD20\\OneDrive - NTT DATA EMEAL\\Documentos\\TechTreck - NTT-2023-2024\\Csharp\\Udemy\\Ultimate Csharp Masterclass\\Exercises\\CookieCookbook\\CookieCookbook\\CookieCookbook\\recipes.json";
    List<List<int>> elementsInList;


    // Adds a new list of ingredient IDs (as part of a recipe)
    public void AddToFile(List<Ingredients> recipe)
    {
        EnsureJsonExists();

        List<int> newRecipeIds = new List<int>();

        foreach (var ingredient in recipe)
        {
            newRecipeIds.Add(ingredient.Id);
        }

        // Add the list of IDs to the list of recipes
        elementsInList.Add(newRecipeIds);

        // Serialize the updated list
        string jsonString = JsonSerializer.Serialize(elementsInList, new JsonSerializerOptions { WriteIndented = true });

        // Write the updated list to the file
        File.WriteAllText(filePath, jsonString);
    }

    // Displays the recipes from the file (only the IDs)
    public void ReadFile()
    {
        EnsureJsonExists();

        ShowItems viewRecipe = new ShowItems();

        for (int i = 0; i < elementsInList.Count; i++)
        {
            Console.WriteLine($"***** Recipe {i + 1} *****");
            foreach (int id in elementsInList[i])
            {
                viewRecipe.ShowElementsFromJson(id);
            }
            Console.WriteLine();
        }
    }

    public void EnsureJsonExists()
    {
        if (File.Exists(filePath) && !string.IsNullOrWhiteSpace(File.ReadAllText(filePath)))
        {
            // Read and deserialize the existing recipe list
            string jsonContent = File.ReadAllText(filePath);
            elementsInList = JsonSerializer.Deserialize<List<List<int>>>(jsonContent);
        }
        else
        {
            // Initialize a new list if the file doesn't exist or is empty
            elementsInList = new List<List<int>>();
        }
    }
}
