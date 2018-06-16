namespace EventManager.Client.Core.Commands
{
    using Service;
    using System;

    public class DeleteEventCommand : BaseCommand
    {
        private readonly EventService eventService;

        public DeleteEventCommand(EventService eventService)
        {
            this.eventService = eventService;
        }

        //DeleteEvent <id>
        //DeleteEvent <name>
        public override string Execute(string[] data)
        {
            string argumentByWhichToDelete = data[0];
            int.TryParse(argumentByWhichToDelete, out int eventId);
            bool isExistent = false;

            if (eventId == 0) //the argument is a name
            {
                isExistent = eventService.IsEventExistent(argumentByWhichToDelete);

                if (isExistent)
                {
                    this.eventService.DeleteEvent(argumentByWhichToDelete);

                    return $"Event {argumentByWhichToDelete} was deleted.";
                }

                return $"Event {argumentByWhichToDelete} does not exist.";
            }
            else
            {
                isExistent = eventService.IsEventExistent(eventId);

                if (isExistent)
                {
                    this.eventService.DeleteEvent(eventId);

                    return $"Event {eventId} was deleted.";
                }

                return $"Event {eventId} does not exist.";
            }
                
        }
    }
}
