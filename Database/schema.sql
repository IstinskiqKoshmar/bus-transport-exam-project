-- SQL schema for the BusTransport SQLite database

CREATE TABLE Cities (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Code TEXT NOT NULL UNIQUE,
    Name TEXT NOT NULL,
    CityName TEXT NOT NULL,
    Country TEXT NOT NULL,
    BusStation TEXT NOT NULL,
    IsActive INTEGER NOT NULL
);

CREATE TABLE Carriers (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    CompanyCode TEXT NOT NULL UNIQUE,
    Country TEXT NOT NULL,
    Phone TEXT NOT NULL,
    Website TEXT NOT NULL,
    IsActive INTEGER NOT NULL
);

CREATE TABLE Trips (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    TripCode TEXT NOT NULL,
    CarrierId INTEGER NOT NULL,
    DepartureCityId INTEGER NOT NULL,
    ArrivalCityId INTEGER NOT NULL,
    DepartureTime TEXT NOT NULL,
    ArrivalTime TEXT NOT NULL,
    Price NUMERIC NOT NULL,
    AvailableSeats INTEGER NOT NULL,
    HasIntermediateStops INTEGER NOT NULL,
    IntermediateStops TEXT NOT NULL,
    Status TEXT NOT NULL,
    Platform TEXT NOT NULL,
    BusNumber TEXT NOT NULL,
    FOREIGN KEY(CarrierId) REFERENCES Carriers(Id),
    FOREIGN KEY(DepartureCityId) REFERENCES Cities(Id),
    FOREIGN KEY(ArrivalCityId) REFERENCES Cities(Id)
);

CREATE TABLE Passengers (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    FullName TEXT NOT NULL,
    Email TEXT NOT NULL UNIQUE,
    Phone TEXT NOT NULL,
    DocumentNumber TEXT NOT NULL,
    City TEXT NOT NULL,
    BirthDate TEXT NOT NULL,
    CreatedAt TEXT NOT NULL
);

CREATE TABLE Tickets (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    TicketCode TEXT NOT NULL UNIQUE,
    PassengerId INTEGER NOT NULL,
    TripId INTEGER NOT NULL,
    PassengerCount INTEGER NOT NULL,
    SeatNumber TEXT NOT NULL,
    PaymentMethod TEXT NOT NULL,
    TicketDate TEXT NOT NULL,
    TotalPrice NUMERIC NOT NULL,
    Status TEXT NOT NULL,
    Notes TEXT NOT NULL,
    FOREIGN KEY(PassengerId) REFERENCES Passengers(Id),
    FOREIGN KEY(TripId) REFERENCES Trips(Id)
);

