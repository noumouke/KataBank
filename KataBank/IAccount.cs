using System.Collections.Generic;

namespace KataBank
{
    public interface IAccount
    {
        void GetAccountInfo();
        //float GetBalance();
        bool Deposit(float montant);
        bool WithDrawal(float montant);
        void DesactiveAccount();
        void ActiveAccount();
        void DisplayAccountOwner();
        List<Customer> GetAllCustomer();
    }
}