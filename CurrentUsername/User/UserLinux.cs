using System.Diagnostics;
using System.Runtime.Versioning;

namespace CurrentUsername.User;

[SupportedOSPlatform("linux")]
public class UserLinux : IUser
{
    public static void GetUser()
    {
        // Escolha o comando que deseja executar
        string command = "who";

        // Inicia o processo para executar o comando
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "/bin/bash",
            Arguments = $"-c \"{command}\"",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using (Process? process = Process.Start(startInfo))
        using (StreamReader? reader = process?.StandardOutput)
        {
            // Lê a saída do comando
            string? result = reader?.ReadToEnd();
            Console.WriteLine(result);
        }
    }
}
