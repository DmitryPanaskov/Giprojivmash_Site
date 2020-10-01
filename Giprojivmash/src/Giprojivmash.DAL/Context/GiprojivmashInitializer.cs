using System;
using System.Collections.Generic;
using System.Linq;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DataModels.Enums;
using Microsoft.AspNetCore.Identity;

namespace Giprojivmash.DAL.Context
{
    public static class GiprojivmashInitializer
    {
        public static void InitializerAsync(GiprojivmashContext context)
        {
            Validator(context);
            InitializerContact(context);
            InitializerContactData(context);
            InitializerVacancy(context);
            InitializerUser(context);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S138:Functions should not have too many lines of code", Justification = "<>")]
        private static void InitializerContact(GiprojivmashContext context)
        {
            if (!context.Contacts.Any())
            {
                var contactEntities = new List<ContactEntity>
                {
                    new ContactEntity
                    {
                        // id = 1
                        FirstName = "ОАО Гипроживмаш",
                        Position = "Приемная",
                        PositionType = PositionType.General,
                        IndexNumber = 1,
                        Gender = Gender.Male,
                    },
                    new ContactEntity
                    {
                        // id = 2
                        Position = "Директор",
                        FirstName = "Дмитрий",
                        LastName = "Шило",
                        Patronymic = "Иванович",
                        PositionType = PositionType.Manager,
                        Photo = "director.jpg",
                        IndexNumber = 2,
                        Gender = Gender.Male,
                    },
                    new ContactEntity
                    {
                        // id = 3
                        Position = "Главный инженер",
                        FirstName = "Екатерина",
                        LastName = "Шаповалова",
                        Patronymic = "Игоревна",
                        Photo = "chief_engineer.jpg",
                        PositionType = PositionType.Manager,
                        IndexNumber = 3,
                        Gender = Gender.Female,
                    },
                    new ContactEntity
                    {
                        // id = 4
                        Position = "Заместитель главного инженера",
                        FirstName = "Юрий",
                        LastName = "Дубов",
                        Patronymic = "Александрович",
                        PositionType = PositionType.Manager,
                        IndexNumber = 4,
                        Gender = Gender.Male,
                    },
                    new ContactEntity
                    {
                        // id = 5
                        Position = "Главный инженер проекта",
                        FirstName = "Евгений",
                        LastName = "Грибанов",
                        Patronymic = "Юрьевич",
                        PositionType = PositionType.ChiefProjectEngineer,
                        IndexNumber = 5,
                        Gender = Gender.Male,
                    },
                    new ContactEntity
                    {
                        // id = 6
                        Position = "Главный инженер проекта",
                        LastName = "Ковалев",
                        FirstName = "Сергей",
                        Patronymic = "Валерьевич",
                        PositionType = PositionType.ChiefProjectEngineer,
                        IndexNumber = 6,
                    },
                    new ContactEntity
                    {
                        // id = 7
                        Position = "Главный констуктор",
                        LastName = "Марочкин",
                        FirstName = "Анатолий",
                        Patronymic = "Вячеславович",
                        PositionType = PositionType.HeadOfDepartment,
                        IndexNumber = 12,
                        Gender = Gender.Male,
                    },
                    new ContactEntity
                    {
                        // id = 8
                        Position = "Главный инженер проекта",
                        LastName = "Петренко",
                        FirstName = "Ирина",
                        Patronymic = "Михайловна",
                        PositionType = PositionType.ChiefProjectEngineer,
                        IndexNumber = 8,
                        Gender = Gender.Female,
                    },
                    new ContactEntity
                    {
                        // id = 9
                        Position = "Бухгалтерия",
                        FirstName = "Елена",
                        LastName = "Черноокая",
                        Patronymic = "Герасимовна",
                        PositionType = PositionType.HeadOfDepartment,
                        IndexNumber = 9,
                        Gender = Gender.Female,
                    },
                    new ContactEntity
                    {
                        // id = 10
                        Position = "Ведущий юрисконсульт",
                        FirstName = "Ольга",
                        LastName = "Игнатова",
                        Patronymic = "Васильевна",
                        PositionType = PositionType.HeadOfDepartment,
                        IndexNumber = 11,
                        Gender = Gender.Female,
                    },
                    new ContactEntity
                    {
                        // id = 11
                        Position = "Отдел кадров",
                        FirstName = "Жанна",
                        LastName = "Кричевская",
                        Patronymic = "Анатольевна",
                        PositionType = PositionType.HeadOfDepartment,
                        IndexNumber = 12,
                        Gender = Gender.Female,
                    },
                    new ContactEntity
                    {
                        // id = 12
                        Position = "Отдел генплана",
                        FirstName = "Наталья",
                        LastName = "Заяц",
                        Patronymic = "Викторовна",
                        PositionType = PositionType.HeadOfDepartment,
                        IndexNumber = 13,
                        Gender = Gender.Female,
                    },
                    new ContactEntity
                    {
                        // id = 13
                        Position = "Архитектурно-планировочный отдел",
                        FirstName = "Александра",
                        LastName = "Горбатовская",
                        Patronymic = "Владимировна",
                        PositionType = PositionType.HeadOfDepartment,
                        IndexNumber = 14,
                        Gender = Gender.Female,
                    },
                    new ContactEntity
                    {
                        // id = 14
                        Position = "Строительный отдел",
                        FirstName = "Сергей",
                        LastName = "Старотиторов",
                        Patronymic = "Владимирович",
                        PositionType = PositionType.HeadOfDepartment,
                        IndexNumber = 15,
                        Gender = Gender.Male,
                    },
                    new ContactEntity
                    {
                        // id = 15
                        Position = "Сметно-экономический отдел",
                        FirstName = "Наталья",
                        LastName = "Цилько",
                        Patronymic = "Павловна",
                        PositionType = PositionType.HeadOfDepartment,
                        IndexNumber = 16,
                        Gender = Gender.Female,
                    },
                    new ContactEntity
                    {
                        // id = 16
                        Position = "Отдел электроснабжения и электроосвещения",
                        FirstName = "Андрей",
                        LastName = "Сиротко",
                        Patronymic = "Евгеньевич",
                        PositionType = PositionType.HeadOfDepartment,
                        IndexNumber = 17,
                        Gender = Gender.Male,
                    },
                    new ContactEntity
                    {
                        // id = 17
                        Position = "Отдел автоматизации и слаботочных систем",
                        FirstName = "Петр",
                        LastName = "Комар",
                        Patronymic = "Анатольевич",
                        PositionType = PositionType.HeadOfDepartment,
                        IndexNumber = 18,
                        Gender = Gender.Male,
                    },
                    new ContactEntity
                    {
                        // id = 18
                        Position = "Отдел водоснабжения и канализации",
                        FirstName = "Лариса",
                        LastName = "Мураль",
                        Patronymic = "Михайловна",
                        PositionType = PositionType.HeadOfDepartment,
                        IndexNumber = 19,
                        Gender = Gender.Female,
                    },
                    new ContactEntity
                    {
                        // id = 19
                        Position = "Отдел теплоснабжения, газоснабжения и вентиляции",
                        FirstName = "Андрей",
                        LastName = "Судаков",
                        Patronymic = "Григорьевич",
                        PositionType = PositionType.HeadOfDepartment,
                        IndexNumber = 20,
                        Gender = Gender.Male,
                    },
                    new ContactEntity
                    {
                        // id = 20
                        Position = "Технологический отдел",
                        FirstName = "Светлана",
                        LastName = "Россол",
                        Patronymic = "Григорьевна",
                        PositionType = PositionType.HeadOfDepartment,
                        IndexNumber = 21,
                        Gender = Gender.Female,
                    },
                    new ContactEntity
                    {
                        // id = 21
                        Position = "Отдел качества и выпуска проектной продукции",
                        FirstName = "Александр",
                        LastName = "Гончаров",
                        Patronymic = "Владимирович",
                        PositionType = PositionType.HeadOfDepartment,
                        IndexNumber = 22,
                        Gender = Gender.Male,
                    },
                    new ContactEntity
                    {
                        // id = 22
                        Position = "Главный инженер проекта",
                        FirstName = "Алла",
                        LastName = "Гуцева",
                        Patronymic = "Алексеевна",
                        PositionType = PositionType.ChiefProjectEngineer,
                        IndexNumber = 23,
                        Gender = Gender.Female,
                    },
                    new ContactEntity
                    {
                        // id = 23
                        Position = "Планово-производственный отдел ",
                        FirstName = "Дмитрий",
                        LastName = "Негреев",
                        Patronymic = "Николаевич",
                        PositionType = PositionType.HeadOfDepartment,
                        IndexNumber = 10,
                        Gender = Gender.Male,
                    },
                    new ContactEntity
                    {
                        // id = 24
                        Position = "Эксплуатационно-техничекий отдел",
                        FirstName = "Виталий",
                        LastName = "Дриндель",
                        Patronymic = "Владимирович",
                        PositionType = PositionType.HeadOfDepartment,
                        IndexNumber = 24,
                        Gender = Gender.Male,
                    },
                    new ContactEntity
                    {
                        // id = 25
                        Position = "Заместитель главного инженера",
                        FirstName = "Виктор",
                        LastName = "Саулин",
                        Patronymic = "Иванович",
                        PositionType = PositionType.Manager,
                        IndexNumber = 25,
                        Gender = Gender.Male,
                    },
                    new ContactEntity
                    {
                        // id = 26
                        Position = "Сектор автоматизации проектных работ",
                        FirstName = "Виктор",
                        LastName = "Емельянцев",
                        Patronymic = "Юрьевич",
                        PositionType = PositionType.HeadOfDepartment,
                        IndexNumber = 21,
                        Gender = Gender.Male,
                    },
                };

                foreach (var item in contactEntities)
                {
                    context.Set<ContactEntity>().Add(item);
                    context.SaveChanges();
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S138:Functions should not have too many lines of code", Justification = "<>")]
        private static void InitializerContactData(GiprojivmashContext context)
        {
            if (!context.ContactDatas.Any())
            {
                var contactEntities = new List<ContactDataEntity>
                {
                    new ContactDataEntity
                    {
                         ContactId = 1,
                         Data = "+375 232 53-27-38",
                         SubData = "+375232532738",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 1,
                         Data = "+375 232 53-50-30",
                         SubData = "+375232535030",
                         ContactDataType = ContactDataType.Fax,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 1,
                         Data = "post@gipro.gomel.by",
                         SubData = "post@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 1,
                         Data = "post@gipro.gomel.by",
                         SubData = "post@gipro.gomel.by",
                         ContactDataType = ContactDataType.VK,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 2,
                         Data = "+375 232 53-27-38",
                         SubData = "+375232532738",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 2,
                         Data = "DmitryShilo@gipro.gomel.by",
                         SubData = "DmitryShilo@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 3,
                         Data = "+375 232 53-27-05",
                         SubData = "+375232532705",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                      ContactId = 3,
                      Data = "EkaterinaShapovalova@gipro.gomel.by",
                      SubData = "EkaterinaShapovalova@gipro.gomel.by",
                      ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 4,
                         Data = "+375 232 53-27-38",
                         SubData = "+375232532738",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 4,
                         Data = "YuriDubov@gipro.gomel.by",
                         SubData = "YuriDubov@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 5,
                         Data = "+375 232 53-27-32",
                         SubData = "+375232532732",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 5,
                         Data = "EvgenyGribanov@gipro.gomel.by",
                         SubData = "EvgenyGribanov@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 6,
                         Data = "+375 232 53-61-09",
                         SubData = "+375232536109",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 6,
                         Data = "SergeyKovalev@gipro.gomel.by",
                         SubData = "SergeyKovalev@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 7,
                         Data = "+375 232 21-30-54",
                         SubData = "+375232213054",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 7,
                         Data = "AnatolyMarochkin@gipro.gomel.by",
                         SubData = "AnatolyMarochkin@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 8,
                         Data = "+375 232 53-61-07",
                         SubData = "+375232536107",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 8,
                         Data = "IrinaPetrenko@gipro.gomel.by",
                         SubData = "IrinaPetrenko@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 9,
                         Data = "+375 232 53-27-08",
                         SubData = "+375232532708",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 9,
                         Data = "ElenaChernookaya@gipro.gomel.by",
                         SubData = "ElenaChernookaya@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 10,
                         Data = "+375 232 53-61-06",
                         SubData = "+375232536106",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 10,
                         Data = "OlgaIgnatova@gipro.gomel.by",
                         SubData = "OlgaIgnatova@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 11,
                         Data = "+375 232 53-27-04",
                         SubData = "+375232536106",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 11,
                         Data = "post@gipro.gomel.by",
                         SubData = "post@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 12,
                         Data = "+375 232 53-27-19",
                         SubData = "+375232532719",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 12,
                         Data = "NatalyaZayats@gipro.gomel.by",
                         SubData = "NatalyaZayats@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 13,
                         Data = "+375 232 53-27-18",
                         SubData = "+375232532718",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 13,
                         Data = "AlexandraGorbatovskaya@gipro.gomel.by",
                         SubData = "AlexandraGorbatovskaya@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 14,
                         Data = "+375 232 21-30-54",
                         SubData = "+375232213054",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 14,
                         Data = "SergeyStarotitorov@gipro.gomel.by",
                         SubData = "SergeyStarotitorov@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 15,
                         Data = "+375 232 53-27-11",
                         SubData = "+375232532711",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 15,
                         Data = "NataliaTsilko@gipro.gomel.by",
                         SubData = "NataliaTsilko@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 16,
                         Data = "+375 232 53-27-41",
                         SubData = "+375232532711",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 16,
                         Data = "AndreySirotko@gipro.gomel.by",
                         SubData = "AndreySirotko@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 17,
                         Data = "+375 232 53-27-18",
                         SubData = "+375232532711",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 17,
                         Data = "PetrKomar@gipro.gomel.by",
                         SubData = "PertKomar@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 18,
                         Data = "+375 232 53-27-09",
                         SubData = "+375232532709",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 18,
                         Data = "LarisaMural@gipro.gomel.by",
                         SubData = "LarisaMural@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 19,
                         Data = "+375 232 53-27-13",
                         SubData = "+375232532713",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 19,
                         Data = "AndreySudakov@gipro.gomel.by",
                         SubData = "AndereySudakov@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 20,
                         Data = "+375 232 53-27-19",
                         SubData = "+375232532719",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 20,
                         Data = "SvetlanaRossol@gipro.gomel.by",
                         SubData = "SvetlanaRossol@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 21,
                         Data = "+375 232 21-30-50",
                         SubData = "+375232213050",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 21,
                         Data = "AlexanderGoncharov@gipro.gomel.by",
                         SubData = "AlexanderGoncharov@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 22,
                         Data = "+375 232 53-27-09",
                         SubData = "+375232532709",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 22,
                         Data = "AllaGutseva@gipro.gomel.by",
                         SubData = "AllaGutseva@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 23,
                         Data = "+375 232 53-61-03",
                         SubData = "+375232536103",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 23,
                         Data = "DmitryNegreev@gipro.gomel.by",
                         SubData = "DmitryNegreev@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 24,
                         Data = "+375 232 21-30-50",
                         SubData = "+375232213050",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 24,
                         Data = "VitalyDrindel@gipro.gomel.by",
                         SubData = "VitalyDrindel@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 25,
                         Data = "+375 232 53-61-08",
                         SubData = "+375232536108",
                         ContactDataType = ContactDataType.WorkTelephone,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 25,
                         Data = "VictorSaulin@gipro.gomel.by",
                         SubData = "VictorSaulin@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                    new ContactDataEntity
                    {
                         ContactId = 26,
                         Data = "VictorEmelyantsev@gipro.gomel.by",
                         SubData = "VictorEmelyantsev@gipro.gomel.by",
                         ContactDataType = ContactDataType.Email,
                    },
                };

                foreach (var item in contactEntities)
                {
                    context.Set<ContactDataEntity>().Add(item);
                    context.SaveChanges();
                }
            }
        }

        private static void InitializerVacancy(GiprojivmashContext context)
        {
            if (!context.Vacancies.Any())
            {
                var vacancyEntities = new List<VacancyEntity>
                {
                    new VacancyEntity
                    {
                           Position = "Начальник отдела.",
                           Description = "На постоянную работу требуется начальник отдела. Требования: " +
                           "- Водительское удостворение категории B" +
                           "- Высшее образование," +
                           "- Знание английского языка " +
                           "Заработная плата по результатам собеседования.",
                           PhoneNumber = "+375 (232) 53-27-04",
                           SubPhoneNumber = "+375232532704",
                    },
                };

                foreach (var item in vacancyEntities)
                {
                    context.Set<VacancyEntity>().Add(item);
                    context.SaveChanges();
                }
            }
        }

        private static void InitializerUser(GiprojivmashContext context)
        {
            if (!context.ApplicationUsers.Any())
            {
                context.ApplicationUsers.Add(new UserEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "post@gipro.gomel.by",
                    UserName = "Admin",
                    PasswordHash = new PasswordHasher<UserEntity>().HashPassword(new UserEntity(), "Admin@246050"),
                    AccessFailedCount = 10,
                    EmailConfirmed = false,
                    LockoutEnabled = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    PhoneNumber = null,
                });
                context.SaveChanges();
            }
        }

        private static void Validator(GiprojivmashContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
        }
    }
}
