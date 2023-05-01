using TripReservation.ItineraryFiles;
using TripReservation.Json_XML;

namespace TripReservation;

internal static class Program
{
    private static void Main()
    {
        /*
         * Main will go through the first UI flow, Agent Login
         */
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
        
        /*
         * After agent login, the flow will ask if you would like to create a New Trip. You enter Y if yes or N for no
         */
        Console.WriteLine("Would you like to create a brand new trip? Y/N");
        while (true)
        {
            var newOrList = Console.ReadLine()?.ToUpper();
            Console.WriteLine();
            if (newOrList == "Y")
            {
                CreatingTripView(Convert.ToInt32(agentLogIn), Agent.GetInstance());
                break;
            }
            if (newOrList == "N")
            {
                break;
            }

            Console.WriteLine("Wrong input, enter either Y or N");

        }

        /*
         * This boolean variable quit will be set to true and exit the following do-while loop if the agent
         * decides to quit the program after listing the trips.
         */
        var quit = false;
        
        /*
         * This do-while loop will list the agent's trips, and then ask for an input with Y meaning you want to
         * continue wokring on a trip, and N being you want to quit the program. You enter new if you would like to
         * create a brand new trip which will take you through the CreateTripView() method.
         */
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
            var answer = Console.ReadLine()?.ToUpper();
            switch (answer)
            {
                case "Y":
                {
                    Console.WriteLine("Which trip would you like to work on?");
                    var choice = Convert.ToInt32(Console.ReadLine());
                    ContinueTrip(Trip.AllTrips?[choice - 1]);
        
                    //Gotta put stuff here
                    break;
                }
                case "NEW":
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

    /*
     * CreateItinerary will handled creating the itinerary if the trip has a status of complete.
     * It will make use of the Decorator and Factory
     */
    private static void CreateItinerary(Trip trip)
    {
        Console.WriteLine("Creating The Itinerary ... ");
        ItineraryFactory.Get(trip);
        Console.WriteLine();
        
        var itinerary = new Itinerary(trip);
        var itin = new ItinDecorator(itinerary);
        var itin2 = new ItinDestination(itin);
        var itin3 = new ItinBooking(itin2);
        var itin4 = new ItinPerson(itin3);
        var itin5 = new ItinBilling(itin4);
        itin5.Output(trip);
        
        Console.WriteLine();
        Console.WriteLine("Press any button to continue ...");
        Console.ReadLine();

        
    }

    /*
     * This will take you through creating a trip from where you left off. It will also create the itinerary if it
     * sees that it has a status of complete.
     */
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
            Console.WriteLine("You have just finished the " + currentStatus + " state, Would you like to move on?  Y/N/quit");
            Console.WriteLine();
            while (true)
            {
                if (Console.ReadLine()?.ToUpper() == "Y")
                {
                    break;
                }
                if (Console.ReadLine()?.ToUpper() == "N")
                {
                    Trip.AllTrips.Insert(trip.TripId - 1, trip);
                    return;
                }

                Console.WriteLine("Enter either Y or N");
            }
 
        }

        Trip.AllTrips.Insert(trip.TripId - 1, trip);
        Console.WriteLine("You have completed the trip!");
        Console.WriteLine("We will take you back to the list of trips");
        Console.WriteLine();
    }

    /*
     * This will take you through creating the very first trip as soon as you log into an agent. The UI flow
     * goes from logging in to automatically creating a new trip. CreatingTripView handles this first creating new trip.
     * After you quit that, control will go to ContinueTrip() method.
     */
    private static void CreatingTripView(int num, Agent agent)
    {
        Console.WriteLine();
        Console.WriteLine("Hello Agent #" + num + " !!!");
        Console.WriteLine("****************************************");
        Console.WriteLine("Creating a new Trip ....");
        Console.WriteLine("****************************************");
        Console.WriteLine("When will the start day of the trip be?");
        var startDate = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("****************************************");
        Console.WriteLine("When will the end day of the trip be?");
        var endDate = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("****************************************");
        Console.WriteLine("What time ill the trip start?");
        var startTime = Console.ReadLine();
        Console.WriteLine();
        var newTrip = new Trip()
        {
            StartTime = startTime,
            StartDate = startDate,
            EndDate = endDate
        };
        var context = new TripContext(newTrip);
        context.Execute();
        Console.WriteLine();
        Console.WriteLine("A new Trip has been created, would you like to continue creating the trip?");
        Console.WriteLine("Enter Y for yes or N for no, you may also quit now.");
        var input = Console.ReadLine();
        Console.WriteLine();


        //This will trigger TripStateAddTravelers
        switch (input?.ToUpper())
        {
            case "Y":
                context.Execute();
                break;
            case "N":
                Trip.AddTrip(newTrip);
                return;
            case "QUIT":
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


    /*
     * This will list all trh trips saved to the agent.
     */
    private static void ListAgentTripsView()
    {
        Console.WriteLine("This is Agents Trips Saved");
        Console.WriteLine("**************************");
        Trip.PrintTrips();
        Console.WriteLine("**************************");
    }

    /*
     * This handles the agent log in. The agent is number 1, 2, and 3. You enter the number corresponding to the agent
     * you want to log in as.
     */
    private static int AgentLogIn()
    {
        Console.WriteLine();
        Console.WriteLine("****************************************");
        Console.WriteLine("Welcome to the Trip reservation System!!");
        Console.WriteLine("****************************************");
        Console.WriteLine("•Agent 1");
        Console.WriteLine("•Agent 2");
        Console.WriteLine("•Agent 3");
        Console.WriteLine();
        Console.WriteLine("Choose from the follow Agents to log in as, ");
        Console.WriteLine("Just enter the number corresponding to the agent");
        do
        {
            var choice = Console.ReadLine();
            Console.WriteLine();

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


}