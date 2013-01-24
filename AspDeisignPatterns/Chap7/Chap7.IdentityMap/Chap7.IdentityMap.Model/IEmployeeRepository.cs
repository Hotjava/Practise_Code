using System;

namespace Chap7.IdentityMap.Model
{
    public interface IEmployeeRepository
    {
         Employee FindBy(Guid Id);
    }
}   