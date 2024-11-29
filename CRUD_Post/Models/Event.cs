namespace CRUD_Post.Models;

public class Event
{
    public Guid Id { set; get; }
    public string Title { set; get; }
    public string Location { set; get; }
    public DateTime Date { set; get; }
    public string Description { set; get; }
    public List<string> Attendees { set; get; } = new List<string>();
    public List<string> Tags { set; get; } = new List<string>();

}
