## FL Studio RPC
Simple program, that shows information about FL Studio in Discord, using discord-rpc-csharp.

### How it looks?

![изображение](https://user-images.githubusercontent.com/28574474/212527317-cab42400-e6c4-4047-aca5-92c7defe5a69.png)

### Usage guide
- For the beginning, see [Before using](README.md#before-using) section
- Compile the program, using [Visual Studio 2022](https://visualstudio.microsoft.com/ru/vs)
- After start, program will open you a dialog, where you have to select FL studio executable
- Set FlStudioRpcGui.exe as your default program to open .flp
- All done!

### Dependencies
- Windows Forms
- [DiscordRPC by Lachee](https://github.com/Lachee/discord-rpc-csharp)
- .NET 5 or higher

### Support
This program has been written long ago, so there is no support.

### Before using
- **Step 1**: Go to the FlStudioRpc/RpcHelper.cs and change ApplicationId to the your app id.
  
  You can create the application on the [Discord Developer Portal](https://discord.com/developers/applications)

- **Step 2**: Then go to the Rich Presence, upload your image, and rename it to "flicon"

  ![изображение](https://user-images.githubusercontent.com/28574474/212527836-8e271e0f-8673-472f-8e08-c6fbbad4dd37.png)
