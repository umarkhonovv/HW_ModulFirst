namespace CRUD_Post.Models;

public class Restaurant
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public double Rating { get; set; }
    public List<Dish> Dishes { get; set; } = new List<Dish>();
}
