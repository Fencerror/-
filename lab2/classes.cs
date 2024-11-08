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
            // Реализация работы сотрудника
        }
    }

    public class LibraryStaff : Staff
    {
        public Staff Supervisor { get; set; }

        public void ServeReader()
        {
            // Реализация обслуживания читателя
        }

        public void ManageReadingRoom()
        {
            // Реализация управления читальным залом
        }

        // Метод readerService, соответствующий диаграмме последовательностей
        public BookCopy ReaderService(Service service, Reader reader)
        {
            // Шаг 1: Читатель получает идентификатор
            int readerId = service.GetID(reader);
            
            // Шаг 2: Отправка lib=a_staff (пропускаем для этой реализации)
            
            // Шаг 3: Анализ идентификации
            string idRes = IdentificationAnalysis(readerId.ToString());
            
            // Шаг 4: Получение предпочтений читателя
            Preferences preferences = GetReaderPreferences();
            
            // Шаг 5: Выполнение readerCheckUp для поиска новой копии книги
            BookCopy newBookCopy = ReaderCheckUp(reader, preferences, idRes);
            
            // Шаг 6: Если найдена новая копия книги, обновляем предпочтения
            if (newBookCopy != null)
            {
                UpdatePreferences(preferences);
            }
            
            return newBookCopy;
        }

        private string IdentificationAnalysis(string identification)
        {
            // Анализ идентификации
            return "id_res";
        }

        private Preferences GetReaderPreferences()
        {
            // Получение предпочтений читателя
            return new Preferences();
        }

        private BookCopy ReaderCheckUp(Reader reader, Preferences preferences, string idRes)
        {
            // Проверка предпочтений читателя и поиск новой копии книги
            return new BookCopy { Id = 101, Title = "Пример Названия Копии", Author = "Пример Автора" };
        }

        private void UpdatePreferences(Preferences preferences)
        {
            // Обновление предпочтений
            preferences.UpdateBookCopy("новая копия книги");
        }

        // Метод для проверки доступности книги, соответствующий диаграмме checkAvailability
        public bool CheckAvailability(List<Book> books)
        {
            // Получаем список копий книги
            List<BookCopy> copies = GetCopies();
            
            // Проходим по каждой копии
            foreach (var copy in copies)
            {
                // Проверяем, содержится ли копия в списке доступных книг
                if (books.Exists(b => b.Id == copy.Id))
                {
                    // Копия найдена, возвращаем true
                    return true;
                }
            }

            // Копия не найдена, возвращаем false
            return false;
        }

        // Получение списка копий книги
        public List<BookCopy> GetCopies()
        {
            // Логика получения копий книги
            return new List<BookCopy>();
        }

        // Метод для резервирования книги
        public Reservation BookReservation(int bookId, Reader reader)
        {
            // Выбор копии книги
            BookCopy bookCopy = chooseBookCopy(bookId);
            
            // Получение комнаты для бронирования
            Room room = getRoom();
            
            // Проверка доступности
            bool isAvailable = checkAvailability();
            
            if (isAvailable)
            {
                // Создание нового объекта бронирования
                Reservation reservation = new Reservation
                {
                    ReservationId = new Random().Next(1000, 9999),
                    Reservable = bookCopy,
                    Reader = reader,
                    ReservationDate = DateTime.Now,
                    Book = new Book { Id = bookId, Title = "Пример Названия", Author = "Пример Автора" },
                    Seat = new Seat { SeatNumber = 1, IsAvailable = true }
                };
                
                // Обновление запроса на бронирование
                updateReservationRequest(reservation, bookCopy);
                
                return reservation;
            }
            else
            {
                throw new Exception("Книга недоступна для бронирования.");
            }
        }

        private BookCopy chooseBookCopy(int bookId)
        {
            // Реализация логики выбора копии книги по идентификатору
            return new BookCopy { Id = bookId, Title = "Пример Названия", Author = "Пример Автора" };
        }

        private Room getRoom()
        {
            // Логика получения доступной комнаты
            return new ReadingRoom { Id = 1, Name = "Главный Читальный Зал", Capacity = 50 };
        }

        private bool checkAvailability()
        {
            // Логика проверки доступности копий книги
            return true;
        }

        private void updateReservationRequest(Reservation reservation, BookCopy bookCopy)
        {
            // Логика обновления запроса на бронирование
            Console.WriteLine($"Запрос на бронирование копии книги '{bookCopy.Title}' обновлен.");
        }
    }

    public class Service
    {
        public int GetID(Reader reader)
        {
            // Метод для получения идентификатора читателя
            return reader.Id;
        }
    }

    public class Book : IReservable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Reader ReservedBy { get; set; }
        public Category Category { get; set; } // Связь между книгой и категорией

        public void Reserve(Reader reader)
        {
            // Реализация резервирования
        }

        public void CancelReservation(Reader reader)
        {
            // Реализация отмены резервирования
        }

        public bool IsReserved()
        {
            return ReservedBy != null;
        }
    }

    public class BookCopy
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }

    public class Preferences
    {
        public void UpdateBookCopy(string bookCopy)
        {
            // Метод для обновления информации о предпочтениях читателя
            Console.WriteLine($"Обновлены предпочтения с новой копией книги: {bookCopy}");
        }
    }

    public class Reader
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Order PlaceOrder(Book book)
        {
            // Реализация размещения заказа
            return new Order();
        }

        public void CancelOrder(Order order)
        {
            // Реализация отмены заказа
        }
    }

    public interface IReservable
    {
        void Reserve(Reader reader);
        void CancelReservation(Reader reader);
        bool IsReserved();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader { Id = 1, Name = "Иван Иванов" };
            LibraryStaff libraryStaff = new LibraryStaff { Id = 101, Name = "Ольга Петрова" };
            Service service = new Service();
            
            // Вызов метода readerService
            BookCopy bookCopy = libraryStaff.ReaderService(service, reader);
            Console.WriteLine($"Новая копия книги: {bookCopy?.Title ?? "Копия не найдена"}");
        }
    }
}
