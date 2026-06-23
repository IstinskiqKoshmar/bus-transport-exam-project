using BusTransport.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusTransport.Web.Controllers;
public class CitiesController(BusTransportDbContext db):Controller
{
    public async Task<IActionResult> Index()=>View(await db.Cities.OrderBy(x=>x.CityName).ToListAsync());
}


