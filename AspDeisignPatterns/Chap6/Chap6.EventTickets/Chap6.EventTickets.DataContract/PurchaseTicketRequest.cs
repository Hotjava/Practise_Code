using System.Runtime.Serialization;

namespace Chap6.EventTickets.DataContract
{
    [DataContract]
    public class PurchaseTicketRequest
    {
        [DataMember]
        public string CorrelationId { get; set; }
        [DataMember]
        public string ReservationId { get; set; }
        [DataMember]
        public string EventId { get; set; }
    }

    [DataContract]
    public class ReserveTicketRequest
    {
        [DataMember]
        public string EventId { get; set; }
        [DataMember]
        public int TicketQuantity { get; set; }
    }
}