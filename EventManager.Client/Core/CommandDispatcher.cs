namespace EventManager.Client.Core
{
    using EventManager.Client.Core.Commands;
    using EventManager.Service;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CommandDispatcher
    {
        public string DispatchCommand(string[] commandParameters)
        {
            string commandName = commandParameters[0];
            commandParameters = commandParameters.Skip(1).ToArray();
            string result = string.Empty;

            EventService eventService = new EventService();

            switch (commandName)
            {
                case "CreateEvent":
                    CreateEventCommand createEvent = new CreateEventCommand(eventService);
                    result = createEvent.Execute(commandParameters);
                    break;
                case "DeleteEvent":
                    DeleteEventCommand deleteEvent = new DeleteEventCommand(eventService);
                    result = deleteEvent.Execute(commandParameters);
                    break;
                case "EditEvent":
                    EditEventCommand editEvent = new EditEventCommand(eventService);
                    result = editEvent.Execute(commandParameters);
                    break;
                case "ListEvents":
                    ListEventsCommand listEvents = new ListEventsCommand(eventService);
                    result = listEvents.Execute(commandParameters);
                    break;
                case "Help":
                    HelpCommand help = new HelpCommand();
                    result = help.Execute(commandParameters);
                    break;
                case "Exit":
                    ExitCommand exit = new ExitCommand(eventService);
                    result = exit.Execute(commandParameters);
                    break;

                default:
                    result = $@"Command {commandName} does not exist. Type ""Help"" to check the available commands.";
                    break;
            }

            return result;
        }
    }
}
