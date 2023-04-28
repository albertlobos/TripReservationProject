namespace TripReservation.TripStates;

public class TripStateAddDestinations : TripState
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
            Console.WriteLine("*************************");
            Console.WriteLine("*** Add a destination ***");
            Console.WriteLine("*************************\n");
            Console.WriteLine("*************************");
            Console.WriteLine("1.Atlanta");
            Console.WriteLine("2.Los Angeles");
            Console.WriteLine("3.New York");
            Console.WriteLine("4.Dallas");
            Console.WriteLine("5.Denver");
            Console.WriteLine("*************************");
            Console.WriteLine("Pick from the following destinations, simply enter the number to the location");
            var destination = Console.ReadLine();
            switch (destination)
            {
                case "Quit":
                    return Status.AddDestinations;
                case "1":
                    context.Trip.Amount = (decimal?)(543.99 * context.Trip.ListOfPeople!.Count);
                    context.Trip.Destination = "Atlanta";
                    break;
                case "2":
                    context.Trip.Amount = (decimal?)(769.99 * context.Trip.ListOfPeople!.Count);
                    context.Trip.Destination = "Los Angeles";
                    break;
                case "3":
                    context.Trip.Amount = (decimal?)(1083.99 * context.Trip.ListOfPeople!.Count);
                    context.Trip.Destination = "New York";
                    break;
                case "4":
                    context.Trip.Amount = (decimal?)(382.99 * context.Trip.ListOfPeople!.Count);
                    context.Trip.Destination = "Dallas";
                    break;
                case "5":
                    context.Trip.Amount = (decimal?)(297.99 * context.Trip.ListOfPeople!.Count);
                    context.Trip.Destination = "Denver";
                    break;
            }

            Console.WriteLine("Would You like to Change your Destination? Y/N");
            var answer = Console.ReadLine();
            if (answer == "quit") return Status.AddDestinations;
            if (answer == "N") done = true;
        } while (done == false);

        context.State = new TripStateChoosePaymentType();
        return Status.ChoosePayment;
    }
}