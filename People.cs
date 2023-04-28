namespace TripReservation;

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

// public class People {
// 	int guests = 0;
// 	String name = "";
// 	public static People people = null;
// 	public static synchronized People getInstance() 
// 	{
// 		if(people == null) 
// 		{
// 			people = new People();
// 		}
// 		return people;
// 	}
// 	public void guests(int guest) 
// 	{
// 		guests = guest;
// 	}
// 	public void setName(String n) 
// 	{
// 		name = n;
// 	}
// 	public void printName()
// 	{
// 		System.out.print(name);
// 	}
// 	public void getName()
// 	{
// 		
// 	}
// }