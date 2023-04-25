using System.Collections;

namespace TripReservation;

public class Trip
{    
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
    
     
    private ArrayList? _listOfPeople = new ArrayList();
    private string? _destination;
    private string? _vehicle;
    private Payment? _payment;

    public Status Status { get; set; }
    public int Time { get; set; }
    public int StartTime { get; set; }
    public int StartDate { get; set; }
    public int EndDate { get; set; }    
    public string? Note { get; set; }
    public decimal? Amount { get; set; }
    
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
    public Payment? Payment
    {
        get => _payment;
        set => _payment = value ?? throw new ArgumentNullException(nameof(value));
    }


}
