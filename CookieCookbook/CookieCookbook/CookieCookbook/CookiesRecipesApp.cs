using System.ComponentModel.Design;

public class CookiesRecipesApp : ListOfIngredients
{
    private JsonOperations jsonOperations = new JsonOperations();
    private List<Ingredients> recipe = new List<Ingredients>();
    private ShowItems viewRecipe = new ShowItems();

    public void Start()
    {
        viewRecipe.ShowIngredients();
        bool repeat = false;
        int attempts = 0;

        while (!repeat)
        {
            Console.WriteLine("Add an ingredient by its ID or type anything else if finished.");
            string input = Console.ReadLine();
            bool isInt = int.TryParse(input, out int index);
            if (isInt)
            {
                if (index > 0 && index <= 8)
                {
                    recipe.Add(new Ingredients(ingredients[index - 1].Id, ingredients[index - 1].Name, ingredients[index - 1].Preparation));
                }
                else
                {
                    Console.WriteLine("Invalid ingredient selected. Recipe will not be saved.");
                }
                attempts++;
            }
            else if (attempts > 0)
            {
                Console.WriteLine("Recipe added:");
                viewRecipe.ShowElementsFromRecipe(recipe);
                jsonOperations.AddToFile(recipe);
                Console.WriteLine("Press any key to exit.");
                repeat = true;
            }
            else if (attempts <= 0 || !isInt)
            {
                Console.WriteLine("Press any key to exit.");
                repeat = true;
            }
        }
    }
}
