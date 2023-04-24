namespace TripReservation;

public class Trip
{


    private Status _status;
    private int _time;
    private string _destination;
    private string _vehicle;
    private int _startTime;
    private int _startDate;
    private int _endDate;
    
    public Trip(int time, string destination, string vehicle, int startTime, int startDate, int endDate)
    {
        _time = time;
        _destination = destination;
        _vehicle = vehicle;
        _startTime = startTime;
        _startDate = startDate;
        _endDate = endDate;
        _status = Status.Create;
    }

    public Status Status
    {
        get => _status;
        set => _status = value;
    }

    public int Time
    {
        get => _time;
        set => _time = value;
    }

    public string Destination
    {
        get => _destination;
        set => _destination = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Vehicle
    {
        get => _vehicle;
        set => _vehicle = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int StartTime
    {
        get => _startTime;
        set => _startTime = value;
    }

    public int StartDate
    {
        get => _startDate;
        set => _startDate = value;
    }

    public int EndDate
    {
        get => _endDate;
        set => _endDate = value;
    }
}



/*

private State _state = State.Started;
private State _state2 = State.Unfinished;
public enum State
{
    Started,
    Unfinished,
    Finished,
    Canceled,
    AwaitingTravelers,
    AwaitingPackages,
    AwaitingPayment,
    AwaitingNote
}

public enum Action
{
    AddTravelers,
    AddPackages,
    AddPayment,
    AddNote,
    Finishing,
    Saving,
}

State ChangeState(State current, State current2, Action action) =>
    (current, current2, action) switch
    {
        (State.Started, State.Unfinished, Action.AddTravelers) => _state2 = State.AwaitingTravelers,
        (State.Started, State.AwaitingTravelers, Action.AddPackages) => _state2 = State.AwaitingPackages,
        (State.Started, State.AwaitingPackages, Action.AddPayment) => _state2 = State.AwaitingPayment,
        (State.Started, State.AwaitingPayment, Action.AddNote) => _state2 = State.AwaitingNote,
        (State.Started, State.AwaitingNote, Action.Finishing) => _state2 = State.AwaitingNote,
        _ => throw new ArgumentOutOfRangeException()
    };

*/