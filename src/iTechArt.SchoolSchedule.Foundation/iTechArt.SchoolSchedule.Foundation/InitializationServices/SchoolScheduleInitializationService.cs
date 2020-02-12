using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArt.Common.Extensions;
using iTechArt.SchoolSchedule.DomainModel.Grades;
using iTechArt.SchoolSchedule.DomainModel.Lessons;
using iTechArt.SchoolSchedule.DomainModel.People;
using iTechArt.SchoolSchedule.DomainModel.Rooms;
using iTechArt.SchoolSchedule.Foundation.Interfaces;
using iTechArt.SchoolSchedule.Repositories.Interfaces;

namespace iTechArt.SchoolSchedule.Foundation.InitializationServices
{
    public class SchoolScheduleInitializationService : ISchoolScheduleInitializationService
    {
        private readonly ISchoolScheduleUnitOfWorkFactory _schoolScheduleUnitOfWorkFactory;


        public SchoolScheduleInitializationService(ISchoolScheduleUnitOfWorkFactory schoolScheduleUnitOfWorkFactory)
        {
            _schoolScheduleUnitOfWorkFactory = schoolScheduleUnitOfWorkFactory;
        }


        public async Task InitializeAsync()
        {
            await InitializeLessonsTime();
            await InitializeSchedule();
        }


        private Task InitializeLessonsTime()
        {
            return Task.Run(() =>
            {
                var lessonTimes = new[]
                {
                    CreateFrom(DayOfWeek.Monday, LessonNumber.First),
                    CreateFrom(DayOfWeek.Monday, LessonNumber.Second),
                    CreateFrom(DayOfWeek.Monday, LessonNumber.Third),
                    CreateFrom(DayOfWeek.Monday, LessonNumber.Fourth),
                    CreateFrom(DayOfWeek.Monday, LessonNumber.Fifth),
                    CreateFrom(DayOfWeek.Monday, LessonNumber.Sixth),
                    CreateFrom(DayOfWeek.Monday, LessonNumber.Seventh),
                    CreateFrom(DayOfWeek.Monday, LessonNumber.Eighth),
                    CreateFrom(DayOfWeek.Monday, LessonNumber.Ninth),

                    CreateFrom(DayOfWeek.Tuesday, LessonNumber.First),
                    CreateFrom(DayOfWeek.Tuesday, LessonNumber.Second),
                    CreateFrom(DayOfWeek.Tuesday, LessonNumber.Third),
                    CreateFrom(DayOfWeek.Tuesday, LessonNumber.Fourth),
                    CreateFrom(DayOfWeek.Tuesday, LessonNumber.Fifth),
                    CreateFrom(DayOfWeek.Tuesday, LessonNumber.Sixth),
                    CreateFrom(DayOfWeek.Tuesday, LessonNumber.Seventh),
                    CreateFrom(DayOfWeek.Tuesday, LessonNumber.Eighth),
                    CreateFrom(DayOfWeek.Tuesday, LessonNumber.Ninth),

                    CreateFrom(DayOfWeek.Wednesday, LessonNumber.First),
                    CreateFrom(DayOfWeek.Wednesday, LessonNumber.Second),
                    CreateFrom(DayOfWeek.Wednesday, LessonNumber.Third),
                    CreateFrom(DayOfWeek.Wednesday, LessonNumber.Fourth),
                    CreateFrom(DayOfWeek.Wednesday, LessonNumber.Fifth),
                    CreateFrom(DayOfWeek.Wednesday, LessonNumber.Sixth),
                    CreateFrom(DayOfWeek.Wednesday, LessonNumber.Seventh),
                    CreateFrom(DayOfWeek.Wednesday, LessonNumber.Eighth),
                    CreateFrom(DayOfWeek.Wednesday, LessonNumber.Ninth),

                    CreateFrom(DayOfWeek.Thursday, LessonNumber.First),
                    CreateFrom(DayOfWeek.Thursday, LessonNumber.Second),
                    CreateFrom(DayOfWeek.Thursday, LessonNumber.Third),
                    CreateFrom(DayOfWeek.Thursday, LessonNumber.Fourth),
                    CreateFrom(DayOfWeek.Thursday, LessonNumber.Fifth),
                    CreateFrom(DayOfWeek.Thursday, LessonNumber.Sixth),
                    CreateFrom(DayOfWeek.Thursday, LessonNumber.Seventh),
                    CreateFrom(DayOfWeek.Thursday, LessonNumber.Eighth),
                    CreateFrom(DayOfWeek.Thursday, LessonNumber.Ninth),

                    CreateFrom(DayOfWeek.Friday, LessonNumber.First),
                    CreateFrom(DayOfWeek.Friday, LessonNumber.Second),
                    CreateFrom(DayOfWeek.Friday, LessonNumber.Third),
                    CreateFrom(DayOfWeek.Friday, LessonNumber.Fourth),
                    CreateFrom(DayOfWeek.Friday, LessonNumber.Fifth),
                    CreateFrom(DayOfWeek.Friday, LessonNumber.Sixth),
                    CreateFrom(DayOfWeek.Friday, LessonNumber.Seventh),
                    CreateFrom(DayOfWeek.Friday, LessonNumber.Eighth),
                    CreateFrom(DayOfWeek.Friday, LessonNumber.Ninth),

                    CreateFrom(DayOfWeek.Saturday, LessonNumber.First),
                    CreateFrom(DayOfWeek.Saturday, LessonNumber.Second),
                    CreateFrom(DayOfWeek.Saturday, LessonNumber.Third),
                    CreateFrom(DayOfWeek.Saturday, LessonNumber.Fourth),
                    CreateFrom(DayOfWeek.Saturday, LessonNumber.Fifth),
                    CreateFrom(DayOfWeek.Saturday, LessonNumber.Sixth),
                    CreateFrom(DayOfWeek.Saturday, LessonNumber.Seventh),
                    CreateFrom(DayOfWeek.Saturday, LessonNumber.Eighth),
                    CreateFrom(DayOfWeek.Saturday, LessonNumber.Ninth)
                };

                var uow = _schoolScheduleUnitOfWorkFactory.CreateSchoolScheduleUnitOfWork();
                lessonTimes.ForEach(uow.GetRepository<LessonTime>().Add);
                uow.SaveAsync().Wait();
                });
        }

