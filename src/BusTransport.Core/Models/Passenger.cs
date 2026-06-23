using System.ComponentModel.DataAnnotations;

namespace BusTransport.Core.Models;

public class Passenger
{
    [Required] public int Id { get; set; }
    [Required, StringLength(100)] public string FullName { get; set; } = string.Empty;
    [Required, EmailAddress, StringLength(120)] public string Email { get; set; } = string.Empty;
    [Required, Phone, StringLength(30)] public string Phone { get; set; } = string.Empty;
    [Required, StringLength(20)] public string DocumentNumber { get; set; } = string.Empty;
    [Required, StringLength(70)] public string City { get; set; } = string.Empty;
    [Required] public DateTime BirthDate { get; set; }
    [Required] public DateTime CreatedAt { get; set; }
}


