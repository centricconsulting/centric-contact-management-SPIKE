using System;
using System.Collections.Generic;

namespace contact_management.web.Models
{
  public class ContactListViewModel : List<Contact>
  {
    public ContactListViewModel()
    {
      KnownContactIds = new List<Guid>();
    }

    public ContactListViewModel(IReadOnlyCollection<Contact> collection) : base(collection)
    {
      KnownContactIds = new List<Guid>();
    }

    public string ForCompany { get; set; }
    public List<Guid> KnownContactIds { get; set; }
  }
}