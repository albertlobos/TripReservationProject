using System.Text.Json;

namespace TripReservation.Json_XML;

public class Saver
{


    public static void SaveTrip(List<Trip> tripList)
    {
        var jsonString = JsonSerializer.Serialize(tripList);
        File.WriteAllText(@"/Users/nelso/Desktop/Spring2023/TripReservation/Json_XML/TripsSaved.json", 
            jsonString);
    }
}