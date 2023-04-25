using TripReservation.TripStates;

namespace TripReservation;

public class TripContext
{
    private Trip _trip;
    private TripState _state;
    
    
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

    public void Execute()
    {
        _trip.Status = _state.Execute(this); 
    }
}