using Diploma.Infrastructure.RelationalDatabase.Base.Models.Addresses;
using Diploma.Infrastructure.RelationalDatabase.MsSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Diploma.Seeder
{
    internal class Program
    {
        private const string TERC_FILE = "C:\\01Mine\\git\\DiplomaPAB2025\\Diploma.API\\TerytPlugin\\FIles\\TERC.csv";
        private const string SIMC_FILE = "C:\\01Mine\\git\\DiplomaPAB2025\\Diploma.API\\TerytPlugin\\FIles\\SIMC.csv";
        private const string ULIC_FILE = "C:\\01Mine\\git\\DiplomaPAB2025\\Diploma.API\\TerytPlugin\\FIles\\ULIC.csv";
        private static ILoggerFactory? loggerFactory;

        static async Task Main(string[] args)
        {
            loggerFactory = LoggerFactory.Create(b =>
            {
                b.AddConsole();
                b.SetMinimumLevel(LogLevel.Trace);
            });
            var logger = loggerFactory.CreateLogger<Program>();

            var db = new MsSqlDiplomaDbContext();
            await db.Database.BeginTransactionAsync();


            logger.LogInformation("Start");
            var sw = new Stopwatch();
            sw.Start();
            await SeedTerytDataAsync(db);



            await db.SaveChangesAsync();
            await db.Database.CommitTransactionAsync();
            sw.Stop();

            string resultMessage = $"End, spend Time: {new TimeSpan(sw.ElapsedTicks)}";
            logger.LogInformation(resultMessage);
        }

        private static async Task SeedTerytDataAsync(MsSqlDiplomaDbContext db)
        {
            var terytLogger = loggerFactory!.CreateLogger("TERYT");
            await db.Divisions.ExecuteDeleteAsync();
            await db.Streets.ExecuteDeleteAsync();
            await db.DivisionTypes.ExecuteDeleteAsync();
            await db.StreetTypes.ExecuteDeleteAsync();
            await db.Countries.ExecuteDeleteAsync();
            await db.SaveChangesAsync();

            terytLogger.LogInformation("Removed Database Data");

            var teryt = new TerytPlugin.TerytClient(
                    TERC_FILE,
                    SIMC_FILE,
                    ULIC_FILE
                    );

            var data = await teryt.GetAsync();
            terytLogger.LogInformation($"Get Data from Files");


            var dbDivisionTypes = new Dictionary<string, DivisionType>();
            var dbDivision = new Dictionary<string, Division>();
            var dbStreetTypes = new Dictionary<string, StreetType>();
            var dbStreets = new Dictionary<string, Street>();

            var poland = new Country
            {
                Name = "Polska",
            };
            await db.Countries.AddAsync(poland);
            terytLogger.LogInformation($"Add {nameof(Country)}");


            foreach (var divisionType in data.DivisionTypes)
            {
                var item = new DivisionType
                {
                    Name = divisionType,
                };

                dbDivisionTypes[divisionType] = item;
                db.DivisionTypes.Add(item);
            }
            terytLogger.LogInformation($"Add {nameof(DivisionType)}");

            foreach (var streetType in data.StreetTypes)
            {
                var item = new StreetType
                {
                    Name = streetType,
                };
                dbStreetTypes[streetType] = item;
                db.StreetTypes.Add(item);
            }
            terytLogger.LogInformation($"Add {nameof(StreetType)}");

            foreach (var division in data.Divisions)
            {
                var item = new Division
                {
                    DivisionId = division.Id,
                    ParentDivisionId = division.ParentId,
                    DivisionType = dbDivisionTypes[division.Type],
                    Name = division.Name,
                    Country = poland,
                };
                dbDivision[division.Id] = item;
                db.Divisions.Add(item);
            }
            terytLogger.LogInformation($"Add {nameof(Division)}");

            foreach (var street in data.Streets)
            {
                var item = new Street
                {
                    StreetId = street.Id,
                    StreetType = street.Type is not null
                        ? dbStreetTypes[street.Type]
                        : null,
                    Name = street.Name,
                    Country = poland,
                };
                dbStreets[street.Id] = item;
                db.Streets.Add(item);
            }
            terytLogger.LogInformation($"Add {nameof(Street)}");

            foreach (var pair in data.Connections.GroupBy(x => x.UlicaId))
            {
                var street = dbStreets[pair.Key];
                foreach (var divisionId in pair)
                {
                    var division = dbDivision[divisionId.MiejscowoscId];
                    street.Divisions.Add(division);
                }
            }
            terytLogger.LogInformation($"Add {nameof(Division)} and {nameof(Street)} connections");
        }
    }
}
