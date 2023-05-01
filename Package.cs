namespace TripReservation;

public class Package
{
    private static Package? _pack;
    private string _from = string.Empty;

    private int _hours;

    private int _price;

    private string _to = string.Empty;

    public static Package? GetInstance()
    {
        lock (typeof(Package))
        {
            if (_pack == null) _pack = new Package();
            return _pack;
        }
    }

    public virtual void SetTo(string location)
    {
        _to = location;
    }

    public virtual void SetFrom(string location)
    {
        _from = location;
    }

    public virtual void SetPrice(int prices)
    {
        _price = prices;
    }

    public virtual void SetHours(int hour)
    {
        _hours = hour;
    }

    public virtual void Display()
    {
        Console.Out.Write(_from + " " + _to + " " + _hours + " " + _price);
    }
}
