
namespace TripReservation;
public class Agent
{
	private static Agent? _agent = null;

	public static Agent? GetInstance()
	{
		lock (typeof(Agent))
		{
			if (_agent == null)
			{
				_agent = new Agent();
			}
			return _agent;
		}
	}
}

// public class Agent {
//
// 	public static Agent agent = null;
// 	public static synchronized Agent getInstance() 
// 	{
// 		if(agent == null) 
// 		{
// 			agent = new Agent();
// 		}
// 		return agent;
// 	}
// }

