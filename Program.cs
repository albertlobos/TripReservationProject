using System.Text.Json;
using TripReservation.Json_XML;

namespace TripReservation;

internal static class Program
{
    private static void Main()
    {
        Trip newTrip = new Trip();
        Trip newTrip2 = new Trip();
        Trip.AddTrip(newTrip);
        Trip.AddTrip(newTrip2);
        
        Saver.JsonSaveTrip(Trip.AllTrips);
       // QuickMenu();

    }

    private static void QuickMenu()
    {
        var quit = false;
        var newTrip = new Trip();
        Trip.AddTrip(newTrip);
        var context = new TripContext(newTrip);
        
        do
        {
            var jsonString = JsonSerializer.Serialize(newTrip);
            Console.WriteLine("Current Trip in Json: ");
            Console.WriteLine(jsonString);
            Console.WriteLine();
            Console.WriteLine();
            
            
            Console.WriteLine("Continue creating trip? Y/N");
            var answer = Console.ReadLine();
            Console.WriteLine();
            if (answer == "Y") context.Execute();
            else quit = true;
        } while (quit == false);

        Console.WriteLine("Done with this");
    }
}
