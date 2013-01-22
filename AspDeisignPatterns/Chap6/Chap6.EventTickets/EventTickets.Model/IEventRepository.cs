using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventTickets.Model
{
    public interface IEventRepository
    {
        Event FindBy(Guid Id);

        void Save(Event eventEntity);
    }
}
