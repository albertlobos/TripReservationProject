using System.Reflection;
using System.Text.Json;

namespace TripReservation.Json_XML;

public static class Saver
{
    
    public static void JsonSaveTrip(List<Trip> tripList)
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
        
        var serializer = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        var jsonString = JsonSerializer.Serialize(tripList, serializer);

        
        Console.WriteLine(File.Exists(filePath)); 
        File.WriteAllText(filePath, jsonString);

        
    }
}