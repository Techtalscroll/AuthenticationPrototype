namespace AuthenticationPrototype.Authentication;

public class FormValidation
{
    public static bool ValidateUsername(string username)
    { return !string.IsNullOrEmpty(username); }

    public static bool ValidatePassword(string password)
    { return !string.IsNullOrEmpty(password); }
}