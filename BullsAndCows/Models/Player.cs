﻿using System;
using System.Linq;
using System.Text;
using BullsAndCows.Common;
using System.Collections.Generic;

namespace BullsAndCows.Models
{
    public class Player
    {
        private string name;
        private int magicNumber;

        public Player(string name, int magicNumber)
        {
            this.Name = name;
            this.MagicNumber = magicNumber;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidOperationException(ExceptionMessages.InvalidName);
                }

                this.name = value;
            }
        }

        public int MagicNumber
        {
            get => this.magicNumber;
            private set
            {
                if (value.ToString().Length != GlobalConstants.NumberLength)
                {
                    throw new InvalidOperationException(ExceptionMessages.InvalidNumberLength);
                }

                if (value.ToString().StartsWith('0'))
                {
                    throw new InvalidOperationException(ExceptionMessages.NumberCannotContainZero);
                }

                this.CheckForSameNumber(value);
                this.magicNumber = value;
            }
        }


        public bool IsWinner { get; private set; }
        public int Cows { get; private set; }
        public int Bulls { get; private set; }

        public string MakeAGuess(int guess, int actualNumber)
        {
            if (guess == actualNumber)
            {
                this.IsWinner = true;
                return OutputMessages.WinnerMessage;
            }

            var guessArray = guess.ToString().ToCharArray();
            var actualArray = actualNumber.ToString().ToCharArray();

            this.Bulls = 0;
            this.Cows = 0;

            for (var i = 0; i < guessArray.Length; i++)
            {
                if (guessArray[i] == actualArray[i])
                {
                    this.Bulls++;
                    continue;
                }

                if (actualArray.Any(c => c == guessArray[i]))
                {
                    this.Cows++;
                }
            }

            if (this.Cows == 0 && this.Bulls == 0)
            {
                return OutputMessages.NoMatchesGuess;
            }

            var sb = new StringBuilder();

            if (this.Cows > 0)
            {
                sb.AppendLine(string.Format(OutputMessages.CowsMessage, this.Cows));
            }

            if (this.Bulls > 0)
            {
                sb.AppendLine(string.Format(OutputMessages.BullsMessage, this.Bulls));
            }

            return sb.ToString().TrimEnd();
        }

        private void CheckForSameNumber(int value)
        {
            var allDigits = new List<char>();

            foreach (var digit in value.ToString())
            {
                if (allDigits.Contains(digit))
                {
                    throw new InvalidOperationException(ExceptionMessages.CannotHaveSameDigitInNumber);
                }

                allDigits.Add(digit);
            }
        }
    }
}
