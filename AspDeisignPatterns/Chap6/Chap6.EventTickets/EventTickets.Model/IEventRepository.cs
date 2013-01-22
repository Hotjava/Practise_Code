using System;

namespace EventTickets.Model
{
    public interface IEventRepository
    {
        Event FindBy(Guid id);
        void Save(Event eventEntry);
    }
}