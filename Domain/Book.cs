using System;

namespace Domain
{
    public class Book
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Editorial { get; private set; }
        public BookStatus Status { get; private set; }

        public Book(string name, string editorial)
        {
            Id = Guid.NewGuid();
            Name = name;
            Editorial = editorial;
            Status = BookStatus.Available;
        }

        public Reservation Reserve(User user)
        {
            if (Status == BookStatus.Available)
            {
                Status = BookStatus.Reserved;
            }
            else
            {
                throw new ApplicationException($"Book is not available. Book id: [{Id}]");
            }

            var reservation = new Reservation(user, this);
            var emailSender = new EmailSender();
            emailSender.SendReservationEmail(reservation);

            return reservation;
        }
    }
}