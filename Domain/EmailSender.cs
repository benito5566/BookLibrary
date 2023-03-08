using System;

namespace Domain
{
    public class EmailSender : IEmailSender
    {
        public void SendReservationEmail(Reservation reservation)
        {
            throw new ApplicationException("EmailSender is not available");
        }
    }
}
