using System.ServiceModel;
using Chap6.EventTickets.Contract;
using Chap6.EventTickets.Datantract;

namespace Chap6.EventTickets.ServiceProxy
{
    public class TicketServiceClientProxy:ClientBase<ITicketService>, ITicketService
    {
        public ReserveTicketResponse ReserveTicket(ReserveTicketRequest request)
        {
            return base.Channel.ReserveTicket(request);
        }

        public PurchaseTicketResponse PurchaseTicket(PurchaseTicketRequest request)
        {
            return base.Channel.PurchaseTicket(request);
        }
    }
}