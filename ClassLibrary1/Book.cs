using System;

namespace Domain
{
    public class Book
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Editorial { get; private set; }
        public BookStatus Status { get; private set; }

        private readonly IEmailSender _emailSender;

        public Book(string name, string editorial, IEmailSender emailSender)
        {
            Id = Guid.NewGuid();
            Name = name;
            Editorial = editorial;
            Status = BookStatus.Available;
            _emailSender = emailSender;
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
            _emailSender.SendReservationEmail(reservation);

            return reservation;
        }
    }
}