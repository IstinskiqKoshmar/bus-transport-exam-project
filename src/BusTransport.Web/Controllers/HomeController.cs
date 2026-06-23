using BusTransport.Data;
using BusTransport.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusTransport.Web.Controllers;

public class HomeController(BusTransportDbContext db) : Controller
{
    public async Task<IActionResult> Index()
    {
        var model = new HomeViewModel
        {
            Cities = await db.Cities.OrderBy(x => x.CityName).ToListAsync(),
            Carriers = await db.Carriers.OrderBy(x => x.Name).ToListAsync(),
            FeaturedTrips = await db.Trips.Include(x => x.Carrier).Include(x => x.DepartureCity).Include(x => x.ArrivalCity).OrderBy(x => (double)x.Price).Take(5).ToListAsync(),
            TripCount = await db.Trips.CountAsync(), TicketCount = await db.Tickets.CountAsync()
        };
        return View(model);
    }

    public async Task<IActionResult> Search(string from, string to, DateTime date, DateTime? returnDate, int passengers = 1, string tripType = "oneway", string sort = "price", int? carrierId = null, bool directOnly = false)
    {
        var query = db.Trips.Include(x => x.Carrier).Include(x => x.DepartureCity).Include(x => x.ArrivalCity).AsQueryable();
        query = query.Where(x => (x.DepartureCity.Code == from || x.DepartureCity.CityName == from) && (x.ArrivalCity.Code == to || x.ArrivalCity.CityName == to) && x.DepartureTime.Date == date.Date && x.AvailableSeats >= passengers);
        if (carrierId.HasValue) query = query.Where(x => x.CarrierId == carrierId);
        if (directOnly) query = query.Where(x => !x.HasIntermediateStops);
        query = sort switch { "duration" => query.OrderBy(x => x.ArrivalTime).ThenByDescending(x => x.DepartureTime), "departure" => query.OrderBy(x => x.DepartureTime), _ => query.OrderBy(x => (double)x.Price) };
        var outbound = await query.ToListAsync();
        var returns = new List<Core.Models.Trip>();
        if (tripType == "roundtrip" && returnDate.HasValue)
        {
            var returnQuery = db.Trips.Include(x => x.Carrier).Include(x => x.DepartureCity).Include(x => x.ArrivalCity)
                .Where(x => (x.DepartureCity.Code == to || x.DepartureCity.CityName == to) && (x.ArrivalCity.Code == from || x.ArrivalCity.CityName == from) && x.DepartureTime.Date == returnDate.Value.Date && x.AvailableSeats >= passengers);
            if (carrierId.HasValue) returnQuery = returnQuery.Where(x => x.CarrierId == carrierId);
            if (directOnly) returnQuery = returnQuery.Where(x => !x.HasIntermediateStops);
            returns = await returnQuery.OrderBy(x => (double)x.Price).ToListAsync();
        }
        return View("SearchResults", new SearchResultsViewModel { From=from, To=to, Date=date, ReturnDate=returnDate, Passengers=passengers, TripType=tripType, Sort=sort, CarrierId=carrierId, DirectOnly=directOnly, Carriers=await db.Carriers.OrderBy(x=>x.Name).ToListAsync(), OutboundTrips=outbound, ReturnTrips=returns });
    }

    public IActionResult Error() => View();
}


