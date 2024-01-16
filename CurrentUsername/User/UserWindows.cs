using System.Management;
using System.Runtime.Versioning;
using System.Security.Principal;

namespace CurrentUsername.User;

[SupportedOSPlatform("windows")]
public class UserWindows : IUser
{
    public static void GetUser()
    {
        Console.WriteLine("Usuário logado: {0}", Environment.UserName);
        Console.WriteLine("Usuário logado: {0}", WindowsIdentity.GetCurrent().Name);

        FindUser("UserName", "Win32_ComputerSystem");
        FindUser("Antecedent", "Win32_LoggedOnUser");
        //FindUser("Name", "Win32_UserAccount");
    }

    public static void FindUser(string property, string dba)
    {
        ManagementObjectSearcher searcher = new($"SELECT {property} FROM {dba}");
        foreach (ManagementObject queryObj in searcher.Get().Cast<ManagementObject>())
        {
            Console.WriteLine("Usuário logado: {0}", queryObj.GetPropertyValue(property));
        }
    }
}
