namespace TripReservation;

public class TripStateCreate : TripState
{
    

    public override Status Execute(TripContext context)
    {
        Console.WriteLine("Hello you Executed the TripState Create");
        context.State = new TripStateAddTravelers();
        return Status.AddTravelers;
    }
}