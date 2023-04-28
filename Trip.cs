using System.Collections;

namespace TripReservation;

public class Trip
{
    private static List<Trip>? _allTrips = new();
    private static int _allId = 0;
    private string? _destination;
    private ArrayList? _listOfPeople = new();
    private Payment? _payment;
    private string? _vehicle;

    public Trip()
    {
        Status = Status.Create;
        TripId = ++_allId;
    }
    

    public int TripId { get; set; }
    public Status Status { get; set; }

    public string? StartTime { get; set; }//
    public string? StartDate { get; set; }//
    public string? EndDate { get; set; }//
    public string? Note { get; set; }//
    public decimal? Amount { get; set; }//

    public string? Destination
    {
        get => _destination;
        set => _destination = value ?? null;
    }

    public ArrayList? ListOfPeople
    {
        get => _listOfPeople;
        set => _listOfPeople = value ?? null;
    }//

    public string? Vehicle
    {
        get => _vehicle;
        set => _vehicle = value ?? null;
    }

    public Payment? Payment
    {
        get => _payment;
        set => _payment = value ?? null;
    }//

    public static List<Trip>? AllTrips
    {
        get => _allTrips;
        set => _allTrips = value ?? null;
    }//

    public static void AddTrip(Trip trip)
    {
        _allTrips.Add(trip);
    }//

    public static void PrintTrips()
    {
        if (AllTrips == null)
        {
            Console.WriteLine("No trips");
            return;
        }

        foreach (var trip in AllTrips)
            Console.WriteLine("The trip id is: " + trip.TripId + ".. Status is: " + trip.Status);
    }//
}