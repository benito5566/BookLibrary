using System;

namespace Domain
{
    public class Reservation
    {
        public Guid Id { get; private set; }
        public Book Book { get; private set; }
        public User User { get; private set; }
        public DateTime DateReserved { get; private set; }

        public Reservation(User user, Book book)
        {
            Id = Guid.NewGuid();
            DateReserved = DateTime.UtcNow;
            User = user;
            Book = book;
        }
    }
}
