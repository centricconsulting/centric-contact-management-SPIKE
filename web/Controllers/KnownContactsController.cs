using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using contact_management.web.Models;
using Microsoft.AspNet.Identity;

namespace contact_management.web.Controllers
{
  public class KnownContactsController : ApplicationApiControllerBase
  {
    [System.Web.Mvc.HttpGet]
    public async Task<List<Contact>> Get()
    {
      var id = User.Identity.GetUserId();
      var user = await Db.Users.Include(c => c.KnownContacts).FirstOrDefaultAsync(c => c.Id == id);
      var model = user.KnownContacts;

      return model;
    }

    [System.Web.Mvc.HttpPost]
    [ResponseType(typeof(Contact))]
    public async Task<IHttpActionResult> Toggle(Guid id)
    {
      var userId = User.Identity.GetUserId();

      if (userId == null) return Unauthorized();

      var contact = await Db.Contacts.FindAsync(id);

      if (contact == null) return NotFound(); 

      
      var user = await Db.Users.Include(c => c.KnownContacts).FirstOrDefaultAsync(c => c.Id == userId);

      var knownContactIds = user.KnownContacts.Select(c => c.Id);

      string knownDescriptor = "";
      if (knownContactIds.Contains(id))
      {
        user.KnownContacts.Remove(contact);
        knownDescriptor = "UNKNOWN";
      }
      else
      {
        user.KnownContacts.Add(contact);
        knownDescriptor = "KNOWN";
      }

      contact.Notes = new List<Note>
      {
        new Note
        {
          Id = Guid.NewGuid(),
          Content = $"***** Contact Marked {knownDescriptor} by {User.Identity.GetUserName()} *****",
          UserId = User.Identity.GetUserId(),
          WhenCreated = DateTime.UtcNow
        }
      };
      await Db.SaveChangesAsync();

      return CreatedAtRoute("DefaultApi", new { controller = "Contact", id = contact.Id }, contact);
    }
  }
}