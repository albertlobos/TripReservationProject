namespace TripReservation;

/*
 * This is the person class. This person class is added into the Person list in Trip class
 */
public class Person
{
    private string? _firstName;
    private string? _lastName;
    private string? _phoneNumber;


    public Person(string? firstName, string? lastName, string? phoneNUmber, int age)
    {
        _firstName = firstName;
        _lastName = lastName;
        _phoneNumber = phoneNUmber;
        Age = age;
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

    public int Age { get; set; }
}