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
            var amountPaying = Console.ReadLine();
            var payment = Convert.ToDecimal(amountPaying);

            if (amountPaying == "quit")
            {
                Trip.AddTrip(context.Trip);
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