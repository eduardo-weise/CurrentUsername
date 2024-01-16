using CurrentUsername.User;

namespace CurrentUsername;

public class Program
{
    public static void Main()
    {
        if (OperatingSystem.IsWindows())
            UserWindows.GetUser();

        if (OperatingSystem.IsLinux())
            UserLinux.GetUser();
    }
}
