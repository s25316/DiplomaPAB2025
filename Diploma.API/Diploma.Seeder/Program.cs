using Diploma.Infrastructure.RelationalDatabase.Base.Models.Addresses;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.Companies;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations.Courses;
using Diploma.Infrastructure.RelationalDatabase.MsSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RadonPlugin;
using System.Diagnostics;

namespace Diploma.Seeder
{
    internal class Program
    {
        private const string TERC_FILE = "C:\\01Mine\\git\\DiplomaPAB2025\\Diploma.API\\TerytPlugin\\FIles\\TERC.csv";
        private const string SIMC_FILE = "C:\\01Mine\\git\\DiplomaPAB2025\\Diploma.API\\TerytPlugin\\FIles\\SIMC.csv";
        private const string ULIC_FILE = "C:\\01Mine\\git\\DiplomaPAB2025\\Diploma.API\\TerytPlugin\\FIles\\ULIC.csv";
        private static ILoggerFactory? loggerFactory;
        private static MsSqlDiplomaDbContext? db;

        static async Task Main(string[] args)
        {
            loggerFactory = LoggerFactory.Create(b =>
            {
                b.AddConsole();
                b.SetMinimumLevel(LogLevel.Trace);
            });
            var logger = loggerFactory.CreateLogger<Program>();

            db = new MsSqlDiplomaDbContext();


            logger.LogInformation("Start");
            var sw = new Stopwatch();
            sw.Start();

            await RemoveRadonDataAsync();
            await RemoveTerytDataAsync();

            await SeedTerytDataAsync();
            await SeedRadonDataAsync();

            sw.Stop();

            string resultMessage = $"End, spend Time: {new TimeSpan(sw.ElapsedTicks)}";
            logger.LogInformation(resultMessage);
        }

        private static async Task RemoveTerytDataAsync()
        {
            var terytLogger = loggerFactory!.CreateLogger("TERYT");
            await db!.Database.BeginTransactionAsync();

            await db.Divisions.ExecuteDeleteAsync();
            await db.Streets.ExecuteDeleteAsync();
            await db.DivisionTypes.ExecuteDeleteAsync();
            await db.StreetTypes.ExecuteDeleteAsync();
            await db.SaveChangesAsync();

            await db.Database.CommitTransactionAsync();
            terytLogger.LogInformation("Removed Database Data");
        }

        private static async Task SeedTerytDataAsync()
        {
            var terytLogger = loggerFactory!.CreateLogger("TERYT");
            var dbDivisionTypes = new Dictionary<string, DivisionType>();
            var dbDivision = new Dictionary<string, Division>();
            var dbStreetTypes = new Dictionary<string, StreetType>();
            var dbStreets = new Dictionary<string, Street>();


            var teryt = new TerytPlugin.TerytClient(
                    TERC_FILE,
                    SIMC_FILE,
                    ULIC_FILE
                    );
            var data = await teryt.GetAsync();
            terytLogger.LogInformation($"Get Data from Files");


            await db!.Database.BeginTransactionAsync();


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

            await db.SaveChangesAsync();
            await db.Database.CommitTransactionAsync();
        }

