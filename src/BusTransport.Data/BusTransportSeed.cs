using BusTransport.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BusTransport.Data;

public static class BusTransportSeed
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>().HasData(
            new City { Id = 1, Code = "SOF", Name = "????????? ???????? ?????", CityName = "?????", Country = "????????", BusStation = "????????? ????????", IsActive = true },
            new City { Id = 2, Code = "PDV", Name = "???????? ?? ???????", CityName = "???????", Country = "????????", BusStation = "???????? ??", IsActive = true },
            new City { Id = 3, Code = "VAR", Name = "???????? ?????", CityName = "?????", Country = "????????", BusStation = "????????? ????????", IsActive = true },
            new City { Id = 4, Code = "BOJ", Name = "???????? ??????", CityName = "??????", Country = "????????", BusStation = "???????? ??", IsActive = true },
            new City { Id = 5, Code = "VTR", Name = "???????? ?????? ???????", CityName = "?????? ???????", Country = "????????", BusStation = "???????? ?????", IsActive = true },
            new City { Id = 6, Code = "RSE", Name = "???????? ????", CityName = "????", Country = "????????", BusStation = "????????? ????????", IsActive = true },
            new City { Id = 7, Code = "SZR", Name = "???????? ????? ??????", CityName = "????? ??????", Country = "????????", BusStation = "????????? ????????", IsActive = true },
            new City { Id = 8, Code = "BLG", Name = "???????? ???????????", CityName = "???????????", Country = "????????", BusStation = "???????? ???????????", IsActive = true });

        modelBuilder.Entity<Carrier>().HasData(
            new Carrier { Id = 1, Name = "?????? ???", CompanyCode = "HEB", Country = "????????", Phone = "+359 32 622 122", Website = "https://example.com/hebros", IsActive = true },
            new Carrier { Id = 2, Name = "????? ??????", CompanyCode = "UIV", Country = "????????", Phone = "+359 2 989 00 00", Website = "https://example.com/ivkoni", IsActive = true },
            new Carrier { Id = 3, Name = "?????-?", CompanyCode = "KAR", Country = "????????", Phone = "+359 2 945 55 44", Website = "https://example.com/karat", IsActive = true },
            new Carrier { Id = 4, Name = "???? ???", CompanyCode = "ARD", Country = "????????", Phone = "+359 36 611 223", Website = "https://example.com/arda", IsActive = true },
            new Carrier { Id = 5, Name = "???? ??????", CompanyCode = "ETA", Country = "????????", Phone = "+359 2 931 11 11", Website = "https://example.com/etap", IsActive = true },
            new Carrier { Id = 6, Name = "??????", CompanyCode = "BIO", Country = "????????", Phone = "+359 52 600 600", Website = "https://example.com/biomet", IsActive = true });

        modelBuilder.Entity<Trip>().HasData(
            new Trip { Id = 1, TripCode = "BUS-0800", CarrierId = 1, DepartureCityId = 2, ArrivalCityId = 1, DepartureTime = new(2026, 6, 25, 8, 0, 0), ArrivalTime = new(2026, 6, 25, 10, 30, 0), Price = 18, AvailableSeats = 31, HasIntermediateStops = false, IntermediateStops = "????", Status = "?? ??????????", Platform = "A1", BusNumber = "PB-4321" },
            new Trip { Id = 2, TripCode = "BUS-1230", CarrierId = 2, DepartureCityId = 2, ArrivalCityId = 1, DepartureTime = new(2026, 6, 25, 12, 30, 0), ArrivalTime = new(2026, 6, 25, 15, 0, 0), Price = 20, AvailableSeats = 18, HasIntermediateStops = true, IntermediateStops = "?????????", Status = "?? ??????????", Platform = "B2", BusNumber = "CB-7724" },
            new Trip { Id = 3, TripCode = "BUS-1800", CarrierId = 3, DepartureCityId = 2, ArrivalCityId = 1, DepartureTime = new(2026, 6, 25, 18, 0, 0), ArrivalTime = new(2026, 6, 25, 20, 20, 0), Price = 19, AvailableSeats = 24, HasIntermediateStops = false, IntermediateStops = "????", Status = "?? ??????????", Platform = "C3", BusNumber = "CB-1908" },
            new Trip { Id = 4, TripCode = "BUS-0715", CarrierId = 6, DepartureCityId = 1, ArrivalCityId = 3, DepartureTime = new(2026, 6, 26, 7, 15, 0), ArrivalTime = new(2026, 6, 26, 13, 25, 0), Price = 36, AvailableSeats = 40, HasIntermediateStops = true, IntermediateStops = "?????? ???????, ?????", Status = "?? ??????????", Platform = "A4", BusNumber = "CB-8650" },
            new Trip { Id = 5, TripCode = "BUS-0945", CarrierId = 4, DepartureCityId = 1, ArrivalCityId = 4, DepartureTime = new(2026, 6, 26, 9, 45, 0), ArrivalTime = new(2026, 6, 26, 15, 10, 0), Price = 34, AvailableSeats = 22, HasIntermediateStops = true, IntermediateStops = "????? ??????, ??????", Status = "????????", Platform = "B1", BusNumber = "CB-4455" },
            new Trip { Id = 6, TripCode = "BUS-1110", CarrierId = 5, DepartureCityId = 1, ArrivalCityId = 6, DepartureTime = new(2026, 6, 26, 11, 10, 0), ArrivalTime = new(2026, 6, 26, 16, 30, 0), Price = 32, AvailableSeats = 28, HasIntermediateStops = true, IntermediateStops = "??????, ????", Status = "?? ??????????", Platform = "D2", BusNumber = "CB-2660" },
            new Trip { Id = 7, TripCode = "BUS-1415", CarrierId = 2, DepartureCityId = 1, ArrivalCityId = 8, DepartureTime = new(2026, 6, 27, 14, 15, 0), ArrivalTime = new(2026, 6, 27, 16, 10, 0), Price = 17, AvailableSeats = 16, HasIntermediateStops = false, IntermediateStops = "????", Status = "?? ??????????", Platform = "A2", BusNumber = "CB-9007" },
            new Trip { Id = 8, TripCode = "BUS-1640", CarrierId = 1, DepartureCityId = 1, ArrivalCityId = 5, DepartureTime = new(2026, 6, 27, 16, 40, 0), ArrivalTime = new(2026, 6, 27, 20, 0, 0), Price = 25, AvailableSeats = 35, HasIntermediateStops = true, IntermediateStops = "?????????, ?????", Status = "?? ??????????", Platform = "C1", BusNumber = "CB-3004" },
            new Trip { Id = 9, TripCode = "BUS-0630", CarrierId = 3, DepartureCityId = 3, ArrivalCityId = 4, DepartureTime = new(2026, 6, 28, 6, 30, 0), ArrivalTime = new(2026, 6, 28, 9, 0, 0), Price = 21, AvailableSeats = 27, HasIntermediateStops = false, IntermediateStops = "????", Status = "??????????", Platform = "B5", BusNumber = "B-5122" },
            new Trip { Id = 10, TripCode = "BUS-1305", CarrierId = 6, DepartureCityId = 4, ArrivalCityId = 1, DepartureTime = new(2026, 6, 28, 13, 5, 0), ArrivalTime = new(2026, 6, 28, 18, 45, 0), Price = 35, AvailableSeats = 12, HasIntermediateStops = true, IntermediateStops = "??????, ????? ??????", Status = "?? ??????????", Platform = "A6", BusNumber = "A-7611" },
            new Trip { Id = 11, TripCode = "BUS-1720", CarrierId = 4, DepartureCityId = 7, ArrivalCityId = 2, DepartureTime = new(2026, 6, 29, 17, 20, 0), ArrivalTime = new(2026, 6, 29, 19, 0, 0), Price = 16, AvailableSeats = 19, HasIntermediateStops = false, IntermediateStops = "????", Status = "?? ??????????", Platform = "D1", BusNumber = "CT-3010" },
            new Trip { Id = 12, TripCode = "BUS-2015", CarrierId = 5, DepartureCityId = 6, ArrivalCityId = 1, DepartureTime = new(2026, 6, 29, 20, 15, 0), ArrivalTime = new(2026, 6, 30, 1, 30, 0), Price = 31, AvailableSeats = 30, HasIntermediateStops = true, IntermediateStops = "????, ??????", Status = "?? ??????????", Platform = "E3", BusNumber = "P-8081" });

        modelBuilder.Entity<Passenger>().HasData(
            new Passenger { Id = 1, FullName = "??????? ???????", Email = "bogomil@example.com", Phone = "+359 888 111 222", DocumentNumber = "BG100001", City = "?????", BirthDate = new(2008, 5, 14), CreatedAt = new(2026, 6, 1) },
            new Passenger { Id = 2, FullName = "???? ??????", Email = "ivan.petrov@example.com", Phone = "+359 888 222 333", DocumentNumber = "BG100002", City = "???????", BirthDate = new(1992, 11, 3), CreatedAt = new(2026, 6, 2) },
            new Passenger { Id = 3, FullName = "????? ?????????", Email = "maria.g@example.com", Phone = "+359 888 333 444", DocumentNumber = "BG100003", City = "?????", BirthDate = new(1997, 8, 22), CreatedAt = new(2026, 6, 4) },
            new Passenger { Id = 4, FullName = "????? ????????", Email = "elena.s@example.com", Phone = "+359 888 444 555", DocumentNumber = "BG100004", City = "??????", BirthDate = new(1990, 1, 28), CreatedAt = new(2026, 6, 6) },
            new Passenger { Id = 5, FullName = "?????? ???????", Email = "georgi.n@example.com", Phone = "+359 888 555 666", DocumentNumber = "BG100005", City = "????", BirthDate = new(1985, 6, 9), CreatedAt = new(2026, 6, 9) });

        modelBuilder.Entity<Ticket>().HasData(
            new Ticket { Id = 1, TicketCode = "BUS-T1001", PassengerId = 1, TripId = 1, PassengerCount = 1, SeatNumber = "12A", PaymentMethod = "?????", TicketDate = new(2026, 6, 15, 10, 20, 0), TotalPrice = 18, Status = "??????", Notes = "QR ?????" },
            new Ticket { Id = 2, TicketCode = "BUS-T1002", PassengerId = 2, TripId = 2, PassengerCount = 2, SeatNumber = "04A-04B", PaymentMethod = "? ????", TicketDate = new(2026, 6, 16, 12, 10, 0), TotalPrice = 40, Status = "??????????", Notes = "??????? ?? ????" },
            new Ticket { Id = 3, TicketCode = "BUS-T1003", PassengerId = 3, TripId = 4, PassengerCount = 1, SeatNumber = "08C", PaymentMethod = "?????", TicketDate = new(2026, 6, 17, 9, 45, 0), TotalPrice = 36, Status = "??????", Notes = "????? ?? ????????" },
            new Ticket { Id = 4, TicketCode = "BUS-T1004", PassengerId = 4, TripId = 5, PassengerCount = 1, SeatNumber = "15B", PaymentMethod = "?????", TicketDate = new(2026, 6, 18, 17, 30, 0), TotalPrice = 34, Status = "??????", Notes = "? ??????? ?????" },
            new Ticket { Id = 5, TicketCode = "BUS-T1005", PassengerId = 5, TripId = 6, PassengerCount = 1, SeatNumber = "10A", PaymentMethod = "??????", TicketDate = new(2026, 6, 19, 8, 15, 0), TotalPrice = 32, Status = "?????????", Notes = "?????????? ?????" },
            new Ticket { Id = 6, TicketCode = "BUS-T1006", PassengerId = 1, TripId = 8, PassengerCount = 1, SeatNumber = "06D", PaymentMethod = "?????", TicketDate = new(2026, 6, 20, 14, 0, 0), TotalPrice = 25, Status = "??????", Notes = "?????????? ????????" });
    }
}
