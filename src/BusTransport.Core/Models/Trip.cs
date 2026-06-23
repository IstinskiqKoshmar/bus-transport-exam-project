using System.ComponentModel.DataAnnotations;

namespace BusTransport.Core.Models;

public class Trip
{
    [Required] public int Id { get; set; }
    [Required, StringLength(12)] public string TripCode { get; set; } = string.Empty;
    [Required] public int CarrierId { get; set; }
    [Required] public Carrier Carrier { get; set; } = null!;
    [Required] public int DepartureCityId { get; set; }
    [Required] public City DepartureCity { get; set; } = null!;
    [Required] public int ArrivalCityId { get; set; }
    [Required] public City ArrivalCity { get; set; } = null!;
    [Required] public DateTime DepartureTime { get; set; }
    [Required] public DateTime ArrivalTime { get; set; }
    [Required, Range(1, 10000)] public decimal Price { get; set; }
    [Required, Range(0, 500)] public int AvailableSeats { get; set; }
    [Required] public bool HasIntermediateStops { get; set; }
    [Required, StringLength(120)] public string IntermediateStops { get; set; } = "Няма";
    [Required, StringLength(25)] public string Status { get; set; } = "По разписание";
    [Required, StringLength(10)] public string Platform { get; set; } = string.Empty;
    [Required, StringLength(20)] public string BusNumber { get; set; } = string.Empty;
    public TimeSpan Duration => ArrivalTime - DepartureTime;
}


