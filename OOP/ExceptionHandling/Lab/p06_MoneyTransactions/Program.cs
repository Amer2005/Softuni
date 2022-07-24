using System;
using System.Collections.Generic;
using System.Linq;

namespace p06_MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputArgs = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

            List<BankAccount> bankAccounts = new List<BankAccount>();

            for (int i = 0; i < inputArgs.Length; i++)
            {
                int accountNumber = int.Parse(inputArgs[i].Split('-')[0]);
                decimal money = decimal.Parse(inputArgs[i].Split('-')[1]);

                BankAccount bankAccount = new BankAccount(accountNumber, money);

                bankAccounts.Add(bankAccount);
            }

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = inputArgs[0];
                int accountNumber = int.Parse(inputArgs[1]);
                decimal money = decimal.Parse(inputArgs[2]);

                
                try
                {
                    if (!bankAccounts.Any(b => b.AccountNumber == accountNumber))
                    {
                        throw new ArgumentException("Invalid account!");
                    }

                    BankAccount bankAccount = bankAccounts.FirstOrDefault(b => b.AccountNumber == accountNumber);

                    if (command == "Deposit")
                    {
                        bankAccount.Deposit(money);
                    }
                    else if (command == "Withdraw")
                    {
                        bankAccount.Withdraw(money);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid command!");
                    }

                    Console.WriteLine($"Account {bankAccount.AccountNumber} has new balance: {bankAccount.Money:f2}");
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }

        public class BankAccount
        {
            public BankAccount(int accountNumber, decimal money)
            {
                this.Money = money;
                this.AccountNumber = accountNumber;
            }

            public decimal Money { get; set; }

            public int AccountNumber { get; }

            public void Deposit(decimal amount)
            {
                Money += amount;
            }

            public void Withdraw(decimal amount)
            {
                if (Money < amount)
                {
                    throw new ArgumentException("Insufficient balance!");
                }

                Money -= amount;
            }
        }
    }
}
