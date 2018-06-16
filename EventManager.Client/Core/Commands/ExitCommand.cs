namespace EventManager.Client.Core.Commands
{
    using EventManager.Service;
    using System;

    public class ExitCommand : BaseCommand
    {
        private readonly EventService eventService;

        public ExitCommand(EventService eventService)
        {
            this.eventService = eventService;
        }

        //Exit
        public override string Execute(string[] data)
        {
            Console.WriteLine("Good Bye!");
            Environment.Exit(0);

            return "Bye-bye!";
        }
    }
}
