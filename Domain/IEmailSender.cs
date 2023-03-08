namespace Domain
{
    public interface IEmailSender
    {
        void SendReservationEmail(Reservation reservation);
    }
}
