using TripReservation.Itinerary;

namespace TripReservation.ItineraryFiles;

public class ItinBooking : ItinDecorator
{
    private readonly string Bookingdecor =
        "\nBooking Time was: " + _trip.StartDate + "\nEnd time is: " + _trip.EndDate + "\n";


    public ItinBooking(ItineraryFiles.ItinComponent itin) : base(itin)
    {
    }


    public void Output()
    {
        base.Output();
        Console.WriteLine(Bookingdecor);
    }
}