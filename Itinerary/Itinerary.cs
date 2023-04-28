namespace TripReservation.Itinerary;

public class Itinerary : ItinComponent
{
    private Trip _trip;

    public void Output()
    {
        Console.WriteLine("itinerary by " + "" + "\n" + _trip.Note);
    }

    
    public Trip Trip
    {
        get => _trip;
        set => _trip = value ?? throw new ArgumentNullException(nameof(value));
    }
}