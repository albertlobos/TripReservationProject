namespace TripReservation;

/*
 * This is the Payment class that extends to the CashPayment and Check Payment
 */
public class Payment
{
    public Payment(decimal amount)
    {
        Amount = amount;
    }


    public decimal Amount { get; set; }
}