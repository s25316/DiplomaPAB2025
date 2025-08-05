// ignore Spelling: Plugin
namespace RadonPlugin.Providers
{
    internal class CustomTimeProvider
    {
        public static DateTime ParseFromUnixEpoch(string unixTime)
        {
            return DateTime.UnixEpoch.AddMilliseconds(long.Parse(unixTime));
        }
    }
}
