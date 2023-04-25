
namespace TripReservation;

public class TripStateAddTravelers : TripState
{
    
    public override Status Execute(TripContext context)
    {
        var done = false;
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

            var newPerson = new Person(firstName, lastName, phoneNumber, age);
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