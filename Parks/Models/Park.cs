using System.ComponentModel.DataAnnotations;

namespace Parks.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    [Required]
    public string Name { get; set; }
    public bool IsStatePark { get; set; }
    public bool IsNationalPark { get; set; }
    public int LocationId { get; set; }
  }
}