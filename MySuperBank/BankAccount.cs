using System;
using System.Collections.Generic;
using System.Text;

namespace MySuperBank
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public Decimal Ballance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
            
        }

        private static int accountNumberSeed = 1234567890;


        private List<Transaction> allTransactions = new List<Transaction>();


        public BankAccount(string name, decimal initialBalance)
        {
            Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Intial Ballance");
            Number = accountNumberSeed.ToString();
            accountNumberSeed++;

        }

        public void MakeDeposit (decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new AccessViolationException(nameof(amount));
            }
            var deposite = new Transaction(amount, date, note);
            allTransactions.Add(deposite);

        }

        public void MakeWithdraw (Decimal amount, DateTime date, string note)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount withdrawal must be positive"); 

            }

            if (Ballance -amount < 0)
            {
                throw new InvalidOperationException("not suffiecient fund");
            }
            var withdarawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdarawal);

        }


        public string GetAccountHistory()
        {
            var report = new StringBuilder();

            report.AppendLine("Date\t\tAmount\t\tNote");
            foreach(var item in allTransactions)
            {
                report.AppendLine($"{item.Date.ToShortDateString()},\t{item.Amount},\t\t{item.Note}");

            }

            return report.ToString();
        }



    }
}
