public class Ingredients
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Preparation { get; set; }

    public Ingredients(int id, string name, string preparation)
    {
        Id = id;
        Name = name;
        Preparation = preparation;
    }
}