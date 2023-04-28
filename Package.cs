
namespace TripReservation;

public class Package
{
    private string _from = string.Empty;

    private string _to = string.Empty;

    private int _price;

    private int _hours;

    private static Package? _pack = null;

    public static Package? GetInstance()
    {
        lock (typeof(Package))
        {
            if (_pack == null)
            {
                _pack = new Package();
            }
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
        Console.Out.Write(this._from + " " + this._to + " " + this._hours + " " + this
            ._price);
    }
}


// public class Package {
// 	String from = "";
// 	String to = "";
// 	int price = 0;
// 	int hours = 0;
// 	public static Package pack = null;
// 	public static synchronized Package getInstance() 
// 	{
// 		if(pack == null) 
// 		{
// 			pack = new Package();
// 		}
// 		return pack;
// 	}
// 	
// 	public void setTo(String location) 
// 	{
// 		to = location;
// 	}
// 	public void setFrom(String location) 
// 	{
// 		from = location;
// 	}
// 	public void setPrice(int prices) 
// 	{
// 		price = prices;
// 	}
// 	public void setHours(int hour) 
// 	{
// 		hours = hour;
// 	}
// 	
// 	
// 	public void display() 
// 	{
// 		System.out.print(this.from + " " + this.to + " "+ this.hours + " " + this.price);
// 	}
// }


