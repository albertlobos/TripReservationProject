



namespace TripReservation;

public class People
{
    private int _guests = 0;

    private string _name = string.Empty;

    private static People? _people = null;

    public static People? GetInstance()
    {
        lock (typeof(People))
        {
            if (_people == null)
            {
                _people = new People();
            }
            return _people;
        }
    }

    public int Guests
    {
        get => _guests;
        set => _guests = value;
    }
    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }
    

    public virtual void PrintName()
    {
        System.Console.Out.Write(_name);
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
