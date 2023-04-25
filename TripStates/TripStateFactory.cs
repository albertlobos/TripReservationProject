namespace TripReservation.TripStates;

public static class TripStateFactory
{

    public static TripState GetState(TripContext context)
    {
        return context.Trip.Status switch
        {
            Status.Create => new TripStateCreate(),
            Status.AddTravelers => new TripStateAddTravelers(),
            Status.AddDestinations => new TripStateAddDestinations(),
            Status.ChoosePayment => new TripStateChoosePaymentType(),
            Status.PayCash => new TripStatePayCash(),
            Status.PayCredit => new TripStatePayCredit(),
            Status.AddNote => new TripStateAddNote(),
            Status.Complete => new TripStateAddComplete(),
            _ => throw new InvalidOperationException()
        };
    }
}