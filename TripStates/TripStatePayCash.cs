namespace TripReservation.TripStates;

public class TripStatePayCash : TripState
{
    public override Status Execute(TripContext context)
    {
        do
        {
            Console.WriteLine("**************************");
            Console.WriteLine("****   Cash Payment   ****");
            Console.WriteLine("**************************\n");
            Console.WriteLine("How much will you be paying in cash?");
            
            
            
            
        } while (true);
    }
}