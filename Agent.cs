namespace TripReservation;

/*
 * This is the Agent Class that uses the Singleton Pattern
 */
public class Agent
{
    private static Agent? _agent;

    public static Agent? GetInstance()
    {
        lock (typeof(Agent))
        {
            if (_agent == null) _agent = new Agent();
            return _agent;
        }
    }
}
