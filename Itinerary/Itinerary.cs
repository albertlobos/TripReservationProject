namespace TripReservation.Itinerary;

public class Itinerary : ItinComponent
{
    public Trip _trip;
    
    
    public void getTrip(Trip trip)
    {
        _trip = trip;
    }

    public void Output()
    {
        Console.WriteLine("itinerary by " +"" + "\n"+ _trip.Note);
        
    }
}