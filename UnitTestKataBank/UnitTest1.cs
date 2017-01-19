using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataBank;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestKataBank
{
    [TestClass]
    public class UnitTest1
    {
        static Customer myCustomer1 = new Customer (4455,"Toto","Dupont",DateTime.Parse("23/05/2000"));
        static Customer myCustomer2 = new Customer(665, "Pierre", "Durant", DateTime.Parse("23/05/1996"));

        Account myAccount1 = new Account(1, 150, myCustomer1);
        Account myAccount2 = new Account(1, 25, myCustomer2);

        [TestMethod]
        public void TestMethodTransfert1()
        {
            
            Bank myBank = new Bank(1);
            myBank.CreateAccount(new List<Account> { myAccount1, myAccount1 });
            myBank.CreateAccount(new List<Account> { myAccount2 });
            myBank.CreateAccount(new List<Account> { myAccount1, myAccount1 });
            myBank.CreateAccount(myAccount2);


            myBank.Transfer(444, 23, 150);
            var expectedValue = new List<Account> { myAccount1, myAccount1 };
            var realValue = myBank.GetAllAccount();
            // myBank.GetBalance()

            Assert.AreNotEqual(expectedValue, realValue, "not equal");
            Environment.Exit(0);


        }

        [TestMethod]
        public void TestMethodTransfert2()
        {
            Account myAccount1 = new Account(122, 150, myCustomer1);
            IAccount myAccount2 = new Account(188, 25, myCustomer2);

            

            Bank myBank = new Bank(1);
            myBank.CreateAccount(new List<Account> { myAccount1, myAccount1 });
            myBank.CreateAccount(myAccount2);

            myBank.Transfer(122, 188, 150);
            
            object expectedValue = 2;
            object realValue = myBank.GetBalance(myAccount1);
            // myBank.GetBalance()

            Assert.AreNotEqual(expectedValue, realValue,"not equal");
            //Environment.Exit(0);


        }



        [TestMethod]
        public void TestMethodTransfert3()
        {
            Account myAccount1 = new Account(122, 150, myCustomer1);
            Account myAccount2 = new Account(188, 25, myCustomer2);

            Bank myBank = new Bank(1);
            myBank.CreateAccount(new List<Account> { myAccount1, myAccount1 });
            myBank.CreateAccount(myAccount2);

            myBank.Transfer(122, 188, 1223444455677877);
            object expectedValue = 2;
            object realValue = myBank.GetBalance(myAccount1);
            // myBank.GetBalance()

            Assert.AreNotEqual(expectedValue, realValue, "not equal");
            //Environment.Exit(0);


        }
    }
}
