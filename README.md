# Let's talk about how qualified you should be
Just be better than me.
# Requirements
• Get Visual Studio.

• You must have a basic knowledge of C#.

• Learn to read and write.

• Have a Discord account.

• Also learn to just read when needed.
# Here we go

First, create a bot for yourself on Discord Developers. 
##### • You can easily find how to do this step on the internet. I will try to make the guide short but meaningful.

______________________________________________________________________

#### So, we have created our bot, we have the Token. Wonderful!
The next step will be to open a new Console App from Visual Studio. The name you give to the project will not affect anything if you proceed according to the guide. So don't get too attached.

When your project opens, you will be greeted by a neat set of code. Our next step is to download Discord.NET into your project.

Now, open "NuGet Package Manager / Manage NuGet Packages for Solution..." from the Tools menu.

The screen you see shows you the NuGet packages available in your project. But we will import the package we will use to our project via GitHub. Click the settings button on the top right and create a new source. Just like the name of the project, the name you give here will not affect anything. In the Source section, paste the address "https://www.myget.org/F/discord-net/api/v3/index.json". This is the address that will allow us to import the Discord.NET NuGet into our project. (For those interested, this is Discord.NET's NuGet address.) We finished the Settings tab. Press the OK button. Then click on what says "nuget.org" if you haven't changed it to the left of the settings button and select the option with the name you just gave the source shortly before. Now, open the Browse tab and type "Discord.NET" in the search field. Click on the top option and put a tick where it says "Project" on the right. This is the part where you choose which files to install NuGet on. Then start the download from the bottom right of the panel you are in. If the "Microsoft.extensions" NuGet is not downloaded, I suggest you download it to avoid any problems in the future.

As of now, we have what it takes to start building our bot. Go back to the main screen.  

Inside the class opposite you, pass the following. Or if you have an alternative solution that you have in mind, you can apply it as well. Because right now we are progressing very fundamentally.

```
public class Tutorial
{
	public static void Main(string[] args)
		=> new Program().MainAsync().GetAwaiter().GetResult();

	public async Task MainAsync()
	{
	}
}
```

This one makes your program start inside an async context.

```
private Task Log(LogMessage msg)
{
	Console.WriteLine(msg.ToString());
	return Task.CompletedTask;
}
```

This code is a logger to process events from Discord.NET before connecting our project with Discord Client.

```
private DiscordSocketClient _client;

public async Task MainAsync()
{
    _client = new DiscordSocketClient();
}
```

Now our project is slowly starting to take shape. We have defined the Discord Client above.

```
    var TOKEN = "Endangered token";
    
    _client.Log += Log;

    await _client.LoginAsync(TokenType.Bot, TOKEN);
    await _client.StartAsync();
 ```
 
 
We now have the setup to handle the client's connection request. However, we need to prevent the client's main management from returning during execution. The site at ```https://docs.stillu.cc/``` has solved this situation by adding a delay of -1. We will use this method too.

```
    await Task.Delay(-1);
 ```
 
It was a long step, wasn't it?  
Our bot is ready to run after this second. But first I need to open up a few issues. Many people prefer not to keep their tokens inside the main file for security. You can achieve this in many ways. Like creating a config file, or calling all such information from a separate text file. Neither are very effective methods. However, they can delay a thief in your home from stealing your Discord bot token for a few seconds.

# Let's do these two methods.

### If you love Config files

In your project, open a new file named app.config

```
<configuration>
    <appSettings>
        <add key="token" value="Your very own token"/>
    </appSettings>    
</configuration>
```

Import the above code into your file. Put your Token to Value. Then go back to your main file. Don't forget to add "System.Configuration.ConfigurationManager" NuGet to your project.

```
    var TOKEN = ConfigurationManager.AppSettings["token"];
    
    await _client.LoginAsync(TokenType.Bot, TOKEN);
    await _client.StartAsync();
 ```

### If you hate Config files

Open a txt file named token in the file directory where your project is located. (Or whatever you want to name it.) Then:

```
var TOKEN = File.ReadAllText("token.txt");
```

Replace the code with the token part above. What the code is doing here is replacing the Token variable with data from "token.txt". Do not have anything other than your token in your txt file. Because the code transfers all the content without any discrimination.


Now, you can run your project. If you encounter an error with the Client, try to install the optional NuGets I mentioned above.
