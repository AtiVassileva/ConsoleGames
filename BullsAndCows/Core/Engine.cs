using System;
using BullsAndCows.Common;
using BullsAndCows.Models;

namespace BullsAndCows.Core
{
    public class Engine
    {
        private Player firstPlayer;
        private Player secondPlayer;

        public void Run()
        {
            ValidatePlayers();

            StartGame();
        }

        private void StartGame()
        {
            while (true)
            {
                Console.Write(GlobalConstants.MakeAGuess, this.firstPlayer.Name);
                var firstPlayerGuess = TryParseNumberInput(Console.ReadLine());

                Console.WriteLine(this.firstPlayer.MakeAGuess(firstPlayerGuess, secondPlayer.MagicNumber));

                if (this.firstPlayer.IsWinner)
                {
                    break;
                }

                Console.Write(GlobalConstants.MakeAGuess, this.secondPlayer.Name);
                var secondPlayerGuess = TryParseNumberInput(Console.ReadLine());

                Console.WriteLine(this.secondPlayer.MakeAGuess(secondPlayerGuess, this.firstPlayer.MagicNumber));

                if (this.secondPlayer.IsWinner)
                {
                    break;
                }
            }
        }

        private void ValidatePlayers()
        {
            Console.Write(GlobalConstants.FirstPlayerName);
            var firstPlayerName = Console.ReadLine();

            Console.Write(GlobalConstants.PlayerNumber, firstPlayerName);
            Console.ForegroundColor = ConsoleColor.White;
            
            var firstNumber = TryParseNumberInput(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Black;

            this.firstPlayer = new Player(firstPlayerName, firstNumber);
            
            Console.Write(GlobalConstants.SecondPlayerName);
            var secondPlayerName = Console.ReadLine();

            Console.Write(GlobalConstants.PlayerNumber, secondPlayerName);
            Console.ForegroundColor = ConsoleColor.White;

            var secondNumber = TryParseNumberInput(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Black;

            this.secondPlayer = new Player(secondPlayerName, secondNumber);

        }

        private static int TryParseNumberInput(string input)
        {
            Console.ForegroundColor = ConsoleColor.Black;

            if (input.StartsWith('0'))
            {
                throw new InvalidOperationException(ExceptionMessages.NumberCannotContainZero);
            }
            var hasParsed = int.TryParse(input, out var result);

            if (!hasParsed)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidNumberFormat);
            }

            if (result.ToString().Length != GlobalConstants.NumberLength)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidNumberLength);
            }
            return result;
        }

    }
}
