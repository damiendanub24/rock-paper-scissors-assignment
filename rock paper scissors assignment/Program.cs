using System;

namespace RockPaperScissorsSummative
{
    class Program
    {
        static void Main(string[] args)
        {
            // --- 1. Game Setup & Variables ---
            int playerMoney = 100; // Starting money for betting system
            int totalWins = 0;
            int totalLosses = 0;
            int totalDraws = 0;
            int roundsPlayed = 0;

            Random random = new Random();
            string[] choices = { "rock", "paper", "scissors" };

            // --- 2. Introduction ---
            Console.WriteLine("========================================");
            Console.WriteLine("  WELCOME TO ROCK, PAPER, SCISSORS!     ");
            Console.WriteLine("========================================");
            Console.WriteLine("Rules: Rock beats Scissors, Scissors beats Paper, Paper beats Rock.");
            Console.WriteLine("You start with $100. Place your bets each round.");
            Console.WriteLine("Type 'quit' at any point during your turn to exit.");
            Console.WriteLine("========================================");
            Console.WriteLine();

            // --- 3. Main Game Loop ---
            while (playerMoney > 0)
            {
                Console.WriteLine($"Current Balance: ${playerMoney}");
                Console.Write("Enter your bet amount (or 0 to quit): ");
                string betInput = Console.ReadLine().Trim();

                // Check for quit intent in bet input
                if (betInput.Equals("quit", StringComparison.OrdinalIgnoreCase) || betInput == "0")
                {
                    break;
                }

                // Bet Validation
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

                // --- 4. Get User Choice ---
                Console.Write("Choose [Rock], [Paper], [Scissors], or type [Quit]: ");
                string playerChoice = Console.ReadLine().Trim().ToLower();

                // Check for quit
                if (playerChoice == "quit")
                {
                    break;
                }

                // Choice Validation
                if (playerChoice != "rock" && playerChoice != "paper" && playerChoice != "scissors")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice! Please choose Rock, Paper, or Scissors.");
                    Console.ResetColor();
                    Console.WriteLine();
                    continue; // Skip the rest of the loop and restart the round
                }

                // --- 5. Generate Computer Choice ---
                int computerIndex = random.Next(0, 3);
                string computerChoice = choices[computerIndex];

                Console.WriteLine();
                Console.WriteLine($"-> You chose: {char.ToUpper(playerChoice[0]) + playerChoice.Substring(1)}");
                Console.WriteLine($"-> Computer chose: {char.ToUpper(computerChoice[0]) + computerChoice.Substring(1)}");

                // --- 6. Compare Choices & Determine Results ---
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

                // --- 7. Output Stats ---
                double winRate = roundsPlayed > 0 ? ((double)totalWins / roundsPlayed) * 100 : 0;

                Console.WriteLine("\n--- CURRENT STATISTICS ---");
                Console.WriteLine($"Wins: {totalWins} | Losses: {totalLosses} | Draws: {totalDraws}");
                Console.WriteLine($"Win Rate: {winRate:F1}%");
                Console.WriteLine("--------------------------\n");

                // Check if bankrupt
                if (playerMoney <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Game Over! You have run out of money.");
                    Console.ResetColor();
                }
            }

            // --- 8. Final End Game Output ---
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
    }
}