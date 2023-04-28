namespace TripReservation.Itinerary;

public class ItinBooking : ItinDecorator
{
    
    string Bookingdecor = "\nBooking Time was: " + _trip.StartDate + "\nEnd time is: " + _trip.EndDate + "\n";
    
    
    
    public ItinBooking(Itinerary itin) : base(itin)
    {
    }
    
    
    public void Output()
    {
        base.Output();
        Console.WriteLine(Bookingdecor);
    }

        
}