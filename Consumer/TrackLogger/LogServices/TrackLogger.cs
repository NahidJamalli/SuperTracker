using System.Globalization;
using TrackLogger.Dtos;

namespace TrackLogger.LogServices;

public class VisitLogger
{
    public static string FILE_NAME = "config.json";

    public async Task LogAsync(string path, TrackingDetailsDto trackingDetailsDto)
    {
        using var sw = new StreamWriter(path, true);

        await sw.WriteLineAsync($"{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture)} | {trackingDetailsDto?.Referer} | {trackingDetailsDto?.UserAgent} | {trackingDetailsDto?.Ip}");
    }
}