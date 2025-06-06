using ReceiptCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptDataLayer
{
    public interface IReceiptAccounts
    {
        List<ReceiptAccounts> GetAccounts();
        public void createaccount(ReceiptAccounts account);
        public void retrieveaccount(ReceiptAccounts account) { }
        public void removeaccount(ReceiptAccounts account);
        public void updateaccount(ReceiptAccounts account);
        bool ValidateAccount(string pin);
        string Getusername(string pin);


    }
}