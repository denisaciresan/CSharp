namespace SimpleBankApp_V2.UserCommunication

{
    public class BankSystem
    {
        private List<BankAccount> accounts;
        private BankAccount currentAccount;

        BankAccount targetAccount;

        public BankSystem()
        {
            accounts = new List<BankAccount>
            {
                new BankAccount(1, 1111, 1000.00, 0, 0),
                new BankAccount(2, 2222, 2000.50, 0, 0),
                new BankAccount(3, 3333, 2000.00, 0, 0)
            };
        }

        public void Login()
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
                foreach (BankAccount account in accounts)
                {
                    if (id == account._id && pin == account._pin)
                    {
                        isCorrect = true;
                        currentAccount = account;
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
            Menu menu = new Menu(currentAccount);
            isCorrect = true;
            menu.ShowMenu();
            menu.Cases();
        }

        public void Deposit(BankAccount loggInAccount)
        {
            Console.WriteLine("=====================================");
            ConvertingInput input = new ConvertingInput();
            double sum = input.ConvertToDouble("How much would you like to deposit?");

            if (sum > 0)
            {
                loggInAccount._sum_lei += sum;
                Console.WriteLine($"You have deposited {sum} lei.");
            }
            else 
            {
                Console.WriteLine("The deposited amount must be greater than 0. Please try again.");
            }
        }

        public void Withdraw(BankAccount loggedInAccount)
        {
            Console.WriteLine("=====================================");
            ConvertingInput input = new ConvertingInput();
            double sum = input.ConvertToDouble("How much would you like to withdraw?");

            if (sum > 0 && sum <= loggedInAccount._sum_lei)
            {
                loggedInAccount._sum_lei -= sum;
                Console.WriteLine($"You have withdrawn {sum} lei.");
            }
            else if (sum <= 0)
            {
                Console.WriteLine("The amount to withdraw must be greater than 0. Please try again.");
            }
            else 
            {
                Console.WriteLine("The amount you wish to withdraw exceeds your available balance. Please try again.");
            }
        }

        public void ShowBalance(BankAccount loggedInAccount)
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("Your current balance is: " + loggedInAccount._sum_lei + " lei, " + loggedInAccount._sum_euro + " euros, " + loggedInAccount._sum_dollar + " dollars.");
        }

        public void Transfer(BankAccount loggedInAccount)
        {
            Console.WriteLine("=====================================");
            ConvertingInput input = new ConvertingInput();
            int accountId = input.ConvertToInt("Enter the ID of the account you want to transfer money to:");

            bool accountExists = false;

            foreach (BankAccount account in accounts)
            {
                if (accountId == account._id)
                {
                    targetAccount = account;
                    accountExists = true;
                    break;
                }
            }

            if (accountExists)
            {
                double amount = input.ConvertToDouble("Enter the amount you want to transfer: ");

                if (amount >= 0 && amount <= loggedInAccount._sum_lei)
                {
                    targetAccount._sum_lei += amount;
                    loggedInAccount._sum_lei -= amount;
                    Console.WriteLine($"You have transferred {amount} lei to the account with ID = {targetAccount._id}");
                }
                else if (amount < 0)
                {
                    Console.WriteLine("The amount to transfer must be greater than 0. Please try again.");
                }
                else if (amount > loggedInAccount._sum_lei)
                {
                    Console.WriteLine("The amount you wish to transfer exceeds your available balance. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("The account with ID = " + accountId + " could not be found. Please try again.");
            }
        }

        public void CurrencyExchange(BankAccount loggedInAccount)
        {
            ConvertingInput input = new ConvertingInput();
            double amount = input.ConvertToDouble("How much would you like to convert?");

            Console.WriteLine("Which currency would you like to convert to?");
            Console.WriteLine("1. Euro");
            Console.WriteLine("2. Dollar");
            int option = input.ConvertToInt("Select the currency you want to convert to: ");

            // August 23, 2024
            double euroRate = 4.9767;
            double dollarRate = 4.4754;
            double convertedAmount = 0;

            if (option == 1)
            {
                convertedAmount = Math.Round(amount / euroRate, 2);
                loggedInAccount._sum_euro += convertedAmount;
                loggedInAccount._sum_lei -= amount;
                Console.WriteLine(amount + " lei = " + convertedAmount + " euros");
            }
            else if (option == 2)
            {
                convertedAmount = Math.Round(amount / dollarRate,2);
                loggedInAccount._sum_dollar += convertedAmount;
                loggedInAccount._sum_lei -= amount;
                Console.WriteLine(amount + " lei = " + convertedAmount + " dollars");
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }
}