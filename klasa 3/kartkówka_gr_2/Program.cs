using System;
using System.Collections.Generic;

// Klasa bazowa dla osoby
public class Person
{
  public string FirstName { get; set; }
  public string LastName { get; set; }

  public Person(string firstName, string lastName)
  {
    FirstName = firstName;
    LastName = lastName;
  }
}

// Klasa reprezentująca gościa, dziedziczy po klasie Person
public class Guest : Person
{
    public List<Room> ReservedRoomsList { get; private set; }

    public Guest(string firstName, string lastName) : base(firstName, lastName)
    {
        ReservedRoomsList = new List<Room>();
    }

    public void ReserveRoom(Room room)
    {
        ReservedRoomsList.Add(room);
    }
}

// Klasa reprezentująca pokój
public class Room
{
  public int RoomNumber { get; set; }
  public string RoomType { get; set; }
  public decimal PricePerNight { get; set; }

  public Room(int roomNumber, string roomType, decimal pricePerNight)
  {
    RoomNumber = roomNumber;
    RoomType = roomType;
    PricePerNight = pricePerNight;
  }
}

// Klasa reprezentująca hotel
public class Hotel
{
    public List<Room> RoomsList { get; private set; }
    public List<Guest> GuestsList { get; private set; }
    public List<Room> ReservedRooms { get; private set; }

    public Hotel()
    {
        RoomsList = new List<Room>();
        GuestsList = new List<Guest>();
        ReservedRooms = new List<Room>();
    }
    public void AddRoom(Room room)
    {
        RoomsList.Add(room);
    }

    public void AddGuest(Guest guest)
    {
        GuestsList.Add(guest);
    }

    public void DisplayReservedRooms()
    {
        Console.WriteLine("Zarezerwowane pokoje:");
        foreach (var room in ReservedRooms)
        {
            Console.WriteLine($"Pokój {room.RoomNumber} ({room.RoomType})");
        }
    }

    public void DisplayGuests()
    {
        Console.WriteLine("Goście w hotelu:");
        foreach (var guest in GuestsList)
        {
            Console.WriteLine($"{guest.FirstName} {guest.LastName}");
        }
    }

    public void ReserveRoom(Guest guest, Room room)
    {
            guest.ReserveRoom(room);
            RoomsList.Remove(room);
            ReservedRooms.Add(room);
            Console.WriteLine($"Gość {guest.FirstName} {guest.LastName} zarezerwował pokój: {room.RoomNumber} ({room.RoomType})");
    }

    public void DisplayRooms()
    {
        Console.WriteLine("Pokoje w hotelu");
        foreach (var room in RoomsList)
        {
            Console.WriteLine($"Pokój {room.RoomNumber} - {room.RoomType} ({room.PricePerNight} PLN za noc)");
        }
    }
}
public class Program
{
    public static void Main()
    {
        Hotel hotel = new Hotel();

        // Dodawanie pokoi
        Room room1 = new Room(101, "Jednoosobowy", 200);
        Room room2 = new Room(102, "Dwuosobowy", 300);
        Room room3 = new Room(103, "Apartament", 500);
        hotel.AddRoom(room1);
        hotel.AddRoom(room2);
        hotel.AddRoom(room3);

        // Wyświetlanie pokoi przed rezerwacją
        hotel.DisplayRooms();
        Console.WriteLine();

        // Dodawanie gości
        Guest guest1 = new Guest("Jan", "Kowalski");
        Guest guest2 = new Guest("Anna", "Nowak");
        Guest guest3 = new Guest("Piotr", "Wiśniewski");
        hotel.AddGuest(guest1);
        hotel.AddGuest(guest2);
        hotel.AddGuest(guest3);

        // Rezerwowanie pokoi
        hotel.ReserveRoom(guest1, room1);
        hotel.ReserveRoom(guest2, room2);
        hotel.ReserveRoom(guest3, room3);
        Console.WriteLine();

        // Wyświetlanie informacji po rezerwacji
        hotel.DisplayGuests();
        Console.WriteLine();

        hotel.DisplayReservedRooms();
        Console.WriteLine();

        Console.ReadKey();
    }
}



