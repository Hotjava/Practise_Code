namespace Chap6.EventTickets.ServiceProxy
{
    public class TicketPresentation
    {
        public string TicketId { get; set; }
        public string EventId { get; set; }
        public string Description { get; set; }
        public bool WasAbleToPurchaseTicket { get; set; }
    }
}