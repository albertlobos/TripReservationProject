namespace TripReservation.TripStates;

public class TripStateComplete : TripState
{
    public override Status Execute(TripContext context)
    {
        Trip.AddTrip(context.Trip);
        Console.WriteLine("Complete !!");
        return Status.Complete;
    }
}