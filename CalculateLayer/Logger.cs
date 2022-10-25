
namespace CalculateLayer
{
    public interface ILogger
    {
        public string LogType { get; set; }

        void AddLog(TransactionType type, int amount, int balance);

        bool LogNotEnoughBalanceInWithdrawal(string message);

        string LogAndReturnMessage(string message);

        bool SayThanksToCustomer(string name, out string message);

        bool GetName(string name);
    }

    public class Logger : ILogger
    {
        public string LogType { get; set; } = string.Empty;

        public void AddLog(TransactionType type, int amount, int balance)
        {
            switch (type)
            {
                case TransactionType.Deposit:
                    Console.WriteLine($"{amount:C} has been deposited into your account, the remaining balance is {balance:C}.");
                    break;
                case TransactionType.Withdrawal:
                    Console.WriteLine($"{amount:C} has been withdrawn from your account, the remaining balance is {balance:C}.");
                    break;
            }
        }

        public bool LogNotEnoughBalanceInWithdrawal(string message)
        {
            Console.WriteLine(message);

            return true;
        }

        public string LogAndReturnMessage(string message)
        {
            Console.WriteLine(message);

            return message;
        }

        public bool SayThanksToCustomer(string name, out string message)
        {
            message = $"Thanks {name} for choosing us.";

            return true;
        }

        public bool GetName(string name)
        {
            return true;
        }
    }

    public enum TransactionType
    {
        Deposit,
        Withdrawal
    }
}
