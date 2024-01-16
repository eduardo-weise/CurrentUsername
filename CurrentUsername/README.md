# WMI User Query Performance Comparison

This README.md provides an overview and performance comparison of different WMI classes used to query logged-in users on a Windows system.

## Win32_ComputerSystem

The `Win32_ComputerSystem` class can be used to retrieve the username of the user logged into the console. It is a quick method but does not provide information about remote sessions.

```cs
ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT UserName FROM Win32_ComputerSystem");
foreach (ManagementObject queryObj in searcher.Get())
{
    Console.WriteLine("UserName: {0}", queryObj["UserName"]);
}

```

## Win32_LoggedOnUser

The `Win32_LoggedOnUser` class can be used to find all user sessions, including remote sessions. It is more comprehensive but can be slower and may return multiple entries for the same user.

```cs
ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_LoggedOnUser");
foreach (ManagementObject queryObj in searcher.Get())
{
    Console.WriteLine("Antecedent: {0}", queryObj["Antecedent"]);
    Console.WriteLine("Dependent: {0}", queryObj["Dependent"]);
}

```

## Win32_UserAccount

The `Win32_UserAccount` class provides information about user accounts on a Windows system. It is not ideal for finding currently logged-in users but is useful for account-related details.

```cs
ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_UserAccount");
foreach (ManagementObject queryObj in searcher.Get())
{
    Console.WriteLine("Name: {0}", queryObj["Name"]);
    // Outras propriedades como Domain, Status, etc.
}

```

## Performance Comparison

- `Win32_ComputerSystem`: Fast for console sessions but does not return information on remote sessions.
- `Win32_LoggedOnUser`: Provides a comprehensive view of all types of user sessions, including remote sessions, but can be slower and may return duplicates.
- `Win32_UserAccount`: Suitable for obtaining user account details but not for checking current logins.

Each class has its advantages and disadvantages, and the choice depends on the specific use case and performance requirements of your application.