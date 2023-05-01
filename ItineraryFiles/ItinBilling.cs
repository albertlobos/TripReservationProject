using TripReservation.ItineraryFiles;

namespace TripReservation.ItineraryFiles;

public class ItinBilling : ItinComponent
{
    
    protected readonly ItinComponent itin;

    public ItinBilling(ItineraryFiles.ItinComponent itin)
    {
        this.itin = itin;
    }


    public void Output(Trip trip)
    {
        this.itin.Output(trip);
        Console.WriteLine("****************************************\nTotal Paid: " + trip.Amount + " in  " + trip.Payment + "\n");
    }
}