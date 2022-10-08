using System;
using automateTellerMachine.database;
using automateTellerMachine.model;
using automateTellerMachine.service;

namespace automateTellerMachine.controller
{
    public class AutomatedTellerMachineController : IAutomateTellerMachineService
    {
        private Account[] accounts = new Accounts().AllAccounts;



        public Account Authentication(long accountNumber, long cardPin)
        {
            return GetAccount(accountNumber,cardPin);
        }

        public long CheckBalance(long accountName)
        {
            Account account = GetAccount(accountName);
            return account != null ? account.AccountBalance : 0;
        }

        public string Transfer(long senderAccountNumber, long ammount, string bank, long accountNumber)
        {
            Account senderAccount = GetAccount(senderAccountNumber);

            Account reciverAccount = GetAccount(accountNumber, bank);

            Console.WriteLine("reciver account: "+accountNumber);
            Console.WriteLine("reciver bank: " + bank);

            if (reciverAccount == null) return "no reciever found";

            if (reciverAccount == senderAccount) return "invalid account";

            if (senderAccount != null)
            {
                long accountBalance = senderAccount.AccountBalance;

                if (accountBalance < ammount) return "Insufficient cash";

                UpdateAccountBalance(senderAccount.AccountNumber, ammount, "DEBIT");

                UpdateAccountBalance(reciverAccount.AccountNumber, ammount, "CREDIT");

                return "Transfer successfully";
            }

            return "something is wrong";
        }

        public string Withdraw(long accountNumber,long ammount)
        {
            Account account = GetAccount(accountNumber);
            if(account != null)
            {
                long accountBalance = account.AccountBalance;


                if (accountBalance < ammount) return "Insufficient cash";


                UpdateAccountBalance(accountNumber, ammount, "DEBIT");

                return "transaction successfully";
            }

            return null;
        }
        

        public Account GetAccount(long accountNumber)
        {
            foreach (Account account in accounts)
            {
                if (account.AccountNumber == accountNumber) return account;
            }
            return null;
        }


        public Account GetAccount(long accountNumber, long cardPin)
        {
            foreach (Account account in accounts)
            {
                if (account.AccountNumber == accountNumber && account.CardPin == cardPin)
                    return account;
            }

            return null;
        }

        public Account GetAccount(long accountNumber, string bank)
        {
            foreach (Account account in accounts)
            {
                if (account.AccountNumber == accountNumber && account.AccountBank == bank)
                    return account;
            }

            return null;
        }



        public void UpdateAccountBalance(long accountNumber, long ammount,string transactionType)
        {
           Account account = GetAccount(accountNumber);

            long accountBalance = account.AccountBalance;

            if (transactionType == ("DEBIT"))
            {
                account.AccountBalance = accountBalance - ammount;
            }

            if (transactionType == "CREDIT") account.AccountBalance = accountBalance + ammount;

        }
    }
}
