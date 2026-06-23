using System.ComponentModel.DataAnnotations;

namespace BusTransport.Core.Models;

public class Ticket
{
    [Required] public int Id { get; set; }
    [Required, StringLength(18)] public string TicketCode { get; set; } = string.Empty;
    [Required] public int PassengerId { get; set; }
    [Required] public Passenger Passenger { get; set; } = null!;
    [Required] public int TripId { get; set; }
    [Required] public Trip Trip { get; set; } = null!;
    [Required, Range(1, 9)] public int PassengerCount { get; set; }
    [Required, StringLength(20)] public string SeatNumber { get; set; } = string.Empty;
    [Required, StringLength(25)] public string PaymentMethod { get; set; } = "Карта";
    [Required] public DateTime TicketDate { get; set; }
    [Required, Range(1, 100000)] public decimal TotalPrice { get; set; }
    [Required, StringLength(25)] public string Status { get; set; } = "Платен";
    [Required, StringLength(250)] public string Notes { get; set; } = "Електронен билет";
}


