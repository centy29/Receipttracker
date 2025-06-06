using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recieptlogic
{
    public class recieptbusinessdata
    {
        public static string[] options = { "1. ADD EXPENSES", "2. PAYMENT METHOD", "3. HISTORY", "4.UPDATE", "5.EXIT" }; // options for the user

        public static List<(string brand, string address, int tin, int invoice, double amount)> receipts = new List<(string, string, int, int, double)>();//here store the add expenses input\

        public static bool removemethod(int invoice)
        {
            for (int i = 0; i < receipts.Count; i++)
            {
                if (receipts[i].invoice == invoice)
                { //changed the method, now it tracks the invoice to select what to remove
                    receipts.RemoveAt(i);
                    return true;
                }
            }
            return false;//next update:  notifies the user the details of the selected invoice
        }

        public static bool UpdateReceipt(int invoice, string newBrand, string newAddress, int newTin, double newAmount)
        {
            for (int i = 0; i < receipts.Count; i++)
            {
                if (receipts[i].invoice == invoice)// scanning if there is the entered invoice in the list
                {
                    receipts[i] = (newBrand, newAddress, newTin, invoice, newAmount);
                    return true;
                }
            }
            return false;
        }// future update: makikita yung details ng invoice after updating


    }

}