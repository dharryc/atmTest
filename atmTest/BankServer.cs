
namespace ATM
{
    class BankServer

    {
        private Dictionary<string, (int, BankAccount)> validCards;

        public BankServer(Dictionary<string, (int, BankAccount)> initialCards)
        {
            validCards = initialCards;
        }
        public bool verifyCard(string cardNumber)
        {
            return validCards.ContainsKey(cardNumber);
        }
        public bool verifyPIN(string cardNumber, int pin)
        {
            if (validCards.ContainsKey(cardNumber))
            {
                var storePin = validCards[cardNumber].Item1;
                return storePin == pin;
            }
            return false;
        }
        public bool processTransaction(string cardNumber, double amount)
        {
            if (validCards[cardNumber].Item2.hasSufficientFunds(amount))
            {
                return true;
            }
            return false;
        }
        public double checkBalance(string cardNumber)
        {
            return validCards[cardNumber].Item2.GetBalance();
        }

    }
}