using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chap6.EventTickets.DataContract;
using EventTickets.Model;

namespace Chap6.EventTickets.Service
{
    public static class TicketPurchaseExtensionMethods
    {
        public static PurchaseTicketResponse ConvertToPurchaseTicketResponse(this TicketPurchase purchase)
        {
            PurchaseTicketResponse response = new PurchaseTicketResponse();
            response.EventId = purchase.Event.Id.ToString();
            response.NoOfTickets = purchase.TicketQuantity;
            response.EventName = purchase.Event.Name;
            response.TicketId = purchase.Id.ToString();
            return response;
        }
    }

    public static class TicketReservationExtension
    {
        public static ReserveTicketResponse ConvertToReserveTicketResponse (this TicketReservation ticketReservation)
        {

            ReserveTicketResponse response = new ReserveTicketResponse();
            response.EventId = ticketReservation.Event.Id.ToString();
            response.EventName = ticketReservation.Event.Name;
            response.NoOfTickets = ticketReservation.TicketQuantity;
            response.ExpirationDate = ticketReservation.ExpiryTime;
            response.ReservationNumber = ticketReservation.Id.ToString();
            return response;
        }

    }
}
