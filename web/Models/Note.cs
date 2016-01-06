using System;

namespace contact_management.web.Models
{
  public class Note : EntityBaseWithContact<Guid>
  {
    public string Content { get; set; }
    public string UserId { get; set; }
    public bool IsSensitive { get; set; }
  }
}