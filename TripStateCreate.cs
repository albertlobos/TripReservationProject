namespace TripReservation;

public class TripStateCreate : TripState
{
    private Trip _trip;

    public TripStateCreate(Trip trip) 
    {
        _trip = trip;
    }

    public override Status Execute(TripContext context)
    {
        Console.WriteLine("Hello you Executed the TripState Create");
        context.State = new TripStateAddTravelers(context.Trip);
        return Status.AddTravelers;
    }
}