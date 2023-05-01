using TripReservation.ItineraryFiles;

namespace TripReservation.Itinerary;

public class ItinDestination : ItinDecorator
{
    private readonly string Destinationdecor = "\nDestination: " + _trip.Destination + "\n";


    public ItinDestination(ItineraryFiles.ItinComponent itin) : base(itin)
    {
    }


    public void Output()
    {
        base.Output();
        Console.WriteLine(Destinationdecor);
    }
}