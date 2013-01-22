﻿using System;
using System.ServiceModel.Activation;
using Chap6.EvetnTickets.Contract;
using Chap6.EventTickets.DataContract;
using Chap6.EventTickets.Repository;
using EventTickets.Model;


namespace Chap6.EventTickets.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class TicketService:ITicketService
    {

        private IEventRepository _eventRepository;
        private static MessageResponseHistory<PurchaseTicketResponse> _responseHistory = new MessageResponseHistory<PurchaseTicketResponse>();

        public TicketService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public TicketService():this(new EventRepository())
        {
        }

        #region Implementation of ITicketService

        public ReserveTicketResponse ReserveTicket(ReserveTicketRequest request)
        {
            ReserveTicketResponse response = new ReserveTicketResponse();

            try
            {
                Event Event = _eventRepository.FindBy(new Guid(request.EventId));

                TicketReservation reservation;

                if (Event.CanReserveTicket(request.TicketQuantity))
                {
                    reservation = Event.ReserveTicket(request.TicketQuantity);

                    _eventRepository.Save(Event);

                    response = reservation.ConvertToReserveTicketResponse();
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.Message = string.Format("There are {0} tickets available.", Event.AvailableAllocation());

                }
            }
             catch (Exception ex)
            {
            // Shield exceptions
            response.Message = ErrorLog.GenerateErrorRefMessageAndLog(ex);
            response.Success = false;
            } 
            return response;
            

        }

        public PurchaseTicketResponse PurchaseTicket(PurchaseTicketRequest request)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}