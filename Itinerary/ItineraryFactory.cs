namespace TripReservation.Itinerary;

public class ItineraryFactory
{
    private Trip _trip;
    //private Trip _state;

    public void Get(Trip trip)
    {
        _trip = trip;

        Console.WriteLine(TripCanProduceItinerary(_trip)
            ? "Itinerary is ready!"
            : "Trip Status is not complete!");
    }

    public Trip Trip
    {
        get => _trip;
        set => _trip = value ?? throw new ArgumentNullException(nameof(value));
    }

    private static bool TripCanProduceItinerary(Trip trip)
    {
        return trip.Status == Status.Complete;
    }
}