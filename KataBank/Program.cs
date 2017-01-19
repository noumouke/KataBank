using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataBank
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Account> myFirstBankAccounts =
                new List<Account>{
                    new Account(30,0, new Customer(4455,"Pascal","Demarre",DateTime.Parse("23/05/2000"))),
                    new Account(42,150, new Customer(665,"Arnaud","Legrand",DateTime.Parse("23/05/1996")))
                };


            Bank myBank = new Bank(1);
            myBank.CreateAccount(myFirstBankAccounts);
            myBank.GetAllAccount();
            myBank.bankAllAccountBalance();

            Console.WriteLine("--------------");
            
            Console.WriteLine(" User story 1 : deposit, withdrawal, balance");
            myBank.GetBalance(23);
            myBank.Deposit(23, 10);
            myBank.WithDrawal(23, 15);
            myBank.GetBalance(23);
            myBank.GetAccountOwner(2);

            Console.WriteLine(" User story 2 :  transfer between client in the same bank");
            myBank.Transfer(2, 23, 150);
            myBank.bankAllAccountBalance();


            Console.ReadLine();

        }
    }
}
