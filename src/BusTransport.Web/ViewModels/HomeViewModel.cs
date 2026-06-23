using BusTransport.Core.Models;

namespace BusTransport.Web.ViewModels;

public class HomeViewModel
{
    public IReadOnlyList<City> Cities { get; set; } = [];
    public IReadOnlyList<Carrier> Carriers { get; set; } = [];
    public IReadOnlyList<Trip> FeaturedTrips { get; set; } = [];
    public int TripCount { get; set; }
    public int TicketCount { get; set; }
}

public class SearchResultsViewModel
{
    public string From { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public DateTime? ReturnDate { get; set; }
    public int Passengers { get; set; }
    public string TripType { get; set; } = "oneway";
    public string Sort { get; set; } = "price";
    public int? CarrierId { get; set; }
    public bool DirectOnly { get; set; }
    public IReadOnlyList<Carrier> Carriers { get; set; } = [];
    public IReadOnlyList<Trip> OutboundTrips { get; set; } = [];
    public IReadOnlyList<Trip> ReturnTrips { get; set; } = [];
}

public class TicketRequestViewModel
{
    public int TripId { get; set; }
    public Trip Trip { get; set; } = null!;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string DocumentNumber { get; set; } = string.Empty;
    public string City { get; set; } = "София";
    public DateTime BirthDate { get; set; } = new(2000, 1, 1);
    public int PassengerCount { get; set; } = 1;
    public string SeatNumber { get; set; } = "12A";
    public string PaymentMethod { get; set; } = "Карта";
    public string Notes { get; set; } = "Електронен билет";
}


