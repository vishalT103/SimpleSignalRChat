📦 MySignalRChat NuGet Package

A simple wrapper around SignalR for real-time chat communication.
Supports:
✔ One-to-one private chat
✔ Group chat
✔ Broadcast messages

🛠 Add Local NuGet Source in .NET

Before using this package, you need to register a local NuGet source in your system so .NET knows where to find it.

1️⃣ Add the local source

Open cmd/terminal and run:

dotnet nuget add source "C:\LocalNugetPackages" -n LocalPackages


✔ This tells .NET to look inside the folder C:\LocalNugetPackages for NuGet packages, under the name LocalPackages.
✔ You only need to do this once per machine.

2️⃣ Copy the .nupkg file

Place your package file (e.g., MySignalRChat.1.0.0.nupkg) into the folder:

C:\LocalNugetPackages

3️⃣ Install the package in your project

From your project folder (where .csproj exists), run:

dotnet add package MySignalRChat --source LocalPackages

4️⃣ Restore packages
dotnet restore

✅ Done!

Now your project can use the package just like any other NuGet dependency:

using MySignalRChat;

var client = new SignalRChatClient("https://localhost:5001/chatHub");
await client.StartAsync();
