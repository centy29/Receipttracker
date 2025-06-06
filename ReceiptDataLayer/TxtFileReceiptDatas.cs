using ReceiptCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptDataLayer
{
    public class TxtFileReceiptDatas : IReceiptAccounts
    {

        string filePath = "txtaccounts.txt";
        List<ReceiptAccounts> Accounts = new List<ReceiptAccounts>();

        public List<ReceiptAccounts> accounts = new List<ReceiptAccounts>();

        public TxtFileReceiptDatas()
        {

            GetDataFromFile();

        }
        public void GetDataFromFile()
        {
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split('|');

                Accounts.Add(new ReceiptAccounts
                {
                    name = parts[0],
                    pin = parts[1],
                });
            }
        }
        public List<ReceiptAccounts> GetAccounts()
        {
            return Accounts;
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
        public bool ValidateAccount(string pin)// validates the pin of the accounts that is in the list
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
        {
            var allaccounts = accounts;
            foreach (var accounts in allaccounts)
            {
                if (accounts.pin == pin)
                {
                    return accounts.name;
                }
            }

            return null;
        }
        private void WriteDataToFile()
        {
            var lines = new string[Accounts.Count];

            for (int i = 0; i < Accounts.Count; i++)
            {
                lines[i] = $"{Accounts[i].name}|{Accounts[i].pin}";
            }

            File.WriteAllLines(filePath, lines);
        }

        public int FindIndex(ReceiptAccounts account)
        {
            for (int i = 0; i < Accounts.Count; i++)
            {
                if (Accounts[i].name == account.pin)
                {
                    return i;
                }
            }

            return -1;
        }

    }
}