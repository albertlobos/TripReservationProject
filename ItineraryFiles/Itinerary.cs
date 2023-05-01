namespace TripReservation.ItineraryFiles;

public class Itinerary : ItinComponent
{
    private Trip _trip;

    public Itinerary(Trip trip)
    {
        _trip = trip;
    }

    protected Itinerary()
    {
        throw new NotImplementedException();
    }
    
    public void Output(Trip trip)
    {
        Console.WriteLine("itinerary by " + "" + "\n" + _trip.Note);
    }

    public Trip Trip
    {
        get => _trip;
        set => _trip = value ?? throw new ArgumentNullException(nameof(value));
    }
}