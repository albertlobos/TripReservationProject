namespace TripReservation.ItineraryFiles;

public class ItinDecorator : ItinComponent
{
    protected static Trip _trip;
    private string componentDecor = "";
    private ItinComponent itinerary;

    public ItinDecorator(ItinComponent itin)
    {
        this.itinerary = itin;
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

        this.itinerary.Output();
    }
}