using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MessagingToolkit.Service.Common.Models.Mapping;

namespace MessagingToolkit.Service.Common.Models
{
    public partial class mainContext : DbContext
    {
        static mainContext()
        {
            Database.SetInitializer<mainContext>(null);
        }

        public mainContext()
            : base("Name=mainContext")
        {
        }

        public DbSet<AppConfig> AppConfigs { get; set; }
        public DbSet<Gateway> Gateways { get; set; }
        public DbSet<Incoming> Incomings { get; set; }
        public DbSet<Outgoing> Outgoings { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppConfigMap());
            modelBuilder.Configurations.Add(new GatewayMap());
            modelBuilder.Configurations.Add(new IncomingMap());
            modelBuilder.Configurations.Add(new OutgoingMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
