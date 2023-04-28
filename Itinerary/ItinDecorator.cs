namespace TripReservation.Itinerary;

public class ItinDecorator : Itinerary
{
    public static Trip _trip;
    private string componentDecor = "";
    public Itinerary itinerary;

    public ItinDecorator(Itinerary itin)
    {
        itinerary = itin;
    }

    public void getTrip(Trip trip)
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