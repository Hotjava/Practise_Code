using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap4.DomainModel.Model
{
    public class BankAccount
    {
        #region properties
        private decimal _balance;
        private Guid _accountNo;
        private string _customerRef;
        private IList<Transaction> _transactions;


        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        public Guid AccountNo
        {
            get { return _accountNo; }
            internal set { _accountNo = value; }
        }

        public string CustomerRef
        {
            get { return _customerRef; }
            set { _customerRef = value; }
        }

        public IList<Transaction> Transactions
        {
            get { return _transactions; }
            set { _transactions = value; }
        }
        #endregion

        public BankAccount(decimal balance, Guid accountNo, string customerRef, IList<Transaction> transactions)
        {
            _balance = balance;
            AccountNo = accountNo;
            _customerRef = customerRef;
            _transactions = transactions;
        }
        
        public BankAccount():this(0, new Guid(), string.Empty, new List<Transaction>() )
        {
            _transactions.Add(new Transaction(0m, 0m, "Account created", DateTime.Now));
        }

        public bool CanWithdraw(decimal amount)
        {
            return Balance >= amount;
        }
    }
}
