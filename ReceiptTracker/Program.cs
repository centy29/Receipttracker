using System;
using System.Collections.Generic;// this is needed to recognize the list
using ReceiptCommon;
using ReceiptDataLayer;
using recieptlogic;//method para ma call yung another class sa main class


namespace reciepttracker
{
    internal class recieptui
    {

        static void Main(string[] args) //main method nga
        {

            Console.WriteLine("WELCOME TO RECEIPT TRACKER");

            ReceiptDataLayer.ReceiptData receiptdata = new ReceiptDataLayer.ReceiptData();

            string pin = string.Empty;// means string has no value
            string name = string.Empty;
            do
            {
                Console.WriteLine("---------------------------");
                Console.Write("ENTER PIN: ");
                pin = Console.ReadLine();

                name = receiptdata.Getusername(pin); //get the name using the pin in the account in the list

                if (name == null)
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("ERROR!, ENTER THE CORRECT PIN!");
                }


            } while (name == null);//LOOP UNTIL THE USER ENTERS THE CORRECT PIN
            Console.WriteLine("--------------------------");
            Console.WriteLine("WELCOME TO RECEIPT TRACKER: " + name); //display the users name upon entering the correct pin

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
                        Console.WriteLine("INVALID INPUT PLEASE CHOOSE NUMBER 1 TO 4");//TO REMIND THE USER TO CHOOSE ONLY 1 TO 5 IN OPTIONS
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
            Console.Write("ENTER INVOICE NUMBER:");
            int invoice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("------------------------");
            Console.Write("ENTER THE BRAND NAME:");
            string brand = Console.ReadLine();

            Console.WriteLine("------------------------");
            Console.Write("ENTER THE ADDRESS:");
            string address = Console.ReadLine();

            Console.WriteLine("------------------------");
            Console.Write("ENTER TIN ID NUMBER:");
            int tin = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("------------------------");
            Console.Write("ENTER THE AMOUNT SPENT:");
            Decimal amount = Convert.ToDecimal(Console.ReadLine());

            var DB = new ReceiptDataLayer.DBReceiptinfo(); //contructor para maconnect sa database

            var Receipt = new DBinfos
            {
                invoice = invoice,
                brand = brand,
                address = address,
                tin = tin,
                amount = amount
            };
            DB.AddReceipt(Receipt);

            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("ALL THE INPUTS ARE SAVED IN THE DATABASE SUCCESSFULLY");


        }

        static void retrievereciept()//method for history option
        {
            var DB = new ReceiptDataLayer.DBReceiptinfo();

            var allreceipts = DB.GetAllRecieptInfos();

            if (allreceipts.Count == 0) {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("THERE NO RECORDED RECEIPTS TO RETRIEVE");
                Console.WriteLine("--------------------------------------");
            }

            foreach (var expense in allreceipts) {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("INVOICE: "+expense.invoice);
                Console.WriteLine("BRAND: " + expense.brand);
                Console.WriteLine("ADDRESS " + expense.address);
                Console.WriteLine("TIN: " + expense.tin);
                Console.WriteLine("AMOUNT: " + expense.amount);
                Console.WriteLine("--------------------------------------");
            }
            return;
        } 

        static void UpdateReceipt()
        {
            var DB = new ReceiptDataLayer.DBReceiptinfo();
            Console.WriteLine("-------------------------------");
            Console.Write("Enter Invoice Number to update:");
            int invoice = Convert.ToInt32(Console.ReadLine());

            var receipt = DB.GetInvoice(invoice); //check yung receipt using invoice
            if (receipt == null) {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("RECEIPT WITH THAT INVOICE IS NOT FOUND!");
                Console.WriteLine("--------------------------------------");
            }
            
            Console.WriteLine("-------------------------------");
            Console.Write("Enter new Brand Name:");
            string brand = Console.ReadLine();

            Console.WriteLine("-------------------------------");
            Console.Write("Enter new Address:");
            string address = Console.ReadLine();

            Console.WriteLine("-------------------------------");
            Console.Write("Enter new TIN Number:");
            int tin = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("-------------------------------");
            Console.Write("Enter new Amount Spent:");
            double amount = Convert.ToDouble(Console.ReadLine());

            DB.AddReceipt(receipt);
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Receipt updated successfully!");
                Console.WriteLine("-------------------------------");
            }
           
        }

    }
}