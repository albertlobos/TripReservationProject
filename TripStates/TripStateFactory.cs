using System.Data;

namespace TripReservation.TripStates;

public static class TripStateFactory
{

    public static TripState GetState(TripContext context)
    {
        switch (context.Trip.Status)
        {
            case Status.Create:
                return new TripStateCreate();
            case Status.AddTravelers:
                return new TripStateAddTravelers();
            case Status.AddDestinations:
                return new TripStateAddDestinations();
            case Status.ChoosePayment:
                return new TripStateChoosePaymentType();
            case Status.PayCash:
                return new TripStatePayCash();
            case Status.PayCredit:
                return new TripStatePayCredit();
            case Status.AddNote:
                return new TripStateAddNote();
            case Status.Complete:
                return new TripStateAddComplete();
        }
        throw new InvalidOperationException();
    }
}