using System;

class Program
{
    static void Main()
    {
        int Lives = 4;
        int Wins = 0;
        int Loses = 0;

        GetDevInfo();

        ColorMessage("Please Enter Your Name", ConsoleColor.Blue);
        string Inputname = Console.ReadLine();
        while (Inputname == "")
        {
            ConsoleColor color = ConsoleColor.Red;
            ColorMessage("Don't Leave the Name Blank. Please Enter Your Name", color);
            Inputname = Console.ReadLine();
        }
        Console.WriteLine();

        // Greet the Player
        GreetPlayer(Inputname);

        // Main Game Loop
        while (true)
        {
            ColorMessage("Guess a number between 1 to 10", ConsoleColor.Blue);
            ShowLives(Lives);

            // Player guessing number
            int GuessNumber = 0;

            // Random generated Correct number 
            Random random = new Random();
            int CorrectNumber = random.Next(1, 10);

            // Each session Loop
            while (true)
            {                
                string input = Console.ReadLine();
                Console.WriteLine();

                // Checking the Guessed number is correct or not
                if (int.TryParse(input, out GuessNumber))
                {
                    if (GuessNumber == CorrectNumber )
                    {
                        Wins++;
                        ColorMessage("WoW! You Have Guess the Correct Number {~ _ ~}.", ConsoleColor.Yellow);
                        NumberWinsLoses(Wins, Loses);
                        break;
                    }
                    else if (GuessNumber <= 0 || GuessNumber > 10 )
                    {
                        ColorMessage("Please Enter a number between 1 to 10", ConsoleColor.Red);
                        Console.WriteLine();
                        ShowLives(Lives);
                    }
                    else
                    {
                        Lives--;
                        if (Lives > 0)
                        {
                            ColorMessage("Try Again to Guess the number", ConsoleColor.Blue);
                            ShowLives(Lives);
                        }
                        
                    }
                }

                // Handeling any wrong input type
                else
                {
                    ColorMessage("Please Enter a number (symbols, blank space, etc are not allowed) and between 1 to 10", ConsoleColor.Red);
                }

                // Checking Lives is or not. And start new session.
                if (Lives <= 0)
                {
                    Loses++;
                    ColorMessage("OHH NO! You have loose all lives :{", ConsoleColor.Red);
                    NumberWinsLoses(Wins, Loses);
                    break;
                }

            }

            // Want to start new session
            ColorMessage("Want to Play Again? [Y or N]", ConsoleColor.Blue);
            string answer = Console.ReadLine().ToUpper();
            Console.WriteLine();

            // Starting new session
            if (answer == "Y")
            {
                Lives = 4;
                ColorMessage("Let's Start the Game Again!", ConsoleColor.Green);
                Console.WriteLine();
                continue;
                
            }

            // Ending whole game
            else
            {
                return;
            }
        }
    }

    // Print the Game Info
    static void GetDevInfo()
    {
        string title = "NumberGuessing";
        string version = "1.0.0";
        string author = "Amit Kumar";

        Console.ForegroundColor = ConsoleColor.Green;
        int times = 37;
        Console.WriteLine(String.Concat(Enumerable.Repeat("*",times)));
        Console.WriteLine(String.Concat(Enumerable.Repeat("*", times)));
        Console.WriteLine("{0}: V {1} by {2}", title, version, author);
        Console.WriteLine(String.Concat(Enumerable.Repeat("*", times)));
        Console.WriteLine(String.Concat(Enumerable.Repeat("*", times)));
        Console.ResetColor();
    }

    // Print the Player greeting
    static void GreetPlayer(string name)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Hello {0}, Let's Play the Game!!", name);
        Console.ResetColor();
        Console.WriteLine();
    }

    // Print the msgs in Custom color
    static void ColorMessage(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    static void ShowLives(int lives)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("Lives: ");
        for (int i = 0; i < lives; i++)
        {
            Console.Write("@ ");
        }
        Console.ResetColor();
        Console.WriteLine();
        
    }

    static void NumberWinsLoses(int wins, int Loses)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Wins = {0}       Loses = {1}", wins, Loses);
        Console.WriteLine();
        Console.ResetColor();
    }
}