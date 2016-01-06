using System;

namespace contact_management.web.Models
{
  public abstract class EntityBase<TKey> : IEntity<TKey>, ITrack
  {
    public TKey Id { get; set; }
    public DateTime WhenCreated { get; set; }
    public DateTime? WhenModified { get; set; }
  }
}