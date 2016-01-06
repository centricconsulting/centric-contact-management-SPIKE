using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using contact_management.web.Models;
using Microsoft.AspNet.Identity;

namespace contact_management.web.Controllers
{
  public class ContactsController : ApplicationControllerBase
  {
    // GET: Contacts
    public async Task<ActionResult> Index(string company = null)
    {
      var model = company == null
        ? new ContactListViewModel(await Db.Contacts.ToListAsync())
        : new ContactListViewModel(await Db.Contacts.Where(c => c.Company == company).ToListAsync());

      model.ForCompany = company;
      model.KnownContactIds = await GetUserKnownContacts();

      return View(model);
    }

    // GET: Contacts/Details/5
    public async Task<ActionResult> Details(Guid? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }

      var contact = await Db.Contacts
                            .Include(c => c.Addresses)
                            .Include(c => c.PhoneNumbers)
                            .Include(c => c.Notes)
                            .FirstOrDefaultAsync(c => c.Id == id);
      
      if (contact == null)
      {
        return HttpNotFound();
      }
      return View(contact);
    }

    // GET: Contacts/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Contacts/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,Company,Title,EmailAddress")] Contact contact)
    {
      if (ModelState.IsValid)
      {
        contact.WhenCreated = DateTime.UtcNow;
        contact.Id = Guid.NewGuid();
        contact.Notes = new List<Note>
        {
          new Note
          {
            Id = Guid.NewGuid(),
            Content = $"***** Record CREATED by {User.Identity.GetUserName()} *****",
            UserId = User.Identity.GetUserId(),
            WhenCreated = DateTime.UtcNow
          }
        };


        Db.Contacts.Add(contact);
        await Db.SaveChangesAsync();
        return RedirectToAction("Index");
      }

      return View(contact);
    }

    // GET: Contacts/Edit/5
    public async Task<ActionResult> Edit(Guid? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Contact contact = await Db.Contacts.FindAsync(id);
      if (contact == null)
      {
        return HttpNotFound();
      }
      return View(contact);
    }

    // POST: Contacts/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(Contact contact)
    {
      if (!ModelState.IsValid) return View(contact);

      var dbVersion = await Db.Contacts.FindAsync(contact.Id);
      if (dbVersion == null) { return HttpNotFound(); }

      dbVersion = contact.ApplyTo(dbVersion);
      dbVersion.WhenModified = DateTime.UtcNow;

      dbVersion.Notes.Add(
        new Note
        {
          Id = Guid.NewGuid(),
          Content = $"***** Record UPDATED by {User.Identity.GetUserName()} *****", 
          UserId = User.Identity.GetUserId(),
          WhenCreated = DateTime.UtcNow
        });

      Db.Entry(dbVersion).State = EntityState.Modified;
      await Db.SaveChangesAsync();
      return RedirectToAction("Index");
    }

    // GET: Contacts/Delete/5
    public async Task<ActionResult> Delete(Guid? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var contact = await Db.Contacts.FindAsync(id);
      if (contact == null)
      {
        return HttpNotFound();
      }
      return View(contact);
    }

    // POST: Contacts/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(Guid id)
    {
      Contact contact = await Db.Contacts.FindAsync(id);
      Db.Contacts.Remove(contact);
      await Db.SaveChangesAsync();
      return RedirectToAction("Index");
    }
  }
}
