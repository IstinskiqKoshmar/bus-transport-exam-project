using BusTransport.Core.Models;
using BusTransport.Data;
using BusTransport.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BusTransport.Web.Controllers;

public class TicketsController(BusTransportDbContext db) : Controller
{
    public async Task<IActionResult> Index(string? email)
    {
        var q=Full(); if(!string.IsNullOrWhiteSpace(email)) q=q.Where(x=>x.Passenger.Email==email);
        ViewBag.Email=email; return View(await q.OrderByDescending(x=>x.TicketDate).ToListAsync());
    }
    public async Task<IActionResult> Details(int id){var item=await Full().FirstOrDefaultAsync(x=>x.Id==id);return item is null?NotFound():View(item);}
    public async Task<IActionResult> Book(int tripId){var f=await db.Trips.Include(x=>x.Carrier).Include(x=>x.DepartureCity).Include(x=>x.ArrivalCity).FirstOrDefaultAsync(x=>x.Id==tripId);return f is null?NotFound():View(new TicketRequestViewModel{TripId=f.Id,Trip=f});}
    [HttpPost,ValidateAntiForgeryToken]
    public async Task<IActionResult> Book(TicketRequestViewModel model)
    {
        var trip=await db.Trips.Include(x=>x.Carrier).Include(x=>x.DepartureCity).Include(x=>x.ArrivalCity).FirstOrDefaultAsync(x=>x.Id==model.TripId);
        if(trip is null)return NotFound(); model.Trip=trip;
        if(string.IsNullOrWhiteSpace(model.FullName)||string.IsNullOrWhiteSpace(model.Email)||string.IsNullOrWhiteSpace(model.DocumentNumber)||model.PassengerCount<1){ModelState.AddModelError(string.Empty,"Попълнете всички задължителни данни.");return View(model);}
        if(trip.AvailableSeats<model.PassengerCount){ModelState.AddModelError(string.Empty,"Няма достатъчно свободни места.");return View(model);}
        var passenger=await db.Passengers.FirstOrDefaultAsync(x=>x.Email==model.Email);
        if(passenger is null){passenger=new Passenger{FullName=model.FullName,Email=model.Email,Phone=model.Phone,DocumentNumber=model.DocumentNumber,City=model.City,BirthDate=model.BirthDate,CreatedAt=DateTime.Now};db.Passengers.Add(passenger);await db.SaveChangesAsync();}
        var ticket=new Ticket{TicketCode=$"BUS-{DateTime.Now:MMddHHmm}",PassengerId=passenger.Id,TripId=trip.Id,PassengerCount=model.PassengerCount,SeatNumber=model.SeatNumber,PaymentMethod=model.PaymentMethod,TicketDate=DateTime.Now,TotalPrice=trip.Price*model.PassengerCount,Status="Платен",Notes=string.IsNullOrWhiteSpace(model.Notes)?"Електронен билет":model.Notes};
        trip.AvailableSeats-=model.PassengerCount;db.Tickets.Add(ticket);await db.SaveChangesAsync();return RedirectToAction(nameof(Confirmation),new{id=ticket.Id});
    }
    public async Task<IActionResult> Confirmation(int id){var item=await Full().FirstOrDefaultAsync(x=>x.Id==id);return item is null?NotFound():View(item);}
    public async Task<IActionResult> Create(){await Lists();return View(new Ticket{TicketCode=$"BUS-{DateTime.Now:MMddHHmm}",TicketDate=DateTime.Now,PassengerCount=1,SeatNumber="12A",PaymentMethod="Карта",Status="Платен",Notes="Електронен билет"});}
    [HttpPost,ValidateAntiForgeryToken]public async Task<IActionResult> Create(Ticket item){ModelState.Remove(nameof(item.Passenger));ModelState.Remove(nameof(item.Trip));var trip=await db.Trips.FindAsync(item.TripId);if(trip is not null)item.TotalPrice=trip.Price*item.PassengerCount;if(!ModelState.IsValid){await Lists();return View(item);}db.Add(item);await db.SaveChangesAsync();return RedirectToAction(nameof(Index));}
    public async Task<IActionResult> Edit(int id){var item=await db.Tickets.FindAsync(id);if(item is null)return NotFound();await Lists();return View(item);}
    [HttpPost,ValidateAntiForgeryToken]public async Task<IActionResult> Edit(int id,Ticket item){if(id!=item.Id)return NotFound();ModelState.Remove(nameof(item.Passenger));ModelState.Remove(nameof(item.Trip));if(!ModelState.IsValid){await Lists();return View(item);}db.Update(item);await db.SaveChangesAsync();return RedirectToAction(nameof(Index));}
    public async Task<IActionResult> Delete(int id){var item=await Full().FirstOrDefaultAsync(x=>x.Id==id);return item is null?NotFound():View(item);}
    [HttpPost,ActionName("Delete"),ValidateAntiForgeryToken]public async Task<IActionResult> DeleteConfirmed(int id){var item=await db.Tickets.FindAsync(id);if(item is not null){db.Remove(item);await db.SaveChangesAsync();}return RedirectToAction(nameof(Index));}
    private IQueryable<Ticket> Full()=>db.Tickets.Include(x=>x.Passenger).Include(x=>x.Trip).ThenInclude(x=>x.Carrier).Include(x=>x.Trip).ThenInclude(x=>x.DepartureCity).Include(x=>x.Trip).ThenInclude(x=>x.ArrivalCity);
    private async Task Lists(){ViewBag.PassengerId=new SelectList(await db.Passengers.ToListAsync(),"Id","FullName");ViewBag.TripId=new SelectList(await db.Trips.ToListAsync(),"Id","TripCode");}
}


