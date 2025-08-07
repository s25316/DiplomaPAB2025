// Ignore Spelling: Teryt, Plugin, Terc, Simc
using TerytPlugin.Models;

namespace TerytPlugin
{
    public class TerytClient
    {
        private readonly string tercFile = "C:\\01Mine\\git\\DiplomaPAB2025\\Diploma.API\\TerytPlugin\\FIles\\TERC.csv";
        private readonly string simcFile = "C:\\01Mine\\git\\DiplomaPAB2025\\Diploma.API\\TerytPlugin\\FIles\\SIMC.csv";

        public async Task<IEnumerable<TercInfo>> GetTercInfoAsync()
        {
            return await ReadFileAsync(
                tercFile,
                str => (TercInfo)str
                );
        }

        public async Task<IEnumerable<SimcInfo>> GetSimcInfoAsync()
        {
            return await ReadFileAsync(
                simcFile,
                str => (SimcInfo)str
                );
        }

        private static async Task<IEnumerable<T>> ReadFileAsync<T>(
            string filePath,
            Func<string, T> parse)
            where T : class
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }

            var items = new List<T>();
            await using (
                FileStream fs = File.Open(
                    path: filePath,
                    mode: FileMode.Open,
                    access: FileAccess.Read,
                    share: FileShare.ReadWrite
                ))
            {
                await using (BufferedStream bs = new BufferedStream(fs))
                {
                    using (StreamReader sr = new StreamReader(bs))
                    {
                        var line = await sr.ReadLineAsync();
                        if (line == null)
                        {
                            return items;
                        }

                        do
                        {
                            line = await sr.ReadLineAsync();
                            if (string.IsNullOrWhiteSpace(line))
                            {
                                continue;
                            }
                            items.Add(parse(line));
                        }

                        while (line != null);
                    }
                }
            }
            return items;
        }
    }
}
