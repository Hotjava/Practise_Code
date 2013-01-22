using System;
using System.Runtime.Serialization;

namespace Chap6.EventTickets.DataContract
{
    [DataContract]
    public class PurchaseTicketResponse:Response
    {
         [DataMember]
         public string TicketId { get; set; }
        [DataMember]
        public string EventName { get; set; }
        [DataMember]
        public String EventId { get; set; }
        [DataMember]
        public int NoOfTickets { get; set; }

    }
}