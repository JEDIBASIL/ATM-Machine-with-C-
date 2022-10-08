using System;
using automateTellerMachine.model;

namespace automateTellerMachine.service
{
    public interface IAutomateTellerMachineService
    {
        public long  CheckBalance(long accountName);

        public Account Authentication(long accountNumber, long cardPin);

        public string Transfer(long senderAccountNumber,  long ammount, string bank, long accountNumber);

        public string Withdraw(long accountNumber, long ammount);
    }
}
