namespace SolsticeData.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SolsticeData.SolsticeDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SolsticeData.SolsticeDataContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SolsticeData.SolsticeDataContext context)
        {
            if (!context.Contacts.Any())
            {
                context.Contacts.Add(new Contact
                {
                    Name = "Juan Perez",
                    Company = "Solstice",
                    Email = "juan@solstice.com",
                    PersonalPhoneNumber = "11-5555-5555",
                    WorkPhoneNumber = "11-5555-5555",
                    Address = new Address
                    {
                        Line1 = "120 23rd Street",
                        City = "Chicago",
                        Country = "USA"
                    }
                });
                context.Contacts.Add(new Contact
                {
                    Name = "Lola Juares",
                    Company = "Solstice",
                    Email = "lola@solstice.com",
                    PersonalPhoneNumber = "11-5555-5555",
                    WorkPhoneNumber = "11-5555-5555",
                    Address = new Address
                    {
                        Line1 = "120 23rd Street",
                        City = "Chicago",
                        Country = "USA"
                    }
                });
                context.SaveChanges();
            }
        }
    }
}
