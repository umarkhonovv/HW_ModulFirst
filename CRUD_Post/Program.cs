using CRUD_Post.Models;
using CRUD_Post.Services;
using CRUD_Post.Servicesl;

namespace CRUD_Post
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public void RunFrontEndEvent()
        {

            var eventService = new EventService();

            while (true)
            {
                Console.WriteLine("1.Add");
                Console.WriteLine("2.Delete");
                Console.WriteLine("3.Update");
                Console.WriteLine("4.Show the event");
                Console.WriteLine("5.Show all events");
                Console.WriteLine("6.Show events by location");
                Console.WriteLine("7.Show the popular event");
                Console.WriteLine("8.Show max tagged event");
                Console.WriteLine("9.Add person to event");

                var option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    var firstEvent = new Event();

                    Console.WriteLine("Write the title of the event :");
                    firstEvent.Title = Console.ReadLine();
                    Console.WriteLine("Write the location of the event :");
                    firstEvent.Location = Console.ReadLine();
                    firstEvent.Date = new DateTime();
                    Console.WriteLine("Write description");
                    firstEvent.Description = Console.ReadLine();
                    Console.WriteLine("Write the amount of attendees");
                    var count = int.Parse(Console.ReadLine());
                    Console.WriteLine("Write the attendees");
                    for (var i = 0; i < count; i++)
                    {
                        Console.Write(": ");
                        var attendee = Console.ReadLine();
                        firstEvent.Attendees.Add(attendee);
                    }
                    Console.WriteLine("Write the amount of tags");
                    var amountOfTags = int.Parse(Console.ReadLine());
                    Console.WriteLine("Write the tag");
                    for (var i = 0; i < amountOfTags; i++)
                    {
                        Console.Write(": ");
                        var tag = Console.ReadLine();
                        firstEvent.Tags.Add(tag);
                    }
                    eventService.Add(firstEvent);
                    Console.Write("The evvent succesfully added to the list of events");
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter the id to delete");
                    var eventId = Guid.Parse(Console.ReadLine());
                    var result = eventService.Delete(eventId);
                    if (result is true)
                    {
                        Console.WriteLine("The event succesfully deleted");
                    }
                    else
                    {
                        Console.WriteLine("There is no such event in the list of events");
                    }
                }
                else if (option == 3)
                {
                    var updatedEvent = new Event();
                    Console.WriteLine("Write the id of the event that you want to update");
                    var id = Guid.Parse(Console.ReadLine());
                    Console.WriteLine("Write the title of the event :");
                    updatedEvent.Title = Console.ReadLine();
                    Console.WriteLine("Write the location of the event :");
                    updatedEvent.Location = Console.ReadLine();
                    updatedEvent.Date = new DateTime();
                    Console.WriteLine("Write description");
                    updatedEvent.Description = Console.ReadLine();
                    Console.WriteLine("Write the amount of attendees");
                    var count = int.Parse(Console.ReadLine());
                    Console.WriteLine("Write the attendees");
                    for (var i = 0; i < count; i++)
                    {
                        Console.Write(": ");
                        var attendee = Console.ReadLine();
                        updatedEvent.Attendees.Add(attendee);
                    }
                    Console.WriteLine("Write the amount of tags");
                    var amountOfTags = int.Parse(Console.ReadLine());
                    Console.WriteLine("Write the tag");
                    for (var i = 0; i < amountOfTags; i++)
                    {
                        Console.Write(": ");
                        var tag = Console.ReadLine();
                        updatedEvent.Tags.Add(tag);
                    }

                    var result = eventService.Update(id, updatedEvent);
                    if (result is true)
                    {
                        Console.WriteLine("The event succesfully updated");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong!");
                    }
                }
                else if (option == 4)
                {
                    Console.WriteLine("Write the id");
                    var id = Guid.Parse(Console.ReadLine());
                    var result = eventService.GetById(id);
                    if (result is null)
                    {
                        Console.WriteLine("There is no such event in the list of events");
                    }
                    else
                    {
                        Console.WriteLine(result);
                    }
                }
                else if (option == 5)
                {
                    var result = eventService.GetEvents;
                    Console.WriteLine(result);
                }
                else if (option == 6)
                {
                    Console.WriteLine("Write the location");
                    var location = Console.ReadLine();
                    var result = eventService.GetEventsByLocation(location);
                    Console.WriteLine(result);
                }
                else if (option == 7)
                {
                    var result = eventService.GetPopularEvent;
                    Console.WriteLine(result);
                }
                else if (option == 8)
                {
                    var result = eventService.GetMaxTaggedEvent;
                    Console.WriteLine(result);
                }
                else if (option == 9)
                {
                    Console.WriteLine("Write id of the event that you want add a person");
                    var id = Guid.Parse(Console.ReadLine());
                    Console.WriteLine("Write person name");
                    var name = Console.ReadLine();
                    var result = eventService.GetById(id);
                    if (result is null)
                    {
                        Console.WriteLine("There is no such event in the list of events");
                    }
                    else
                    {
                        result.Attendees.Add(name);
                        Console.WriteLine("The person succesfully added");
                    }
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void RunFrontendPost()
        {
            var postService = new PostServices();

            while (true)
            {
                Console.WriteLine("1.Add");
                Console.WriteLine("2.Delete");
                Console.WriteLine("3.Update");
                Console.WriteLine("4.Show the post");
                Console.WriteLine("5.Show posts");
                Console.WriteLine("6.Show the most viewed post");
                Console.WriteLine("7.Show the most liked post");
                Console.WriteLine("8.Show the most commented post");
                Console.WriteLine("9.Show posts by comment");
                Console.WriteLine("10.Add viewer name");
                Console.WriteLine("11.Add comment");
                Console.WriteLine("12.Add like");

                var option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    var firstPost = new Post();

                    Console.WriteLine("Write the owner name :");
                    firstPost.OwnerName = Console.ReadLine();
                    Console.WriteLine("Write the type");
                    firstPost.Type = Console.ReadLine();
                    Console.WriteLine("Write the description");
                    firstPost.Description = Console.ReadLine();
                    Console.WriteLine("Write the amount of likes");
                    firstPost.QuantityLinkes = int.Parse(Console.ReadLine());
                    Console.WriteLine("Write the amount of comments");
                    var amountOfComments = int.Parse(Console.ReadLine());
                    for (var i = 0; i < amountOfComments; i++)
                    {
                        Console.WriteLine(": ");
                        var comment = Console.ReadLine();
                        firstPost.Comments.Add(comment);
                    }
                    Console.WriteLine("Write the amount of iewer names");
                    var amountOfViewerNames = int.Parse(Console.ReadLine());
                    for (var i = 0; i < amountOfViewerNames; i++)
                    {
                        Console.WriteLine(": ");
                        var viewerName = Console.ReadLine();
                        firstPost.ViewerNames.Add(viewerName);
                    }
                    postService.AddPost(firstPost);
                    Console.Write("The post succesfully added to the list of posts");
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter the id :");
                    var id = Guid.Parse(Console.ReadLine());
                    var result = postService.Delete(id);
                    if (result is true)
                    {
                        Console.WriteLine("The post succesfully deleted");
                    }
                    else
                    {
                        Console.WriteLine("There is no such post in the list of post");
                    }
                }
                else if (option == 3)
                {
                    var updatedPost = new Post();
                    Console.WriteLine("Enter the id of the post that you want to update");
                    var id = Guid.Parse(Console.ReadLine());
                    Console.WriteLine("Write the owner name :");
                    updatedPost.OwnerName = Console.ReadLine();
                    Console.WriteLine("Write the type");
                    updatedPost.Type = Console.ReadLine();
                    Console.WriteLine("Write the description");
                    updatedPost.Description = Console.ReadLine();
                    Console.WriteLine("Write the amount of likes");
                    updatedPost.QuantityLinkes = int.Parse(Console.ReadLine());
                    Console.WriteLine("Write the amount of comments");
                    var amountOfComments = int.Parse(Console.ReadLine());
                    for (var i = 0; i < amountOfComments; i++)
                    {
                        Console.WriteLine(": ");
                        var comment = Console.ReadLine();
                        updatedPost.Comments.Add(comment);
                    }
                    Console.WriteLine("Write the amount of iewer names");
                    var amountOfViewerNames = int.Parse(Console.ReadLine());
                    for (var i = 0; i < amountOfViewerNames; i++)
                    {
                        Console.WriteLine(": ");
                        var viewerName = Console.ReadLine();
                        updatedPost.ViewerNames.Add(viewerName);
                    }
                    var result = postService.Update(updatedPost);

                    if (result is true)
                    {
                        Console.WriteLine("The post succesfully updated");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong!");
                    }
                }
                else if (option == 4)
                {
                    Console.WriteLine("Write the id of the post that you want to get");
                    var id = Guid.Parse(Console.ReadLine());
                    var result = postService.GetById(id);
                    if (result is null)
                    {
                        Console.WriteLine("There is no such post in the list of post");
                    }  
                    else
                    {
                        Console.WriteLine(result);
                    }
                }
            }
        }
    }
}
