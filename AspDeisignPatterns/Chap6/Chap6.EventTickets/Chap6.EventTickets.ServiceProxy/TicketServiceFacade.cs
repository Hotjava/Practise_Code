using Chap6.EventTickets.DataContract;
using Chap6.EvetnTickets.Contract;

namespace Chap6.EventTickets.ServiceProxy
{
    public class TicketServiceFacade
    {
        private ITicketService _ticketService;

        public TicketServiceFacade(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public TicketReservationPresentation ReserveTicketsFor(string EventId, int NoOfTkts)
        {
            TicketReservationPresentation reservation = new TicketReservationPresentation();
            ReserveTicketRequest  request = new ReserveTicketRequest();
            request.EventId = EventId;
            request.TicketQuantity = NoOfTkts;

            ReserveTicketResponse response = _ticketService.ReserveTicket(request);

            if (response.Success)
            {
                reservation.TicketWasSuccessfullyReserved = true;
                reservation.ReservationId = response.ReservationNumber;
                reservation.ExpiryDate = response.ExpirationDate;
                reservation.EventId = response.EventId;
                reservation.Description = string.Format("{0} ticket(s) reserved for {1}.<br/>"
                                                        + "<small>This reservation will expire on {2} at {3}.</small>",
                                                        response.NoOfTickets,
                                                        response.EventName,
                                                        response.ExpirationDate.ToLongDateString(),
                                                        response.ExpirationDate.ToShortDateString()
                    );
            }
            else
            {
                reservation.TicketWasSuccessfullyReserved = false;
                reservation.Description = response.Message;
            }
            return reservation;

        }

        public TicketPresentation PurchaseTicket(string eventId, string reservationId)
        {
            TicketPresentation presentation = new TicketPresentation();

            PurchaseTicketRequest request = new PurchaseTicketRequest();
            request.ReservationId = reservationId;
            request.EventId = eventId;
            request.CorrelationId = reservationId;

            PurchaseTicketResponse response = _ticketService.PurchaseTicket(request);
            if (response.Success)
            {
                presentation.Description = string.Format("{0} ticket(s) purchased for {1}. <br/>" + "" +
                                                         "<small>Your e-ticket id is {2}</small>"
                                                         , response.NoOfTickets
                                                         , response.EventName
                                                         , response.TicketId);
                presentation.EventId = response.EventId;
                presentation.TicketId = response.TicketId;
                presentation.WasAbleToPurchaseTicket = true;
            }
            else
            {
                presentation.WasAbleToPurchaseTicket = false;
                presentation.Description = response.Message;
            }
            return presentation;
        }
    }
}