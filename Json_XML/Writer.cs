using System.Reflection;
using System.Text.Json;

namespace TripReservation.Json_XML;

/*
 * This Writer class handles Saving the trip into the Json File.
 */
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

        // Console.WriteLine("This is the running path: " + runningPath);
        // Console.WriteLine("This is the assembly location path: " + assemblyLocation);
        // Console.WriteLine("This is the filePath after doing the join: " + filePath);
        // Console.WriteLine(File.Exists(filePath));
        
        
        var jsonString = JsonSerializer.Serialize(Trip.AllTrips);

        File.WriteAllText(@filePath, jsonString);
    }
}