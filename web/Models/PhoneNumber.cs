using System;

namespace contact_management.web.Models
{
  public class PhoneNumber : EntityBaseWithContact<Guid>, ICanBePrimary
  {
    public string Number { get; set; }
    public string Description { get; set; }
    public bool Primary { get; set; }
  }
}