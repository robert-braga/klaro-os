namespace Klaro.Domain;

public class User
{
    public Guid Id { get; private init; }
    public string Email { get; private set; }
    public DateTime CreatedAt { get; private init; }

    /// <summary>
    /// Private constructor without parameters to be used by EF Core
    /// </summary>
    private User() { }

    public User(Guid id, string email)
    {
        if(string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Email cannot be empty", nameof(email));
        }

        Id = id;
        Email = email;
        CreatedAt = DateTime.UtcNow;
    }

}
