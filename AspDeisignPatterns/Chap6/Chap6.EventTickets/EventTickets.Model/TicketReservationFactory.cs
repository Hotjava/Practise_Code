using System;

namespace EventTickets.Model
{
    public class TicketReservationFactory
    {
        public static TicketReservation CreateReservation(Event Event, int tktQty)
        {
            TicketReservation reservation = new TicketReservation()
                                                {
                                                    Event = Event,
                                                    ExpiryTime = DateTime.Now.AddMinutes(1),
                                                    HasBeenRedeemed = false,
                                                    Id = new Guid(),
                                                    TicketQuantity = tktQty
                                                };
            return reservation;
        }
    }
}