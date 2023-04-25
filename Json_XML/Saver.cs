using System.Text.Json;

namespace TripReservation.Json_XML;

public static class Saver
{
    
    public static void JsonSaveTrip(List<Trip> tripList)
    {
        var serializer = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        var jsonString = JsonSerializer.Serialize(tripList, serializer);
        
        
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(File.Exists(@"/Users/nelso/Desktop/Spring2023/TripReservation/Json_XML/TripsSaved.json"));
        File.WriteAllText(@"/Users/nelso/Desktop/Spring2023/TripReservation/Json_XML/TripsSaved.json", 
            jsonString);

        
    }
}