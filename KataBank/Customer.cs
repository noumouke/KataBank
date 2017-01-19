using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataBank
{
   public class Customer
    {
        string customerName;
        string customerLastName;
        DateTime customerBithdate;
        public readonly int customerID;
        //IList<Account> customerAccount;

        /// <summary>
        /// 
        /// </summary>
        public Customer(int id, string name, string lastName, DateTime bithDate)
        {
            customerName = name;
            customerLastName = lastName;
            customerBithdate = bithDate;
            customerID = id;
        }

        public string GetCustomerName()
        {
            string name = $"{customerName}  {customerLastName} {customerID}";
            Logger.Display(name);
            
            return name;
        }

    }
}
