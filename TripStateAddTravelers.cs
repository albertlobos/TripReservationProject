namespace TripReservation;

public class TripStateAddTravelers : TripState
{
    private Trip _trip;
    public TripStateAddTravelers(Trip trip)
    {
        _trip = trip;
    }

    public override Status Execute(TripContext context)
    {
        throw new NotImplementedException();
    }
}