namespace contact_management.web.Models
{
  public interface IEntity<TKey>
  {
    TKey Id { get; set; }
  }
}