using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace TripReservation;
class Program
{
    static void Main(string[] args)
    {

        Trip newTrip = new Trip(1200, "LA", "Volks", 0800, 020223,021323);
        Console.WriteLine(newTrip.Status);
        TripContext newTripContext = new TripContext(newTrip);
        Console.WriteLine(newTrip.Status);
        newTrip.Status = newTripContext.Execute();
        Console.WriteLine(newTrip.Status);
        Console.WriteLine(newTripContext.State);
        Console.WriteLine();
        string jsonString = JsonSerializer.Serialize(newTripContext);
        Console.Write(jsonString);
        
        
        
        //TripContext newTrip2 = JsonSerializer.Deserialize<TripContext>(jsonString);


        /*
        Console.WriteLine("Hello, World!");
        var albert = new Person("Albert", "Lobos", "6786402216", 23);
        string jsonString = JsonSerializer.Serialize(albert);
        Console.WriteLine(jsonString);
        var newAlbert = JsonSerializer.Deserialize<Person>(jsonString);
        Console.WriteLine(newAlbert.Age);
        */
    }
}
