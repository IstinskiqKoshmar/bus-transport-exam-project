using BusTransport.Core.Models;
using BusTransport.Data;
using BusTransport.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusTransport.Tests;

public class TicketRepositoryTests
{
    private BusTransportDbContext context = null!;
    private IRepository<Ticket> repository = null!;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<BusTransportDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        context = new BusTransportDbContext(options);
        repository = new EfRepository<Ticket>(context);
    }

    private static Ticket NewTicket() => new() { TicketCode="TEST-001", PassengerId=1, TripId=1, PassengerCount=1, SeatNumber="12A", PaymentMethod="Карта", TicketDate=DateTime.Now, TotalPrice=100, Status="Платен", Notes="Тест" };

    [Test] public async Task Create_AddsTicket() { var item=await repository.AddAsync(NewTicket()); Assert.That(item.Id,Is.GreaterThan(0)); Assert.That(await context.Tickets.CountAsync(),Is.EqualTo(1)); }
    [Test] public async Task ReadById_ReturnsTicket() { var item=await repository.AddAsync(NewTicket()); var found=await repository.GetByIdAsync(item.Id); Assert.That(found?.TicketCode,Is.EqualTo("TEST-001")); }
    [Test] public async Task ReadAll_ReturnsAllTickets() { await repository.AddAsync(NewTicket()); var second=NewTicket();second.TicketCode="TEST-002";await repository.AddAsync(second); Assert.That((await repository.GetAllAsync()).Count,Is.EqualTo(2)); }
    [Test] public async Task Update_ChangesStatus() { var item=await repository.AddAsync(NewTicket());item.Status="Отменен";await repository.UpdateAsync(item);Assert.That((await repository.GetByIdAsync(item.Id))?.Status,Is.EqualTo("Отменен")); }
    [Test] public async Task Delete_RemovesTicket() { var item=await repository.AddAsync(NewTicket());await repository.DeleteAsync(item.Id);Assert.That(await repository.GetByIdAsync(item.Id),Is.Null); }

    [TearDown] public void Cleanup()=>context.Dispose();
}


