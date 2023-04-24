namespace TripReservation;

public class TripStateCreate : TripState
{
    private Trip _trip;

    public TripStateCreate(Trip trip) 
    {
        _trip = trip;
    }

    public override Status Execute()
    {
        Console.WriteLine("Hello you Executed the TripState Create");
        return Status.AddTravelers;
    }
}