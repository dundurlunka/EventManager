namespace EventManager.Client.Core
{
    using Data;
    using System;
    using System.Data.Entity.Validation;

    public class Engine
    {
        private readonly CommandDispatcher commandDispatcher;

        public Engine(CommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
        }

        public void Run()
        {
            EventManagerContext context = new EventManagerContext();
            Console.WriteLine("Loading database. Please wait a moment");
            context.Database.Initialize(true);

            Console.WriteLine(@"You just started Daniel Georgiev's Event Manager. View the syntax of the commands by typing ""Help"" (without the quotation marks)");
            while (true)
            {
                try
                {
                    string input = Console.ReadLine().Trim();
                    string[] data = input.Split(' ');
                    string result = this.commandDispatcher.DispatchCommand(data);
                    Console.WriteLine(result);
                }
                catch (DbEntityValidationException validationException)
                {
                    foreach (var eve in validationException.EntityValidationErrors)
                    {
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("Error: {0}", ve.ErrorMessage);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
