namespace TripReservation;

/*
 * These statuses are attached to the trip. Each instance of trip starts at status create and moves down.
 * Depending on the status will choose the state that will be attached to the tripContext in
 * the tripStateContextFactory.
 */
public enum Status
{
    Create,
    AddTravelers,
    AddDestinations,
    ChoosePayment,
    PayCash,
    PayCheck,
    AddNote,
    Complete
}