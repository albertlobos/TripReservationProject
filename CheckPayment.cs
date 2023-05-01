namespace TripReservation;

/*
 * This is a child class that extends from Payment. It will be attached to the client's trip as a Payment
 */
public class CheckPayment : Payment
{
    public CheckPayment(decimal amount, int checkNumber) : base(amount)
    {
        CheckNumber = checkNumber;
    }

    public int CheckNumber { get; set; }
}