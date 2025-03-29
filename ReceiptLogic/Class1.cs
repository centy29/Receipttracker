using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recieptlogic
{
    public class reciept
    {
        public static string[] options = { "1. ADD EXPENSES", "2. PAYMENT METHOD", "3. HISTORY", "4.EXIT " }; // options for the user

        public static List<(string brand, string address, int tin, int invoice, double amount)> receipts = new List<(string, string, int, int, double)>();//here store the add expenses input\

        public static bool removemethod()
        {
            if (receipts.Count > 0)
            {

                receipts.RemoveAt(receipts.Count - 1);//BABAWASAN YUN ITEMS NA NASA LIST NG ISA 
                return true;
            }
            else
            {

                return false;//REMINDS THE USER TO ADD ITEM BEFORE USING THI9S OPTION AGAIN
            }


            return true;
        }
        //PROCESSING LOGIC BL/DL
        //MORE UPDATE: THE USER WILL BE REMINDED THE LATEST INPUT IN THE LIST AND CAN CHOOSE WHAT TO REMOVE

    }
}
