namespace TripReservation;

/*
 * This is the People clas that will be implemented with the Singleton Pattern.
 */
public class People
{
    private static People? _people;

    private string _name = string.Empty;

    public int Guests { get; set; } = 0;

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public static People? GetInstance()
    {
        lock (typeof(People))
        {
            if (_people == null) _people = new People();
            return _people;
        }
    }


    public virtual void PrintName()
    {
        Console.Out.Write(_name);
    }
}
