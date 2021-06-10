public class Tutorial
{
	public static void Main(string[] args)
		=> new Program().MainAsync().GetAwaiter().GetResult();

	public async Task MainAsync()
	{
	}
  
  private Task Log(LogMessage msg)
{
	Console.WriteLine(msg.ToString());
	return Task.CompletedTask;
}
private DiscordSocketClient _client;

public async Task MainAsync()
{
    _client = new DiscordSocketClient();

    var TOKEN = "token";

    _client.Log += Log;
    await _client.LoginAsync(TokenType.Bot, TOKEN);
    await _client.StartAsync();

    await Task.Delay(-1);
}
  
}

