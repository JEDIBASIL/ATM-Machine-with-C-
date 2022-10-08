using System;
using automateTellerMachine.model;

namespace automateTellerMachine.database
{
    public class Accounts
    {
        

        private Account[] accounts = new Account[3];

        public Account[] AllAccounts { get => accounts; set => accounts = value; }

        public Accounts()
        {
            Account account1 = new Account("2342", "OTON JEDIDIAH", 2152573874, "UBA", 4500000, 2152);
            Account account2 = new Account("2342", "PEACE JOHNSON", 0903251525, "Zenith", 6000, 3212);
            Account account3 = new Account("2342", "OTON JEDIDIAH", 0012573874, "UBA", 45000, 9875);

            this.AllAccounts[0] = account1;
            this.AllAccounts[1] = account2;
            this.AllAccounts[2] = account3;
        }
    }
}
