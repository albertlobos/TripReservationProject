namespace TripReservation.TripStates;

public class TripStateAddTravelers : TripState
{
    public override Status Execute(TripContext context)
    {
        return AddDestinations(context);
    }

    private static Status AddDestinations(TripContext context)
    {
        var done = false;
        do
        {
            Console.WriteLine("************************");
            Console.WriteLine("**** Add a traveler ****");
            Console.WriteLine("************************");
            Console.WriteLine("Enter First Name: ");
            var firstName = Console.ReadLine();
            Console.WriteLine();
            if (firstName == "quit")
            {
                Trip.AllTrips.Insert(context.Trip.TripId - 1, context.Trip);
                return Status.AddTravelers;
            }

            Console.WriteLine("Enter Last Name: ");
            var lastName = Console.ReadLine();
            Console.WriteLine();
            if (lastName == "quit")
            {
                Trip.AllTrips.Insert(context.Trip.TripId - 1, context.Trip);
                return Status.AddTravelers;
            }

            Console.WriteLine("Enter Phone: ");
            var phoneNumber = Console.ReadLine();
            Console.WriteLine();
            if (phoneNumber == "quit")
            {
                Trip.AllTrips.Insert(context.Trip.TripId - 1, context.Trip);
                return Status.AddTravelers;
            }

            Console.WriteLine("Enter Age: ");
            var ageString = Console.ReadLine();
            Console.WriteLine();
            if (ageString == "quit")
            {
                Trip.AllTrips.Insert(context.Trip.TripId - 1, context.Trip);
                return Status.AddTravelers;
            }

            var age = Convert.ToInt32(ageString);

            var newPerson = new Person(firstName, lastName, phoneNumber, age);
            context.Trip.ListOfPeople!.Add(newPerson);
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("Do you want to add another traveler?");
                Console.WriteLine("Enter Y for yes and N for no or \"quit\" to quit");
                var answer = Console.ReadLine()?.ToUpper();
                if (answer == "QUIT")
                    return Status.AddTravelers;
                if (answer == "N")
                {
                    done = true;
                    break;
                }
                if (answer == "Y")
                {
                    break;
                }

                Console.WriteLine("Enter either Y/N/quit");
                Console.WriteLine();
            }
            
        } while (done == false);

        context.State = new TripStateAddDestinations();
        return Status.AddDestinations;
    }
}