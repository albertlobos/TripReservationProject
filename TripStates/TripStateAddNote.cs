namespace TripReservation.TripStates;

public class TripStateAddNote : TripState
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
            Console.WriteLine("Write the note you would like to add to the trip. or type \"quit\" to simply quit: ");
            Console.WriteLine();
            var note = Console.ReadLine();
            Console.WriteLine();
            if (note == "quit")
            {
                Trip.AllTrips.Insert(context.Trip.TripId - 1, context.Trip);
                return Status.AddNote;
            }

            Console.WriteLine("Your note says:  \n" + note);
            Console.WriteLine();
            Console.WriteLine("Do you want to continue adding this note? Y/N/quit");
            note = Console.ReadLine();
            Console.WriteLine();

            switch (note)
            {
                case "quit":
                    Trip.AllTrips.Insert(context.Trip.TripId - 1, context.Trip);
                    return Status.AddNote;
                case "Y":
                    context.Trip.Note = note;
                    context.State = new TripStateComplete();
                    return Status.Complete;
                case "N":
                    break;
            }
        } while (true);
    }
}