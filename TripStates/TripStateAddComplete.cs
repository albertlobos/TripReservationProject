namespace TripReservation.TripStates;

public class TripStateComplete : TripState
{
    public override Status Execute(TripContext context)
    {
        Console.WriteLine("Complete !!");
        return Status.Complete;
    }
}