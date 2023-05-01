namespace TripReservation;

/*
 * This is a child class that extends from Payment. It will be attached to the client's trip
 */
public class CashPayment : Payment
{
    public CashPayment(decimal amount) : base(amount)
    {
    }
}