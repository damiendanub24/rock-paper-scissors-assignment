using System;

namespace RockPaperScissorsSummative
{
    class Program
    {
        static void Main(string[] args)
        {
            game();
            Song();
        }
        public static void game()
        {
            int playerMoney = 100;
            int totalWins = 0;
            int totalLosses = 0;
            int totalDraws = 0;
            int roundsPlayed = 0;
            new Thread(() => Song()).Start();
            Random random = new Random();
            string[] choices = { "rock", "paper", "scissors" };
            Console.WriteLine("========================================");
            Console.WriteLine("  WELCOME TO ROCK, PAPER, SCISSORS!     ");
            Console.WriteLine("========================================");
            Console.WriteLine("Rules: Rock beats Scissors, Scissors beats Paper, Paper beats Rock.");
            Console.WriteLine("You start with $100. Place your bets each round.");
            Console.WriteLine("Type 'quit' at any point during your turn to exit.");
            Console.WriteLine("========================================");
            Console.WriteLine();

            while (playerMoney > 0)
            {
                Console.WriteLine($"Current Balance: ${playerMoney}");
                Console.Write("Enter your bet amount (or 0 to quit): ");
                string betInput = Console.ReadLine().Trim();

                if (betInput.Equals("quit", StringComparison.OrdinalIgnoreCase) || betInput == "0")
                {
                    break;
                }

                if (!int.TryParse(betInput, out int currentBet) || currentBet < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input! Please enter a valid positive number.");
                    Console.ResetColor();
                    Console.WriteLine();
                    continue;
                }

                if (currentBet > playerMoney)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"You cannot bet more than your current balance of ${playerMoney}!");
                    Console.ResetColor();
                    Console.WriteLine();
                    continue;
                }

                Console.Write("Choose [Rock], [Paper], [Scissors], or type [Quit]: ");
                string playerChoice = Console.ReadLine().Trim().ToLower();

                if (playerChoice == "quit")
                {
                    break;
                }

                if (playerChoice != "rock" && playerChoice != "paper" && playerChoice != "scissors")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice! Please choose Rock, Paper, or Scissors.");
                    Console.ResetColor();
                    Console.WriteLine();
                    continue;
                }

                int computerIndex = random.Next(0, 3);
                string computerChoice = choices[computerIndex];

                Console.WriteLine();
                Console.WriteLine($"-> You chose: {char.ToUpper(playerChoice[0]) + playerChoice.Substring(1)}");
                Console.WriteLine($"-> Computer chose: {char.ToUpper(computerChoice[0]) + computerChoice.Substring(1)}");

                if (playerChoice == computerChoice)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("It's a draw!");
                    Console.ResetColor();
                    totalDraws++;
                }
                else if ((playerChoice == "rock" && computerChoice == "scissors") ||
                         (playerChoice == "paper" && computerChoice == "rock") ||
                         (playerChoice == "scissors" && computerChoice == "paper"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"You WIN this round! You won ${currentBet}.");
                    Console.ResetColor();
                    playerMoney += currentBet;
                    totalWins++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"You LOSE this round! You lost ${currentBet}.");
                    Console.ResetColor();
                    playerMoney -= currentBet;
                    totalLosses++;
                }

                roundsPlayed++;

                double winRate = roundsPlayed > 0 ? ((double)totalWins / roundsPlayed) * 100 : 0;

                Console.WriteLine("\n--- CURRENT STATISTICS ---");
                Console.WriteLine($"Wins: {totalWins} | Losses: {totalLosses} | Draws: {totalDraws}");
                Console.WriteLine($"Win Rate: {winRate:F1}%");
                Console.WriteLine("--------------------------\n");

                if (playerMoney <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Game Over! You have run out of money.");
                    Console.ResetColor();
                }
            }

            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine("        FINAL TOURNAMENT RESULTS        ");
            Console.WriteLine("========================================");
            Console.WriteLine($"Total Rounds Played: {roundsPlayed}");
            Console.WriteLine($"Final Balance:       ${playerMoney}");
            Console.WriteLine($"Total Wins:          {totalWins}");
            Console.WriteLine($"Total Losses:        {totalLosses}");
            Console.WriteLine($"Total Draws:         {totalDraws}");

            double finalWinRate = roundsPlayed > 0 ? ((double)totalWins / roundsPlayed) * 100 : 0;
            Console.WriteLine($"Final Win Rate:      {finalWinRate:F1}%");
            Console.WriteLine("========================================");
            Console.WriteLine("Thank you for playing!");
            Console.ReadLine();
        }
        public static void Song()
        {
            const int Quarter = 375;
            const int Eighth = Quarter / 2;
            const int Half = Quarter * 2;
            const int Whole = Quarter * 4;

            // Frequencies for C# Minor scale notes (Octave 4/5)
            const int Csh4 = 277;
            const int Dsh4 = 311;
            const int E4 = 330;
            const int Fsh4 = 370;
            const int Gsh4 = 415;
            const int Ash4 = 466;
            const int B4 = 494;
            const int Csh5 = 554;
            const int Dsh5 = 622;
            const int E5 = 659;
            const int A9 = 440;


            // --- Chorus Opening Phrase ---
            Console.Beep(Gsh4, Quarter);
            Console.Beep(Csh5, Quarter);
            Console.Beep(Dsh5, Quarter);
            Console.Beep(E5, Half);
            Thread.Sleep(Eighth); // Brief programmatic rest

            Console.Beep(Dsh5, Quarter);
            Console.Beep(Csh5, Quarter);
            Console.Beep(B4, Quarter);
            Console.Beep(Gsh4, Whole);

            // --- Second Phrase ---
            Console.Beep(A9, Quarter);
            Console.Beep(Csh5, Quarter);
            Console.Beep(E5, Quarter);
            Console.Beep(Dsh5, Half);
            Thread.Sleep(Eighth);

            Console.Beep(Csh5, Quarter);
            Console.Beep(B4, Quarter);
            Console.Beep(Gsh4, Quarter);
            Console.Beep(Csh4, Whole);

        }

    }
}