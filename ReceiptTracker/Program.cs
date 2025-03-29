using System;
using System.Collections.Generic;// this is needed to recognize the list
using recieptlogic;//method para ma call yung another class sa main class

namespace reciepttracker
{
    internal class recieptui
    {

        static void Main(string[] args) //main method nga
        {

            Console.WriteLine("WELCOME TO RECEIPT TRACKER");

            string pin = "centy"; //variable name tsaka pin and username
            string userpin;
            do
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("ENTER PIN: ");
                userpin = Console.ReadLine();

                if (userpin != pin)
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("ERROR!, ENTER THE CORRECT PIN!");
                }


            } while (userpin != pin);//LOOP UNTIL THE USER ENTERS THE CORRECT PIN
            Console.WriteLine("---------------------------");
            Console.WriteLine("WELCOME TO RECEIPT TRACKER");

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
                        if (recieptlogic.reciept.removemethod())
                        {
                            Removereciept();//DISPLAY IF TRUE
                        }
                        else
                        {
                            Console.WriteLine("ADD AN ITEM BEFORE USING THIS OPTION AGAIN");//DISPLAY IF FALSE
                        }
                        break;
                    case 3:
                        reciepthistory();//TO DISPLAY THE HISTORY INPUT 
                        break;
                    case 4: //exit method
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("THANKS FOR USING EXPENSES TRACKER");
                        break;
                    default:
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("INVALID INPUT PLEASE CHOOSE NUMBER 1 TO 4");//TO REMIND THE USER TO CHOOSE ONLY 1 TO 4 IN OPTIONS
                        break;

                }
            } while (userinput != 4);
        }

        static void DisplayOptions()//easiest method para sa looping ni mam
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("PICK AN OPTION: ");

            foreach (var option in reciept.options) //this is used for displaying the list of options
            {
                Console.WriteLine(option);
            }
        }
        static int GetUserInput()
        {
            Console.WriteLine("------------------------");
            int userinput = Convert.ToInt16(Console.ReadLine());
            return userinput;
        }

        static void Removereciept()
        {
            Console.WriteLine("RECIEPT REMOVE! REMOVING THE LATEST INPUT!");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("THE LASTEST INPUT HAVE BEEN REMOVED SUCCESSFULLY");
        }

        static void Addreciept()
        {
            Console.WriteLine("ADD THE RECEIPT DETAILS");

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
            Console.WriteLine("ENTER INVOICE NUMBER");
            int invoice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("------------------------");
            Console.WriteLine("ENTER THE AMOUNT SPENT");
            double amount = Convert.ToInt32(Console.ReadLine());

            recieptlogic.reciept.receipts.Add((brand, address, tin, invoice, amount));// a method for adding the input from here to store in the list
            Console.WriteLine("-------------------------------");
            Console.WriteLine("THE RECEIPT DETAILS ADDED SUCCESSFULLY");
            Console.WriteLine("-------------------------------");

        } //MORE UPDATE: MAKE IT SAVED TO A DATABASE FOR EASY STORING AND SEE THE STORED DATA

        static void reciepthistory()
        {
            foreach (var expense in recieptlogic.reciept.receipts)//USED TO DISPLAY THE LIST OF EXPENSES NA NAINPUT OR NA ADD
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("THE BRAND: " + expense.brand);
                Console.WriteLine("THE ADDRESS: " + expense.address);
                Console.WriteLine("THE TIN: " + expense.tin);
                Console.WriteLine("THE INVOICE: " + expense.invoice);
                Console.WriteLine("THE AMOUNT: " + expense.amount);
                Console.WriteLine("-----------------------");
            }
        } //MORE UPDATE: CAN CHOOSE THE ITEM THEY WANT A HISTORY OR SHOWS ALL THE ITEMS STORED IN THE LIST
    }
}

