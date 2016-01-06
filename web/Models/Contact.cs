using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace contact_management.web.Models
{
  public class ContactListViewModel : List<Contact>
  {

    public ContactListViewModel()
    {
    }

    public ContactListViewModel(IReadOnlyCollection<Contact> collection) : base(collection)
    {
    }

    public string ForCompany { get; set; }
  }


  public class Contact : EntityBase<Guid>
  {
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    [Required] public string Company { get; set; }
    public string Title { get; set; }
    public string EmailAddress { get; set; }

    public virtual List<PhoneNumber> PhoneNumbers { get; set; }
    public virtual List<Address> Addresses { get; set; }
    public virtual List<Note> Notes { get; set; }

    public Contact ApplyTo(Contact contact)
    {
      contact.FirstName = FirstName;
      contact.LastName = LastName;
      contact.Company = Company;
      contact.Title = Title;
      contact.EmailAddress = EmailAddress;

      return contact;
    }
  }
}