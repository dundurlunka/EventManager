namespace EventManager.Client.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EventManager.Service;

    public class CreateEventCommand : BaseCommand
    {
        private readonly EventService eventService;

        public CreateEventCommand(EventService eventService)
        {
            this.eventService = eventService;
        }

        //CreateEvent <name> <location> <startDate> <endDate>
        public override string Execute(string[] data)
        {
            string name = data[0];
            string location = data[1];
            DateTime startDate = DateTime.Parse(data[2]);
            DateTime endDate = DateTime.Parse(data[3]);

            if (this.eventService.IsEventExistent(name))
            {
                throw new InvalidOperationException($"Event {name} already exists!");
            }

            this.eventService.CreateEvent(name, location, startDate, endDate);

            return $"Event {name} at {location} on {startDate.ToShortDateString()} was successfully created!";
        }
    }
}
