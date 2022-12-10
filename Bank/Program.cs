using System;
using System.IO;

namespace BankGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"
            $$$$$$$\   $$$$$$\  $$\   $$\ $$\   $$\        $$$$$$\   $$$$$$\  $$\      $$\ $$$$$$$$\ 
            $$  __$$\ $$  __$$\ $$$\  $$ |$$ | $$  |      $$  __$$\ $$  __$$\ $$$\    $$$ |$$  _____|
            $$ |  $$ |$$ /  $$ |$$$$\ $$ |$$ |$$  /       $$ /  \__|$$ /  $$ |$$$$\  $$$$ |$$ |      
            $$$$$$$\ |$$$$$$$$ |$$ $$\$$ |$$$$$  /        $$ |$$$$\ $$$$$$$$ |$$\$$\$$ $$ |$$$$$\    
            $$  __$$\ $$  __$$ |$$ \$$$$ |$$  $$<         $$ |\_$$ |$$  __$$ |$$ \$$$  $$ |$$  __|   
            $$ |  $$ |$$ |  $$ |$$ |\$$$ |$$ |\$$\        $$ |  $$ |$$ |  $$ |$$ |\$  /$$ |$$ |      
            $$$$$$$  |$$ |  $$ |$$ | \$$ |$$ | \$$\       \$$$$$$  |$$ |  $$ |$$ | \_/ $$ |$$$$$$$$\ 
            \_______/ \__|  \__|\__|  \__|\__|  \__|       \______/ \__|  \__|\__|     \__|\________|
                                                                                         
                                                                                         
                                                                                         
                                                    
                                        
                                        ");
            Console.WriteLine();
            Console.Write(@"
[*] Register if you are a new user!!!

[1] Register
[2] Login
[3] Exit

[#] Select Option: ");
            string option = Console.ReadLine();

            // Making a new line for clean looks
            Console.WriteLine();

            // Register Section
            if (option == "1")
            {
                Console.WriteLine("[# REGISTER]");
                Console.WriteLine();
                // Username Input
                Console.Write("Enter Username: ");
                string input_username = Console.ReadLine();

                // Password Input
                Console.Write("Enter Password: ");
                string input_password = Console.ReadLine();

                string user_data = input_username;
                string password_data = input_password;

                Console.WriteLine($"Username: {user_data}");
                File.WriteAllText("user_database.txt", user_data);
                Console.WriteLine($"Password: {password_data}");
                File.WriteAllText("password_database.txt", password_data);
                Console.WriteLine("Restart the program again.");
                Console.ReadLine();
            }
            // Login Section
            else if (option == "2")
            {
                Console.WriteLine("[# LOGIN]");
                Console.WriteLine();
                // Username Input_Login
                Console.Write("Enter Username: ");
                string login_input_username = Console.ReadLine();

                // Password Input_Login
                Console.Write("Enter Password: ");
                string login_input_password = Console.ReadLine();

                // Read database
                string read_user = File.ReadAllText("user_database.txt");
                string read_pass = File.ReadAllText("password_database.txt");

                // Using While loop until the username and password are correct
                while (login_input_username != read_user || login_input_username == "" && login_input_password != read_pass || login_input_password == "")
                {
                    Console.WriteLine("Wrong Username and Password!");
                    Console.WriteLine();
                    // Username Input_Login
                    Console.Write("Enter Username: ");
                    login_input_username = Console.ReadLine();

                    // Password Input_Login
                    Console.Write("Enter Password: ");
                    login_input_password = Console.ReadLine();
                }
                // Login Successful Section and putting options after the login!
                Console.WriteLine("You are login!!");
                Console.Write(@"
[1] Deposit
[2] Withdraw
[3] Balance

[#] Select Option: ");
                string after_login_option = Console.ReadLine();

                // Deposit Section
                if (after_login_option == "1")
                {
                    Console.Write("Enter the amount for deposit: $");
                    string deposit_amount_input = Console.ReadLine();
                    while (Convert.ToDouble(deposit_amount_input) <= 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Deposit Amount should be atleast 1 or more!");
                        Console.Write("Enter the amount for deposit: $");
                        deposit_amount_input = Console.ReadLine();
                    }
                    string read_balance = File.ReadAllText("balance_database.txt");
                    double balance_update = Convert.ToDouble(read_balance) + Convert.ToDouble(deposit_amount_input);
                    File.WriteAllText("balance_database.txt", Convert.ToString(balance_update));
                    Console.Write("Deposit have beeen done!");
                    Console.WriteLine($"Current Balance: ${balance_update}");
                    Console.ReadLine();

                }
                
                // Withdraw Section
                else if (after_login_option == "2")
                {
                    Console.Write("Amount of Money to withdraw: ");
                    string withdraw_amount = Console.ReadLine();

                    // Using While loop if the withdraw amount is less than $10 or equal to $0
                    while (Convert.ToDouble(withdraw_amount) < 10 || Convert.ToDouble(withdraw_amount)  == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("The Withdraw Amount should be atleast $10 or more!");
                        Console.Write("Amount of Money to withdraw: ");
                        withdraw_amount = Console.ReadLine();
                    }
                    string read_balance = File.ReadAllText("balance_database.txt");

                    // Using if condition if balance is greater than or equal to $10
                    if (Convert.ToDouble(read_balance) >= 10)
                    {
                        if (Convert.ToDouble(read_balance) > Convert.ToDouble(withdraw_amount))
                        {
                            Console.WriteLine();
                            double balance_update = Convert.ToDouble(read_balance) - Convert.ToDouble(withdraw_amount);
                            Console.WriteLine($"${withdraw_amount} have been withdraw from the balance.");
                            File.WriteAllText("balance_database.txt", Convert.ToString(balance_update));
                            Console.WriteLine($"Current Balance: ${balance_update}");
                            Console.ReadLine();
                        }
                        else if (Convert.ToDouble(read_balance) <= Convert.ToDouble(withdraw_amount))
                        {
                            Console.WriteLine("Sorry, the withdraw can't be process because the current balance amount is less than the withdraw amount. Please restart the program to try again!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Balance and Withdraw: Something went wrong here!");
                            Console.ReadLine();
                        }
                    }
                    else if (Convert.ToDouble(read_balance) < 10)
                    {
                        Console.WriteLine("Current balance is less than $10 and the withdraw amount should be atleast $10. Restart the program and try again!");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Withdraw: Something went wrong here!");
                        Console.ReadLine();
                    }
                }
                else if (after_login_option == "3")
                {
                    string read_current_balance = File.ReadAllText("balance_database.txt");
                    Console.WriteLine($"Current Balance: ${read_current_balance}");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Check the option number!");
                    Console.ReadLine();
                }

            }

            else if (option == "3")
            {
                
            }
            else
            {
                Console.WriteLine("Wrong Options");
                Console.WriteLine("Please restart the program again");
                Console.ReadLine();
            }
        }
    }
}
