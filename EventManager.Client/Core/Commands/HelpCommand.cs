namespace EventManager.Client.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HelpCommand : BaseCommand
    { 
        public override string Execute(string[] data)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Here you can find the needed information to operate with the program");
            sb.AppendLine("To create an event:");
            sb.AppendLine("- CreateEvent <name> <location> <startDate> <endDate>");
            sb.AppendLine("To edit an event:");
            sb.AppendLine("- EditEvent <id> <location> <startDate> <endDate>");
            sb.AppendLine("To delete an event:");
            sb.AppendLine("- DeleteEvent <id/name>");
            sb.AppendLine("To list all events:");
            sb.AppendLine("- ListEvents");
            sb.AppendLine("To exit");
            sb.AppendLine("- Exit");

            return sb.ToString().Trim();
        }
    }
}
