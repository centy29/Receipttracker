using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using ReceiptCommon;
namespace ReceiptDataLayer
{
    public class JsonFileReceiptDatas : IReceiptAccounts
    {

        private readonly string filePath = "receiptaccs.json";

        public List<ReceiptAccounts> accounts = new List<ReceiptAccounts>();

        public JsonFileReceiptDatas()
        {

            GetjsonDataFromFile();

        }
        public void GetjsonDataFromFile() //reads if the account is in the Json File brackets
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }

            string jsonfile = File.ReadAllText(filePath);

            accounts = JsonSerializer.Deserialize<List<ReceiptAccounts>>(jsonfile,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            ) ?? new List<ReceiptAccounts>();
        }
        private void WriteJsonDataToFile()
        {
            string jsonString = JsonSerializer.Serialize(accounts, new JsonSerializerOptions
            { WriteIndented = true });

            File.WriteAllText(filePath, jsonString);
        }
        private int FindAccountIndex(string name, string pin)
        {
            var accounts = GetAccounts();

            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].name == name && accounts[i].pin == pin)
                {
                    return i;
                }
            }

            return -1;
        }
        public List<ReceiptAccounts> GetAccounts()
        {
            return accounts;
        }
        public void createaccount(ReceiptAccounts account)
        {
            accounts.Add(account);
            WriteJsonDataToFile();

        }
        public void removeaccount(ReceiptAccounts account)
        {
            int index = FindAccountIndex(account.name, account.pin);
            if (index >= 0)
            {
                accounts.RemoveAt(index);
                WriteJsonDataToFile();
            }

        }
        public void updateaccount(ReceiptAccounts account)
        {
            int index = FindAccountIndex(account.name, account.pin);
            if (index >= 0)
            {
                accounts[index].name = account.name;
                accounts[index].pin = account.pin;
                WriteJsonDataToFile();
            }
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