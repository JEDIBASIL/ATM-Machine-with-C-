using System;
namespace automateTellerMachine.exception
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string errorMessage)
        {
            Message(errorMessage);

        }
        public new void Message(string message)
        {
            Console.WriteLine(message);
        }
    }
}
