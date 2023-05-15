using System;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
// Lee Houk
// IT112
// NOTES: I originally attempted to do this using a seperate class for Users, however that proved to be difficult in accessing the user data while keeping it in the Bank class. This simplified version was much easier to manage and less stressful.
// BEHAVIORS NOT IMPLEMENTED AND WHY: None

namespace Houk_MultiUser_Bank
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Bank Bank = new Bank();
            Menu(Bank);
        }
        
        static void Menu(Bank Bank)
        {
            bool loggedin = true;
            string username;
            string password;
            int currentUser = -1;
                        
            do
            {
                Console.WriteLine("Welcome to Lee's Bank. The total funds available is " + Bank.BankBalance.ToString("C") + ". Please choose from the following options.");
                Console.WriteLine("1) Log in");
                Console.WriteLine("2) Exit the app");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Please log in to continue.");
                        Console.WriteLine("Enter your username: ");
                        username = Console.ReadLine();
                        Console.WriteLine("Enter your password: ");
                        password = Console.ReadLine();
                        
                        for(int i = 0; i < Bank.user.Length; i++)
                        {
                            if (username == Bank.user[i])
                            {
                                if (password == Bank.password[i])
                                {
                                    loggedin = true;
                                    currentUser = i;
                                    break;
                                }
                            }
                            else
                            {
                                loggedin= false;
                            }
                        }
                        if (!loggedin)
                        {
                            Console.WriteLine("Your username or password is incorrect.");                                                        
                        }
                        while (loggedin)
                        {                            
                            decimal amount = 0;
                            if (Bank.balance[currentUser] > 0)
                            {
                                Console.WriteLine("Welcome " + Bank.user[currentUser] + ", please choose from the listed options:");
                                Console.WriteLine("1) Make a deposit");
                                Console.WriteLine("2) Make a withdrawal");
                                Console.WriteLine("3) Check balance");
                                Console.WriteLine("4) Log out");
                                Console.WriteLine("\r\nSelect an option:");

                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        Console.WriteLine("How much would you like to deposit?");
                                        amount = decimal.Parse(Console.ReadLine());
                                        Bank.Deposit(Bank.CustomerDeposit(currentUser, amount));
                                        Console.WriteLine(Bank.CustomerBalance(currentUser) + "\n" + Bank.GetBalance() + "\n");
                                        break;
                                    case "2":
                                        Console.WriteLine("How much would you like to withdraw?");
                                        amount = decimal.Parse(Console.ReadLine());
                                        if (amount <= Bank.Limit)
                                        {
                                            Bank.Withdraw(Bank.CustomerWithdraw(currentUser, amount));
                                            Console.WriteLine(Bank.CustomerBalance(currentUser) + "\n" + Bank.GetBalance() + "\n");
                                            loggedin = true;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n" + Bank.Error());
                                            Bank.Withdraw(Bank.CustomerWithdraw(currentUser, amount));
                                            Console.WriteLine(Bank.CustomerBalance(currentUser) + "\n" + Bank.GetBalance() + "\n");
                                            loggedin = true;
                                            break;
                                        }
                                    case "3":
                                        Console.WriteLine(Bank.CustomerBalance(currentUser) + "\n");
                                        loggedin = true;
                                        break;                                        
                                    case "4":
                                        loggedin= false;
                                        currentUser = -1;
                                        break;
                                    default:
                                        loggedin = true;
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please choose from the listed options:");
                                Console.WriteLine("1) Make a deposit");
                                Console.WriteLine("2) Check balance");
                                Console.WriteLine("3) Log out");
                                Console.WriteLine("\r\nSelect an option:");

                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        Console.WriteLine("How much would you like to deposit?");
                                        amount = decimal.Parse(Console.ReadLine());
                                        Bank.Deposit(Bank.CustomerDeposit(currentUser, amount));
                                        Console.WriteLine(Bank.CustomerBalance(currentUser) + "\n" + Bank.GetBalance() + "\n");
                                        loggedin = true;
                                        break;
                                        //return true;
                                    case "2":
                                        Console.WriteLine(Bank.CustomerBalance(currentUser) + "\n");
                                        loggedin = true;
                                        break;
                                        //return true;
                                    case "3":
                                        loggedin = false;
                                        break;
                                        //return true;
                                    default:
                                        loggedin = true;
                                        break;
                                        //return true;
                                }
                            }
                        }
                        break;
                    case "2":
                        Environment.Exit(0);
                        break;
                }
            }while (!loggedin);
        }                                                                  
    }
}