namespace TripReservation.TripStates;

public class TripStateChoosePaymentType : TripState
{
    public override Status Execute(TripContext context)
    {
        return ChoosePayment(context);
    }

    private static Status ChoosePayment(TripContext context)
    {
        do
        {
            Console.WriteLine("***************************");
            Console.WriteLine("*** Choose Payment Type ***");
            Console.WriteLine("***************************\n");
            Console.WriteLine("Are You Paying Cash or Check?\n" +
                              "Enter \"cash\" for cash or \"check\" for check or \"quit\" to quit");
            var answer = Console.ReadLine();
            switch (answer)
            {
                case "cash":
                    context.State = new TripStatePayCash();
                    return Status.PayCash;
                case "check":
                    context.State = new TripStatePayCheck();
                    return Status.PayCheck;
                case "quit":
                    Trip.AddTrip(context.Trip);
                    return Status.ChoosePayment;
                default:
                    Console.WriteLine("Wrong input, Try Again");
                    break;
            }
        } while (true);
    }
}