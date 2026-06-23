using BusTransport.Core.Models;
using BusTransport.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BusTransport.Web.Controllers;

public class TripsController(BusTransportDbContext db) : Controller
{
    public async Task<IActionResult> Index(string? status) { var q=db.Trips.Include(x=>x.Carrier).Include(x=>x.DepartureCity).Include(x=>x.ArrivalCity).AsQueryable(); if(!string.IsNullOrWhiteSpace(status)) q=q.Where(x=>x.Status==status); return View(await q.OrderBy(x=>x.DepartureTime).ToListAsync()); }
    public async Task<IActionResult> Details(int id) { var item=await Full().FirstOrDefaultAsync(x=>x.Id==id); return item is null?NotFound():View(item); }
    public async Task<IActionResult> Create() { await Lists(); return View(new Trip { DepartureTime=DateTime.Today.AddDays(7).AddHours(9), ArrivalTime=DateTime.Today.AddDays(7).AddHours(11), Status="По разписание", Platform="A1", BusNumber="CB-0000", IntermediateStops="Няма", AvailableSeats=48 }); }
    [HttpPost, ValidateAntiForgeryToken] public async Task<IActionResult> Create(Trip item) { ModelState.Remove(nameof(item.Carrier)); ModelState.Remove(nameof(item.DepartureCity)); ModelState.Remove(nameof(item.ArrivalCity)); if(!ModelState.IsValid){await Lists();return View(item);} db.Add(item); await db.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Edit(int id) { var item=await db.Trips.FindAsync(id); if(item is null)return NotFound(); await Lists(); return View(item); }
    [HttpPost, ValidateAntiForgeryToken] public async Task<IActionResult> Edit(int id, Trip item) { if(id!=item.Id)return NotFound(); ModelState.Remove(nameof(item.Carrier)); ModelState.Remove(nameof(item.DepartureCity)); ModelState.Remove(nameof(item.ArrivalCity)); if(!ModelState.IsValid){await Lists();return View(item);} db.Update(item); await db.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Delete(int id) { var item=await Full().FirstOrDefaultAsync(x=>x.Id==id); return item is null?NotFound():View(item); }
    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken] public async Task<IActionResult> DeleteConfirmed(int id) { var item=await db.Trips.FindAsync(id); if(item is not null){db.Remove(item);await db.SaveChangesAsync();} return RedirectToAction(nameof(Index)); }
    private IQueryable<Trip> Full()=>db.Trips.Include(x=>x.Carrier).Include(x=>x.DepartureCity).Include(x=>x.ArrivalCity);
    private async Task Lists(){ViewBag.CarrierId=new SelectList(await db.Carriers.ToListAsync(),"Id","Name");ViewBag.DepartureCityId=new SelectList(await db.Cities.ToListAsync(),"Id","Code");ViewBag.ArrivalCityId=new SelectList(await db.Cities.ToListAsync(),"Id","Code");}
}


