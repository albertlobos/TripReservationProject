namespace TripReservation;

public static class TripStateFactory
{

    public static TripState GetState(TripContext context)
    {
        
        switch (context.Trip.Status)
        {
            case Status.Create:
                return new TripStateCreate();
            case Status.AddTravelers:
                return new TripStateAddTravelers();
            case Status.AddDestinations:
                
                break;
            case Status.ChoosePayment:
                break;
            case Status.AddNote:
                break;
            case Status.Complete:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        return null;
    }
}