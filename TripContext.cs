using TripReservation.TripStates;

namespace TripReservation;

/*
 * This is the TripContext class. This will hold the Trip data and the TripState.State. Depending on the state,
 * the trip context will execute a different Execute() method. We still use the same Execute() method.
 */
public class TripContext
{
    private TripState _state;
    private Trip _trip;


    public TripContext(Trip trip)
    {
        _trip = trip;
        _state = TripStateFactory.GetState(this);
    }

    public Trip Trip
    {
        get => _trip;
        set => _trip = value ?? throw new ArgumentNullException(nameof(value));
    }

    public TripState State
    {
        get => _state;
        set => _state = value ?? throw new ArgumentNullException(nameof(value));
    }

    public void ChangeState(TripState newState)
    {
        _state = newState;
    }

    /*
     * This execute() method will change its inner _state.Execute() behavior depending on the current
     * State of the trip. When Execute() is called it will trigger a state's Execute() method.
     * This state's execute() method will return a _trip.Status which will be saved to the trip itself.
     * The TripContext.State is changed while inside the Execute method of the respected State.
     */
    public void Execute()
    {
        _trip.Status = _state.Execute(this);
    }
}