using System.Reflection;
using System.Text.Json;

namespace TripReservation.Json_XML;

public static class Writer
{
    public static void JsonSaveTrip()
    {
        var assemblyLocation = Assembly.GetExecutingAssembly().Location;
        var runningPath = Path.GetDirectoryName(assemblyLocation);
        runningPath = Path.GetDirectoryName(runningPath);
        runningPath = Path.GetDirectoryName(runningPath);
        runningPath = Path.GetDirectoryName(runningPath);
        var filePath = Path.Join(runningPath, "/Json_XML/TripsSaved.json");

        var jsonString = JsonSerializer.Serialize(Trip.AllTrips);

        File.WriteAllText(@"/Users/nelso/Desktop/Spring2023/TripReservation/TripsSaved.json", jsonString);
    }
}