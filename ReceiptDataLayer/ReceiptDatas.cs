using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptDataLayer
{
    public class ReceiptDatas
    {
        private static List<accountdetails> accounts = new List<accountdetails>();

        public  ReceiptDatas() {
            createdummyaccount();
        }
        private static void createdummyaccount()
        {

            accounts.Add(new accountdetails
            {
                name = "vincent",
                pin = "centy"

            });

            accounts.Add(new accountdetails
            {
                name = "zyrah",
                pin = "zj"

            });
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
        public string Getusername(string pin) { // method for the pin gets the name in the account

            foreach (var account in accounts) {

                if (account.pin == pin) {

                    return account.name;
                }
            }
            return null;
        }
       

    }
    }

