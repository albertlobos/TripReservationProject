using TripReservation.ItineraryFiles;

namespace TripReservation.ItineraryFiles;

public class ItinDestination : ItinComponent
{
    //private readonly string Destinationdecor = "\nDestination: " + _trip.Destination + "\n";
    protected readonly ItinComponent itin;

    public ItinDestination(ItineraryFiles.ItinComponent itin)
    {
        this.itin = itin;
    }


    public void Output(Trip trip)
    {
        this.itin.Output(trip);
        Console.WriteLine("****************************************\nDestination: " + trip.Destination + "\n");
    }
}