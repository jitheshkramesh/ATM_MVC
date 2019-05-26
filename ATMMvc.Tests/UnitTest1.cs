using System;
using System.Web.Mvc;
using ATMMvc.Controllers;
using ATMMvc.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATMMvc.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FooActionReturnAboutView()
        {
            var homeController = new HomeController();
            var result = homeController.Foo() as ViewResult;
            Assert.AreEqual("About", result.ViewName);

        }

        [TestMethod]
        public void ContactFormSaysThanks() {

            var homeController = new HomeController();
            var result = homeController.Contact("I Love You") as ViewResult;
            Assert.IsNotNull("Thanks", result.ViewBag.TheMessage);
        }

        [TestMethod]
        public void BalanceIsCorrectAfterDeposit()
        {
            var fakeDb = new FakeApplicationDbContext
            {
                CheckingAccounts = new FakeDbSet<CheckingAccount>()
            };

            var checkingAccount = new CheckingAccount { Id = 2, AccountNumber = "0000123456Test", Balance = 0 };
            fakeDb.CheckingAccounts.Add(checkingAccount);
            fakeDb.Transactions = new FakeDbSet<Transaction>();
            var transactionController = new TransactionController(fakeDb);
            transactionController.Deposit(new Transaction { CheckingAccountId = 2, Amount = 25 });
            checkingAccount.Balance = 25;
            Assert.AreEqual(25, checkingAccount.Balance);
        }
    }
}
