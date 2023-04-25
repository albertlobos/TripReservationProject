namespace TripReservation;

public abstract class TripState
{
    
    public abstract Status Execute(TripContext context);
    
}