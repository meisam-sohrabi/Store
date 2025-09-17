namespace LogService
{
    public class LogService : ILogService
    {
        public async Task LogAsync(string message, string appServiceName, string currentuser)
        {
            var path = Path.Combine(AppContext.BaseDirectory, "Log");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}";
            var fileName = appServiceName + "Log" + ".txt";
            if (File.Exists(Path.Combine(path, fileName)))
            {
                await File.AppendAllTextAsync(Path.Combine(path, fileName), logMessage);

            }
        }
    }
}
