namespace TripReservation;

public class TripContext
{
    private Trip _trip;
    private TripState _state;
    
    
    public TripContext(Trip trip)
    {
        _trip = trip;

        switch (trip.Status)
        {
            case Status.Create:
                _state = new TripStateCreate(trip);
                break;
            case Status.AddTravelers:
                _state = new TripStateAddTravelers(trip);
                break;
        }
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

    public Status Execute()
    {
        _trip.Status = _state.Execute();
        return _trip.Status;
    }
}