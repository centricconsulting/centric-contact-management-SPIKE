using System;

namespace contact_management.web.Models
{
  public abstract class EntityBaseWithContact<TKey> : EntityBase<TKey>
  {
    public Guid ContactId { get; set; }
    public virtual Contact Contact { get; set; }
  }
}