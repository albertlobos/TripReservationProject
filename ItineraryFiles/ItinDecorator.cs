namespace TripReservation.ItineraryFiles;

public class ItinDecorator : Itinerary
{
    protected static Trip _trip;
    private string componentDecor = "";
    private Itinerary itinerary;

    protected ItinDecorator(Itinerary itin) : base(_trip)
    {
        itinerary = itin;
    }

    public void GetTrip(Trip trip)
    {
        _trip = trip;
    }

    public void Output()
    {
        //componentDecor = "Itinerarary by " ;

        //componentDecor += ItinDestination.destDecor();
        //componentDecor += ItinBooking.bookDecor();

        itinerary.Output();
    }
}