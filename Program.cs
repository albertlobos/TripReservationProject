using System.Text.Json;

namespace TripReservation;

internal static class Program
{
    private static void Main()
    {
        
        QuickMenu();
        
    }

    private static void QuickMenu()
    {
        var quit = false;
        var newTrip = new Trip();
        var context = new TripContext(newTrip);
        
        do
        {
            var jsonString = JsonSerializer.Serialize(newTrip);
            Console.WriteLine("Current Trip in Json: ");
            Console.WriteLine(jsonString);
            Console.WriteLine();
            
            
            Console.WriteLine("Continue creating trip? Y/N");
            var answer = Console.ReadLine();
            if (answer == "Y") context.Execute();
            else quit = true;
        } while (quit == false);

        Console.WriteLine("Done with this");
    }
}
