using TripReservation.Itinerary;

namespace TripReservation.ItineraryFiles;

public class ItinBilling : ItinDecorator
{
    private readonly string Billingdecor = "\nTotal: " + _trip.Amount + "\n";


    public ItinBilling(ItineraryFiles.ItinComponent itin) : base(itin)
    {
    }


    public void Output()
    {
        base.Output();
        Console.WriteLine(Billingdecor);
    }
}