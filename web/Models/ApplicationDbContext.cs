using System.Data.Entity;
using System.Web.Compilation;
using Microsoft.AspNet.Identity.EntityFramework;

namespace contact_management.web.Models
{
  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<PhoneNumber> PhoneNumbers { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Note> Notes { get; set; } 

    public ApplicationDbContext() : base("CentricContactSpikeConnectionString", throwIfV1Schema: false) { }

    public static ApplicationDbContext Create() { return new ApplicationDbContext(); }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Contact>()
                  .HasMany<ApplicationUser>(s => s.KnownUsers)
                  .WithMany(c => c.KnownContacts)
                  .Map(cs =>
                  {
                    cs.MapLeftKey("ContactId");
                    cs.MapRightKey("ApplicationUserId");
                    cs.ToTable("Contacts_ApplicationUsers");
                  });

      base.OnModelCreating(modelBuilder);
    }
  }
}