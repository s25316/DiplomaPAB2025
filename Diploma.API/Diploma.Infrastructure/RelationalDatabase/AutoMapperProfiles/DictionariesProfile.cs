using AutoMapper;
using DatabaseCourseForm = Diploma.Infrastructure.RelationalDatabase.Base.Models.EducationInstitutions.Courses.CourseForm;
using DatabaseCourseLanguage = Diploma.Infrastructure.RelationalDatabase.Base.Models.EducationInstitutions.Courses.CourseLanguage;
using DatabaseCourseLevel = Diploma.Infrastructure.RelationalDatabase.Base.Models.EducationInstitutions.Courses.CourseLevel;
using DatabaseCourseProfile = Diploma.Infrastructure.RelationalDatabase.Base.Models.EducationInstitutions.Courses.CourseProfile;
using DatabaseCourseTitle = Diploma.Infrastructure.RelationalDatabase.Base.Models.EducationInstitutions.Courses.CourseTitle;
using DatabaseDiscipline = Diploma.Infrastructure.RelationalDatabase.Base.Models.EducationInstitutions.Discipline;
using DatabaseEducationInstitutionKind = Diploma.Infrastructure.RelationalDatabase.Base.Models.EducationInstitutions.EducationInstitutionKind;
using UseCaseCourseForm = Diploma.UseCase.Shared.Models.Dictionaries.CourseForm;
using UseCaseCourseLanguage = Diploma.UseCase.Shared.Models.Dictionaries.CourseLanguage;
using UseCaseCourseLevel = Diploma.UseCase.Shared.Models.Dictionaries.CourseLevel;
using UseCaseCourseProfile = Diploma.UseCase.Shared.Models.Dictionaries.CourseProfile;
using UseCaseCourseTitle = Diploma.UseCase.Shared.Models.Dictionaries.CourseTitle;
using UseCaseDiscipline = Diploma.UseCase.Shared.Models.Dictionaries.Discipline;
using UseCaseEducationInstitutionKind = Diploma.UseCase.Shared.Models.Dictionaries.EducationInstitutionKind;

namespace Diploma.Infrastructure.RelationalDatabase.AutoMapperProfiles
{
    public class DictionariesProfile : Profile
    {
        public DictionariesProfile()
        {
            CreateMap<DatabaseCourseForm, UseCaseCourseForm>()
                .ConstructUsing(db => new UseCaseCourseForm
                {
                    Id = db.FormId,
                    Name = db.Name,
                })
                .ForAllMembers(opt => opt.Ignore());

            CreateMap<DatabaseCourseLanguage, UseCaseCourseLanguage>()
                .ConstructUsing(db => new UseCaseCourseLanguage
                {
                    Id = db.LanguageId,
                    Name = db.Name,
                })
                .ForAllMembers(opt => opt.Ignore());

            CreateMap<DatabaseCourseLevel, UseCaseCourseLevel>()
                .ConstructUsing(db => new UseCaseCourseLevel
                {
                    Id = db.LevelId,
                    Name = db.Name,
                })
                .ForAllMembers(opt => opt.Ignore());

            CreateMap<DatabaseCourseProfile, UseCaseCourseProfile>()
                .ConstructUsing(db => new UseCaseCourseProfile
                {
                    Id = db.ProfileId,
                    Name = db.Name,
                })
                .ForAllMembers(opt => opt.Ignore());

            CreateMap<DatabaseCourseTitle, UseCaseCourseTitle>()
                .ConstructUsing(db => new UseCaseCourseTitle
                {
                    Id = db.TitleId,
                    Name = db.Name,
                })
                .ForAllMembers(opt => opt.Ignore());

            CreateMap<DatabaseDiscipline, UseCaseDiscipline>()
                .ConstructUsing(db => new UseCaseDiscipline
                {
                    Id = db.DisciplineId,
                    Name = db.Name,
                })
                .ForAllMembers(opt => opt.Ignore());

            CreateMap<DatabaseEducationInstitutionKind, UseCaseEducationInstitutionKind>()
                .ConstructUsing(db => new UseCaseEducationInstitutionKind
                {
                    Id = db.KindId,
                    Name = db.Name,
                })
                .ForAllMembers(opt => opt.Ignore());
        }
    }
}
