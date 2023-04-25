namespace TripReservation.TripStates;

public class TripStateAddNote: TripState
{
    public override Status Execute(TripContext context)
    {
        return AddNote(context);
    }

    private static Status AddNote(TripContext context)
    {
        Console.WriteLine("*************************");
        Console.WriteLine("***   Create Note   ***");
        Console.WriteLine("*************************\n");
        do
        {
            Console.WriteLine("Write the note you would like to add to the trip. or type \"quit\" to simply quit");
            var note = Console.ReadLine();
            if (note == "quit")
            {
                return Status.AddNote;
            }
            else
            {
                Console.WriteLine("Your note says:  \n" + note);
                Console.WriteLine("Do you want to continue adding this note? Y/N/quit");
                note = Console.ReadLine();

                switch (note)
                {
                    case "quit":
                        return Status.AddNote;
                    case "Y":
                        context.State = new TripStateComplete();
                        return Status.Complete;
                    case "N":
                        break;
                }
            }
        } while (true);
    }
}