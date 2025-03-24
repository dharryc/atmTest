namespace ATM;

class ATM
{
    public enum ATMAction{
        InsertCard,
        EnterPin,
        DisplayOptions
    }
    private bool cardInserted;
    private bool pinValidated;
    private BankServer bankServer;
    private string currentCardNumber;

    public ATM(BankServer server)
    {
        bankServer = server;
        cardInserted = false;
        pinValidated = false;
    }
    public void insertCard(string cardNumber)
    {
        if (bankServer.verifyCard(cardNumber))
        {
            currentCardNumber = cardNumber;
            Console.WriteLine("Card verification successful! Plese enter pin, then press enter:\n");
            if(enterPIN())
            {
                requestAmount();
            }
            else ejectCard();
        }
        else ejectCard();
    }
    public bool enterPIN()
    {
        try{
            int pin = Convert.ToInt32(Console.ReadLine());
            return(bankServer.verifyPIN(currentCardNumber, pin));
        }
        catch
        {
            Console.WriteLine("Please enter a valid pin");
            return enterPIN();
        }
    }
    public void requestAmount()
    {
        double amountOut = 0;
        try{
            amountOut = Convert.ToDouble(Console.ReadLine());
        }
        catch{
            requestAmount();
        }
        bankServer.processTransaction(currentCardNumber, amountOut);
    }
    public void dispenseCash()
    {
        for(int a = 0; a < int.MaxValue; a ++)
        {
            Console.Write("$$$");
        }
        ejectCard();
    }
    public void ejectCard()
    {
        currentCardNumber = "";
        cardInserted = false;
    }
    public void checkBalance()
    {
        Console.WriteLine("Your current balance is " + bankServer.checkBalance(currentCardNumber));
    }
    public ATMAction getNextAction()
    {
        if(!cardInserted) return ATMAction.InsertCard;
        else if(!pinValidated) return ATMAction.EnterPin;
        else return ATMAction.DisplayOptions;
    }
}