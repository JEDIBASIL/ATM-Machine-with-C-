using System;
using System.Diagnostics.Tracing;
using automateTellerMachine.controller;
using automateTellerMachine.model;

namespace automateTellerMachine.view
{
    public class AutomatedTellerMachineView
    {
        private long userAccountNumber;
        private long userCardPin;
        private string[] banks = {"UBA","Zenith","Ecobank","First Bank","GTB"};

        AutomatedTellerMachineController atmController = new AutomatedTellerMachineController();

        public AutomatedTellerMachineView()
        {
            service();
        }

        public void service()
        {
            long[] userAuthDetails = AuthorizationInput();

            this.userAccountNumber = userAuthDetails[0];

            this.userCardPin = userAuthDetails[1];

            Account userAccount = atmController.Authentication(userAccountNumber, userCardPin);

            view(userAccount);
        }

        public void view(Account userAccount)
        {

            if(userAccount != null)
            {
                TransactionOption();
                try
                {
                    int option = Int32.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine(atmController.CheckBalance(userAccountNumber));

                            PeformAnotherTransactionOption();

                            int anotherTransaction = Int32.Parse(Console.ReadLine());

                            if (anotherTransaction == 1) view(userAccount);

                            else service();

                            break;

                        case 2:

                            try
                            {
                                displayBanksOption();
        
                                Console.Write("Enter bank: ");

                                long bankName = long.Parse(Console.ReadLine());

                                Console.Write("Enter account number: ");

                                long reciverAccountNumber = long.Parse(Console.ReadLine());

                                Console.Write("Enter amount: ");

                                long ammount = long.Parse(Console.ReadLine());

                                Console.WriteLine(atmController.Transfer(userAccountNumber, ammount, banks[bankName - 1], reciverAccountNumber));

                                PeformAnotherTransactionOption();

                                anotherTransaction = Int32.Parse(Console.ReadLine());

                                if (anotherTransaction == 1) view(userAccount);

                                else service();

                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Invalid Details");
                            }


                            break;

                        case 3:

                            try
                            {
                                Console.Write("Enter Ammount: ");

                                long withdrawAmount = long.Parse(Console.ReadLine());

                                Console.WriteLine(atmController.Withdraw(userAccountNumber, withdrawAmount));

                                PeformAnotherTransactionOption();

                                anotherTransaction = Int32.Parse(Console.ReadLine());

                                if (anotherTransaction == 1) view(userAccount);

                                else service();

                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Invalid amount");
                            }

                            break;

                        default:
                            Console.WriteLine("Invalid transaction");

                            view(userAccount);

                            break;
                    }
                   
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid transaction");

                    view(userAccount);
                }
            }

            else Console.WriteLine("Wrong Pin");
        }






        public long[] AuthorizationInput()
        {
            long accountNumber, cardPin;

            accountNumber = GetAccountNumber();

            cardPin = GetCardPin(3);

            return new long[] {accountNumber, cardPin };
        }

        public long GetAccountNumber()
        {
            long accountNumberInt = 0;
            Console.Write("Enter your account number 💳 ⌲ ");

            string acountNumber = Console.ReadLine();

            try
            {
                accountNumberInt = long.Parse(acountNumber);

            }
            catch (Exception)
            {
                Console.Write("Please enter a valid card \n");
                GetAccountNumber();
            }

            return accountNumberInt;
        }

        public int GetCardPin(int trialNumber)
        {
            int cardPinInt = 0;

            int trials = trialNumber;

            Console.Write("Enter your card pin 💳 ⌲ ");

            string cardPin = Console.ReadLine();

            try
            {
                cardPinInt = Int32.Parse(cardPin);
            }
            catch (Exception)
            {
                Console.Write("Wrong pin \n");

                Console.Write("you have "+ trials + " trial \n");

                trials--;

                GetCardPin(trials);  
            }

            return cardPinInt;
        }

        public void TransactionOption()
        {
            Console.WriteLine("1️⃣⌲ Check balance \n");

            Console.WriteLine("2️⃣⌲ Quick teller  \n");

            Console.WriteLine("3️⃣⌲ Withdraw  \n");

            Console.Write("🔢 Select a transaction : ");

        }

        public void PeformAnotherTransactionOption()
        {
            Console.WriteLine("⌲⌲⌲⌲do you want to perform another transaction \n");

            Console.WriteLine("1️⃣⌲ Yes");

            Console.WriteLine("2️⃣⌲⌲ No");
        }


        public void displayBanksOption()
        {
            for(int i =0; i < banks.Length; i++)
            {
                int counter = 1;
                Console.WriteLine(i+counter +"⌲ " +banks[i]);
            }
        }
    }
}
