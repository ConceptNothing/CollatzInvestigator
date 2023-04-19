using ConsoleUi.Core;
using ConsoleUi.Infrastructure;
using SequenceCalculator.Core;
using SequenceCalculator.Infrastructure;

namespace CollatzInvestigator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICollatzInvestigator calculator = new CollatzCalculator();
            IUserInterface userInterface = new UserInterface(calculator);
            userInterface.Run();
        }
    }
}