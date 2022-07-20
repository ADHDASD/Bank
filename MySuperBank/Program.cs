using System;

namespace MySuperBank
{
    class Program
    {
        static void Main(string[] args)
        {

            var account = new BankAccount("Biniam", 10000);

            Console.WriteLine($"Account{account.Number} was created for {account.Owner} with {account.Ballance} ");

            account.MakeWithdraw(180, DateTime.Now, "grocery");

            Console.WriteLine(account.Ballance);

            account.MakeDeposit(980, DateTime.Now, "salary");

            Console.WriteLine(account.Ballance);

            Console.WriteLine(account.GetAccountHistory());
        }
    }
}
