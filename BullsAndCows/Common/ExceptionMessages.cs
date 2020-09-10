namespace BullsAndCows.Common
{
    public static class ExceptionMessages
    {
        public static string InvalidName =
            "Name cannot be null or whitespace!";

        public static string InvalidNumberLength =
            "Number length should be exactly 4 characters!";

        public static string InvalidNumberFormat =
            "Invalid input format! Your number should be a 4-digit integer!";

        public static string GameOverNoWinner =
            "Game over! No winner recorded!";

        public static string NumberCannotContainZero =
            "Your number cannot start with Zero! (0)";

        public static string CannotHaveSameDigitInNumber =
            "You cannot have the same digit twice in your number!";

    }
}
