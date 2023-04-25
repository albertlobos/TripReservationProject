using System.Collections;

namespace TripReservation;

public class Trip
{
    private ArrayList? _listOfPeople = new ArrayList();
    private string? _destination;
    private string? _vehicle;

    public Trip()
    {
        Status = Status.Create;
    }
    public Trip(int time, string? destination, string? vehicle, int startTime, int startDate, int endDate, ArrayList? listOfPeople)
    {
        Time = time;
        _destination = destination;
        _vehicle = vehicle;
        StartTime = startTime;
        StartDate = startDate;
        EndDate = endDate;
        _listOfPeople = listOfPeople;
        Status = Status.Create;
    }



    public Status Status { get; set; }
    public int Time { get; set; }
    public int StartTime { get; set; }

    public int StartDate { get; set; }

    public int EndDate { get; set; }
    public string? Destination
    {
        get => _destination;
        set => _destination = value ?? throw new ArgumentNullException(nameof(value));
    }
    public ArrayList? ListOfPeople
    {
        get => _listOfPeople;
        set => _listOfPeople = value ?? throw new ArgumentNullException(nameof(value));
    }
    public string? Vehicle
    {
        get => _vehicle;
        set => _vehicle = value ?? throw new ArgumentNullException(nameof(value));
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