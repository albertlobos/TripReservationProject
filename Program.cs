﻿using System.Collections;
using System.Text.Json;

namespace TripReservation;
class Program
{
    static void Main(string[] args)
    {

        Trip newTrip = new Trip(1200, "LA", "Volks", 0800, 020223,021323, new ArrayList());
        Console.WriteLine(newTrip.Status);
        TripContext newTripContext = new TripContext(newTrip);
        Console.WriteLine(newTrip.Status);
        newTripContext.Execute();
        Console.WriteLine(newTrip.Status);
        Console.WriteLine(newTripContext.State);
        
        
        Console.WriteLine();
        Console.WriteLine();
        var jsonString = JsonSerializer.Serialize(newTrip);
        Console.Write(jsonString);
        Console.WriteLine();
        Console.WriteLine();
        //
        newTripContext.Execute();
        //
        Console.WriteLine(newTrip.Status);
        Console.WriteLine(newTripContext.State);
        jsonString = JsonSerializer.Serialize(newTrip);
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
