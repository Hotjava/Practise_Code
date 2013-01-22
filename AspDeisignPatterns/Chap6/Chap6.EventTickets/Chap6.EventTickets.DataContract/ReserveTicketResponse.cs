using System;
using System.Runtime.Serialization;

namespace Chap6.EventTickets.DataContract
{
    [DataContract]
    public class ReserveTicketResponse:Response
    {
        [DataMember]
        public string ReservationNumber {get; set;}
        [DataMember]
        public DateTime ExpirationDate { get; set; }
        [DataMember]
        public String EventName { get; set; }
        [DataMember]
        public String EventId { get; set; }
        [DataMember]
        public int NoOfTickets { get; set; }

    }
}