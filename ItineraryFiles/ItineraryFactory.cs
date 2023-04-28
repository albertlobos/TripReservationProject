namespace TripReservation.ItineraryFiles;

public class ItineraryFactory
{
    private Trip _trip;
    //private Trip _state;

    public static void Get(Trip trip)
    {

        Console.WriteLine(TripCanProduceItinerary(trip)
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