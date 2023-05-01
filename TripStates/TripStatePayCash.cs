namespace TripReservation.TripStates;

public class TripStatePayCash : TripState
{
    public override Status Execute(TripContext context)
    {
        return PayCash(context);
    }

    private static Status PayCash(TripContext context)
    {
        var amountDue = context.Trip.Amount;
        do
        {
            Console.WriteLine("**************************");
            Console.WriteLine("****   Cash Payment   ****");
            Console.WriteLine("**************************\n");
            Console.WriteLine("You Owe: " + amountDue);
            Console.WriteLine("How much will you be paying in cash today?");
            Console.WriteLine("Enter the exact amount: ");
            var amountPaying = Console.ReadLine();
            Console.WriteLine();
            var payment = Convert.ToDecimal(amountPaying);

            if (amountPaying == "quit")
            {
                Trip.AllTrips.Insert(context.Trip.TripId - 1, context.Trip);
                return Status.PayCash;
            }

            if (payment == amountDue)
            {
                context.Trip.Payment = new CashPayment(payment);
                Console.WriteLine("You have paid for the trip!");
                context.State = new TripStateAddNote();
                return Status.AddNote;
            }

            Console.WriteLine("Payment must be exact amount due.");
        } while (true);
    }
}