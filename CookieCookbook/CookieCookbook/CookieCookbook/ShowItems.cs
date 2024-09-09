public class ShowItems : ListOfIngredients
{
    public void ShowElementsFromRecipe(List<Ingredients> recipe)
    {
        if (recipe.Count > 0)
        {
            for (int i = 0; i < recipe.Count; i++)
            {
                Console.WriteLine($"{recipe[i].Name}. {recipe[i].Preparation}");
            }
        }
        else
        {
            Console.WriteLine("No ingredients.");
        }
    }

    public void ShowElementsFromJson(int id)
    {
        Ingredients recipeFound = ingredients[0];
        bool recipeExists = false;

        for (int i = 0; i < ingredients.Count; i++)
        {
            if (id == ingredients[i].Id)
            {
                recipeFound = ingredients[i];
                recipeExists = true;
            }
        }
        if (recipeExists)
        {
            Console.WriteLine($"{recipeFound.Name}. {recipeFound.Preparation}");
        }
        else
        {
            Console.WriteLine("No ingredients.");
        }

    }

    public void ShowIngredients()
    {
        JsonOperations jsonOperations = new JsonOperations();
        jsonOperations.ReadFile();

        Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
        for (int i = 0; i < ingredients.Count; i++)
        {
            Console.WriteLine(ingredients[i].Id + ". " + ingredients[i].Name);
        }

    }
}
