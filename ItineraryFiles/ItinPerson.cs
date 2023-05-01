namespace TripReservation.ItineraryFiles;

public class ItinPerson : ItinComponent
{
    public int count = 0;
    //string Persondecor = "";
    protected readonly ItinComponent itin;


    public ItinPerson(ItineraryFiles.ItinComponent itin)
    {
        this.itin = itin;
    }


    public void Output(Trip trip)
    {
        
        this.itin.Output(trip);
        Console.WriteLine("****************************************\n" + trip.ListOfPeople.Count + " Travelers:");
        while (count < trip.ListOfPeople.Count)
        {
            Console.WriteLine(count + ": " + trip.ListOfPeople[count]);
            count++;
        }
    }
}