using System;

namespace contact_management.web.Models
{
  public interface ITrack
  {
    DateTime WhenCreated { get; set; }
    DateTime? WhenModified { get; set; }
  }
}