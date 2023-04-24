using System.Data;

namespace TripReservation;

public class TripStateAddTravelers : TripState
{
    private Trip _trip;
    public TripStateAddTravelers(Trip trip)
    {
        _trip = trip;
    }

    public override Status Execute(TripContext context)
    {
        bool done = false;
        do
        {
            Console.WriteLine("Add a traveler \n");
            Console.WriteLine("Enter First Name");
            var firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            var lastName = Console.ReadLine();
            Console.WriteLine("Enter Phone ");
            var phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Age");
            var age = Convert.ToInt32(Console.ReadLine());

            Person newPerson = new Person(firstName, lastName, phoneNumber, age);
            context.Trip.ListOfPeople.Add(newPerson);
            Console.WriteLine();
            Console.WriteLine("Do you want to add another traveler?");
            Console.WriteLine("Enter Y for yes and N for no");
            var answer = Console.ReadLine();
            if (answer == "N")
            {
                done = true;
            }

        } while (done == false);

        context.State = this;
        return Status.AddDestinations;
    }
}