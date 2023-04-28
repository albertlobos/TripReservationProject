using System.Text.Json;
using System.Xml.Serialization;
using TripReservation.ItineraryFiles;
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
                Reader.JsonLoader();
                break;
            case 2:
                Reader.JsonLoader();
                break;
            case 3:
                Reader.JsonLoader();
                break;
        }
        
        CreatingTripView(Convert.ToInt32(agentLogIn), Agent.GetInstance());
        
        var quit = false;
        
        do
        {
            Writer.JsonSaveTrip();
            ListAgentTripsView();
            Console.WriteLine();
            Console.WriteLine();
            //var num = Console.ReadLine();
            //var input = Convert.ToInt32(num);
            Console.WriteLine("Would you like to work on one of these trips or start a new one?");
            Console.WriteLine("Type in either: Y/N/new");
            var answer = Console.ReadLine();
            switch (answer)
            {
                case "Y":
                {
                    Console.WriteLine("Which trip would you like to work on?");
                    var choice = Convert.ToInt32(Console.ReadLine());
                    ContinueTrip(Trip.AllTrips[choice - 1]);
        
                    //Gotta put stuff here
                    break;
                }
                case "new":
                {
                    CreatingTripView(Convert.ToInt32(agentLogIn), Agent.GetInstance());
                    Writer.JsonSaveTrip();
                    break;
                }
                case "N":
                    quit = true;
                    Writer.JsonSaveTrip();
                    break;
            }
        } while (quit == false);
        
    }

    //This will handle creating the itinerary
    private static void CreateItinerary(Trip trip)
    {
        Console.WriteLine("I the creat itinerarty method");
        ItineraryFactory.Get(trip);
       // ItineraryFiles.Itinerary itinerary = new ItineraryFiles.Itinerary(trip);
     //   itinerary.Output();
        Console.WriteLine();
      //  ItineraryFiles.Itinerary itinerary = new ItineraryFiles.Itinerary(trip);
      //  itinerary.Output();
    }

    //This will take you through the creating a trip from where ever it ended from to finish
    private static void ContinueTrip(Trip trip)
    {
        var context = new TripContext(trip);
        Trip.AllTrips.Remove(trip);

        if (trip.Status == Status.Complete)
        {
            //print itinerary
            CreateItinerary(trip);
            Trip.AllTrips.Insert(trip.TripId - 1, trip);
            return;
        }

        while (trip.Status != Status.Complete)
        {
            var currentStatus = trip.Status;
            Console.WriteLine("You are in state: " + trip.Status);
            context.Execute();
            if (trip.Status == currentStatus) return;
            Console.WriteLine("You have just finished the " + currentStatus + " state, Would you like to move on?");

            switch (Console.ReadLine())
            {
                case "Y":
                    break;
                case "N":
                    Trip.AllTrips.Insert(trip.TripId - 1, trip);
                    return;
            }
        }

        Trip.AllTrips.Insert(trip.TripId - 1, trip);
        Console.WriteLine("You have completed the trip!");
        Console.WriteLine("We will take you back to the list of trips");
        Console.WriteLine();
    }

    //This will take you through the creating a trip from new to finish
    private static void CreatingTripView(int num, Agent agent)
    {
        Console.WriteLine();
        Console.WriteLine("Hello Agent #" + num + " !!!");
        Console.WriteLine("Creating a new Trip ....");
        Console.WriteLine("When will the start day of the trip be?");
        var startDate = Console.ReadLine();
        Console.WriteLine("When will the end day of the trip be?");
        var endDate = Console.ReadLine();
        Console.WriteLine("What time ill the trip start?");
        var startTime = Console.ReadLine();
        var newTrip = new Trip()
        {
            StartTime = startTime,
            StartDate = endDate,
            EndDate = endDate
        };
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
                context.Execute();
                break;
            case "N":
                Trip.AddTrip(newTrip);
                return;
            case "quit":
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
                context.Execute();
                break;
            case "N":
                Trip.AddTrip(newTrip);
                return;
            case "quit":
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
                context.Execute();
                break;
            case "N":
                Trip.AddTrip(newTrip);
                return;
            case "quit":
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
                    context.Execute();
                    break;
                case "N":
                    Trip.AddTrip(newTrip);
                    return;
                case "quit":
                    Trip.AddTrip(newTrip);
                    return;
            }
        }

        if (context.Trip.Status == Status.PayCheck)
        {
            Console.WriteLine();
            Console.WriteLine("You have chosen Check Payment to your trip!");
            Console.WriteLine("Would you like to keep going? Enter Y for yes or N for no, you may also quit now.");
            input = Console.ReadLine();
            switch (input)
            {
                case "Y":
                    context.Execute();
                    break;
                case "N":
                    Trip.AddTrip(newTrip);
                    return;
                case "quit":
                    Trip.AddTrip(newTrip);
                    return;
            }
        }

        if (context.Trip.Status is Status.PayCash or Status.PayCheck) return;


        //This will trigger the note stage
        Console.WriteLine();
        Console.WriteLine("You have paid for your trip! You may now add a note to the trip!");
        Console.WriteLine("Would you like to keep going? Enter Y for yes or N for no, you may also quit now.");
        input = Console.ReadLine();
        switch (input)
        {
            case "Y":
                context.Execute();
                break;
            case "N":
                Trip.AddTrip(newTrip);
                return;
            case "quit":
                Trip.AddTrip(newTrip);
                return;
        }

        if (context.Trip.Status == Status.AddNote) return;

        //This will trigger the completing stage
        Console.WriteLine();
        Console.WriteLine("You have added the note to the trip! ");
        Console.WriteLine("Would you like to keep complete the trip? Enter Y for yes or N for no, " +
                          "\nyou may also quit now.");
        input = Console.ReadLine();
        switch (input)
        {
            case "Y":
                context.Execute();
                Trip.AddTrip(newTrip);
                break;
            case "N":
                Trip.AddTrip(newTrip);
                return;
            case "quit":
                Trip.AddTrip(newTrip);
                return;
        }

        Console.WriteLine();
        Console.WriteLine("You have completed your trip!! Your trips you are working on will now be shown.");
        Console.WriteLine();
    }


    //This is the ListAgentTripsView which will print out all the trips
    private static void ListAgentTripsView()
    {
        Console.WriteLine("This is Agents Trips Saved");
        Console.WriteLine("**************************");
        Trip.PrintTrips();
        Console.WriteLine("**************************");
    }

    //This is the first view where the agent will log in
    private static int AgentLogIn()
    {
        Console.WriteLine("****************************************");
        Console.WriteLine("Welcome to the Trip reservation System!!");
        Console.WriteLine("****************************************");
        Console.WriteLine("•Agent 1");
        Console.WriteLine("•Agent 2");
        Console.WriteLine("•Agent 3");
        Console.WriteLine();
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

    //This was to practice
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