using BusTransport.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusTransport.Web.Controllers;
public class CarriersController(BusTransportDbContext db):Controller
{
    public async Task<IActionResult> Index()=>View(await db.Carriers.OrderBy(x=>x.Name).ToListAsync());
}


