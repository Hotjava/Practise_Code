using System;
using Chap7.IdentityMap.Model;

namespace Chap7.IdentityMap.Repository
{
    public class EmployeeRepository:IEmployeeRepository

    {
        private IdentityMap<Employee> _identityMap;

        public EmployeeRepository(IdentityMap<Employee> identityMap)
        {
            _identityMap = identityMap;
        }

        #region Implementation of IEmployeeRepository

        public Employee FindBy(Guid Id)
        {
            Employee employee = _identityMap.GetById(Id);

            if(employee==null)
            {
                employee = DataStoreFindBy(Id);
                _identityMap.Store(employee, Id);
            }

            return employee;
        }

        private Employee DataStoreFindBy(Guid id)
        {
            Employee employee = default(Employee);
            return employee;
        }

        #endregion
    }
}