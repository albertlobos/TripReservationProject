using System.Reflection;
using System.Text.Json;

namespace TripReservation.Json_XML;

/*
 * This Reader class will handle Loading the trip from the Json File
 */
public static class Reader
{
    public static void JsonLoader()
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

        if (File.ReadAllText(@filePath) == null)
        {
            Writer.JsonSaveTrip();
            Trip.AllTrips =
                JsonSerializer.Deserialize<List<Trip>>(
                    File.ReadAllText(@filePath));
            return;
        }
        
        Trip.AllTrips =
            JsonSerializer.Deserialize<List<Trip>>(
                File.ReadAllText(@filePath));
    }
}