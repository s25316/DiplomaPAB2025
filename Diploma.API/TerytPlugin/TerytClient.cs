// Ignore Spelling: Teryt, Plugin, Terc, Simc, Ulic
using TerytPlugin.FileModels;
using TerytPlugin.Models;

namespace TerytPlugin
{
    public class TerytClient
    {
        private readonly string tercFile;
        private readonly string simcFile;
        private readonly string ulicFile;


        public TerytClient(string tercFile, string simcFile, string ulicFile)
        {
            this.tercFile = tercFile;
            this.simcFile = simcFile;
            this.ulicFile = ulicFile;
        }


        public async Task<TerytInfo> GetAsync()
        {
            // Main Divisions
            var tercItems = await GetTercInfoAsync();
            var simcItems = await GetSimcInfoAsync();
            var divisions = new Dictionary<string, Division>();
            var divisionTypes = new HashSet<string>();
            foreach (var item in tercItems)
            {
                var division = (Division)item;

                if (divisions.ContainsKey(division.Id))
                {
                    throw new ArgumentException(division.Id);
                }

                divisions.Add(division.Id, division);
                divisionTypes.Add(division.Type);
            }
            foreach (var item in simcItems)
            {
                var division = (Division)item;
                if (divisions.ContainsKey(division.Id))
                {
                    throw new ArgumentException(division.Id);
                }

                divisions.Add(division.Id, division);
                divisionTypes.Add(division.Type);
            }


            // Streets Preparation
            var ulicData = await GetUlicInfoAsync();

            var streets = new Dictionary<string, Street>();
            var connections = new List<Connection>();
            var streetTypes = new HashSet<string>();

            foreach (var item in ulicData)
            {
                if (!string.IsNullOrWhiteSpace(item.Type))
                {
                    streetTypes.Add(item.Type);
                }
                var connection = item.GetConnection();
                connections.Add(connection);
                if (!streets.ContainsKey(connection.UlicaId))
                {
                    var street = item.GetStreet();
                    streets[street.Id] = street;
                }
            }

            return new TerytInfo
            {
                DivisionTypes = divisionTypes,
                Divisions = divisions.Values,

                StreetTypes = streetTypes,
                Streets = streets.Values,

                Connections = connections,
            };
        }

        private async Task<IEnumerable<TercInfo>> GetTercInfoAsync()
        {
            return await ReadFileAsync(
                tercFile,
                str => (TercInfo)str
                );
        }

        private async Task<IEnumerable<SimcInfo>> GetSimcInfoAsync()
        {
            return await ReadFileAsync(
                simcFile,
                str => (SimcInfo)str
                );
        }

        private async Task<IEnumerable<UlicInfo>> GetUlicInfoAsync()
        {
            return await ReadFileAsync(
                ulicFile,
                str => (UlicInfo)str
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
