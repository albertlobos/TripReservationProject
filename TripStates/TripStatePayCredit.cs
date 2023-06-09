namespace TripReservation.TripStates;

public class TripStatePayCheck : TripState
{
    public override Status Execute(TripContext context)
    {
        return PayCheck(context);
    }

    private static Status PayCheck(TripContext context)
    {
        var amountDue = context.Trip.Amount;
        do
        {
            Console.WriteLine("*************************");
            Console.WriteLine("***   Check Payment   ***");
            Console.WriteLine("*************************\n");
            Console.WriteLine("You Owe: " + amountDue);
            Console.WriteLine("How much will you be paying in check today?");
            Console.WriteLine("Enter the exact amount: ");
            var amountPaying = Console.ReadLine();
            Console.WriteLine();
            var payment = Convert.ToDecimal(amountPaying);

            if (amountPaying == "quit")
            {
                Trip.AllTrips.Insert(context.Trip.TripId - 1, context.Trip);
                return Status.PayCheck;
            }

            if (payment == amountDue)
            {
                Console.WriteLine("Enter the check number");
                var checkNum = Convert.ToInt32(Console.ReadLine());
                context.Trip.Payment = new CheckPayment(payment, checkNum);
                Console.WriteLine("You have paid for the trip!");
                context.State = new TripStateAddNote();
                return Status.AddNote;
            }

            Console.WriteLine("Payment must be exact amount due.");
        } while (true);
    }
}