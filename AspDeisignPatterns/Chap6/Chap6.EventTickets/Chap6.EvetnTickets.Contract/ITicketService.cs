using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Chap6.EventTickets.DataContract;

namespace Chap6.EvetnTickets.Contract
{
    [ServiceContract(Namespace = "EventTickets/")]
    public interface ITicketService
    {
        [OperationContract]
        ReserveTicketResponse ReserveTicket(ReserveTicketRequest request);

        [OperationContract]
        PurchaseTicketResponse PurchaseTicket(PurchaseTicketRequest request);
    }
}
