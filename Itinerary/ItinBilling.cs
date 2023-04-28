namespace TripReservation.Itinerary;

public class ItinBilling : ItinDecorator
{
    private readonly string Billingdecor = "\nTotal: " + _trip.Amount + "\n";


    public ItinBilling(Itinerary itin) : base(itin)
    {
    }


    public void Output()
    {
        base.Output();
        Console.WriteLine(Billingdecor);
    }
}