using CRUD_Post.Models;

namespace CRUD_Post.Servicesl;

public class EventService
{
    private List<Event> events;

    public EventService()
    {
        events = new List<Event>();
    }

    public Event Add(Event newEwent)
    {
        newEwent.Id = Guid.NewGuid();
        events.Add(newEwent);

        return newEwent;
    }

    public Event GetById(Guid id)
    {
        foreach (Event anEvent in events)
        {
            if (anEvent.Id == id)
            {
                return anEvent;
            }
        }

        return null;
    }

    public bool Delete(Guid id)
    {
        var result = GetById(id);

        if (result is null)
        {
            return false;
        }

        return true;
    }

    public bool Update(Guid id, Event updatedEvent)
    {
        var result = GetById(id);

        if (result is null)
        {
            return false;
        }

        result = updatedEvent;

        return true;
    }

    public List<Event> GetEvents()
    {
        return events;
    }

    public List<Event> GetEventsByLocation(string location)
    {
        var listOfEventsByLocation = new List<Event>();

        foreach (Event anEvent in events)
        {
            if (anEvent.Location == location)
            {
                listOfEventsByLocation.Add(anEvent);
            }
        }

        return listOfEventsByLocation;
    }

    public Event GetPopularEvent()
    {
        var popularEvent = new Event();

        foreach (Event anEvent in events)
        {
            if (anEvent.Attendees.Count > popularEvent.Attendees.Count)
            {
                popularEvent = anEvent;
            }
        }

        return popularEvent;
    }

    public Event GetMaxTaggedEvent()
    {
        var maxTaggedEvent = new Event();

        foreach (Event anEvent in events)
        {
            if (anEvent.Tags.Count > maxTaggedEvent.Tags.Count)
            {
                maxTaggedEvent = anEvent;
            }
        }

        return maxTaggedEvent;
    }

    public bool AddPersonToEvent(Guid Id, string person)
    {
        var result = GetById(Id);

        if (result is null)
        {
            return false;
        }

        result.Attendees.Add(person);

        return true; 
    }
}
