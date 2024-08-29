
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Bună ziua! Bine ați venit!");
        Console.WriteLine("=====================================");

        // Logare in program
        Console.WriteLine("Vă rugam introduceti ID-ul:");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Va rugam introduceti PIN-ul:");
        int pin = Convert.ToInt32(Console.ReadLine());

        // Variabile
        double[,] clienti = new double[,] { { 1, 1111, 1000.00 },
                            { 2, 2222, 2000.50} };

        int a = 0;
        bool logare = false;

        Console.Clear();

        for (int i = 0; i < clienti.GetLength(0); i++)
        {

            if (id == clienti[i, 0] && pin == clienti[i, 1])
            {
                logare = true;
                a = i;
                break;
            }
        }

        // de verificat
        if (logare)
        {
            meniu();
        }
        else
        {
            Console.WriteLine("Utilizator sau parola incorecta!");
            Console.ReadKey();
        }

        // Metode
        void meniu()
        {
            Console.WriteLine("Meniu:");
            Console.WriteLine("=====================================");
            Console.WriteLine("1. Depunere");
            Console.WriteLine("2. Retragere numerar");
            Console.WriteLine("3. Interogare sold");
            Console.WriteLine("4. Transfer bancar");
            Console.WriteLine("5. Convertor valutar");
            Console.WriteLine("6. Iesire");
            Console.WriteLine("=====================================");
            Console.WriteLine("Optiunea ta:");

            int raspuns = 0;
            bool validInput = false;

            while (!validInput)
            {
                string input = Console.ReadLine();
                try
                {
                    raspuns = Convert.ToInt32(input);

                    switch (raspuns)
                    {
                        case 1:
                            depunere();
                            break;
                        case 2:
                            retragere();
                            break;
                        case 3:
                            sold();
                            break;
                        case 4:
                            transfer();
                            break;
                        case 5:
                            schimbValutar();
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Va rugam introduceti un numar valid.");
                            Console.ReadKey();
                            break;
                    }
                    validInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Valoare invalida. Va rugam sa introduceti un numar.");
                }
            }

        }

        void depunere()
        {
            double suma = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("=====================================");
                Console.WriteLine("Ce suma doriti sa depuneti?");
                string input = Console.ReadLine();

                try
                {
                    suma = Convert.ToDouble(input);

                    if (suma > 0)
                    {
                        clienti[a, 2] += suma;
                        Console.WriteLine($"Ai depus {suma} lei");
                        validInput = true; // Setăm input-ul ca fiind valid
                    }
                    else if (suma <= 0)
                    {
                        Console.WriteLine("Suma depusa trebuie sa fie mai mare decat 0. Va rugam incercati din nou.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Valoare invalida. Va rugam sa introduceti un numar.");
                }
            }

            continuitate();
        }


        void retragere()
        {
            double suma = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("=====================================");
                Console.WriteLine("Ce suma doriti sa retrageti?");
                string input = Console.ReadLine();

                try
                {
                    suma = Convert.ToDouble(input);
                    if (suma >= 0 && suma <= clienti[a, 2])
                    {
                        clienti[a, 2] -= suma;
                        Console.WriteLine($"S-au retras {suma} lei");
                    }
                    else if (suma < 0)
                    {
                        Console.WriteLine("Suma retrasa trebuie sa fie mai mare decat 0. Va rugam incercati din nou.");
                    }
                    else if (suma > clienti[a, 2])
                    {
                        Console.WriteLine("Suma pe care doriti sa o retrageti depaseste soldul disponibil. Va rugam incercati din nou.");
                    }
                    else
                    {
                        Console.WriteLine("Valoare invalida. Va rugam incercati din nou!");
                    }
                    validInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Valoare invalida. Va rugam sa introduceti un numar.");
                }
            }

            continuitate();
        }

        void sold()
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("Soldul dumneavostră este: " + clienti[a, 2]);
            continuitate();
        }

        void transfer()
        {
            int contid = 0;
            int pozitie_cont = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Introduceti ID-ul contului in care doriti sa transferati bani:");
                string input = Console.ReadLine();

                try
                {
                    contid = Convert.ToInt32(input);

                    for (int i = 0; i < clienti.GetLength(0); i++)
                    {

                        if (contid == clienti[i, 0])
                        {
                            pozitie_cont = i;
                            break;
                        }
                    }

                    if (contid == clienti[pozitie_cont, 0])
                    {
                        Console.WriteLine("Introduceti suma pe care doriti sa o transferati: ");
                        double suma = Convert.ToDouble(Console.ReadLine());

                        if (suma >= 0 && suma <= clienti[a, 2])
                        {
                            clienti[pozitie_cont, 2] += suma;
                            clienti[a, 2] -= suma;
                            Console.WriteLine($"Ai depus {suma} lei in contul cu ID = {clienti[pozitie_cont, 0]}");
                        }
                        else if (suma < 0)
                        {
                            Console.WriteLine("Suma depusa trebuie sa fie mai mare decat 0. Va rugam incercati din nou.");
                        }
                        else if (suma > clienti[a, 2])
                        {
                            Console.WriteLine("Suma pe care doriti sa o depuneti depaseste soldul disponibil. Va rugam incercati din nou.");
                        }
                        else
                        {
                            Console.WriteLine("Valoare invalida. Va rugam incercati din nou.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Contul cu ID = " + contid + " nu a putut fi gasit. Va rugam incercati din nou.");
                    }
                    validInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Valoare invalida. Va rugam sa introduceti un numar.");
                }
            }
            continuitate();
        }

        void schimbValutar()
        {
            double suma = 0;
            int optiune = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Ce suma doriti sa convertiti?");

                string input1 = Console.ReadLine();

                Console.WriteLine("In ce moneda doriti sa convertiti suma: ");
                Console.WriteLine("1. Euro");
                Console.WriteLine("2. Dolar");

                string input2 = Console.ReadLine();

                // 23 august 2024
                double euro = 4.9767;
                double dolar = 4.4754;
                double suma_convertita = 0;
                try
                {
                    suma = Convert.ToDouble(input1);
                    optiune = Convert.ToInt32(input2);
                    if (optiune == 1)
                    {
                        suma_convertita = suma / euro;
                        Console.WriteLine(suma + " lei = " + suma_convertita + " euro");
                    }
                    else if (optiune == 2)
                    {
                        suma_convertita = suma / dolar;
                        Console.WriteLine(suma + " lei = " + suma_convertita + " dolari");
                    }
                    else
                    {
                        Console.WriteLine("Optiune invalida");
                    }
                    validInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Valoare invalida. Va rugam sa introduceti un numar.");
                }
            }
            continuitate();

        }


        void continuitate()
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("Doriti sa realizati o alta operatiune? Y/N");
            string rasp = Console.ReadLine().ToUpper();

            if (rasp == "Y")
            {
                Console.Clear();
                meniu();
            }
            else if (rasp == "N")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Optiune invalida!");
            }
        }
    }
}