using UnityEngine.UIElements;

public static class UserDataValidation
{
    private static bool LoginIsValid(string login)
    {
        if (login.Length < 3) return false;
        return true;
    }

    private static bool EmailIsValid(string email)
    {
        if(email.Length < 3) return false;
        return true;
    }

    private static bool PasswordIsValid(string password)
    {
        if (password.Length < 8) return false;

        return true;
    }
    
    public static string CheckSignIn(string login, string password)
    {
        if (!LoginIsValid(login)) return "Wrong login";

        if (!PasswordIsValid(password)) return "Password must be longer";

        return "Success";
    }

    public static string CheckSignUp(string login, string password, string email)
    {
        if (!EmailIsValid(email)) return "Wrong Email";

        return CheckSignIn(login, password);
    }

}