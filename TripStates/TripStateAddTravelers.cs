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
            Console.WriteLine("Enter First Name");
            var firstName = Console.ReadLine();
            if (firstName == "quit")
            {
                Trip.AddTrip(context.Trip);
                return Status.AddTravelers;
            }

            Console.WriteLine("Enter Last Name");
            var lastName = Console.ReadLine();
            if (lastName == "quit")
            {
                Trip.AddTrip(context.Trip);
                return Status.AddTravelers;
            }

            Console.WriteLine("Enter Phone ");
            var phoneNumber = Console.ReadLine();
            if (phoneNumber == "quit")
            {
                Trip.AddTrip(context.Trip);
                return Status.AddTravelers;
            }

            Console.WriteLine("Enter Age");
            var ageString = Console.ReadLine();
            if (ageString == "quit")
            {
                Trip.AddTrip(context.Trip);
                return Status.AddTravelers;
            }

            var age = Convert.ToInt32(ageString);

            var newPerson = new Person(firstName, lastName, phoneNumber, age);
            context.Trip.ListOfPeople!.Add(newPerson);
            Console.WriteLine();
            Console.WriteLine("Do you want to add another traveler?");
            Console.WriteLine("Enter Y for yes and N for no or \"quit\" to quit");
            var answer = Console.ReadLine();
            switch (answer)
            {
                case "quit":
                    return Status.AddTravelers;
                case "N":
                    done = true;
                    break;
            }
        } while (done == false);

        context.State = new TripStateAddDestinations();
        return Status.AddDestinations;
    }
}