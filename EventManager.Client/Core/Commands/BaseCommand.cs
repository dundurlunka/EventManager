namespace EventManager.Client.Core.Commands
{
    using EventManager.Service;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class BaseCommand
    {
        public abstract string Execute(string[] data);
    }
}
