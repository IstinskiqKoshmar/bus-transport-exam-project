using System.ComponentModel.DataAnnotations;

namespace BusTransport.Core.Models;

public class City
{
    [Required] public int Id { get; set; }
    [Required, StringLength(5)] public string Code { get; set; } = string.Empty;
    [Required, StringLength(100)] public string Name { get; set; } = string.Empty;
    [Required, StringLength(70)] public string CityName { get; set; } = string.Empty;
    [Required, StringLength(70)] public string Country { get; set; } = string.Empty;
    [Required, StringLength(80)] public string BusStation { get; set; } = string.Empty;
    [Required] public bool IsActive { get; set; }
}


