namespace TripReservation;

public abstract class Payment
{
    protected Payment(decimal amount)
    {
        Amount = amount;
    }

    public decimal Amount { get; }
}