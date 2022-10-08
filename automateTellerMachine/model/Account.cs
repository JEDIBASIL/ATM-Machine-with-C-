using System;
namespace automateTellerMachine.model
{
    public class Account
    {
        private string accountId;

        private string accountName;

        private long accountNumber;

        private string accountBank;

        private long accountBalance;

        private int cardPin;

        public Account(string accountId,  string accountName, long accountNumber, string accountBank, long accountBalance, int cardPin)
        {
            this.AccountId = accountId;

            this.AccountName = accountName;

            this.AccountNumber = accountNumber;

            this.AccountBank = accountBank;

            this.AccountBalance = accountBalance;

            this.CardPin = cardPin;
        }

        public Account()
        {

        }

        public string AccountName { get => accountName; set => accountName = value; }

        public long AccountNumber { get => accountNumber; set => accountNumber = value; }

        public long AccountBalance { get => accountBalance; set => accountBalance = value; }

        public int CardPin { get => cardPin; set => cardPin = value; }

        public string AccountId { get => accountId; set => accountId = value; }

        public string AccountBank { get => accountBank; set => accountBank = value; }

        public override string ToString()
        {
            return this.accountBalance + "\n" +
                    this.accountName + "\n" +
                    this.accountBalance;
        }

    }
}
