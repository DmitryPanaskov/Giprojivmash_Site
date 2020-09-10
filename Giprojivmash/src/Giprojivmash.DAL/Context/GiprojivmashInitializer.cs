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
            InitializerServiceFirstLayer(context);
            InitializerServiceSecondLayer(context);
            InitializerServiceThirdLayer(context);
            InitializerContact(context);
            InitializerContactData(context);
            InitializerDepartment(context);
            InitializerVacancy(context);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out", Justification = "<>")]
        private static void InitializerServiceFirstLayer(GiprojivmashContext context)
        {
            if (!context.ServiceFirstLayers.Any())
            {
                var serviceFirstLayerEntities = new List<ServiceFirstLayerEntity>
                {
                    new ServiceFirstLayerEntity
                    {
                        // id = 1;
                        Description = "Проектирование зданий и сооружений I и II уровней ответственности",
                        PhotoTitle = "design.jpg",
                        DescriptionShort = "Комплексные решения в проектировании объектов любой сложности",
                        Title = "Проектирование",
                    },
                    new ServiceFirstLayerEntity
                    {
                        // id = 2;
                        Description = "Обоснование инвестиций",
                        PhotoTitle = "engineering.jpg",
                        DescriptionShort = "Инженерные и консультационные услуги на профессиональном уровне",
                        Title = "Обоснование инвестиций",
                    },
                    new ServiceFirstLayerEntity
                    {
                        // id = 3;
                        Description = "Работы и услуги, состовляющие инженерно-геодезические деятельность специального назначения.",
                        PhotoTitle = "geodesy.jpg",
                        DescriptionShort = "Проводим работыя с использованием высокоточное оборудование и современное програмное обеспечение",
                        Title = "Инженерно-геодезические изыскания",
                    },
                    new ServiceFirstLayerEntity
                    {
                         // id = 4;
                        Description = "Инженерно-экологические изыскания",
                        PhotoTitle = "ecology.jpg",
                        DescriptionShort = "Проводим работы с использованием современного оборудование и современное програмное обеспечение",
                        Title = "Инженерно-экологические изыскания",
                    },
                    new ServiceFirstLayerEntity
                    {
                         // id = 5;
                        Description = "Промышленная безопасность",
                        PhotoTitle = "industrialSafety.jpg",
                        DescriptionShort = "Проектирование технических устройств применяемых на опасных производственных объектах",
                        Title = "Промышленная безопасность",
                    },
                    new ServiceFirstLayerEntity
                    {
                         // id = 6;
                        Description = "Проектирование систем пожаробезопасности и систем охраны",
                        PhotoTitle = "safety.jpg",
                        DescriptionShort = "Проектирование систем пожаробезопасности и систем охраны",
                        Title = "Системы безопасности",
                    },
                };

                foreach (var item in serviceFirstLayerEntities)
                {
                    context.Set<ServiceFirstLayerEntity>().Add(item);
                    context.SaveChanges();
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out", Justification = "<>")]
        private static void InitializerServiceSecondLayer(GiprojivmashContext context)
        {
            if (!context.ServiceSecondLayers.Any())
            {
                var serviceSecondLayerEntities = new List<ServiceSecondLayerEntity>
                {
                    new ServiceSecondLayerEntity
                    {
                        // id = 1;
                        ServiceFirstLayerId = 1,
                        Description = "1.1 Разработка проектной документации для строительства следующих видов зданий и сооружений I и II уровней ответственности:",
                    },
                    new ServiceSecondLayerEntity
                    {
                        // id =2;
                        ServiceFirstLayerId = 1,
                        Description = "1.2 Разработка разделов проектной документации:",
                    },
                    new ServiceSecondLayerEntity
                    {
                         // id = 3;
                        ServiceFirstLayerId = 1,
                        Description = "1.3 Управление проектированием с привлечением субподрядных организаций (функции генерального проектировщика).",
                    },
                    new ServiceSecondLayerEntity
                    {
                        // id = 4;
                        ServiceFirstLayerId = 3,
                        Description = "C",
                    },
                    new ServiceSecondLayerEntity
                    {
                         // id = 5;
                    },
                    new ServiceSecondLayerEntity
                    {
                         // id = 6;
                    },
                    new ServiceSecondLayerEntity
                    {
                         // id = 7;
                    },
                    new ServiceSecondLayerEntity
                    {
                    },
                };

                foreach (var item in serviceSecondLayerEntities)
                {
                    context.Set<ServiceSecondLayerEntity>().Add(item);
                    context.SaveChanges();
                }
            }
        }

        private static void InitializerServiceThirdLayer(GiprojivmashContext context)
        {
            if (!context.ServiceThirdLayers.Any())
            {
                var serviceThirdLayerEntities = new List<ServiceThirdLayerEntity>
                {
                    new ServiceThirdLayerEntity
                    {
                        ServiceSecondLayerId = 1,
                        Description = "- производственные здания и сооружения и их комплексы;",
                    },
                    new ServiceThirdLayerEntity
                    {
                        ServiceSecondLayerId = 1,
                        Description = "- сельскохозяйственные здания и сооружения и их комплексы;",
                    },
                    new ServiceThirdLayerEntity
                    {
                        ServiceSecondLayerId = 1,
                        Description = "- жилые здания и их комплексы;",
                    },
                    new ServiceThirdLayerEntity
                    {
                        ServiceSecondLayerId = 1,
                        Description = "- общественные здания и сооружения и их комплексы.",
                    },
                    new ServiceThirdLayerEntity
                    {
                        ServiceSecondLayerId = 2,
                        Description = "- генеральный план и транспорт;",
                    },
                    new ServiceThirdLayerEntity
                    {
                        ServiceSecondLayerId = 2,
                        Description = "- архитектурные решения;",
                    },
                    new ServiceThirdLayerEntity
                    {
                        ServiceSecondLayerId = 2,
                        Description = "- строительные решения;",
                    },
                    new ServiceThirdLayerEntity
                    {
                        ServiceSecondLayerId = 2,
                        Description = "- инженерное оборудование, сети и системы (тепло-, холодо-, водо-, газоснабжения, канализации," +
                        " отопления, вентиляции и кондиционирования воздуха, электроснабжения, электрооборудования, электроосвещения, связи, радиофикации и телевидения);",
                    },
                    new ServiceThirdLayerEntity
                    {
                        ServiceSecondLayerId = 2,
                        Description = "- специальные разделы (охрана окружающей среды, инженерно-технические мероприятия гражданской обороны, мероприятия по предупреждению " +
                        "чрезвычайных ситуаций, организация строительства, защита строительных конструкций от коррозии);",
                    },
                    new ServiceThirdLayerEntity
                    {
                        ServiceSecondLayerId = 2,
                        Description = "- технологические решения.",
                    },
                };

                foreach (var item in serviceThirdLayerEntities)
                {
                    context.Set<ServiceThirdLayerEntity>().Add(item);
                    context.SaveChanges();
                }
            }
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
                        FirstName = "Владимир",
                        LastName = "Шкундалев",
                        Patronymic = "Петрович",
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
                         Data = "ShkundavlevVladimir@gipro.gomel.by",
                         SubData = "ShkundavlevVladimir@gipro.gomel.by",
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
                         Data = "komarPetr@gipro.gomel.by",
                         SubData = "komarPetr@gipro.gomel.by",
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

        private static void InitializerDepartment(GiprojivmashContext context)
        {
            if (!context.Departments.Any())
            {
                var departmentEntities = new List<DepartmentEntity>
                {
                    new DepartmentEntity
                    {
                        // id = 1
                        Name = "Общие",
                    },
                    new DepartmentEntity
                    {
                        // id = 2
                        Name = "Руководство",
                    },
                    new DepartmentEntity
                    {
                        // id = 3
                      Name = "Главные инженеры проекта",
                    },
                    new DepartmentEntity
                    {
                        // id = 4
                      Name = "Отдел кадров",
                    },
                    new DepartmentEntity
                    {
                        // id = 5
                      Name = "Бухгалтерия",
                    },
                    new DepartmentEntity
                    {
                        // id = 6
                      Name = "Планово-производственный отдел",
                    },
                    new DepartmentEntity
                    {
                        // id = 7
                      Name = "Отдел генплана",
                    },
                    new DepartmentEntity
                    {
                        // id = 8
                      Name = "Архитектурно-планировочный отдел",
                    },
                    new DepartmentEntity
                    {
                        // id = 9
                      Name = "Строительынй отдел",
                    },
                    new DepartmentEntity
                    {
                        // id = 10
                      Name = "Отдел электроснабжения и электроосвещения",
                    },
                    new DepartmentEntity
                    {
                        // id = 11
                      Name = "Отдел автоматизации и слаботочных систем",
                    },
                    new DepartmentEntity
                    {
                        // id = 12
                      Name = "Отдел водоснабжения и канализации",
                    },
                    new DepartmentEntity
                    {
                        // id = 13
                      Name = "Отдел тепноснабжения, газоснабжения и вентиляции",
                    },
                    new DepartmentEntity
                    {
                        // id = 14
                      Name = "Технологический отдел",
                    },
                    new DepartmentEntity
                    {
                        // id = 15
                      Name = "Отдел качества и выпуска проектной документации",
                    },
                };

                foreach (var item in departmentEntities)
                {
                    context.Set<DepartmentEntity>().Add(item);
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
