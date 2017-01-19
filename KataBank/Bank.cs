using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataBank
{
  public  class Bank
    {
        public int bankID = 0;
        static List<Account> accounts = new List<Account>();
        static List<Customer> customers;
        //static Random ran = new Random();

        static Bank()
        {
            customers = new List<Customer>
                                    {
                                      new Customer (4455,"Toto","Dupont",DateTime.Parse("23/05/2000")),
                                      new Customer (665,"Pierre","Durant",DateTime.Parse("23/04/1996")),
                                      new Customer (7755,"Toto2","Dupont2",DateTime.Parse("23/05/1998")),
                                      new Customer (66590,"Pierrette","De Durant",DateTime.Parse("23/06/1980")),
                                    };

            accounts.Add(new Account(23, 50, customers[0]));
            accounts.Add(new Account(2, 150, customers[1]));
        }

        public Bank(int id)
        {
            Random ran = new Random(id);
            bankID = ran.Next();
        }

        /// <summary>
        /// creer un nouveau compte et ajoute à la liste des utilisateurs si ce dernier est absent.
        /// </summary>
        /// <param name="newAccount"></param>
        public void CreateAccount(IAccount newAccount)
        {
            if (accounts.Contains(newAccount)) return;
            if (accounts.Where(x => x.accountId == ((Account)newAccount).accountId).Any()) return;
            var currentAccountCustomers = newAccount.GetAllCustomer();
            foreach (var item in currentAccountCustomers)
            {
                AddNewCustomer(item);
            }
            accounts.Add((Account)newAccount);
        }


        /// <summary>
        /// creer un nouveau compte
        /// </summary>
        /// <param name="newAccounts"></param>
        public void CreateAccount(List<Account> newAccounts)
        {
            foreach (var account in newAccounts.Distinct())
            {
                CreateAccount(account);
            }
        }

        /// <summary>
        /// ajoute un nouveau client
        /// </summary>
        /// <param name="newCustomer"></param>
        public void AddNewCustomer(Customer newCustomer)
        {
            if (customers.Contains(newCustomer) || 
                customers.Where(x => x.customerID == newCustomer.customerID).Any()) return;
            customers.Add(newCustomer);
        }


        public List<Account> GetAllAccount()
        {
            Console.WriteLine(" Liste des comptes :");
            Console.WriteLine("----------------");
            accounts.ForEach(s => s.GetAccountInfo());
            Console.WriteLine("----------------");
            return accounts;
        }

        public Account GetAccountById(int accountId)
        {
            Account result = accounts.Where(x => x.accountId == accountId).FirstOrDefault();
            return result;
        }

        public IAccount GetAccount(IAccount account)
        {
            return accounts.FirstOrDefault(x => x.Equals(account));
        }

        public void DesactiveAccount(Account account)
        {
            GetAccount(account).DesactiveAccount();
        }

        public void AcitvateAccount(Account account)
        {
            GetAccount(account)?.ActiveAccount();
        }

        public bool Deposit(Account account, float amount)
        {
            return account == null ? false : account.Deposit(amount);
        }

        public bool Deposit(int accountId, float amount)
        {
            return Deposit(GetAccountById(accountId), amount);
        }


        public bool WithDrawal(Account account, float amount)
        {
            return account == null ? false : account.WithDrawal(amount);
        }

        public bool WithDrawal(int accountNumber, float amount)
        {
            return WithDrawal(GetAccountById(accountNumber), amount);
        }


        public float GetBalance(Account account)
        {
            return account == null ? float.NaN : account.GetBalance();
        }

        public float GetBalance(int accountNumber)
        {
            return GetBalance(GetAccountById(accountNumber));
        }

        public void GetAccountOwner(Account account = null)
        {

            account?.DisplayAccountOwner();
        }

        public void GetAccountOwner(int accountNumber)
        {
            Account account = GetAccountById(accountNumber);

            account?.DisplayAccountOwner();
        }


        public bool Transfer(Account fromAccount, Account toAccount, float amount)
        {
            object obj = new object();
            bool result = false;
            if (fromAccount == null || toAccount == null) return false;
            if (amount <= 0) return false;
            lock(obj)
            {
                try
                {
                    fromAccount?.WithDrawal(amount);
                    toAccount?.Deposit(amount);
                    result = true;
                }
                catch (Exception ex)
                {
                    Logger.Display($"Tranfer error message: {ex.Message}");
                    throw;
                }
                
            }

            return result;
            
        }

        public void bankAllAccountBalance()
        {
            accounts.ForEach(x => x.GetBalance());
        } 

        public bool Transfer(int fromAccountID, int toAccountID, float amount)
        {

            if (GetAccountById(fromAccountID) == null || GetAccountById(toAccountID) == null) return false;

            return Transfer(GetAccountById(fromAccountID),
                            GetAccountById(toAccountID),
                                            amount);

        }
        }
}
