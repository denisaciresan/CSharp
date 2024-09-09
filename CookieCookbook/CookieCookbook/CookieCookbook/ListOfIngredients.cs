public class ListOfIngredients
{
    public List<Ingredients> ingredients;

    public ListOfIngredients()
    {
        ingredients = new List<Ingredients>()
        {
            new Ingredients(1, "Wheat flour", "Sieve. Add to other ingredients."),
            new Ingredients(2, "Coconut flour", "Sieve. Add to other ingredients."),
            new Ingredients(3, "Butter", "Melt on low heat. Add to other ingredients."),
            new Ingredients(4, "Chocolate", "Melt in a water bath. Add to other ingredients."),
            new Ingredients(5, "Sugar", "Add to other ingredients."),
            new Ingredients(6, "Cardamom", "Take half a teaspoon. Add to other ingredients."),
            new Ingredients(7, "Cinnamon", "Take half a teaspoon. Add to other ingredients."),
            new Ingredients(8, "Cocoa powder", "Add to other ingredients.")
        };
    }    
}
