namespace TripReservation.TripStates;

public class TripStateCreate : TripState
{
    public override Status Execute(TripContext context)
    {
        Console.WriteLine("You have successfully created a new trip");
        context.State = new TripStateAddTravelers();
        return Status.AddTravelers;
    }
}