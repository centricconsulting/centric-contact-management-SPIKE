using contact_management.web.Models;

namespace contact_management.web.Migrations
{
  using System;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.Linq;

  internal sealed class Configuration : DbMigrationsConfiguration<web.Models.ApplicationDbContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(web.Models.ApplicationDbContext context)
    {
      //  This method will be called after migrating to the latest version.

      //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
      //  to avoid creating duplicate seed data. E.g.
      //
      //    context.People.AddOrUpdate(
      //      p => p.FullName,
      //      new Person { FullName = "Andrew Peters" },
      //      new Person { FullName = "Brice Lambson" },
      //      new Person { FullName = "Rowan Miller" }
      //    );
      //

      var contact = new Contact
      {
        Id = Guid.NewGuid(),
        FirstName = "First",
        LastName = "Contact",
        Company = "CompanyA",
        Title = "Yes",
        WhenCreated = DateTime.UtcNow.AddDays(-7),
        WhenModified = DateTime.UtcNow
      };

      context.Contacts.AddOrUpdate(m => m.FirstName,
        contact,
        new Contact { Id = Guid.NewGuid(), FirstName = "ABC", LastName = "Man", Company = "CompanyA", WhenCreated = DateTime.UtcNow.AddDays(-7), Title = "CEO"},
        new Contact { Id = Guid.NewGuid(), FirstName = "DEF", LastName = "Smith", Company = "CompanyA", WhenCreated = DateTime.UtcNow.AddDays(-7), Title = "Developer" },
        new Contact { Id = Guid.NewGuid(), FirstName = "GHI", LastName = "Jones", Company = "CompanyB", WhenCreated = DateTime.UtcNow.AddDays(-7), Title = "Analyst" },
        new Contact { Id = Guid.NewGuid(), FirstName = "JKL", LastName = "James", Company = "CompanyB", WhenCreated = DateTime.UtcNow.AddDays(-7), Title = "Director" },
        new Contact { Id = Guid.NewGuid(), FirstName = "MNO", LastName = "Rogers", Company = "CompanyB", WhenCreated = DateTime.UtcNow.AddDays(-7), Title = "Account Manager" },
        new Contact { Id = Guid.NewGuid(), FirstName = "PQR", LastName = "Rip", Company = "CompanyC", WhenCreated = DateTime.UtcNow.AddDays(-7), Title = "Tester" },
        new Contact { Id = Guid.NewGuid(), FirstName = "STU", LastName = "Chair", Company = "CompanyC", WhenCreated = DateTime.UtcNow.AddDays(-7), Title = "IT Director" },
        new Contact { Id = Guid.NewGuid(), FirstName = "VWX", LastName = "Table", Company = "CompanyC", WhenCreated = DateTime.UtcNow.AddDays(-7), Title = "President" },
        new Contact { Id = Guid.NewGuid(), FirstName = "YZA", LastName = "Lounge", Company = "Other Company", WhenCreated = DateTime.UtcNow.AddDays(-7), Title = "El Presidente" }

      );

      contact = context.Contacts.Find(contact.Id);

      context.PhoneNumbers.AddOrUpdate(p => p.Number,
        new PhoneNumber { Id = Guid.NewGuid(), Number = "1118675309", ContactId = contact.Id, Description = "Jenny", Primary = true, WhenCreated = DateTime.UtcNow },
        new PhoneNumber { Id = Guid.NewGuid(), Number = "1112223333", ContactId = contact.Id, Description = "Work", Primary = false, WhenCreated = DateTime.UtcNow }
      );
    }
  }
}
