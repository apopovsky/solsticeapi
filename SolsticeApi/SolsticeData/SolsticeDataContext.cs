namespace SolsticeData
{
    using System.Data.Entity;

    public class SolsticeDataContext : DbContext
    {
        // Your context has been configured to use a 'SolsticeDataContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SolsticeData.SolsticeDataContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SolsticeDataContext' 
        // connection string in the application configuration file.
        public SolsticeDataContext()
            : base("name=SolsticeDataContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SolsticeDataContext, Migrations.Configuration>());

        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasIndex(a => a.Email).IsUnique();
        }
    }
}