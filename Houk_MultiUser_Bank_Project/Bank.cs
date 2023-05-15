using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Houk_MultiUser_Bank
{
    internal class Bank
    {
        private const decimal _startBalance = 10000;
        private decimal _balance;
        private decimal _limit = 500M;

        public string[] user = { "jlennon", "pmccartney", "gharrison", "rstarr" };
        public string[] password = { "johnny", "pauly", "georgy", "ringoy" };
        public decimal[] balance = { 1250M, 2500M, 3000M, 1000M };

        public Bank()
        {
            _balance = _startBalance;
        }

        public string GetBalance()
        {
            return "The banks overall cash on hand is " + BankBalance.ToString("C");
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                amount = 0;
            }
            _balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > _limit && _balance >= _limit)
            {
                amount = _limit;
            }
            if (amount < 0)
            {
                amount = 0;
            }
            if (amount > _balance)
            {
                amount = _balance;
            }
            _balance -= amount;
        }
        public decimal CustomerWithdraw(int currentUser, decimal amount)
        {
            int i = currentUser;
            if (amount > _limit && balance[i] >= _limit)
            {
                amount = _limit;
            }
            if (amount < 0)
            {
                amount = 0;
            }
            if (amount > balance[i])
            {
                amount = balance[i];
            }
            balance[i] -= amount;
            return amount;
        }

        public decimal CustomerDeposit(int currentUser, decimal amount)
        {
            int i = currentUser;
            if (amount < 0)
            {
                amount = 0;
            }
            balance[i] += amount;
            return amount;
        }

        public string CustomerBalance(int currentUser)
        {
            int i = currentUser;
            return "Your current balance is " + balance[i].ToString("C");
        }
        public string Error()
        {
            return "Withdrawals are limited to " + _limit.ToString("C");
        }

        public decimal BankBalance
        {
            get { return _balance; }
        }

        public decimal Limit
        {
            get { return _limit; }
        }
    }
}