        private static async Task RemoveRadonDataAsync()
        {
            var radonLogger = loggerFactory!.CreateLogger("RADON");
            await db!.Database.BeginTransactionAsync();

            await db.EducationInstitutionCourses.ExecuteDeleteAsync();
            await db.DisciplineCourses.ExecuteDeleteAsync();
            await db.Courses.ExecuteDeleteAsync();
            await db.EducationInstitutions.ExecuteDeleteAsync();

            await db.CompanyAddresses.ExecuteDeleteAsync();
            await db.CompanyNames.ExecuteDeleteAsync();
            await db.Companies.ExecuteDeleteAsync();

            await db.EducationInstitutionKinds.ExecuteDeleteAsync();
            await db.CourseForms.ExecuteDeleteAsync();
            await db.CourseLanguages.ExecuteDeleteAsync();
            await db.CourseLevels.ExecuteDeleteAsync();
            await db.CourseProfiles.ExecuteDeleteAsync();
            await db.CourseTitles.ExecuteDeleteAsync();
            await db.Disciplines.ExecuteDeleteAsync();

            await db.SaveChangesAsync();
            await db.Database.CommitTransactionAsync();
            radonLogger.LogInformation("Removed Database Data");
        }
        private static async Task SeedRadonDataAsync()
        {
            var radonLogger = loggerFactory!.CreateLogger("RADON");

            var courseLanguages = new Dictionary<string, CourseLanguage>();
            var disciplines = new Dictionary<string, Discipline>();
            var educationInstitutions = new Dictionary<Guid, EducationInstitution>();

            await db!.Database.BeginTransactionAsync();

            var radon = new RadonClient();

            // EducationInstitutionKind
            foreach (var item in await radon.GetInstitutionKindsAsync())
            {
                var dbItem = new EducationInstitutionKind
                {
                    KindId = item.Code,
                    Name = item.NamePl,
                };
                await db.EducationInstitutionKinds.AddAsync(dbItem);
            }
            radonLogger.LogInformation($"Add {nameof(EducationInstitutionKind)}");

            // CourseForm
            foreach (var item in await radon.GetCourseInstanceFormsAsync())
            {
                var dbItem = new CourseForm
                {
                    FormId = item.Code,
                    Name = item.NamePl,
                };
                await db.CourseForms.AddAsync(dbItem);
            }
            radonLogger.LogInformation($"Add {nameof(CourseForm)}");

            // CourseLanguage
            foreach (var item in await radon.GetCoursePhilologicalLanguagesAsync())
            {
                var dbItem = new CourseLanguage
                {
                    LanguageId = item.Code,
                    Name = item.NamePl,
                };
                courseLanguages.Add(item.Code, dbItem);
                await db.CourseLanguages.AddAsync(dbItem);
            }
            radonLogger.LogInformation($"Add {nameof(CourseLanguage)}");

            // CourseLevel
            foreach (var item in await radon.GetCourseLevelsAsync())
            {
                var dbItem = new CourseLevel
                {
                    LevelId = item.Code,
                    Name = item.NamePl,
                };
                await db.CourseLevels.AddAsync(dbItem);
            }
            radonLogger.LogInformation($"Add {nameof(CourseLevel)}");

            // CourseProfile
            foreach (var item in await radon.GetCourseProfilesAsync())
            {
                var dbItem = new CourseProfile
                {
                    ProfileId = item.Code,
                    Name = item.NamePl,
                };
                await db.CourseProfiles.AddAsync(dbItem);
            }
            radonLogger.LogInformation($"Add {nameof(CourseProfile)}");

            // CourseTitle
            foreach (var item in await radon.GetCourseProfessionalTitlesAsync())
            {
                var dbItem = new CourseTitle
                {
                    TitleId = item.Code,
                    Name = item.NamePl,
                };
                await db.CourseTitles.AddAsync(dbItem);
            }
            radonLogger.LogInformation($"Add {nameof(CourseTitle)}");

            // Discipline
            foreach (var item in await radon.GetDisciplinesAsync())
            {
                var dbItem = new Discipline
                {
                    DisciplineId = item.Code,
                    Name = item.NamePl,
                };
                disciplines.Add(item.Code, dbItem);
                await db.Disciplines.AddAsync(dbItem);
            }
            radonLogger.LogInformation($"Add {nameof(Discipline)}");

            // EducationInstitution
            foreach (var item in await radon.GetInstitutionsAsync())
            {
                var company = new Company
                {
                    CompanyId = item.Uuid,
                    Regon = item.Regon,
                    Website = item.Contacts?.Www,
                    PhoneNumber = item.Contacts?.Phone,
                    Email = item.Contacts?.Email,
                    StartDate = item.Dates.StartDate,
                    EndDate = item.Dates.LiquidationDate,
                };
                await db.Companies.AddAsync(company);

                foreach (var nameInfo in item.Names)
                {
                    var companyName = new CompanyName
                    {
                        Company = company,
                        Name = nameInfo.Name,
                        Date = nameInfo.DateFrom,
                    };
                    await db.CompanyNames.AddAsync(companyName);
                }

                var educationInstitution = new EducationInstitution
                {
                    Company = company,
                    KindId = item.Kind.Id,
                };
                educationInstitutions.Add(item.Uuid, educationInstitution);
                await db.EducationInstitutions.AddAsync(educationInstitution);
            }
            radonLogger.LogInformation($"Add {nameof(EducationInstitution)}");

            foreach (var item in await radon.GetCoursesAsync())
            {
                var dbItem = new Course
                {
                    CourseId = item.Id,
                    Name = item.CourseName,
                    StartDate = item.EducationStartDate,
                    EndDate = item.LiquidationDate,
                    NumberOfSemesters = item.NumberOfSemesters,
                    LanguageId = item.Language.Id,
                    FormId = item.Form.Id,
                    TitleId = item.Title.Id,
                    ProfileId = item.Profile.Id,
                    LevelId = item.Level.Id,
                };
                await db.Courses.AddAsync(dbItem);

                // If language Not Exists - RADON give not full list
                if (!courseLanguages.ContainsKey(item.Language.Id))
                {
                    var notFoundLanguage = new CourseLanguage
                    {
                        LanguageId = item.Language.Id,
                        Name = item.Language.Name,
                    };
                    courseLanguages.Add(item.Language.Id, notFoundLanguage);
                    await db.CourseLanguages.AddAsync(notFoundLanguage);
                }

                foreach (var diciplineInfo in item.Disciplines)
                {
                    var dbDisciplineCourse = new DisciplineCourse
                    {
                        DisciplineId = diciplineInfo.Code,
                        Course = dbItem,
                        Percentage = diciplineInfo.Percentage,
                        IsMain = diciplineInfo.DisciplineLeading,
                    };
                    await db.DisciplineCourses.AddAsync(dbDisciplineCourse);

                    // If Discipline Not Exists - RADON give not full list
                    if (!disciplines.ContainsKey(diciplineInfo.Code))
                    {
                        var notFoundDiscipline = new Discipline
                        {
                            DisciplineId = diciplineInfo.Code,
                            Name = diciplineInfo.Name,
                        };
                        disciplines.Add(diciplineInfo.Code, notFoundDiscipline);
                        await db.Disciplines.AddAsync(notFoundDiscipline);
                    }
                }

                foreach (var coLeadingInstitutions in item.CoLeadingInstitutions)
                {
                    if (coLeadingInstitutions.Uuid == null)
                    {
                        string message = $"Empty Id CoLeading Institution: {coLeadingInstitutions}";
                        radonLogger.LogWarning(message);
                    }
                    else if (!educationInstitutions.ContainsKey(coLeadingInstitutions.Uuid.Value))
                    {
                        string message = $"Not Found Institution: {coLeadingInstitutions}";
                        radonLogger.LogError(message);
                    }
                    else
                    {
                        var dbCoLead = new EducationInstitutionCourse
                        {
                            Course = dbItem,
                            InstitutionId = coLeadingInstitutions.Uuid.Value,
                            IsMainInstitution = false,
                            DateFrom = coLeadingInstitutions.DateFrom,
                            DateTo = coLeadingInstitutions.DateTo,
                        };
                        await db.EducationInstitutionCourses.AddAsync(dbCoLead);
                    }
                }

                var dbMain = new EducationInstitutionCourse
                {
                    Course = dbItem,
                    InstitutionId = item.MainInstitution.Id,
                    IsMainInstitution = true,
                    DateFrom = item.EducationStartDate,
                    DateTo = item.LiquidationDate,
                };
                await db.EducationInstitutionCourses.AddAsync(dbMain);
            }
            radonLogger.LogInformation($"Add {nameof(Course)}");

            await db.SaveChangesAsync();
            await db.Database.CommitTransactionAsync();
        }
    }
}
