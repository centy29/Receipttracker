using System;
using System.Collections.Generic;// this is needed to recognize the list
using ReceiptDataLayer;
using recieptlogic;//method para ma call yung another class sa main class

namespace reciepttracker
{
    internal class recieptui
    {

        static void Main(string[] args) //main method nga
        {

            Console.WriteLine("WELCOME TO RECEIPT TRACKER");

            ReceiptDatas receiptdata = new ReceiptDatas();

            string pin = string.Empty;
            string name = string.Empty;
            do
            {
                Console.WriteLine("---------------------------");
                Console.Write("ENTER PIN: ");
                pin = Console.ReadLine();

                if (!receiptdata.ValidateAccount(pin))
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("ERROR!, ENTER THE CORRECT PIN!");
                }


            } while (!receiptdata.ValidateAccount(pin));//LOOP UNTIL THE USER ENTERS THE CORRECT PIN
            Console.WriteLine("--------------------------");
            Console.WriteLine("WELCOME TO RECEIPT TRACKER"+ name);

            int userinput = 0;

            do
            {
                DisplayOptions();// to display again after executing or finishing an option               
                userinput = GetUserInput();

                switch (userinput)
                {
                    case 1:
                        Addreciept();//TO DISPLAY THE ADD EXPENSE METHOD
                        break;
                    case 2:
                        Console.WriteLine("-----------------------");
                        Console.WriteLine("Here are your receipts:");
                        foreach (var recit in recieptlogic.recieptbusinessdata.receipts) //display ng mga listahan ng invoice na naistored
                        {
                            Console.WriteLine("-------------------------");
                            Console.WriteLine("Invoice:" + recit.invoice);
                        }
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("ENTER THE INVOICE YOU WANT TO REMOVE: ");
                        int removeInvoice = Convert.ToInt32(Console.ReadLine());
                        if (recieptbusinessdata.removemethod(removeInvoice))
                        {
                            Removereciept();//DISPLAY IF TRUE
                                            //next update:  notifies the user the details of the selected invoice
                        }
                        else
                        {
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("ADD AN ITEM BEFORE USING THIS OPTION AGAIN");//DISPLAY IF FALSE
                        }
                        break;
                    case 3:
                        retrievereciept();//TO DISPLAY THE HISTORY INPUT 
                        break;
                    case 4: //updating method
                           UpdateReceipt();
                        break;
                    case 5: //exit method
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("THANKS FOR USING RECEIPT TRACKER");
                        break;
                    default:
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("INVALID INPUT PLEASE CHOOSE NUMBER 1 TO 4");//TO REMIND THE USER TO CHOOSE ONLY 1 TO 4 IN OPTIONS
                        break;

                }
            } while (userinput != 5);
        }

        static void DisplayOptions()//easiest method para sa looping ni mam
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("PICK AN OPTION: ");

            foreach (var option in recieptbusinessdata.options) //this is used for displaying the list of options
            {
                Console.WriteLine(option);
            }
        }
        static int GetUserInput()
        {
            Console.WriteLine("------------------------");
            int userinput = Convert.ToInt32(Console.ReadLine());
            return userinput;
        }

        static void Removereciept()
        {
            Console.WriteLine("RECIEPT REMOVE! REMOVING THE LATEST INPUT!");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("THE LASTEST INPUT HAVE BEEN REMOVED SUCCESSFULLY");
        }

        static void Addreciept()//method for adding receipt details
        {
            Console.WriteLine("ADD THE RECEIPT DETAILS");

            Console.WriteLine("------------------------");
            Console.WriteLine("ENTER INVOICE NUMBER");
            int invoice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("------------------------");
            Console.WriteLine("ENTER THE BRAND NAME");
            string brand = Console.ReadLine();

            Console.WriteLine("------------------------");
            Console.WriteLine("ENTER THE ADDRESS");
            string address = Console.ReadLine();

            Console.WriteLine("------------------------");
            Console.WriteLine("ENTER TIN ID NUMBER");
            int tin = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("------------------------");
            Console.WriteLine("ENTER THE AMOUNT SPENT");
            double amount = Convert.ToInt32(Console.ReadLine());

            recieptlogic.recieptbusinessdata.receipts.Add((brand, address, tin, invoice, amount));// a method for adding the input from here to store in the list
            Console.WriteLine("-------------------------------");
            Console.WriteLine("THE RECEIPT DETAILS ADDED SUCCESSFULLY");
            Console.WriteLine("-------------------------------");

        } //MORE UPDATE: MAKE IT SAVED TO A DATABASE FOR EASY STORING AND SEE THE STORED DATA

        static void retrievereciept()//method for history option
        {
            if (recieptlogic.recieptbusinessdata.receipts.Count == 0) {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("There are no recorded receipts!");
                return;
            }

            foreach (var expense in recieptlogic.recieptbusinessdata.receipts)//USED TO DISPLAY THE LIST OF EXPENSES NA NAINPUT OR NA ADD
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("THE INVOICE: " + expense.invoice);
                Console.WriteLine("THE BRAND: " + expense.brand);
                Console.WriteLine("THE ADDRESS: " + expense.address);
                Console.WriteLine("THE TIN: " + expense.tin);
                Console.WriteLine("THE AMOUNT: " + expense.amount);
                Console.WriteLine("-----------------------");
            }
        } //MORE UPDATE: CAN CHOOSE THE ITEM THEY WANT A HISTORY OR SHOWS ALL THE ITEMS STORED IN THE LIST

        static void UpdateReceipt()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Enter Invoice Number to update:");//next update: selectable and list instead na mag input ng mahabang invoice
            int invoice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Enter new Brand Name:");
            string brand = Console.ReadLine();

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Enter new Address:");
            string address = Console.ReadLine();

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Enter new TIN Number:");
            int tin = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Enter new Amount Spent:");
            double amount = Convert.ToDouble(Console.ReadLine());

            bool updated = recieptbusinessdata.UpdateReceipt(invoice, brand, address, tin, amount);
            if (updated)
            {
                Console.WriteLine("Receipt updated successfully!");
            }
            else
            {
                Console.WriteLine("Receipt with that invoice number not found.");
            }
        }

    }
}

