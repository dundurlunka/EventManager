namespace EventManager.Data
{
    using Data.Migrations;
    using Models;
    using System.Data.Entity;

    public class EventManagerContext : DbContext
    {
        public EventManagerContext()
            : base("name=EventManagerContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EventManagerContext, Configuration>());
        }

        public virtual DbSet<Event> Events { get; set; }
    }
}