using System;
using System.Collections.Generic;
using System.Text;

namespace BullsAndCows.Contracts
{
    public interface IPlayer
    {
        string Name { get; }

        int MagicNumber { get; }

        bool IsWinner { get; }

        string MakeAGuess(int guess, int actualNumber);
    } 
}
