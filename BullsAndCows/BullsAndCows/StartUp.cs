using System;
using BullsAndCows.Core;
using BullsAndCows.Common;

namespace BullsAndCows
{
    public class StartUp
    {
        public static void Main()
        {
            var engine = new Engine();

            try
            {
                engine.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                AskForAnotherRound(engine);
            }
        }

        private static void AskForAnotherRound(Engine engine)
        {
            Console.WriteLine(ExceptionMessages.GameOverNoWinner);

            Console.Write(GlobalConstants.PlayAnotherRound);
            var answer = Console.ReadLine();

            if (answer?.ToLower() == GlobalConstants.PositiveAnswer)
            {
                engine.Run();
            }
            else
            {
                Console.WriteLine(GlobalConstants.GoodbyeGreeting);
                Environment.Exit(0);
            }
        }
    }
}
