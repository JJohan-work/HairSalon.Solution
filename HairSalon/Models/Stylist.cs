namespace HairSalon.Models
{
  public class Stylist
  {
    public int StylistId { get; set; }
    public string Name { get; set; }
    public string StartDate { get; set; }
    public int CustomerCount { get; set; }
    public string Notes { get; set; }
  }
}

// name, start date, number of customers