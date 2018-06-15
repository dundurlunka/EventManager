namespace EventManager.Client.Core.Commands
{
    using EventManager.Service;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class EditEventCommand : BaseCommand
    {
        private readonly EventService eventService;

        public EditEventCommand(EventService eventService)
        {
            this.eventService = eventService;
        }

        //EditEvent <id> <name> <location> <startDate> <endDate>
        public override string Execute(string[] data)
        {
            int id = int.Parse(data[0]);
            string name = data[1];
            string location = data[2];
            DateTime startDate = DateTime.Parse(data[3]);
            DateTime endDate = DateTime.Parse(data[4]);

            if (!this.eventService.IsEventExistent(id))
            {
                throw new InvalidOperationException($"Event with ID {id} does not exist.");
            }

            this.eventService.EditEvent(id, name, location, startDate, endDate);

            return $@"Event ""{name}"" was successfully edited!";
        }
    }
}
