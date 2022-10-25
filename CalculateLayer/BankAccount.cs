
namespace CalculateLayer
{
    public class BankAccount
    {
        public int Balance { get; set; } = 100;
        private readonly ILogger _logger;

        public BankAccount(ILogger logger)
        {
            _logger = logger;
        }

        public int Deposit(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The amount entered must be greater than 0.");
            }

            Balance += amount;

            _logger.LogType = "Success";
            _logger.AddLog(TransactionType.Deposit, amount, Balance);
            var logType = _logger.LogType;

            return Balance;
        }

        public int Withdrawal(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The amount entered must be greater than 0.");
            }

            if (Balance < amount)
            {
                var result = _logger.LogNotEnoughBalanceInWithdrawal("The account balance is insufficient.");
                throw new ArgumentException("The account balance is insufficient.");
            }

            Balance -= amount;

            _logger.AddLog(TransactionType.Withdrawal, amount, Balance);

            return Balance;
        }
    }
}
