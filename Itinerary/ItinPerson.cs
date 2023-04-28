namespace TripReservation.Itinerary;

public class ItinPerson : ItinDecorator
{
    

    
    public int count = 0;
    //string Persondecor = "";
     


    public ItinPerson(Itinerary itin) : base(itin)
    {
    }
    
    
    public void Output()
    {
        
        base.Output();
        Console.WriteLine("\n"+ _trip.ListOfPeople.Count + "Travelers: \n");
        while (count < _trip.ListOfPeople.Count)
        {
            Console.WriteLine(count + ": " + _trip.ListOfPeople[count]);
        }

        
        
    }
}