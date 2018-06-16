namespace EventManager.Service
{
    using Data;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EventService
    {
        public void CreateEvent(string name, string location, DateTime startDate, DateTime endDate)
        {
            Event newEvent = new Event()
            {
                Name = name,
                Location = location,
                StartDate = startDate,
                EndDate = endDate
            };

            using(EventManagerContext context = new EventManagerContext())
            {
                context.Events.Add(newEvent);
                context.SaveChanges();
            }
        }

        public void DeleteEvent(string name)
        {            
            using(EventManagerContext context = new EventManagerContext())
            {
                Event eventToBeDeleted = this.GetEvent(name);
                context.Events.Attach(eventToBeDeleted);
                context.Events.Remove(eventToBeDeleted);

                context.SaveChanges();
            }
        }

        public void DeleteEvent(int id)
        {
            using (EventManagerContext context = new EventManagerContext())
            {
                Event eventToBeDeleted = this.GetEvent(id);
                context.Events.Attach(eventToBeDeleted);
                context.Events.Remove(eventToBeDeleted);

                context.SaveChanges();
            }
        }

        public void EditEvent(int id, string name, string location, DateTime startDate, DateTime endDate)
        {
            using (EventManagerContext context = new EventManagerContext())
            {
                Event eventToBeEdited = this.GetEvent(id);
                context.Events.Attach(eventToBeEdited);

                eventToBeEdited.Name = name;
                eventToBeEdited.Location = location;
                eventToBeEdited.StartDate = startDate;
                eventToBeEdited.EndDate = endDate;
                
                context.SaveChanges();
            }
        }

        public IEnumerable<Event> GetAll()
        {
            using (EventManagerContext context = new EventManagerContext())
            {
                return context.Events.ToList();
            }
        }

        public bool IsEventExistent(string name)
        {
            using (EventManagerContext context = new EventManagerContext())
            {
                return context.Events.Any(e => e.Name == name);
            }
        }

        public bool IsEventExistent(int id)
        {
            using (EventManagerContext context = new EventManagerContext())
            {
                return context.Events.Any(e => e.Id == id);
            }
        }

        public Event GetEvent(int id)
        {
            using (EventManagerContext context = new EventManagerContext())
            {
                return context.Events.First(e => e.Id == id);
            }
        }
        
        public Event GetEvent(string name)
        {
            using (EventManagerContext context = new EventManagerContext())
            {
                return context.Events.First(e => e.Name == name);
            }
        }
    }
}
