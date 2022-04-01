using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parks.Models
{
  public class Location
  {
    public Location()
    {
      this.Parks = new HashSet<Park>();
    }
    public int LocationId { get; set; }
    [Required]
    public string State { get; set; }
    public virtual ICollection<Park> Parks { get; set; }

  }
}