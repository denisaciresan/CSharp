using SimpleBankApp_V2.UserCommunication;

public class Menu
{
    private BankSystem bank = new BankSystem();
    BankAccount account;

    public Menu(BankAccount account)
    {
        this.account = account;
    }

    public void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("Menu:");
        Console.WriteLine("=====================================");
        Console.WriteLine("1. Deposit");
        Console.WriteLine("2. Withdraw cash");
        Console.WriteLine("3. Check balance");
        Console.WriteLine("4. Bank transfer");
        Console.WriteLine("5. Currency converter");
        Console.WriteLine("6. Exit");
        Console.WriteLine("=====================================");

    }

    public void Cases()
    {
        bool loop = false;

        do
        {
            ConvertingInput input = new ConvertingInput();
            int option = input.ConvertToInt("Your option:");

            switch (option)
            {
                case 1:
                    bank.Deposit(account);
                    break;
                case 2:
                    bank.Withdraw(account);
                    break;
                case 3:
                    bank.ShowBalance(account);
                    break;
                case 4:
                    bank.Transfer(account);
                    break;
                case 5:
                    bank.CurrencyExchange(account);
                    break;
                case 6:
                    Environment.Exit(0);
                    loop = true;
                    break;
                default:
                    Console.WriteLine("Please insert a valid number");
                    Console.ReadKey();
                    break;
            }
        }
        while (!loop);
    }

}
