using System;

namespace contact_management.web.Models
{
  public class Address : EntityBaseWithContact<Guid>, ICanBePrimary
  {
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public bool Primary { get; set; }
  }
}