using System;

namespace Domain
{
    public class StubEmailSender : IEmailSender
    {
        public void SendReservationEmail(Reservation reservation)
        {
            Console.WriteLine("Email has been sent!");
        }
    }
}
