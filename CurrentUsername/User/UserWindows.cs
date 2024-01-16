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

        ManagementObjectSearcher win32_ComputerSystem = new("SELECT UserName FROM Win32_ComputerSystem");
        foreach (ManagementObject queryObj in win32_ComputerSystem.Get().Cast<ManagementObject>())
        {
            Console.WriteLine("Usuário logado: {0}", queryObj["UserName"]);
        }

        ManagementObjectSearcher win32_UserAccount = new("SELECT Name FROM Win32_UserAccount");
        foreach (ManagementObject queryObj in win32_UserAccount.Get().Cast<ManagementObject>())
        {
            Console.WriteLine("Usuário logado: {0}", queryObj["Name"]);
            // Outras propriedades como Domain, Status, etc.
        }

        ManagementObjectSearcher win32_LoggedOnUser = new("SELECT * FROM Win32_LoggedOnUser");
        foreach (ManagementObject queryObj in win32_LoggedOnUser.Get().Cast<ManagementObject>())
        {
            Console.WriteLine("Antecedent: {0}", queryObj["Antecedent"]);
            Console.WriteLine("Dependent: {0}", queryObj["Dependent"]);
        }
    }
}
