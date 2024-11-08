using System;
using System.Collections.Generic;

namespace LibrarySystem
{
    public class Library
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }

        public void Work()
        {
            // Implementation of work
        }
    }

    public class LibraryStaff : Staff
    {
        public Staff Supervisor { get; set; }

        public void ServeReader()
        {
            // Implementation of serveReader
        }

        public void ManageReadingRoom()
        {
            // Implementation of manageReadingRoom
        }
    }

    public interface IReservable
    {
        void Reserve(Reader reader);
        void CancelReservation(Reader reader);
        bool IsReserved();
    }

    public class Book : IReservable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Reader ReservedBy { get; set; }

        public void Reserve(Reader reader)
        {
            // Implementation of reserve
        }

        public void CancelReservation(Reader reader)
        {
            // Implementation of cancelReservation
        }

        public bool IsReserved()
        {
            // Implementation of isReserved
            return ReservedBy != null;
        }
    }

    public class Category
    {
        public string Name { get; set; }
    }

    public class Reader
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Order PlaceOrder(Book book)
        {
            // Implementation of placeOrder
            return new Order();
        }

        public void CancelOrder(Order order)
        {
            // Implementation of cancelOrder
        }
    }

    public class Order
    {
        public int OrderNumber { get; set; }

        public void Confirm()
        {
            // Implementation of confirm
        }

        public void Cancel()
        {
            // Implementation of cancel
        }
    }

    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Open()
        {
            // Implementation of open
        }

        public void Close()
        {
            // Implementation of close
        }
    }

    public class ReadingRoom : Room
    {
        public int Capacity { get; set; }

        public void ReserveSeat(Reader reader)
        {
            // Implementation of reserveSeat
        }

        public void ReleaseSeat(Reader reader)
        {
            // Implementation of releaseSeat
        }

        public void ManageRoom()
        {
            // Implementation of manageRoom
        }
    }

    public class Seat : IReservable
    {
        public int SeatNumber { get; set; }
        public bool IsAvailable { get; set; }
        public Reader ReservedBy { get; set; }

        public void Reserve(Reader reader)
        {
            // Implementation of reserve
        }

        public void CancelReservation(Reader reader)
        {
            // Implementation of cancelReservation
        }

        public bool IsReserved()
        {
            // Implementation of isReserved
            return ReservedBy != null;
        }
    }

    public class Reservation
    {
        public int ReservationId { get; set; }
        public IReservable Reservable { get; set; }
        public Reader Reader { get; set; }
        public DateTime ReservationDate { get; set; }

        public void Confirm()
        {
            // Implementation of confirm
        }

        public void Cancel()
        {
            // Implementation of cancel
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Example usage
        }
    }
}
