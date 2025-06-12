using ReceiptCommon;
using System.Security.Cryptography.X509Certificates;

namespace ReceiptDataLayer
{

    public class ReceiptData
    {

        public IReceiptAccounts Receiptacc;

        public List<ReceiptAccounts> accounts = new List<ReceiptAccounts>();
        public ReceiptData()
        {
            //Receiptacc = new InMemoryReceiptDatas();
            // Receiptacc = new TxtFileReceiptDatas();
            //Receiptacc = new JsonFileReceiptDatas();
            Receiptacc = new DBReceiptData();
        }
        public List<ReceiptAccounts> GetAllAccounts()
        {
            return Receiptacc.GetAccounts();
        }
        public void AddAccount(ReceiptAccounts accounts)
        {
            Receiptacc.createaccount(accounts);
        }
        public void UpdateAccount(ReceiptAccounts accounts)
        {
            Receiptacc.updateaccount(accounts);
        }
        public void removeAccount(ReceiptAccounts accounts)
        {
            Receiptacc.removeaccount(accounts);
        }
        public void RetrieveAccount(ReceiptAccounts accounts)
        {
            Receiptacc.retrieveaccount(accounts);
        }

        public string Getusername(string pin)
        { // method for the pin gets the name in the account
            var allaccounts = Receiptacc.GetAccounts();
            foreach (var accounts in allaccounts)
            {
                if (accounts.pin == pin)
                {
                    return accounts.name;
                }
            }

            return null;
        }
    }

}