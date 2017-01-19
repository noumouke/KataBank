using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataBank
{
   public class Account : IAccount
    {
        float currentBalance = 0; 
        public readonly int accountId;
        static bool isActive = true;
        List<Customer> Accountcustomers = new List<Customer>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        public Account(int Id, float Balance, Customer customer)
        {
            accountId = Id;
            currentBalance = Balance;
            Accountcustomers.Add(customer);
        }



        public void GetAccountInfo()
        {
            Logger.Display($"account number :{accountId}");
        } 


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public float GetBalance()
        {
            
            Logger.Display($"account Number : {accountId}  - Balance :{currentBalance}");
            Console.Write("\t\t");
            Accountcustomers.ForEach(p => p.GetCustomerName());
            return currentBalance;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="montant"></param>
        public bool Deposit(float montant)
        {
            bool result = true;
            try
            {
                currentBalance += montant;
                Logger.Display($"Nouveau depôt : {montant} - compte: {accountId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
                throw;
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="montant"></param>
       public bool WithDrawal(float montant)
       {
            bool result = true;
            try
            {
                currentBalance -= montant;
                Logger.Display($"nouveau retrait : {montant} - compte: {accountId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
                throw;
            }
            return result;
       }


        public void DesactiveAccount()
        {
            if (!isActive)
            {
                Logger.Display("Account is already disactivated");
            }
            isActive = false;
            Logger.Display("Account is now disable");
        }

        public void ActiveAccount()
        {
            if (isActive)
            {
                Logger.Display("Account is already enabled");
                return;
            }
             isActive = true;
             Logger.Display("Account is now enable");
        }


        public void DisplayAccountOwner()
        {
            Accountcustomers.ForEach(x=> x.GetCustomerName());
        }

        public List<Customer> GetAllCustomer()
        {
            return Accountcustomers;
        }
    }
}
