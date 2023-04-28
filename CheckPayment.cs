namespace TripReservation;

public class CheckPayment : Payment
{
    public CheckPayment(decimal amount, int checkNumber) : base(amount)
    {
        CheckNumber = checkNumber;
    }

    public int CheckNumber { get; set; }
}