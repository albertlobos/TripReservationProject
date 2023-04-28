namespace TripReservation.Itinerary;

public class ItinDecorator : Itinerary
{
    public Itinerary itinerary;
    string componentDecor = "";
    public static Trip _trip;

    public ItinDecorator(Itinerary itin)
    {
        this.itinerary = itin;

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

        this.itinerary.Output();

    }
    
}