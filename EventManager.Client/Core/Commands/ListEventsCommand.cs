namespace EventManager.Client.Core.Commands
{
    using EventManager.Client.Utilities;
    using EventManager.Models;
    using EventManager.Service;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ListEventsCommand : BaseCommand
    {
        private readonly EventService eventService;

        public ListEventsCommand(EventService eventService)
        {
            this.eventService = eventService;
        }

        public override string Execute(string[] data)
        {        
            var entities = eventService.GetAll();

            if (entities.Count() == 0)
            {
                return "There are no events registered!";
            }
            return ConsoleUtilities.DrawTable<Event>(entities);
        }
    }
}
