using System;
using System.Collections.Generic;
using System.Linq;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DataModels.Enums;

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
                    },
                    new ContactEntity
                    {
                        // id = 4
                        Position = "Заместитель главного инженера",
                        FirstName = "Юрий",
                        LastName = "Дубов",
                        Patronymic = "Александрович",
                        PositionType = PositionType.Manager,
                    },
                    new ContactEntity
                    {
                        // id = 5
                        Position = "Главный инженер проекта",
                        FirstName = "Евгений",
                        LastName = "Грибанов",
                        Patronymic = "Юрьевич",
                        PositionType = PositionType.ChiefProjectEngineer,
                    },
                    new ContactEntity
                    {
                        // id = 6
                        Position = "Главный инженер проекта",
                        LastName = "Ковалев",
                        FirstName = "Сергей",
                        Patronymic = "Валерьевич",
                        PositionType = PositionType.ChiefProjectEngineer,
                    },
                    new ContactEntity
                    {
                        // id = 7
                        Position = "Главный инженер проекта",
                        LastName = "Марочкин",
                        FirstName = "Анатолий",
                        Patronymic = "Вячеславович",
                        PositionType = PositionType.ChiefProjectEngineer,
                    },
                    new ContactEntity
                    {
                        // id = 8
                        Position = "Главный инженер проекта",
                        LastName = "Петренко",
                        FirstName = "Ирина",
                        Patronymic = "Михайловна",
                        PositionType = PositionType.ChiefProjectEngineer,
                    },
                    new ContactEntity
                    {
                        // id = 9
                        Position = "Бухгалтерия",
                        FirstName = "Елена",
                        LastName = "Черноокая",
                        Patronymic = "Герасимовна",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                    new ContactEntity
                    {
                        // id = 10
                        Position = "Юрисконсульт",
                        FirstName = "Ольга",
                        LastName = "Игнатова",
                        Patronymic = "Васильевна",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                    new ContactEntity
                    {
                        // id = 11
                        Position = "Отдел кадров",
                        FirstName = "Жанна",
                        LastName = "Кричевская",
                        Patronymic = "Анатольевна",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                    new ContactEntity
                    {
                        // id = 12
                        Position = "Отдел генплана",
                        FirstName = "Наталья",
                        LastName = "Заяц",
                        Patronymic = "Викторовна",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                    new ContactEntity
                    {
                        // id = 13
                        Position = "Архитектурно-планировочный отдел",
                        FirstName = "Александра",
                        LastName = "Горбатовская",
                        Patronymic = "Владимировна",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                    new ContactEntity
                    {
                        // id = 14
                        Position = "Строительный отдел",
                        FirstName = "Сергей",
                        LastName = "Старотиторов",
                        Patronymic = "Владимирович",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                    new ContactEntity
                    {
                        // id = 15
                        Position = "Сметно-экономический отдел",
                        FirstName = "Наталья",
                        LastName = "Цилько",
                        Patronymic = "Павловна",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                    new ContactEntity
                    {
                        // id = 16
                        Position = "Отдел электроснабжения и электроосвещения",
                        FirstName = "Андрей",
                        LastName = "Сиротко",
                        Patronymic = "Евгеньевич",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                    new ContactEntity
                    {
                        // id = 17
                        Position = "Отдел автоматизации и слаботочных систем",
                        FirstName = "Петр",
                        LastName = "Комар",
                        Patronymic = "Анатольевич",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                    new ContactEntity
                    {
                        // id = 18
                        Position = "Отдел водоснабжения и канализации",
                        FirstName = "Лариса",
                        LastName = "Мураль",
                        Patronymic = "Михайловна",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                    new ContactEntity
                    {
                        // id = 19
                        Position = "Отдел теплоснабжения, газоснабжения и вентиляции",
                        FirstName = "Андрей",
                        LastName = "Судаков",
                        Patronymic = "Григорьевич",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                    new ContactEntity
                    {
                        // id = 20
                        Position = "Технологический отдел",
                        FirstName = "Светлана",
                        LastName = "Россол",
                        Patronymic = "Григорьевна",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                    new ContactEntity
                    {
                        // id = 21
                        Position = "Отдел качества и выпуска проектной продукции",
                        FirstName = "Александр",
                        LastName = "Гончаров",
                        Patronymic = "Владимирович",
                        PositionType = PositionType.HeadOfDepartment,
                    },
                    new ContactEntity
                    {
                        // id = 22
                        Position = "Главный инженер проекта",
                        FirstName = "Алла",
                        LastName = "Гуцева",
                        Patronymic = "Алексеевна",
                        PositionType = PositionType.ChiefProjectEngineer,
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
                         Data = "+375 232 53-27-39",
                         SubData = "+375232532739",
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
                           NumberPhone = "+375 (232) 53-27-04",
                           SubNumberPhone = "+375232532704",
                    },
                };

                foreach (var item in vacancyEntities)
                {
                    context.Set<VacancyEntity>().Add(item);
                    context.SaveChanges();
                }
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