        private Task InitializeSchedule()
        {
            return Task.Run(() =>
            {
                var uow = _schoolScheduleUnitOfWorkFactory.CreateSchoolScheduleUnitOfWork();
                
                var lessonsTimesDictionary = uow.GetRepository<LessonTime>().GetAllAsync()
                    .Result.ToDictionary(rs => (day: rs.DayOfWeek, order: rs.Order));

                var buralkin = CreateTeacherFrom("Буралкин", "Александр", "Николаевич", CreateAddressFrom("8", "Bannaia"));
                var lenko = CreateTeacherFrom("Ленько", "Валентина", "Николаевна", CreateAddressFrom("8", "Bannaia"));
                var cvirko = CreateTeacherFrom("Цвирко", "Юлия", "Викторовна", CreateAddressFrom("8", "Bannaia"));
                var arlukevich = CreateTeacherFrom("Арлукевич", "Наталья", "Николаевна", CreateAddressFrom("8", "Bannaia"));
                var fedorova = CreateTeacherFrom("Фёдорова", "Елена", "Михайловна", CreateAddressFrom("8", "Bannaia"));
                var bondareva = CreateTeacherFrom("Бондарева", "Алла", "Васильевна", CreateAddressFrom("8", "Bannaia"));
                var protasenya = CreateTeacherFrom("Протасеня", "Татьяна", "Михайловна", CreateAddressFrom("8", "Bannaia"));
                var chepurko = CreateTeacherFrom("Чепурко", "Татьяна", "Михайловна", CreateAddressFrom("8", "Bannaia"));
                var berezovik = CreateTeacherFrom("Березовик", "Наталья", "Петровна", CreateAddressFrom("8", "Bannaia"));
                var emelyanova = CreateTeacherFrom("Емельянова", "Надежда", "Андреевна", CreateAddressFrom("8", "Bannaia"));
                var chechura = CreateTeacherFrom("Чечура", "Владимир", "Григорьевич", CreateAddressFrom("8", "Bannaia"));
                var efankova = CreateTeacherFrom("Ефанкова", "Нина", "Ильинична", CreateAddressFrom("8", "Bannaia"));
                var serokurova = CreateTeacherFrom("Серокурова", "Наталья", "Олеговна", CreateAddressFrom("8", "Bannaia"));
                var katsuba = CreateTeacherFrom("Кацуба", "Ирина", "Ленгиновна", CreateAddressFrom("8", "Bannaia"));
                var pantelei = CreateTeacherFrom("Пантелей", "Наталья", "Викторовна", CreateAddressFrom("8", "Bannaia"));
                var yachuk = CreateTeacherFrom("Ящук", "Светлана", "Александровна", CreateAddressFrom("8", "Bannaia"));
                var pavlovich = CreateTeacherFrom("Павлович", "Татьяна", "Николаевна", CreateAddressFrom("8", "Bannaia"));
                var konyahina = CreateTeacherFrom("Коняхина", "Таиса", "Михайловна", CreateAddressFrom("8", "Bannaia"));
                var veremeichik = CreateTeacherFrom("Веремейчик", "Сергей", "Александрович", CreateAddressFrom("8", "Bannaia"));
                var belitskaya = CreateTeacherFrom("Белицкая", "Валентина", "Николаевна", CreateAddressFrom("8", "Bannaia"));
                var gogleva = CreateTeacherFrom("Гоглева", "Ксения", "Георгиевна", CreateAddressFrom("8", "Bannaia"));
                var penchik = CreateTeacherFrom("Пенчик", "Алла", "Михайловна", CreateAddressFrom("8", "Bannaia"));
                var vasilevskaya = CreateTeacherFrom("Василевская", "Валентина", "Викторовна", CreateAddressFrom("8", "Bannaia"));
                var efimovich = CreateTeacherFrom("Ефимович", "Ирина", "Фёдоровна", CreateAddressFrom("8", "Bannaia"));
                var taranova = CreateTeacherFrom("Таранова", "Татьяна", "Михайловна", CreateAddressFrom("8", "Bannaia"));
                var davidovich = CreateTeacherFrom("Давидович", "Анатолий", "Павлович", CreateAddressFrom("8", "Bannaia"));
                var osmolovskaya = CreateTeacherFrom("Осмоловская", "Валентина", "Ивановна", CreateAddressFrom("8", "Bannaia"));
                var zhuravlevich = CreateTeacherFrom("Журавлевич", "Ольга", "Георгиевна", CreateAddressFrom("8", "Bannaia"));
                var shulyakovskaya = CreateTeacherFrom("Шуляковская", "Марина", "Владимировна", CreateAddressFrom("8", "Bannaia"));
                var korobko = CreateTeacherFrom("Коробко", "Ирина", "Михайловна", CreateAddressFrom("8", "Bannaia"));
                var mysleiko = CreateTeacherFrom("Мыслейко", "Наталья", "Николаевна", CreateAddressFrom("8", "Bannaia"));
                var bondarTeacher = CreateTeacherFrom("Бондарь", "Елена", "Викторовна", CreateAddressFrom("8", "Bannaia"));
                var lukyanchenko = CreateTeacherFrom("Лукьянченко", "Галина", "Михайловна", CreateAddressFrom("8", "Bannaia"));
                var micura = CreateTeacherFrom("Мицура", "Жанна", "Александровна", CreateAddressFrom("8", "Bannaia"));

                var history = CreateCourseFrom("История");
                var foreingLanguage = CreateCourseFrom("Иностранный язык");
                var chemistry = CreateCourseFrom("Химия");
                var belLit = CreateCourseFrom("Белорусская литература");
                var physics = CreateCourseFrom("Физика");
                var physcult = CreateCourseFrom("Физическая культура и здоровье");
                var informatics = CreateCourseFrom("Информатика");
                var math = CreateCourseFrom("Математика");
                var obshestv = CreateCourseFrom("Обществоведение");
                var biology = CreateCourseFrom("Биология");
                var mp = CreateCourseFrom("Медицинская подготовка");
                var dp = CreateCourseFrom("Допризывная подготовка");
                var belLanguage = CreateCourseFrom("Белорусский язык");
                var rusLanguage = CreateCourseFrom("Русский язык");
                var rusLit = CreateCourseFrom("Русская литература");
                var geography = CreateCourseFrom("География");
                var chzs = CreateCourseFrom("Час здоровья и спорта");
                var astronomy = CreateCourseFrom("Астрономия");

                var r214 = CreateClassroomFrom("214");
                var r321b = CreateClassroomFrom("321б");
                var r323a = CreateClassroomFrom("323а");
                var r111a = CreateClassroomFrom("111а");
                var r111b = CreateClassroomFrom("111б");
                var r111v = CreateClassroomFrom("111в");
                var r203 = CreateClassroomFrom("203");
                var r209 = CreateClassroomFrom("209");
                var r114 = CreateClassroomFrom("114");
                var r303 = CreateClassroomFrom("303");
                var r306 = CreateClassroomFrom("306");
                var rSportGirls = CreateClassroomFrom("Спортзал (девочки)");
                var rSportBoys = CreateClassroomFrom("Спортзал (мальчики)");
                var r309 = CreateClassroomFrom("309");
                var r321a = CreateClassroomFrom("321а");
                var r313 = CreateClassroomFrom("313");
                var r314 = CreateClassroomFrom("314");
                var r221 = CreateClassroomFrom("221");
                var r207 = CreateClassroomFrom("207");
                var r307 = CreateClassroomFrom("307");
                var r113 = CreateClassroomFrom("113");
                var r212 = CreateClassroomFrom("212");
                var r322a = CreateClassroomFrom("322a");
                var r322b = CreateClassroomFrom("322б");
                var r223 = CreateClassroomFrom("223");
                var r211 = CreateClassroomFrom("211");
                var r323b = CreateClassroomFrom("323б");
                var r311 = CreateClassroomFrom("311");
                var r206 = CreateClassroomFrom("206");
                var r312 = CreateClassroomFrom("312");
                var r324 = CreateClassroomFrom("324");
                var r305 = CreateClassroomFrom("305");
                var r213 = CreateClassroomFrom("213");
                var r210 = CreateClassroomFrom("210");
                var r220 = CreateClassroomFrom("220");
                var r222 = CreateClassroomFrom("222");
                var r112 = CreateClassroomFrom("112");

                Grade Initialize11AFormYana2018()
                {
                    var kuchuro = CreatePupilFrom("Кучуро", "Полина", CreateAddressFrom("8", "Bannaia"));
                    var ligorova = CreatePupilFrom("Лигорова", "Злата", CreateAddressFrom("8", "Bannaia"));
                    var merzlova = CreatePupilFrom("Мерзлова", "Виктория", CreateAddressFrom("8", "Bannaia"));
                    var novickiy = CreatePupilFrom("Новицкий", "Владислав", CreateAddressFrom("8", "Bannaia"));
                    var efimchik = CreatePupilFrom("Ефимчик", "Ян", CreateAddressFrom("8", "Bannaia"));
                    var degelevich = CreatePupilFrom("Дегелевич", "Полина", CreateAddressFrom("8", "Bannaia"));
                    var kolke = CreatePupilFrom("Кольке", "Анастасия", CreateAddressFrom("8", "Bannaia"));
                    var belko = CreatePupilFrom("Белько", "Егор", CreateAddressFrom("8", "Bannaia"));
                    var suvorov = CreatePupilFrom("Суворов", "Михаил", CreateAddressFrom("8", "Bannaia"));
                    var zikanova = CreatePupilFrom("Зиканова", "Валерия", CreateAddressFrom("8", "Bannaia"));
                    var turpakov = CreatePupilFrom("Турпаков", "Даниил", CreateAddressFrom("8", "Bannaia"));
                    var selivonchik = CreatePupilFrom("Селивончик", "Александра", CreateAddressFrom("8", "Bannaia"));
                    var vasykevich = CreatePupilFrom("Васюкевич", "Александра", CreateAddressFrom("8", "Bannaia"));
                    var korzun = CreatePupilFrom("Корзун", "Екатерина", CreateAddressFrom("8", "Bannaia"));
                    var ivanovskaya = CreatePupilFrom("Ивановская", "Дарья", CreateAddressFrom("8", "Bannaia"));
                    var pushkova = CreatePupilFrom("Пушкова", "Елизавета", CreateAddressFrom("8", "Bannaia"));
                    var lahai = CreatePupilFrom("Лахай", "Ольга", CreateAddressFrom("8", "Bannaia"));
                    var skalaba = CreatePupilFrom("Скалаба", "Валентина", CreateAddressFrom("8", "Bannaia"));

                    var profilObschestvSubGr = CreateGradeGroupFrom("Профильная группа по Обществоведению",
                        new List<Pupil>
                        {
                            kuchuro, ligorova, merzlova, novickiy, efimchik, degelevich, kolke, belko, suvorov
                        });
                    var profilForeignSubGr = CreateGradeGroupFrom("Профильная группа по Иностранному языку",
                        new List<Pupil>
                        {
                            kuchuro, ligorova, merzlova, novickiy, efimchik, degelevich, kolke, belko, suvorov
                        });
                    var baseChemistrySubGr = CreateGradeGroupFrom("Базовая группа по Химии",
                        new List<Pupil>
                        {
                            kuchuro, ligorova, merzlova, novickiy, efimchik, degelevich, kolke, belko, suvorov
                        });
                    var baseBiologySubGr = CreateGradeGroupFrom("Базовая группа по Биологии",
                        new List<Pupil>
                        {
                            kuchuro, ligorova, merzlova, novickiy, efimchik, degelevich, kolke, belko, suvorov
                        });

                    var baseObschestvSubGr = CreateGradeGroupFrom("Базовая группа по Обществоведению",
                        new List<Pupil>
                        {
                            zikanova, turpakov, selivonchik, vasykevich, korzun, ivanovskaya, pushkova, lahai,
                            skalaba
                        });
                    var baseForeignSubGr = CreateGradeGroupFrom("Базовая группа по Иностранному языку",
                        new List<Pupil>
                        {
                            zikanova, turpakov, selivonchik, vasykevich, korzun, ivanovskaya, pushkova, lahai,
                            skalaba
                        });
                    var profilChemistrySubGr = CreateGradeGroupFrom("Профильная группа по Химии",
                        new List<Pupil>
                        {
                            zikanova, turpakov, selivonchik, vasykevich, korzun, ivanovskaya, pushkova, lahai,
                            skalaba
                        });
                    var profilBiologySubGr = CreateGradeGroupFrom("Профильная группа по Биологии",
                        new List<Pupil>
                        {
                            zikanova, turpakov, selivonchik, vasykevich, korzun, ivanovskaya, pushkova, lahai,
                            skalaba
                        });

                    var info1stSubGr = CreateGradeGroupFrom("1-я группа по Информатике",
                        new List<Pupil>
                        {
                            kuchuro, efimchik, degelevich, kolke, belko, zikanova, vasykevich, korzun,
                            ivanovskaya
                        });
                    var info2ndSubGr = CreateGradeGroupFrom("2-я группа по Информатике",
                        new List<Pupil>
                        {
                            ligorova, merzlova, novickiy, suvorov, turpakov, selivonchik, pushkova, lahai,
                            skalaba
                        });
                    var profilBelLangSubGr = CreateGradeGroupFrom("Профильная группа по Белорусскому языку",
                        new List<Pupil>
                            {kuchuro, novickiy, efimchik, degelevich, belko, suvorov, turpakov, ivanovskaya});
                    var baseRusLangSubGr = CreateGradeGroupFrom("Базовая группа по Русскому языку",
                        new List<Pupil>
                            {kuchuro, novickiy, efimchik, degelevich, belko, suvorov, turpakov, ivanovskaya});
                    var profilRusLangSubGr = CreateGradeGroupFrom("Профильная группа по Русскому языку",
                        new List<Pupil>
                        {
                            ligorova, merzlova, kolke, zikanova, selivonchik, vasykevich, korzun, pushkova,
                            lahai, skalaba
                        });
                    var baseBelLangSubGr = CreateGradeGroupFrom("Базовая группа по Белорусскому языку",
                        new List<Pupil>
                        {
                            ligorova, merzlova, kolke, zikanova, selivonchik, vasykevich, korzun, pushkova,
                            lahai, skalaba
                        });
                    var medSubGr = CreateGradeGroupFrom("Группа по Медицинской подготовке",
                        new List<Pupil>
                        {
                            kuchuro, ligorova, merzlova, degelevich, kolke, zikanova, selivonchik, vasykevich,
                            korzun, ivanovskaya, pushkova, lahai, skalaba
                        });
                    var armySubGr = CreateGradeGroupFrom("Группа по Допризывной подготовке",
                        new List<Pupil> {novickiy, efimchik, belko, suvorov, turpakov});
                    var physcultGirlsSubGr = CreateGradeGroupFrom("Женская группа по Физкультуре",
                        new List<Pupil>
                        {
                            kuchuro, ligorova, merzlova, degelevich, kolke, zikanova, selivonchik, vasykevich,
                            korzun, ivanovskaya, pushkova, lahai, skalaba
                        });
                    var physcultBoysSubGr = CreateGradeGroupFrom("Мужская группа по Физкультуре",
                        new List<Pupil> {novickiy, efimchik, belko, suvorov, turpakov});

                    return new Grade
                    {
                        Number = GradeNumber.Eleventh,
                        Letter = "А",
                        Pupils = new List<Pupil>
                        {
                            kuchuro, ligorova, merzlova, novickiy, efimchik, degelevich, kolke, belko, suvorov,
                            zikanova, turpakov, selivonchik, vasykevich, korzun, ivanovskaya, pushkova, lahai,
                            skalaba
                        },
                        Groups = new List<Group>
                        {
                            profilObschestvSubGr, profilForeignSubGr, baseChemistrySubGr, baseBiologySubGr,
                            baseObschestvSubGr, baseForeignSubGr, profilChemistrySubGr, profilBiologySubGr,
                            info1stSubGr, info2ndSubGr,
                            profilBelLangSubGr, baseRusLangSubGr, profilRusLangSubGr, baseBelLangSubGr,
                            medSubGr, armySubGr, physcultGirlsSubGr, physcultBoysSubGr
                        },
                        Lessons = new List<Lesson>
                        {
                            CreateLessonFrom(r203, chemistry,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.First)],
                                pantelei,
                                baseChemistrySubGr),
                            CreateLessonFrom(r306, biology,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.First)],
                                serokurova,
                                profilBiologySubGr),
                            CreateLessonFrom(r114, belLit,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.Second)],
                                chepurko),
                            CreateLessonFrom(r214, history,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.Third)],
                                emelyanova),
                            CreateLessonFrom(rSportGirls, chzs,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.Fourth)], yachuk,
                                physcultGirlsSubGr),
                            CreateLessonFrom(rSportBoys, chzs,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.Fourth)],
                                pavlovich,
                                physcultBoysSubGr),
                            CreateLessonFrom(r213, dp,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.Fifth)],
                                veremeichik,
                                armySubGr),
                            CreateLessonFrom(r312, mp,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.Fifth)],
                                konyahina,
                                medSubGr),
                            CreateLessonFrom(r322a, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.Sixth)],
                                mysleiko,
                                profilForeignSubGr),
                            CreateLessonFrom(r210, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.Sixth)],
                                taranova,
                                baseForeignSubGr),
                            CreateLessonFrom(r322a, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.Seventh)],
                                mysleiko,
                                profilForeignSubGr),

                            CreateLessonFrom(r314, math,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.First)],
                                gogleva),
                            CreateLessonFrom(r303, physics,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Second)],
                                vasilevskaya),
                            CreateLessonFrom(rSportGirls, physcult,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Third)], yachuk,
                                physcultGirlsSubGr),
                            CreateLessonFrom(rSportBoys, physcult,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Third)],
                                pavlovich,
                                physcultBoysSubGr),
                            CreateLessonFrom(r203, chemistry,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Fourth)],
                                korobko,
                                profilChemistrySubGr),
                            CreateLessonFrom(r221, biology,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Fourth)],
                                shulyakovskaya, baseBiologySubGr),
                            CreateLessonFrom(r203, chemistry,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Fifth)],
                                korobko,
                                profilChemistrySubGr),
                            CreateLessonFrom(r214, obshestv,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Fifth)],
                                zhuravlevich,
                                profilObschestvSubGr),
                            CreateLessonFrom(r207, geography,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Sixth)],
                                efankova),

                            CreateLessonFrom(r212, rusLit,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.First)],
                                berezovik),
                            CreateLessonFrom(r212, rusLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.Second)],
                                berezovik,
                                baseRusLangSubGr),
                            CreateLessonFrom(r323a, belLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.Second)],
                                lenko,
                                baseBelLangSubGr),
                            CreateLessonFrom(r206, history,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.Third)],
                                emelyanova),
                            CreateLessonFrom(r203, chemistry,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.Fourth)],
                                pantelei,
                                baseChemistrySubGr),
                            CreateLessonFrom(r307, biology,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.Fourth)],
                                serokurova,
                                profilBiologySubGr),
                            CreateLessonFrom(r314, math,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.Fifth)],
                                gogleva),
                            CreateLessonFrom(r323a, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.Sixth)],
                                mysleiko,
                                profilForeignSubGr),
                            CreateLessonFrom(r323b, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.Sixth)],
                                taranova,
                                baseForeignSubGr),

                            CreateLessonFrom(r314, math,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.First)],
                                gogleva),
                            CreateLessonFrom(r309, informatics,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Second)],
                                penchik,
                                info1stSubGr),
                            CreateLessonFrom(r305, informatics,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Second)],
                                bondarTeacher, info2ndSubGr),
                            CreateLessonFrom(r212, rusLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Third)],
                                berezovik,
                                profilRusLangSubGr),
                            CreateLessonFrom(r323a, belLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Third)],
                                protasenya,
                                profilBelLangSubGr),
                            CreateLessonFrom(r212, rusLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Fourth)],
                                berezovik,
                                profilRusLangSubGr),
                            CreateLessonFrom(r323a, belLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Fourth)],
                                protasenya,
                                profilBelLangSubGr),
                            CreateLessonFrom(rSportGirls, physcult,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Fifth)],
                                yachuk,
                                physcultGirlsSubGr),
                            CreateLessonFrom(rSportBoys, physcult,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Fifth)],
                                pavlovich,
                                physcultBoysSubGr),
                            CreateLessonFrom(r220, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Sixth)],
                                mysleiko,
                                profilForeignSubGr),
                            CreateLessonFrom(r203, chemistry,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Sixth)],
                                korobko,
                                profilChemistrySubGr),
                            CreateLessonFrom(r220, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Seventh)],
                                mysleiko,
                                profilForeignSubGr),

                            CreateLessonFrom(r114, belLit,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.First)],
                                chepurko),
                            CreateLessonFrom(r206, obshestv,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Second)],
                                chechura,
                                baseObschestvSubGr),
                            CreateLessonFrom(r214, obshestv,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Second)],
                                zhuravlevich,
                                profilObschestvSubGr),
                            CreateLessonFrom(r306, astronomy,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Third)],
                                katsuba),
                            CreateLessonFrom(r303, physics,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Fourth)],
                                vasilevskaya),
                            CreateLessonFrom(r113, biology,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Fifth)],
                                shulyakovskaya,
                                baseBiologySubGr),
                            CreateLessonFrom(r207, chemistry,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Fifth)], korobko,
                                profilChemistrySubGr),
                            CreateLessonFrom(r313, math,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Sixth)],
                                gogleva),
                            CreateLessonFrom(r323b, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Seventh)],
                                taranova,
                                baseForeignSubGr),

                            CreateLessonFrom(r214, obshestv,
                                lessonsTimesDictionary[(DayOfWeek.Saturday, LessonNumber.First)],
                                zhuravlevich,
                                profilObschestvSubGr),
                            CreateLessonFrom(r203, chemistry,
                                lessonsTimesDictionary[(DayOfWeek.Saturday, LessonNumber.First)],
                                korobko,
                                profilChemistrySubGr),
                            CreateLessonFrom(r212, rusLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Saturday, LessonNumber.Second)],
                                berezovik,
                                profilRusLangSubGr),
                            CreateLessonFrom(r211, belLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Saturday, LessonNumber.Second)],
                                protasenya,
                                profilBelLangSubGr),
                            CreateLessonFrom(r307, biology,
                                lessonsTimesDictionary[(DayOfWeek.Saturday, LessonNumber.Third)],
                                serokurova,
                                profilBiologySubGr)
                        }
                    };
                }

                Grade Initialize11BFormYana2018()
                {
                    var bolbas = CreatePupilFrom("Болбас", "Яна", CreateAddressFrom("8", "Bannaia"));
                    var bondar = CreatePupilFrom("Бондарь", "Захар", CreateAddressFrom("8", "Bannaia"));
                    var bylinkskiy = CreatePupilFrom("Былинский", "Трофим", CreateAddressFrom("8", "Bannaia"));
                    var grek = CreatePupilFrom("Грек", "Роман", CreateAddressFrom("8", "Bannaia"));
                    var glotova = CreatePupilFrom("Глотова", "Диана", CreateAddressFrom("8", "Bannaia"));
                    var zaycev = CreatePupilFrom("Зайцев", "Дмитрий", CreateAddressFrom("8", "Bannaia"));
                    var kurbyko = CreatePupilFrom("Курбыко", "Валерий", CreateAddressFrom("8", "Bannaia"));
                    var kyreichik = CreatePupilFrom("Курейчик", "Павел", CreateAddressFrom("8", "Bannaia"));
                    var pogireichik = CreatePupilFrom("Погирейчик", "Маргарита", CreateAddressFrom("8", "Bannaia"));
                    var philchenko = CreatePupilFrom("Фильченко", "Владимир", CreateAddressFrom("8", "Bannaia"));
                    var danchenko = CreatePupilFrom("Данченко", "Евгений", CreateAddressFrom("8", "Bannaia"));
                    var karchevskiy = CreatePupilFrom("Карчевский", "Игорь", CreateAddressFrom("8", "Bannaia"));
                    var katsubaJr = CreatePupilFrom("Кацуба", "Анастасия", CreateAddressFrom("8", "Bannaia"));
                    var plavskiy = CreatePupilFrom("Плавский", "Степан", CreateAddressFrom("8", "Bannaia"));
                    var rak = CreatePupilFrom("Рак", "Илья", CreateAddressFrom("8", "Bannaia"));

                    var foreignLanguage1stSubGr = CreateGradeGroupFrom("1-я группа по Иностранному языку",
                        new List<Pupil> {bolbas, bondar, bylinkskiy, grek});
                    var foreignLanguage2ndSubGr = CreateGradeGroupFrom("2-я группа по Иностранному языку",
                        new List<Pupil> {glotova, zaycev, kurbyko, kyreichik, pogireichik, philchenko});
                    var foreignLanguage3rdSubGr = CreateGradeGroupFrom("3-я группа по Иностранному языку",
                        new List<Pupil> {danchenko, karchevskiy, katsubaJr, plavskiy, rak});

                    var physics1stSubGr = CreateGradeGroupFrom("1-я группа по Физике",
                        new List<Pupil>
                            {bolbas, bondar, bylinkskiy, glotova, grek, danchenko, zaycev, karchevskiy});
                    var physics2ndSubGr = CreateGradeGroupFrom("2-я группа по Физике",
                        new List<Pupil>
                            {katsubaJr, kurbyko, kyreichik, plavskiy, pogireichik, rak, philchenko});

                    var math1stSubGr = CreateGradeGroupFrom("1-я группа по Математике",
                        new List<Pupil>
                            {bolbas, bondar, bylinkskiy, glotova, grek, danchenko, zaycev, karchevskiy});
                    var math2ndSubGr = CreateGradeGroupFrom("2-я группа по Математике",
                        new List<Pupil>
                            {katsubaJr, kurbyko, kyreichik, plavskiy, pogireichik, rak, philchenko});

                    var info1stSubGr = CreateGradeGroupFrom("1-я группа по Информатике",
                        new List<Pupil>
                            {bolbas, bondar, bylinkskiy, glotova, grek, danchenko, zaycev, karchevskiy});
                    var info2ndSubGr = CreateGradeGroupFrom("2-я группа по Информатике",
                        new List<Pupil>
                            {katsubaJr, kurbyko, kyreichik, plavskiy, pogireichik, rak, philchenko});
                    var profilBelLang = CreateGradeGroupFrom("Профильная группа по Белорусскому языку",
                        new List<Pupil> {bondar, bylinkskiy, zaycev, karchevskiy, katsubaJr, philchenko});
                    var baseRusLang = CreateGradeGroupFrom("Базовая группа по Русскому языку",
                        new List<Pupil> {bondar, bylinkskiy, zaycev, karchevskiy, katsubaJr, philchenko});
                    var profilRusLang = CreateGradeGroupFrom("Профильная группа по Русскому языку",
                        new List<Pupil>
                            {bolbas, glotova, grek, danchenko, kurbyko, kyreichik, plavskiy, pogireichik, rak});
                    var baseBelLang = CreateGradeGroupFrom("Базовая группа по Белорусскому языку",
                        new List<Pupil>
                            {bolbas, glotova, grek, danchenko, kurbyko, kyreichik, plavskiy, pogireichik, rak});
                    var medSubGr = CreateGradeGroupFrom("Группа по Медицинской подготовке",
                        new List<Pupil> {bolbas, glotova, pogireichik, katsubaJr});
                    var armySubGr = CreateGradeGroupFrom("Группа по Допризывной подготовке",
                        new List<Pupil>
                        {
                            bondar, bylinkskiy, grek, zaycev, kurbyko, kyreichik, philchenko, danchenko,
                            karchevskiy, plavskiy, rak
                        });
                    var physcultGirlsSubGr = CreateGradeGroupFrom("Женская группа по Физкультуре",
                        new List<Pupil> {bolbas, glotova, pogireichik, katsubaJr});
                    var physcultBoysSubGr = CreateGradeGroupFrom("Мужская группа по Физкультуре",
                        new List<Pupil>
                        {
                            bondar, bylinkskiy, grek, zaycev, kurbyko, kyreichik, philchenko, danchenko,
                            karchevskiy, plavskiy, rak
                        });

                    return new Grade
                    {
                        Number = GradeNumber.Eleventh,
                        Letter = "Б",
                        Pupils = new List<Pupil>
                        {
                            bolbas, bondar, bylinkskiy, grek, glotova, zaycev, kurbyko, kyreichik,
                            pogireichik, philchenko, danchenko, karchevskiy, katsubaJr, plavskiy, rak
                        },
                        Groups = new List<Group>
                        {
                            foreignLanguage1stSubGr, foreignLanguage2ndSubGr, foreignLanguage3rdSubGr,
                            physics1stSubGr, physics2ndSubGr,
                            math1stSubGr, math2ndSubGr, info1stSubGr, info2ndSubGr, profilBelLang, baseRusLang,
                            profilRusLang,
                            baseBelLang, medSubGr, armySubGr, physcultGirlsSubGr, physcultBoysSubGr
                        },
                        Lessons = new List<Lesson>
                        {
                            CreateLessonFrom(r214, history,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.First)],
                                emelyanova),
                            CreateLessonFrom(r321b, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.Second)],
                                taranova, foreignLanguage1stSubGr),
                            CreateLessonFrom(r323a, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.Second)],
                                davidovich, foreignLanguage2ndSubGr),
                            CreateLessonFrom(r111b, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.Second)],
                                osmolovskaya, foreignLanguage3rdSubGr),
                            CreateLessonFrom(r314, biology,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.Third)],
                                serokurova),
                            CreateLessonFrom(r114, belLit,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.Fourth)],
                                chepurko),
                            CreateLessonFrom(r306, physics,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.Fifth)], katsuba,
                                physics1stSubGr),
                            CreateLessonFrom(r303, physics,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.Fifth)],
                                vasilevskaya, physics2ndSubGr),
                            CreateLessonFrom(r306, physics,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.Sixth)], katsuba,
                                physics1stSubGr),
                            CreateLessonFrom(r303, physics,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.Sixth)],
                                vasilevskaya, physics2ndSubGr),
                            CreateLessonFrom(r203, chemistry,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.Seventh)],
                                pantelei),

                            CreateLessonFrom(r309, informatics,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.First)],
                                penchik, info1stSubGr),
                            CreateLessonFrom(r307, math,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.First)],
                                efimovich, math2ndSubGr),
                            CreateLessonFrom(r314, math,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Second)],
                                gogleva, math1stSubGr),
                            CreateLessonFrom(r309, informatics,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Second)],
                                penchik, info2ndSubGr),
                            CreateLessonFrom(r207, geography,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Third)],
                                efankova),
                            CreateLessonFrom(r312, obshestv,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Fourth)],
                                chechura),
                            CreateLessonFrom(rSportGirls, physcult,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Fifth)], yachuk,
                                physcultGirlsSubGr),
                            CreateLessonFrom(rSportBoys, physcult,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Fifth)],
                                pavlovich, physcultBoysSubGr),
                            CreateLessonFrom(r307, mp,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Sixth)],
                                konyahina, medSubGr),
                            CreateLessonFrom(r309, dp,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Sixth)],
                                veremeichik, armySubGr),

                            CreateLessonFrom(r206, history,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.First)],
                                emelyanova),
                            CreateLessonFrom(r307, biology,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.Second)],
                                serokurova),
                            CreateLessonFrom(r314, math,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.Third)],
                                gogleva, math1stSubGr),
                            CreateLessonFrom(r313, math,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.Third)],
                                efimovich, math2ndSubGr),
                            CreateLessonFrom(r314, math,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.Fourth)],
                                gogleva, math1stSubGr),
                            CreateLessonFrom(r313, math,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.Fourth)],
                                efimovich, math2ndSubGr),
                            CreateLessonFrom(rSportGirls, chzs,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.Fifth)],
                                yachuk, physcultGirlsSubGr),
                            CreateLessonFrom(rSportBoys, chzs,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.Fifth)],
                                pavlovich, physcultBoysSubGr),
                            CreateLessonFrom(r314, belLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.Sixth)],
                                lenko, baseBelLang),
                            CreateLessonFrom(r212, rusLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.Sixth)],
                                berezovik, baseRusLang),
                            CreateLessonFrom(r212, rusLit,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.Seventh)],
                                berezovik),

                            CreateLessonFrom(r322a, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.First)],
                                taranova, foreignLanguage1stSubGr),
                            CreateLessonFrom(r323a, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.First)],
                                davidovich, foreignLanguage2ndSubGr),
                            CreateLessonFrom(r111b, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.First)],
                                osmolovskaya, foreignLanguage3rdSubGr),
                            CreateLessonFrom(r222, chemistry,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Second)],
                                pantelei),
                            CreateLessonFrom(r314, math,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Third)],
                                gogleva, math1stSubGr),
                            CreateLessonFrom(r221, math,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Third)],
                                efimovich, math2ndSubGr),
                            CreateLessonFrom(r306, physics,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Fourth)],
                                katsuba, physics1stSubGr),
                            CreateLessonFrom(r303, physics,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Fourth)],
                                vasilevskaya, physics2ndSubGr),
                            CreateLessonFrom(r211, belLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Fifth)],
                                protasenya, profilBelLang),
                            CreateLessonFrom(r212, rusLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Fifth)],
                                berezovik, profilRusLang),
                            CreateLessonFrom(r211, belLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Sixth)],
                                protasenya, profilBelLang),
                            CreateLessonFrom(r212, rusLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Sixth)],
                                berezovik, profilRusLang),

                            CreateLessonFrom(rSportGirls, physcult,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.First)], yachuk,
                                physcultGirlsSubGr),
                            CreateLessonFrom(rSportBoys, physcult,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.First)],
                                pavlovich, physcultBoysSubGr),
                            CreateLessonFrom(r306, physics,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Second)],
                                katsuba, physics1stSubGr),
                            CreateLessonFrom(r303, physics,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Second)],
                                vasilevskaya, physics2ndSubGr),
                            CreateLessonFrom(r314, math,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Third)], gogleva,
                                math1stSubGr),
                            CreateLessonFrom(r221, math,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Third)],
                                efimovich, math2ndSubGr),
                            CreateLessonFrom(r314, math,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Fourth)],
                                gogleva, math1stSubGr),
                            CreateLessonFrom(r221, math,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Fourth)],
                                efimovich, math2ndSubGr),
                            CreateLessonFrom(r114, belLit,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Fifth)],
                                chepurko),
                            CreateLessonFrom(r323b, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Sixth)],
                                taranova, foreignLanguage1stSubGr),
                            CreateLessonFrom(r323a, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Sixth)],
                                davidovich, foreignLanguage2ndSubGr),
                            CreateLessonFrom(r111b, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Sixth)],
                                osmolovskaya, foreignLanguage3rdSubGr),
                            CreateLessonFrom(r306, astronomy,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Seventh)],
                                katsuba),

                            CreateLessonFrom(r314, math,
                                lessonsTimesDictionary[(DayOfWeek.Saturday, LessonNumber.First)],
                                gogleva, math1stSubGr),
                            CreateLessonFrom(r311, math,
                                lessonsTimesDictionary[(DayOfWeek.Saturday, LessonNumber.First)],
                                efimovich, math2ndSubGr),
                            CreateLessonFrom(r306, physics,
                                lessonsTimesDictionary[(DayOfWeek.Saturday, LessonNumber.Second)],
                                katsuba, physics1stSubGr),
                            CreateLessonFrom(r303, physics,
                                lessonsTimesDictionary[(DayOfWeek.Saturday, LessonNumber.Second)],
                                vasilevskaya, physics2ndSubGr),
                            CreateLessonFrom(r211, belLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Saturday, LessonNumber.Third)],
                                protasenya, profilBelLang),
                            CreateLessonFrom(r212, rusLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Saturday, LessonNumber.Third)],
                                berezovik, profilRusLang)
                        }
                    };
                }

                Grade Initialize11VFormYana2018()
                {
                    var beskostaya = CreatePupilFrom("Бескостая", "Екатерина", CreateAddressFrom("8", "Bannaia"));
                    var pigal = CreatePupilFrom("Пигаль", "Алеся", CreateAddressFrom("8", "Bannaia"));
                    var roy = CreatePupilFrom("Рой", "Эллина", CreateAddressFrom("8", "Bannaia"));
                    var soloduho = CreatePupilFrom("Солодухо", "Есения", CreateAddressFrom("8", "Bannaia"));
                    var tuftina = CreatePupilFrom("Тюфтина", "Вероника", CreateAddressFrom("8", "Bannaia"));
                    var shevchenko = CreatePupilFrom("Шевченко", "Ульяна", CreateAddressFrom("8", "Bannaia"));
                    var vishnyak = CreatePupilFrom("Вишняк", "Юлия", CreateAddressFrom("8", "Bannaia"));
                    var vladimirova = CreatePupilFrom("Владимирова", "Валерия", CreateAddressFrom("8", "Bannaia"));
                    var gelyk = CreatePupilFrom("Гелюк", "Анастасия", CreateAddressFrom("8", "Bannaia"));
                    var efimchik = CreatePupilFrom("Ефимчик", "Оксана", CreateAddressFrom("8", "Bannaia"));
                    var ivanova = CreatePupilFrom("Иванова", "Анна", CreateAddressFrom("8", "Bannaia"));
                    var kydelko = CreatePupilFrom("Кудёлко", "Виолетта", CreateAddressFrom("8", "Bannaia"));
                    var piletskaya = CreatePupilFrom("Пилецкая", "Карина", CreateAddressFrom("8", "Bannaia"));
                    var sarycheva = CreatePupilFrom("Сарычева", "Анна", CreateAddressFrom("8", "Bannaia"));
                    var sosnovskaya = CreatePupilFrom("Сосновская", "Вероника", CreateAddressFrom("8", "Bannaia"));
                    var sokolskaya = CreatePupilFrom("Сокольская", "Валерия", CreateAddressFrom("8", "Bannaia"));
                    var sytko = CreatePupilFrom("Сытько", "Анна", CreateAddressFrom("8", "Bannaia"));
                    var tverdova = CreatePupilFrom("Твердова", "Екатерина", CreateAddressFrom("8", "Bannaia"));
                    var ubozhenko = CreatePupilFrom("Убоженко", "Дарья", CreateAddressFrom("8", "Bannaia"));

                    var profilBelLanSubGr = CreateGradeGroupFrom("Профильная группа по Белорусскому языку",
                        new List<Pupil> {beskostaya, pigal, roy, soloduho, tuftina, shevchenko});
                    var baseRusLanSubGr = CreateGradeGroupFrom("Базовая группа по Русскому языку",
                        new List<Pupil> {beskostaya, pigal, roy, soloduho, tuftina, shevchenko});

                    var profilRusLanSubGr = CreateGradeGroupFrom("Профильная группа по Русскому языку",
                        new List<Pupil>
                        {
                            vishnyak, vladimirova, gelyk, efimchik, ivanova, kydelko, piletskaya, sarycheva,
                            sosnovskaya, sokolskaya, sytko, tverdova, ubozhenko
                        });
                    var baseBelLanSubGr = CreateGradeGroupFrom("Базовая группа по Белорусскому языку",
                        new List<Pupil>
                        {
                            vishnyak, vladimirova, gelyk, efimchik, ivanova, kydelko, piletskaya, sarycheva,
                            sosnovskaya, sokolskaya, sytko, tverdova, ubozhenko
                        });

                    var math1stSubGr = CreateGradeGroupFrom("1-я группа по Математике",
                        new List<Pupil>
                        {
                            roy, soloduho, tuftina, shevchenko, sarycheva, sosnovskaya, sokolskaya, sytko,
                            tverdova, ubozhenko
                        });
                    var math2ndSubGr = CreateGradeGroupFrom("2-я группа по Математике",
                        new List<Pupil>
                        {
                            beskostaya, pigal, vishnyak, vladimirova, gelyk, efimchik, ivanova, kydelko,
                            piletskaya
                        });

                    var foreignLang1stSubGr = CreateGradeGroupFrom("1-я группа по Иностранному языку",
                        new List<Pupil> {efimchik, ubozhenko});
                    var foreignLang2ndSubGr = CreateGradeGroupFrom("2-я группа по Иностранному языку",
                        new List<Pupil> {beskostaya, vishnyak, roy, tuftina, sosnovskaya, kydelko, gelyk});
                    var foreignLang3rdSubGr = CreateGradeGroupFrom("3-я группа по Иностранному языку",
                        new List<Pupil>
                        {
                            tverdova, sytko, sokolskaya, sarycheva, shevchenko, soloduho, piletskaya, ivanova,
                            vladimirova, pigal
                        });

                    var info1stSubGr = CreateGradeGroupFrom("1-я группа по Информатике",
                        new List<Pupil>
                            {beskostaya, vishnyak, vladimirova, gelyk, efimchik, ivanova, kydelko, piletskaya});
                    var info2ndSubGr = CreateGradeGroupFrom("2-я группа по Информатике",
                        new List<Pupil>
                        {
                            pigal, roy, soloduho, tuftina, shevchenko, sarycheva, sosnovskaya, sokolskaya,
                            sytko, tverdova, ubozhenko
                        });

                    var medSubGr = CreateGradeGroupFrom("Группа по Медицинской подготовке",
                        new List<Pupil>
                        {
                            beskostaya, pigal, roy, soloduho, tuftina, shevchenko, vishnyak, vladimirova, gelyk,
                            efimchik, ivanova, kydelko, piletskaya, sarycheva, sosnovskaya, sokolskaya, sytko,
                            tverdova, ubozhenko
                        });
                    var physcultGirlsSubGr = CreateGradeGroupFrom("Женская группа по Физкультуре",
                        new List<Pupil>
                        {
                            beskostaya, pigal, roy, soloduho, tuftina, shevchenko, vishnyak, vladimirova, gelyk,
                            efimchik, ivanova, kydelko, piletskaya, sarycheva, sosnovskaya, sokolskaya, sytko,
                            tverdova, ubozhenko
                        });

                    return new Grade
                    {
                        Number = GradeNumber.Eleventh,
                        Letter = "В",
                        Pupils = new List<Pupil>
                        {
                            beskostaya, pigal, roy, soloduho, tuftina, shevchenko, vishnyak, vladimirova, gelyk,
                            efimchik, ivanova, kydelko, piletskaya, sarycheva, sosnovskaya, sokolskaya, sytko,
                            tverdova, ubozhenko
                        },
                        Groups = new List<Group>
                        {
                            profilBelLanSubGr, baseRusLanSubGr, profilRusLanSubGr, baseBelLanSubGr,
                            math1stSubGr, math2ndSubGr,
                            foreignLang1stSubGr, foreignLang2ndSubGr, foreignLang3rdSubGr,
                            info1stSubGr, info2ndSubGr, medSubGr, physcultGirlsSubGr
                        },
                        Lessons = new List<Lesson>
                        {
                            CreateLessonFrom(r111b, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.First)],
                                osmolovskaya, foreignLang1stSubGr),
                            CreateLessonFrom(r323a, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.First)],
                                davidovich, foreignLang2ndSubGr),
                            CreateLessonFrom(r321b, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.First)],
                                taranova, foreignLang3rdSubGr),
                            CreateLessonFrom(r214, history,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.Second)],
                                emelyanova),
                            CreateLessonFrom(r306, physics,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.Third)],
                                katsuba),
                            CreateLessonFrom(r203, chemistry,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.Fourth)],
                                pantelei),
                            CreateLessonFrom(r114, belLit,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.Fifth)],
                                chepurko),
                            CreateLessonFrom(r206, obshestv,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.Sixth)],
                                chechura),
                            CreateLessonFrom(r307, biology,
                                lessonsTimesDictionary[(DayOfWeek.Monday, LessonNumber.Seventh)],
                                serokurova),

                            CreateLessonFrom(r111b, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.First)],
                                osmolovskaya, foreignLang1stSubGr),
                            CreateLessonFrom(r323a, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.First)],
                                davidovich, foreignLang2ndSubGr),
                            CreateLessonFrom(r323b, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.First)],
                                taranova, foreignLang3rdSubGr),
                            CreateLessonFrom(r111b, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Second)],
                                osmolovskaya, foreignLang1stSubGr),
                            CreateLessonFrom(r323a, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Second)],
                                davidovich, foreignLang2ndSubGr),
                            CreateLessonFrom(r323b, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Second)],
                                taranova, foreignLang3rdSubGr),
                            CreateLessonFrom(r313, math,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Third)],
                                belitskaya, math1stSubGr),
                            CreateLessonFrom(r314, math,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Third)],
                                gogleva, math2ndSubGr),
                            CreateLessonFrom(rSportGirls, physcult,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Fourth)],
                                yachuk, physcultGirlsSubGr),
                            CreateLessonFrom(r207, geography,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Fifth)],
                                efankova),
                            CreateLessonFrom(r212, rusLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Sixth)],
                                berezovik, profilRusLanSubGr),
                            CreateLessonFrom(r303, belLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Sixth)], lenko,
                                profilBelLanSubGr),
                            CreateLessonFrom(r212, rusLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Seventh)],
                                berezovik, profilRusLanSubGr),
                            CreateLessonFrom(r303, belLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Tuesday, LessonNumber.Seventh)],
                                lenko, profilBelLanSubGr),

                            CreateLessonFrom(r313, math,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.First)],
                                belitskaya, math1stSubGr),
                            CreateLessonFrom(r314, math,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.First)],
                                gogleva, math2ndSubGr),
                            CreateLessonFrom(r313, math,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.Second)],
                                belitskaya, math1stSubGr),
                            CreateLessonFrom(r314, math,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.Second)],
                                gogleva, math2ndSubGr),
                            CreateLessonFrom(r212, rusLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.Third)],
                                berezovik, baseRusLanSubGr),
                            CreateLessonFrom(r323a, belLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.Third)],
                                lenko, baseBelLanSubGr),
                            CreateLessonFrom(r212, rusLit,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.Fourth)],
                                berezovik),
                            CreateLessonFrom(r214, history,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.Fifth)],
                                emelyanova),
                            CreateLessonFrom(r306, mp,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.Sixth)],
                                konyahina, medSubGr),
                            CreateLessonFrom(r307, biology,
                                lessonsTimesDictionary[(DayOfWeek.Wednesday, LessonNumber.Seventh)],
                                serokurova),

                            CreateLessonFrom(r309, informatics,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.First)],
                                penchik, info1stSubGr),
                            CreateLessonFrom(r305, informatics,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.First)],
                                bondarTeacher, info2ndSubGr),
                            CreateLessonFrom(r111b, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Second)],
                                osmolovskaya, foreignLang1stSubGr),
                            CreateLessonFrom(r323a, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Second)],
                                davidovich, foreignLang2ndSubGr),
                            CreateLessonFrom(r322a, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Second)],
                                taranova, foreignLang3rdSubGr),
                            CreateLessonFrom(r306, physics,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Third)],
                                katsuba),
                            CreateLessonFrom(r313, math,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Fourth)],
                                belitskaya, math1stSubGr),
                            CreateLessonFrom(r314, math,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Fourth)],
                                gogleva, math2ndSubGr),
                            CreateLessonFrom(r112, chemistry,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Fifth)],
                                pantelei),
                            CreateLessonFrom(rSportGirls, chzs,
                                lessonsTimesDictionary[(DayOfWeek.Thursday, LessonNumber.Sixth)],
                                yachuk, physcultGirlsSubGr),

                            CreateLessonFrom(r313, math,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.First)],
                                belitskaya, math1stSubGr),
                            CreateLessonFrom(r314, math,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.First)], gogleva,
                                math2ndSubGr),
                            CreateLessonFrom(r313, math,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Second)],
                                belitskaya, math1stSubGr),
                            CreateLessonFrom(r314, math,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Second)],
                                gogleva, math2ndSubGr),
                            CreateLessonFrom(rSportGirls, physcult,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Third)], yachuk,
                                physcultGirlsSubGr),
                            CreateLessonFrom(r213, belLit,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Fourth)],
                                chepurko),
                            CreateLessonFrom(r111b, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Fifth)],
                                osmolovskaya, foreignLang1stSubGr),
                            CreateLessonFrom(r323a, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Fifth)],
                                davidovich, foreignLang2ndSubGr),
                            CreateLessonFrom(r323b, foreingLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Fifth)],
                                taranova, foreignLang3rdSubGr),
                            CreateLessonFrom(r306, astronomy,
                                lessonsTimesDictionary[(DayOfWeek.Friday, LessonNumber.Sixth)],
                                katsuba),

                            CreateLessonFrom(r212, rusLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Saturday, LessonNumber.First)],
                                berezovik, profilRusLanSubGr),
                            CreateLessonFrom(r303, belLanguage,
                                lessonsTimesDictionary[(DayOfWeek.Saturday, LessonNumber.First)], lenko,
                                profilBelLanSubGr),
                            CreateLessonFrom(r313, math,
                                lessonsTimesDictionary[(DayOfWeek.Saturday, LessonNumber.Second)],
                                belitskaya, math1stSubGr),
                            CreateLessonFrom(r314, math,
                                lessonsTimesDictionary[(DayOfWeek.Saturday, LessonNumber.Second)],
                                gogleva, math2ndSubGr),
                        }
                    };
                }

                var repo = uow.GetRepository<Grade>();
                var grade11A = Initialize11AFormYana2018();
                var grade11B = Initialize11BFormYana2018();
                var grade11V = Initialize11VFormYana2018();
                repo.Add(grade11A);
                repo.Add(grade11B);
                repo.Add(grade11V);
                uow.SaveAsync().Wait();
                
            });
        }

        private static Teacher CreateTeacherFrom(string surname, string name, string patronymic, Address address)
        {
            return new Teacher { Name = name, Surname = surname, Patronymic = patronymic, Address = address };
        }

        private static Pupil CreatePupilFrom(string surname, string name, Address address)
        {
            return new Pupil { Name = name, Surname = surname, Patronymic = String.Empty, Address = address };
        }

        private static Course CreateCourseFrom(string name)
        {
            return new Course { Name = name };
        }

        private static Classroom CreateClassroomFrom(string name)
        {
            return new Classroom { Name = name };
        }

        private static Group CreateGradeGroupFrom(string name, ICollection<Pupil> pupils)
        {
            return new Group { Name = name, PupilGroups = pupils.Select(p => new PupilGroup { Pupil = p }).ToList() };
        }

        private static Lesson CreateLessonFrom(Classroom classroom, Course course, LessonTime lessonTime, Teacher teacher, Group group = null)
        {
            return new Lesson { Classroom = classroom, Course = course, LessonTime = lessonTime, Group = group, Teacher = teacher };
        }

        private static LessonTime CreateFrom(DayOfWeek dayOfWeek, LessonNumber lessonOrder)
        {
            return new LessonTime { DayOfWeek = dayOfWeek, Order = lessonOrder };
        }

        private static Address CreateAddressFrom(string houseNumber, string street)
        {
            return new Address { HouseNumber = houseNumber, Street = street };
        }
    }
}