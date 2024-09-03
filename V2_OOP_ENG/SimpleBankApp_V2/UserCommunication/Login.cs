namespace SimpleBankApp_V2.UserCommunication
{
    public class Login
    {
        BankSystem bank = new BankSystem();

        public void Log()
        {
            Console.WriteLine("Hello!");
            Console.WriteLine("Wellcom to SmartBanking!");
            ConvertingInput input = new ConvertingInput();

            bool isCorrect = false;

            while (!isCorrect)
            {
                int id = input.ConvertToInt("Insert your ID account:");
                int pin = input.ConvertToInt("Insert your PIN account:");

                // Check if the ID and PIN match any account
                foreach (BankAccount account in bank.accounts)
                {
                    if (id == account._id && pin == account._pin)
                    {
                        isCorrect = true;
                        bank.currentAccount = account;
                        break;
                    }
                }

                // If ID or PIN is incorrect, prompt the user to try again
                if (!isCorrect)
                {
                    Console.WriteLine("Id or Pin incorrect. Try again.");
                }

            }

            // Proceed to menu after successful login
            Menu menu = new Menu(bank.currentAccount);
            isCorrect = true;
            menu.ShowMenu();
            menu.Cases();
        }
    }
}