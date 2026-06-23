using System.ComponentModel.DataAnnotations;

namespace BusTransport.Core.Models;

public class Carrier
{
    [Required] public int Id { get; set; }
    [Required, StringLength(80)] public string Name { get; set; } = string.Empty;
    [Required, StringLength(8)] public string CompanyCode { get; set; } = string.Empty;
    [Required, StringLength(70)] public string Country { get; set; } = string.Empty;
    [Required, StringLength(30)] public string Phone { get; set; } = string.Empty;
    [Required, StringLength(120)] public string Website { get; set; } = string.Empty;
    [Required] public bool IsActive { get; set; }
}


