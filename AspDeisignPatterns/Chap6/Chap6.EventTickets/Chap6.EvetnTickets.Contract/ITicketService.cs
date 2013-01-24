using System.ServiceModel;
using Chap6.EventTickets.DataContract;

namespace Chap6.EventTickets.Contract
{
    [ServiceContract(Namespace = "http://Chap6.EventTickets/")]
    public interface ITicketService
    {
        [OperationContract]
        ReserveTicketResponse ReserveTicket(ReserveTicketRequest request);

        [OperationContract]
        PurchaseTicketResponse PurchaseTicket(PurchaseTicketRequest request);
    }
}
