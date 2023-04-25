namespace TripReservation;

public class Person
{
    private string? _firstName;
    private string? _lastName;
    private string? _phoneNumber;
    private int _age;


    public Person(string? firstName, string? lastName, string? phoneNUmber, int age)
    {
        this._firstName = firstName;
        this._lastName = lastName;
        this._phoneNumber = phoneNUmber;
        this._age = age;
    }

    public string? FirstName
    {
        get => _firstName;
        set => _firstName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string? LastName
    {
        get => _lastName;
        set => _lastName = value ?? throw new ArgumentNullException(nameof(value));
    }
    public string? PhoneNumber
    {
        get => _phoneNumber;
        set => _phoneNumber = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Age
    {
        get => _age;
        set => _age = value;
    }
}