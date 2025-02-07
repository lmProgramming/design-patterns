namespace DesignPatterns.Layer
{
    public class DopeAccount : Account
    {
        public DopeAccount(int _id, decimal _balance) : base(_id, _balance)
        {
        }

        public void Debit(decimal amount, out bool success)
        {
            if (!HasEnoughBalance(amount))
            {
                success = false;
                return;
            }

            Balance -= amount;
            success = true;
        }

        public bool HasEnoughBalance(decimal amount)
        {
            return Balance > amount;
        }

        public void TransferTo(Account accountTo, decimal amount, out bool success)
        {
            if (!HasEnoughBalance(amount))
            {
                success = false;
                return;
            }

            Balance -= amount;
            accountTo.Balance += amount;
            success = true;
        }
    }
}
