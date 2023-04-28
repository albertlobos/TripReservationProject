using System.Text.Json;
using TripReservation.Json_XML;

namespace TripReservation;

internal static class Program
{
    private static void Main()
    {
        
            var agentLogIn = AgentLogIn();
            switch (agentLogIn)
            {
                case 1:
                    if(Trip.AllTrips == null)
                        Loader.JsonLoader();
                    break;
                case 2:
                    if(Trip.AllTrips == null)
                        Loader.JsonLoader();
                    break;
                case 3:
                    if(Trip.AllTrips == null)
                        Loader.JsonLoader();
                    break;
            }

            CreatingTripView(Convert.ToInt32(agentLogIn), Agent.GetInstance());

            bool quit = false;
            do
            {
            ListAgentTripsView();
            Console.WriteLine();
            quit = true;




            } while (quit!);


    }

    private static void CreatingTripView(int num, Agent agent)
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
        
        
        //This will trigger TripStateAddTravelers
        switch (input)
        {
            case "Y":
                Console.WriteLine("Yes");
                context.Execute();
                break;
            case "N":
                Console.WriteLine("No");
                Trip.AddTrip(newTrip);
                return;
            case "quit":
                Console.WriteLine("quit");
                Trip.AddTrip(newTrip);
                return;
        }
        
        if (context.Trip.Status == Status.AddTravelers) return;
        
        //This will trigger the TripStateAddDestination
        Console.WriteLine();
        Console.WriteLine("You have added travelers to your trip!");
        Console.WriteLine("Would you like to keep going? Enter Y for yes or N for no, you may also quit now.");
        input = Console.ReadLine();
        
        switch (input)
        {
            case "Y":
                Console.WriteLine("Yes");
                context.Execute();
                break;
            case "N":
                Console.WriteLine("No");
                Trip.AddTrip(newTrip);
                return;
            case "quit":
                Console.WriteLine("quit");
                Trip.AddTrip(newTrip);
                return;
        }

        if (context.Trip.Status == Status.AddDestinations) return;
        
        
        //This will trigger the TripStateChoosePayment
        
        Console.WriteLine();
        Console.WriteLine("You have added Destinations to your trip!");
        Console.WriteLine("Would you like to keep going? Enter Y for yes or N for no, you may also quit now.");
        input = Console.ReadLine();
        
        switch (input)
        {
            case "Y":
                Console.WriteLine("Yes");
                context.Execute();
                break;
            case "N":
                Console.WriteLine("No");
                Trip.AddTrip(newTrip);
                return;
            case "quit":
                Console.WriteLine("quit");
                Trip.AddTrip(newTrip);
                return;
        }

        if (context.Trip.Status == Status.ChoosePayment) return;

        if (context.Trip.Status == Status.PayCash)
        {
            Console.WriteLine();
            Console.WriteLine("You have chosen Cash Payment to your trip!");
            Console.WriteLine("Would you like to keep going? Enter Y for yes or N for no, you may also quit now.");
            input = Console.ReadLine();
            switch (input)
            {
                case "Y":
                    Console.WriteLine("Yes");
                    context.Execute();
                    break;
                case "N":
                    Console.WriteLine("No");
                    Trip.AddTrip(newTrip);
                    return;
                case "quit":
                    Console.WriteLine("quit");
                    Trip.AddTrip(newTrip);
                    return;
            }
            
        }
        
        if(context.Trip.Status == Status.PayCheck)
        {
            Console.WriteLine();
            Console.WriteLine("You have chosen Check Payment to your trip!");
            Console.WriteLine("Would you like to keep going? Enter Y for yes or N for no, you may also quit now.");
            input = Console.ReadLine();
            switch (input)
            {
                case "Y":
                    Console.WriteLine("Yes");
                    context.Execute();
                    break;
                case "N":
                    Console.WriteLine("No");
                    Trip.AddTrip(newTrip);
                    return;
                case "quit":
                    Console.WriteLine("quit");
                    Trip.AddTrip(newTrip);
                    return;
            }
            
        }
        
        if(context.Trip.Status is Status.PayCash or Status.PayCheck) return;
        
        
        
        //This will trigger the note stage
        Console.WriteLine();
        Console.WriteLine("You have paid for your trip! You may now add a note to the trip!");
        Console.WriteLine("Would you like to keep going? Enter Y for yes or N for no, you may also quit now.");
        input = Console.ReadLine();
        switch (input)
        {
            case "Y":
                Console.WriteLine("Yes");
                context.Execute();
                break;
            case "N":
                Console.WriteLine("No");
                Trip.AddTrip(newTrip);
                return;
            case "quit":
                Console.WriteLine("quit");
                Trip.AddTrip(newTrip);
                return;
        }
            
        if(context.Trip.Status == Status.AddNote) return;
        
        //This will trigger the completing stage
        Console.WriteLine();
        Console.WriteLine("You have added the note to the trip! ");
        Console.WriteLine("Would you like to keep complete the trip? Enter Y for yes or N for no, " +
                          "\nyou may also quit now.");
        input = Console.ReadLine();
        switch (input)
        {
            case "Y":
                Console.WriteLine("Yes");
                context.Execute();
                break;
            case "N":
                Console.WriteLine("No");
                Trip.AddTrip(newTrip);
                return;
            case "quit":
                Console.WriteLine("quit");
                Trip.AddTrip(newTrip);
                return;
        }
        
        Console.WriteLine();
        Console.WriteLine("You have completed your trip!! Your trips you are working on will now be shown.");
        Console.WriteLine();
    }
    

    //Maybe a bool to see if you want to restart or not
    public static void ListAgentTripsView()
    {
        Console.WriteLine("This is Agents Trips Saved");
        Console.WriteLine("**************************");
        Trip.PrintTrips();
        
    }

    private static int AgentLogIn()
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
                    // Loader.JsonLoader();
                    // CreatingTripView(Convert.ToInt32(choice), Agent.GetInstance());
                    return 1;
                case "2":
                    Console.WriteLine("Logging in as Agent 2...");
                    return 2;
                case "3":
                    Console.WriteLine("logging in as Agent 3...");
                    return 3;
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