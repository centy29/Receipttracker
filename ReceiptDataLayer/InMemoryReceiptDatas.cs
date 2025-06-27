using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReceiptCommon;
namespace ReceiptDataLayer
{
    public class InMemoryReceiptDatas : IReceiptAccounts
    {


        public List<ReceiptAccounts> accounts = new List<ReceiptAccounts>();
        public List<ReceiptAccounts> GetAccounts()
        {
            return accounts;
        }
        public void createaccount(ReceiptAccounts account)
        {

        }
        public void removeaccount(ReceiptAccounts account)
        {

        }
        public void updateaccount(ReceiptAccounts account)
        {

        }
        public void retrieveaccount(ReceiptAccounts account)
        {

        }
        public InMemoryReceiptDatas()
        {
            createdummyaccount();
        }
        private void createdummyaccount()
        {

            accounts.Add(new ReceiptAccounts
            {
                name = "vincent",
                pin = "centy"

            });

            accounts.Add(new ReceiptAccounts
            {
                name = "zyrah",
                pin = "zj"

            });
        }

        public bool ValidateAccount(string pin)// validates the pin of the accounts that is on the list
        {
            foreach (var account in accounts)
            {
                if (account.pin == pin)
                {
                    return true;
                }
            }
            return false;
        }
        public string Getusername(string pin)
        { // method for the pin get the name in the account

            foreach (var account in accounts)
            {

                if (account.pin == pin)
                {

                    return account.name;
                }
            }
            return null;
        }




    }
}