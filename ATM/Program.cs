using System;
using System.Collections.Generic;
namespace ATM
{
    class cardHolder
    {
        static void Main(string[] args)
        {
            // Simple menu options
            void printOptions()
            {
                Console.WriteLine("Please choose one of the following options : ");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show balance");
                Console.WriteLine("4. Exit");
            }
            void deposit(cardHolder currentUser)
            {
                Console.WriteLine("How much money would you like to deposit: ");
                var deposit = double.Parse(Console.ReadLine());
                currentUser.Balance += deposit;
                Console.WriteLine($"you deposited {deposit}. your new balance is : {currentUser.Balance}");
            }
            void withdraw(cardHolder currentUser)
            {
                Console.WriteLine("How much money would you like to withdraw: ");
                var withdrawal = double.Parse(Console.ReadLine());
                // Check if the user has enough money
                if (currentUser.Balance < withdrawal)
                {
                    Console.WriteLine("Insufficient balance.");
                }
                else
                {
                    currentUser.Balance = (currentUser.Balance - withdrawal);
                    Console.WriteLine("Your money has been withdrawn. Enjoy.");
                }
            }
            void balance(cardHolder currentUser)
            {
                Console.WriteLine($"Current balance: {currentUser.Balance}");
            }

            // Fake Database (db)
            List<cardHolder> cardHolders = new List<cardHolder>();
            cardHolders.Add(new cardHolder("4539670213328661", 2678, "Jax", "Baker", 789.21));
            cardHolders.Add(new cardHolder("4556523425762292", 1111, "Olivia", "Benson", 100000.89));
            cardHolders.Add(new cardHolder("4438165405674677", 9112, "James", "Bond", 90.21));
            cardHolders.Add(new cardHolder("4916489397106972", 7724, "Bradd", "Smit", 562.22));
            cardHolders.Add(new cardHolder(" 4556129970220155", 8954, "Tom", "Shardy", 97891.56));

            Console.WriteLine("Welcome to SimpleATM");
            Console.WriteLine("Please insert your debit card: ");
            string debitCardNum = "";
            cardHolder currentUser;

            while (true)
            {
                try
                {
                    debitCardNum = Console.ReadLine();
                    // Check against our db
                    currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                    if (currentUser != null) { break; }
                    else { Console.WriteLine("Card not recognized. Please try again."); }
                }
                catch { Console.WriteLine("Card not recognized. Please try again."); }

            }
            Console.WriteLine("Please enter your pin: ");
            var userPin = 0;
            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    // If user pin is found, "break" out of loop
                    if (currentUser.pin == userPin) { break; }
                    else { Console.WriteLine("Pin not recognized. Please try again."); }

                }
                catch { Console.WriteLine("Pin not recognized. Please try again."); }
            }

            Console.WriteLine("Welcome " + currentUser.FirstName + " :D ");
            var option = 0;
            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch { }
                if (option == 1) { deposit(currentUser); }
                else if (option == 2) { withdraw(currentUser); }
                else if (option == 3) { balance(currentUser); }
                else if (option == 4) { break; }
                else { option = 0; }

            } while (option != 4);
            Console.WriteLine("Thank you have a nice day.");
        }
        // Declaring variables for the ATM machine
        string cardNum;
        int pin;
        string firstName;
        string lastName;
        double balance;

        // Intialize constructor
        public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
        {
            // Objects instatiated
            this.Num = cardNum;
            this.Pin = pin;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Balance = balance;
        }

        public string Num { get; set; }

        public int Pin { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Balance { get; set; }
    }
}