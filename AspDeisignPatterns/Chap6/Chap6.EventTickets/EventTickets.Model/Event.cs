using System;
using System.Collections.Generic;
using System.Linq;

namespace EventTickets.Model
{
   
    public class Event
    {
        public List<TicketReservation> ReservedTickets { get; set; }
        public List<TicketPurchase> PurchasedTickets { get; set; }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int  Allocation { get; set; }
        
        public Event()
        {
            ReservedTickets = new List<TicketReservation>();
            PurchasedTickets = new List<TicketPurchase>();
        }

        public int AvailableAllocation()
        {
            int salesAndReservation = 0;
            PurchasedTickets.ForEach(t=> salesAndReservation+=t.TicketQuantity);
            ReservedTickets.FindAll(r=>r.StillActive()).ForEach(r=>salesAndReservation+=r.TicketQuantity);
            return Allocation - salesAndReservation;
        }

        public bool CanPurchaseTicketWith(Guid reservationId)
        {
            if (HasReservationWith(reservationId))
            {
                return GetReservationWith(reservationId).StillActive();
            }
            return false;
        }

        private TicketReservation GetReservationWith(Guid reservationId)
        {
            if(!HasReservationWith(reservationId))
                throw new ApplicationException(string.Format("No Reservation ticket with matching if of {0}", reservationId.ToString()));
            return ReservedTickets.FirstOrDefault(t => t.Id == reservationId);
        }

        private bool HasReservationWith(Guid reservationId)
        {
            return ReservedTickets.Exists(r => r.Id == reservationId);
        }

        public TicketPurchase PurchaseTicketWith(Guid reservationId)
        {
            if (!CanPurchaseTicketWith(reservationId))
            {
                throw new ApplicationException(DetermineWhyATicketCannotbePurchasedWith(reservationId));
            }
            TicketReservation reservation = GetReservationWith(reservationId);

            TicketPurchase ticket = TicketPurchaseFactory.CreateTicket(this, reservation.TicketQuantity);
            reservation.HasBeenRedeemed = true;
            PurchasedTickets.Add(ticket);
            return ticket;
        }

        public string DetermineWhyATicketCannotbePurchasedWith(Guid reservationId)
        {
            string reservationIssue = string.Empty;
            if (HasReservationWith(reservationId))
            {
                TicketReservation reservation = GetReservationWith(reservationId);
                if (reservation.HasExpired())
                    reservationIssue = string.Format("Ticket reservation '{0}' has been expired",
                                                     reservationId.ToString());
                else if (reservation.HasBeenRedeemed)
                    reservationIssue = string.Format("Ticket reservation '{0}' has already been redeemed",
                                                     reservationId.ToString());

            }
            else
            {
                reservationIssue = string.Format("There is no ticket res");
            }
            return reservationIssue;
        }

        public bool CanReserveTicket(int qty)
        {
            return AvailableAllocation() >= qty;
        }

        public TicketReservation ReserveTicket(int tktQty)
        {
            if(!CanReserveTicket(tktQty))
                ThrowExceptionWithDetailsOnWhyTicketsCannotBeReserved();
            TicketReservation reservation =
                        TicketReservationFactory.CreateReservation(this, tktQty);
                        ReservedTickets.Add(reservation); 
                        return reservation;
        }
        
        private void ThrowExceptionWithDetailsOnWhyTicketsCannotBeReserved()
        { 
            throw new ApplicationException
            ("There are no tickets available to reserve.");
        }
        
    }
}