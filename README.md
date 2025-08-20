Got it 👍 — here’s the same thing written in **your style**, like the doc you drafted earlier:

---

# 📦 MySignalRChat NuGet Packages

A simple wrapper around SignalR for real-time chat communication.
Supports:

* ✔ One-to-one private chat
* ✔ Group chat
* ✔ Broadcast messages

Now we have **two NuGet packages**:

* `SimpleSignalRChat.Client` → for chat clients (desktop, mobile, web apps)
* `SimpleSignalRChat.Server` → for hosting SignalR hubs in ASP.NET Core

---

## 🛠 Add Local NuGet Source in .NET

Before using these packages, register a local NuGet source so .NET knows where to find them.

1️⃣ Add the local source

```sh
dotnet nuget add source "C:\LocalNugetPackages" -n LocalPackages
```

✔ This tells .NET to look inside `C:\LocalNugetPackages` for NuGet packages.
✔ You only need to do this once per machine.

---

2️⃣ Copy the `.nupkg` files

After building in **Release**, copy both packages into the folder:

```
C:\LocalNugetPackages
```

Files:

* `SimpleSignalRChat.Client.1.0.0.nupkg`
* `SimpleSignalRChat.Server.1.0.0.nupkg`

---

3️⃣ Install the package in your project

👉 If you are building a client app:

```sh
dotnet add package SimpleSignalRChat.Client --source LocalPackages
```

👉 If you are building a server app:

```sh
dotnet add package SimpleSignalRChat.Server --source LocalPackages
```

---

4️⃣ Restore packages

```sh
dotnet restore
```

---

## ✅ Done!

Now you can use the packages in your projects.

### Example (Client App)

```csharp
using SimpleSignalRChat.Client;

var client = new SignalRChatClient("https://localhost:5001/chatHub");
await client.StartAsync();

await client.SendBroadcastMessage("Vishal", "Hello, everyone!");
```

---

### Example (Server App)

```csharp
using SimpleSignalRChat.Server;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapHub<ChatHub>("/chatHub");

app.Run();
```

---

👉 This way you can develop **client apps** or **server apps** separately by just installing the right NuGet package.

---

Do you also want me to extend this in **your style** to show how someone can use *both packages together* in a single solution (client + server in one go)?
