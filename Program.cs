using System.Text.Json;

namespace TripReservation;

internal static class Program
{
    private static void Main()
    {
        AgentLogIn();
    }

    private static void AfterAgentLogin(int num, Agent agent)
    {
        Console.WriteLine();
        Console.WriteLine("Hello Agent #" + num + " !!!");
        Console.WriteLine("Creating a new Trip ....");
        var newTrip = new Trip();
        var context = new TripContext(newTrip);
        context.Execute();
        Console.WriteLine();
        Console.WriteLine("A new Trip has been created, would you like to continue creating the trip?");
        Console.WriteLine("Enter Y for yes or N for no, you may also quit now.");
        var input = Console.ReadLine();

        switch (input)
        {
            case "Y":
                Console.WriteLine("Yes");
                context.Execute();
                break;
            case "N":
                Console.WriteLine("No");
                Trip.AddTrip(newTrip);

                break;
            case "quit":
                Console.WriteLine("quit");
                break;
        }
    }

    private static void AgentLogIn()
    {
        Console.WriteLine("****************************************");
        Console.WriteLine("Welcome to the Trip reservation System!!");
        Console.WriteLine("****************************************");
        Console.WriteLine();
        Console.WriteLine("");
        Console.WriteLine("•Agent 1");
        Console.WriteLine("•Agent 2");
        Console.WriteLine("•Agent 3");
        Console.WriteLine("Choose from the follow Agents to log in as, ");
        Console.WriteLine("just enter the number corresponding to the agent");
        var choice = Console.ReadLine();

        do
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Logging in as Agent 1...");
                    AfterAgentLogin(Convert.ToInt32(choice), Agent.GetInstance());
                    break;
                case "2":
                    Console.WriteLine("Logging in as Agent 2...");
                    break;
                case "3":
                    Console.WriteLine("logging in as Agent 3...");
                    break;
            }

            Console.WriteLine("Choose a valid choice, either 1, 2, or 3");
        } while (true);
    }

    private static void QuickMenu()
    {
        var quit = false;
        var newTrip = new Trip();
        Trip.AddTrip(newTrip);
        var context = new TripContext(newTrip);

        do
        {
            var jsonString = JsonSerializer.Serialize(newTrip);
            Console.WriteLine("Current Trip in Json: ");
            Console.WriteLine(jsonString);
            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("Continue creating trip? Y/N");
            var answer = Console.ReadLine();
            Console.WriteLine();
            if (answer == "Y") context.Execute();
            else quit = true;
        } while (quit == false);

        Console.WriteLine("Done with this");
    }
}