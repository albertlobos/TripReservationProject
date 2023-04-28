using System.Reflection;
using System.Text.Json;

namespace TripReservation.Json_XML;

public static class Writer
{
    public static void JsonSaveTrip()
    {
        var assemblyLocation = Assembly.GetExecutingAssembly().Location;
        Console.WriteLine("Assembly Location: " + assemblyLocation);
        var runningPath = Path.GetDirectoryName(assemblyLocation);
        runningPath = Path.GetDirectoryName(runningPath);
        runningPath = Path.GetDirectoryName(runningPath);
        runningPath = Path.GetDirectoryName(runningPath);
        Console.WriteLine("Running Path: " + runningPath + "/Json_XML/TripsSaved.json");
        var filePath = Path.Join(runningPath, "/Json_XML/TripsSaved.json");
        Console.WriteLine("File Path: " + filePath);

        var jsonString = JsonSerializer.Serialize(Trip.AllTrips);

        Console.WriteLine(File.Exists(filePath));
        File.WriteAllText(@"/Users/nelso/Desktop/Spring2023/TripReservation/TripsSaved.json", jsonString);
    }
}