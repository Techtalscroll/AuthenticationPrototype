namespace AuthenticationPrototype.Authentication;

public class Account {
    private string _username = "user";
    private string _password = "user";

    public bool Login(string username, string password) { return _username == username && _password == password; }
}
