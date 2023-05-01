using TripReservation.ItineraryFiles;

namespace TripReservation.ItineraryFiles;

public class ItinBooking : ItinComponent
{
    
    protected readonly ItinComponent itin;

    public ItinBooking(ItineraryFiles.ItinComponent itin)
    {
        this.itin = itin;
    }


    public void Output(Trip trip)
    {
        this.itin.Output(trip);
        Console.WriteLine( "****************************************\nBooking Time is: " + trip.StartDate + "\nEnd time is: " + trip.EndDate + "\n");
    }

    
}