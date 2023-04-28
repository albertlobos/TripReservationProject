namespace TripReservation.Itinerary;

public class ItineraryFactory
{
    
    public Trip _trip;
    //private Trip _state;

    public void Get(Trip trip)
    {
        _trip = trip;

        Console.WriteLine(TripCanProduceItinerary(_trip) == true
            ? "Itinerary is ready!"
            : "Trip Status is not complete!");
    }
    
    public Boolean TripCanProduceItinerary(Trip trip)
    { 
            if(trip.Status == Status.Complete)
            {
                return true;
            }
            else
            {
                return false;
            }
    }
            
    
    
}